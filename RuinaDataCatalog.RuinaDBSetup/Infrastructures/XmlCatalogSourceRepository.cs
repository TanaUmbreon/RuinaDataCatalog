using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using LOR_DiceSystem;
using LOR_XML;
using RuinaDataCatalog.RuinaDBSetup.Repositries;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures;

/// <summary>
/// Ruina カタログ データの元データ XML ファイルに対する直接的な操作を提供します。
/// </summary>
public class XmlCatalogSourceRepository : ICatalogSourceRepository
{
    /// <summary>読み込んだバトル ページ情報のリスト</summary>
    private readonly List<DiceCardXmlInfo> _cards = new();
    /// <summary>読み込んだバトル ページ説明のリスト</summary>
    private readonly List<BattleCardDesc> _cardDescriptions = new();

    public IEnumerable<DiceCardXmlInfo> Cards => _cards;
    public IEnumerable<BattleCardDesc> CardDescriptions => _cardDescriptions;

    /// <summary>
    /// <see cref="XmlCatalogSourceRepository"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="sourceDirectoryPath">読み込む元データ XML ファイルが格納されたフォルダー パス。</param>
    public XmlCatalogSourceRepository(string sourceDirectoryPath)
    {
        if (sourceDirectoryPath == null) { throw new ArgumentNullException(nameof(sourceDirectoryPath)); }

        Console.WriteLine("元データを読み込みます。");

        foreach (string sourceFilePath in EnumerateSourceFiles(sourceDirectoryPath))
        {
            Console.WriteLine($"- '{sourceFilePath}'");

            try
            {
                string rootName = LoadRootElementName(sourceFilePath);
                LoadingResult result = rootName switch
                {
                    "DiceCardXmlRoot" => LoadFrom<DiceCardXmlRoot>(sourceFilePath).SelectItems(r => r.cardXmlList).AddTo(ref _cards),
                    "BattleCardDescRoot" => LoadFrom<BattleCardDescRoot>(sourceFilePath).SelectItems(r => r.cardDescList).AddTo(ref _cardDescriptions),
                    _ => LoadingResult.UnknownRoot,
                };
                Console.WriteLine($"  - {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  - {ex.Message}");
            }
        }

        Console.WriteLine("読み込みが完了しました。");
        Console.WriteLine();
    }

    /// <summary>
    /// 指定したフォルダーとサブ フォルダーに含まれる元データ XML ファイルの絶対パスを列挙します。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static IEnumerable<string> EnumerateSourceFiles(string path)
        => new DirectoryInfo(path)
            .EnumerateFiles("*", SearchOption.AllDirectories)
            .Where(f => Regex.IsMatch(f.Extension.ToLower(), @"^\.(txt|xml)$", RegexOptions.IgnoreCase))
            .Select(f => f.FullName)
            .ToArray();

    /// <summary>
    /// 指定した XML ファイルからルート要素のローカル名を読み込んで返します。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string LoadRootElementName(string path)
    {
        try
        {
            return XDocument.Load(path).Root?.Name.LocalName
                ?? throw new ApplicationException("ルート要素がありません。");
        }
        catch (ApplicationException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("XML ファイルとして読み込みできません。", ex);
        }
    }

    #region 「XML の読込→ルート要素から対象データの選択→リストへ追加」を行うメソッド チェーンの定義

    /// <summary>
    /// 指定した元データ XML ファイルを読み込み、そのルート要素を格納した結果を返します。
    /// </summary>
    /// <typeparam name="TXmlRoot"></typeparam>
    /// <param name="sourceFilePath"></param>
    /// <returns></returns>
    private LoadedRootResult<TXmlRoot> LoadFrom<TXmlRoot>(string sourceFilePath) where TXmlRoot : class
    {
        var serializer = new XmlSerializer(typeof(TXmlRoot));
        using var reader = new StreamReader(sourceFilePath, Encoding.UTF8);
        var root = serializer.Deserialize(reader) as TXmlRoot ?? throw new InvalidCastException();
        return new LoadedRootResult<TXmlRoot>(root);
    }

    private class LoadedRootResult<TXmlRoot>
    {
        private readonly TXmlRoot _root;

        public LoadedRootResult(TXmlRoot root)
            => _root = root;

        /// <summary>
        /// 読み込んだルート要素からリストに追加する要素のコレクションを選択し、その要素のコレクションを格納した結果を返します。
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public SelectedItemsResult<TItem> SelectItems<TItem>(Func<TXmlRoot, IEnumerable<TItem>> selector)
            => new SelectedItemsResult<TItem>(selector.Invoke(_root));
    }

    private class SelectedItemsResult<TItem>
    {
        private readonly IEnumerable<TItem> _items;

        public SelectedItemsResult(IEnumerable<TItem> items)
            => _items = items;

        /// <summary>
        /// 選択した要素のコレクションを指定したリストに追加します。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public LoadingResult AddTo(ref List<TItem> list)
        {
            list.AddRange(_items);
            return new LoadingResult(typeof(TItem).Name , _items.Count());
        }
    }

    /// <summary>
    /// 元データ XML ファイルを読み込んだ結果を格納します。
    /// </summary>
    private class LoadingResult
    {
        public static readonly LoadingResult UnknownRoot = new();

        private readonly string _typeName;
        private readonly int _loadedCount;

        public LoadingResult(string typeName, int loadedCount)
        {
            _typeName = typeName;
            _loadedCount = loadedCount;
        }

        private LoadingResult() : this("", 0) { }

        public override string ToString()
        {
            if (this == UnknownRoot) { return "読込対象外のルート要素です。"; }

            return $"読み込んだデータ数: {_loadedCount} <{_typeName}>";
        }
    }

    #endregion
}
