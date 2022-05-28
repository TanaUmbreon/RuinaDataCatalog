using Microsoft.Data.Sqlite;
using RuinaDataCatalog.RuinaDBSetup.Properties;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

/// <summary>
/// バトル ページ情報テーブル群を再構築するコマンドです。
/// </summary>
public static class SqliteRebuildCardDescriptionTablesCommand
{
    /// <summary>
    /// 指定した接続を使用してコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    public static void Execute(SqliteConnection connection)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }

        using var transaction = connection.BeginTransaction(deferred: true);
        using var command = connection.CreateCommand(Resources.RebuildCardDescriptionTables);
        command.ExecuteNonQuery();

        transaction.Commit();
    }
}
