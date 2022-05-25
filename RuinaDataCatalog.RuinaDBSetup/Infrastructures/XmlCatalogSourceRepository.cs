using System.Text;
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
    /// <summary>XML ファイルの読込で使用する文字エンコーディング</summary>
    private readonly Encoding _encoding = Encoding.UTF8;
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

        foreach(FileInfo file in EnumerateFiles(sourceDirectoryPath))
        {
            try
            {
                Console.Write($"'{file.FullName}' を読み込みます... ");

                string? rootName = XDocument.Load(file.FullName).Root?.Name.LocalName;

                switch (rootName)
                {
                    case null:
                        var serializer = new XmlSerializer(typeof(DiceCardXmlRoot));
                        Console.WriteLine("エラーのため読み飛ばしました <ルート要素なし>");
                        continue;
                    default:
                        Console.WriteLine($"読込対象外のルート要素のため読み飛ばしました <{rootName}>");
                        continue;
                }

                Console.WriteLine("完了");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーのため読み飛ばしました <{ex.GetType().Name}>");
                throw;
            }
        }
    }

    private static IEnumerable<FileInfo> EnumerateFiles(string path)
    {
        var dir = new DirectoryInfo(path);
        return dir
            .EnumerateFiles("*", SearchOption.AllDirectories)
            .Where(f => f.Extension == ".txt" || f.Extension == ".xml")
            .ToArray();
    }
}
