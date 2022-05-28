using Microsoft.Data.Sqlite;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

/// <summary>
/// <see cref="SqliteCommand"/> クラスの拡張メソッドを提供します。
/// </summary>
public static class SqliteCommandExtension
{
    /// <summary>
    /// 指定したパラメーター名、データ型および値を持つパラメータを
    /// <see cref="SqliteCommand.Parameters">Parameters</see> プロパティに追加します。
    /// </summary>
    /// <param name="command">パラメーター追加先のコマンド。</param>
    /// <param name="parameterName">パラメーター名。</param>
    /// <param name="type">パラメーターのデータ型。</param>
    /// <param name="value">パラメーターの値。</param>
    /// <returns>このインスタンス。</returns>
    public static SqliteCommand AddParameter(this SqliteCommand command, string parameterName, SqliteType type, object value)
    {
        if (command == null) { throw new ArgumentNullException(nameof(command)); }
        if (parameterName == null) { throw new ArgumentNullException(nameof(parameterName)); }

        command.Parameters.Add(parameterName, type).Value = value;

        return command;
    }
}
