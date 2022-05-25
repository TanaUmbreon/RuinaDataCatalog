using RuinaDataCatalog.RuinaDBSetup.Infrastructures;
using RuinaDataCatalog.RuinaDBSetup.Models.ConvertExtensions;
using RuinaDataCatalog.RuinaDBSetup.Repositries;

namespace RuinaDataCatalog.RuinaDBSetup;

public class Program
{
    #region エントリ ポイント

    public static void Main(string[] args)
        => new Program(args).Execute();

    #endregion

    /// <summary>コマンド ライン オプション</summary>
    private readonly CommandLineOption _option;

    /// <summary>
    /// <see cref="Program"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="args">コマンド ライン引数。</param>
    private Program(string[] args)
    {
        _option = CommandLineOption.FromArgs(args);
    }

    /// <summary>
    /// アプリケーションのメイン ロジックを実行します。
    /// </summary>
    private void Execute()
    {
        Console.WriteLine("Ruina データベース ファイルを作成します。");
        Console.WriteLine($"読込元: '{Path.GetFullPath(_option.ReadXmlFromPath)}'");
        Console.WriteLine($"出力先: '{Path.GetFullPath(_option.WriteDatabaseToPath)}'");
        Console.WriteLine($"上書き出力: {(_option.OverwritesDatabase ? "する" : "しない")}");
        Console.WriteLine();

        ICatalogSourceRepository source = CreateCatalogSourceRepository();
        ICatalogSetupRepository catalog = CreateCatalogSetupRepository();

        catalog.SetupEnumDescriptions();
        catalog.SetupCards(source.Cards.Select(c => c.ToCardInfo()));
        catalog.SetupCardDescriptions(source.CardDescriptions.Select(c => c.ToCardDescriptionInfo()));

        Console.WriteLine("Ruina データベースを作成しました。");
    }

    private ICatalogSourceRepository CreateCatalogSourceRepository()
        => new XmlCatalogSourceRepository(_option.ReadXmlFromPath);

    private ICatalogSetupRepository CreateCatalogSetupRepository()
        => new SqliteCatalogSetupRepository(_option.WriteDatabaseToPath, _option.OverwritesDatabase);
}
