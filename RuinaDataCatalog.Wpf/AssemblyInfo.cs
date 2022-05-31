using System.Diagnostics;
using System.Reflection;
using System.Windows;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

namespace RuinaDataCatalog.Wpf;

/// <summary>
/// このアプリケーションに関するアセンブリ情報を参照するユーティリティ クラスです。
/// </summary>
internal static class AssemblyInfo
{
    /// <summary>現在実行中のコードを格納しているアセンブリのファイル バージョン情報</summary>
    private static readonly FileVersionInfo versionInfo;

    /// <summary>
    /// アセンブリの製品名を取得します。
    /// </summary>
    public static string ProductName => versionInfo.ProductName ?? "";

    static AssemblyInfo()
    {
        versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
    }
}
