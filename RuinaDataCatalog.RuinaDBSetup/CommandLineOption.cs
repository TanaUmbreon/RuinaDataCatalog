using CommandLine;

namespace RuinaDataCatalog.RuinaDBSetup;

/// <summary>
/// コマンド ライン オプションを格納します。
/// </summary>
public class CommandLineOption
{
    /// <summary>
    /// 元データとして読み込む XML ファイルが格納されたフォルダーのパスを相対パスまたは絶対パスで取得または設定します。
    /// </summary>
    [Option("read-xml-from", Required = true, HelpText = "元データにする XML ファイルが格納されたフォルダーのパスを指定します。")]
    public string ReadXmlFromPath { get; set; } = "";

    /// <summary>
    /// 作成する Ruina データベース ファイルのパスを相対パスまたは絶対パスで取得または設定します。
    /// </summary>
    [Option("write-db-to", Required = true, HelpText = "作成する Ruina データベース ファイルの出力先パスを指定します。")]
    public string WriteDatabaseToPath { get; set; } = "";

    /// <summary>
    /// 作成する Ruina データベース ファイルが既に存在する時、ファイルを上書きして作成する事を示す値を取得または設定します。
    /// </summary>
    [Option("overwrite", Default = false, HelpText = "ファイルを上書き出力します。")]
    public bool OverwritesDatabase { get; set; } = false;

    /// <summary>
    /// 指定したコマンド ライン引数から <see cref="CommandLineOption"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="args">コマンド ライン引数。</param>
    /// <returns></returns>
    public static CommandLineOption FromArgs(string[] args)
        => Parser.Default.ParseArguments<CommandLineOption>(args).MapResult(
            opt => opt,
            err => throw new ArgumentException("無効なコマンド ライン引数です。", nameof(args)));
}
