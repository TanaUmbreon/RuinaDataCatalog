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
/// ���̃A�v���P�[�V�����Ɋւ���A�Z���u�������Q�Ƃ��郆�[�e�B���e�B �N���X�ł��B
/// </summary>
internal static class AssemblyInfo
{
    /// <summary>���ݎ��s���̃R�[�h���i�[���Ă���A�Z���u���̃t�@�C�� �o�[�W�������</summary>
    private static readonly FileVersionInfo versionInfo;

    /// <summary>
    /// �A�Z���u���̐��i�����擾���܂��B
    /// </summary>
    public static string ProductName => versionInfo.ProductName ?? "";

    static AssemblyInfo()
    {
        versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
    }
}
