using Microsoft.Data.Sqlite;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Properties;

namespace RuinaDataCatalog.Core.Infrastructures;

/// <summary>
/// 指定したバトル ページ情報を追加または上書きするコマンドです。
/// </summary>
public static class SqliteInsertOrReplaceCardDescriptionCommand
{
    /// <summary>
    /// 指定した接続を使用して、指定したバトル ページ情報を追加するコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    /// <param name="cardDescription">追加または上書きするバトル ページ情報。</param>
    public static void Execute(SqliteConnection connection, CardDescriptionInfo cardDescription)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }
        if (cardDescription == null) { throw new ArgumentNullException(nameof(cardDescription)); }

        using var transaction = connection.BeginTransaction(deferred: true);

        using (var command = connection.CreateCommand(Resources.InsertOrReplaceCardDescription))
        {
            command
                .AddParameter("$ID", SqliteType.Integer, cardDescription.Id)
                .AddParameter("$LOCALIZED_NAME", SqliteType.Text, cardDescription.LocalizedName)
                .AddParameter("$ABILITY", SqliteType.Text, cardDescription.Ability);

            command.ExecuteNonQuery();
        }

        foreach (var behaviour in cardDescription.Behaviour)
        {
            using var command = connection.CreateCommand(Resources.InsertOrReplaceCardBehaviourDescription);

            command
                .AddParameter("$CARD_DESC_ID", SqliteType.Integer, cardDescription.Id)
                .AddParameter("$INDEX", SqliteType.Integer, behaviour.Id)
                .AddParameter("$BEHAVIOUR_DESC", SqliteType.Text, behaviour.BehaviourDesc);

            command.ExecuteNonQuery();
        }

        transaction.Commit();
    }
}
