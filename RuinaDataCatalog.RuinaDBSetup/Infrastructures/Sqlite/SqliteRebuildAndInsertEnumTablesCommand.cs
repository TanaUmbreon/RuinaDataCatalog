﻿using Microsoft.Data.Sqlite;
using RuinaDataCatalog.RuinaDBSetup.Properties;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

/// <summary>
/// 列挙値の説明テーブル群を再構築し、固定のレコードを追加するコマンドです。
/// </summary>
public static class SqliteRebuildAndInsertEnumTablesCommand
{
    /// <summary>
    /// 指定された接続を使用してコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    public static void Execute(SqliteConnection connection)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }

        using var transaction = connection.BeginTransaction(deferred: true);
        using var command = connection.CreateCommand(Resources.RebuildAndInsertEnumTables);
        command.ExecuteNonQuery();

        transaction.Commit();
    }
}
