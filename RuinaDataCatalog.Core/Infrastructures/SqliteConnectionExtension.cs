using System.Data;
using Microsoft.Data.Sqlite;

namespace RuinaDataCatalog.Core.Infrastructures;

/// <summary>
/// <see cref="SqliteConnection"/> クラスの拡張メソッドを提供します。
/// </summary>
public static class SqliteConnectionExtension
{
    /// <summary>
    /// 指定した SQL を実行するコマンドを生成して返します。
    /// </summary>
    /// <param name="connection">コマンド生成元の接続。</param>
    /// <param name="sql">接続先のデータベースを操作する SQL。</param>
    /// <returns></returns>
    public static SqliteCommand CreateCommand(this SqliteConnection connection, string sql)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }
        if (sql == null) { throw new ArgumentNullException(nameof(sql)); }

        SqliteCommand? command = null;
        try
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            return command;
        }
        catch
        {
            command?.Dispose();
            throw;
        }
    }
}
