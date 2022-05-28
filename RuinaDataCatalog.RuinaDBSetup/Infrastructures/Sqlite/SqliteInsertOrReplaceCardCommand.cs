using Microsoft.Data.Sqlite;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.RuinaDBSetup.Properties;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

/// <summary>
/// 指定したバトル ページ情報を追加または上書きするコマンドです。
/// </summary>
public static class SqliteInsertOrReplaceCardCommand
{
    /// <summary>
    /// 指定した接続を使用して、指定したバトル ページ情報を追加するコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    /// <param name="card">追加または上書きするバトル ページ情報。</param>
    public static void Execute(SqliteConnection connection, CardInfo card)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }
        if (card == null) { throw new ArgumentNullException(nameof(card)); }

        using var transaction = connection.BeginTransaction(deferred: true);

        using (var command = connection.CreateCommand(Resources.InsertOrReplaceCard))
        {
            command
                .AddParameter("$ID", SqliteType.Integer, card.Id)
                .AddParameter("$NAME", SqliteType.Text, card.Name)
                .AddParameter("$TEXT_ID", SqliteType.Integer, card.TextId)
                .AddParameter("$ARTWORK", SqliteType.Text, card.Artwork)
                .AddParameter("$RARITY", SqliteType.Integer, card.Rarity)
                .AddParameter("$RANGE", SqliteType.Integer, card.Range)
                .AddParameter("$COST", SqliteType.Integer, card.Cost)
                .AddParameter("$AFFECTION", SqliteType.Integer, card.Affection)
                .AddParameter("$EMOTION_LIMIT", SqliteType.Integer, card.EmotionLimit)
                .AddParameter("$SCRIPT", SqliteType.Text, card.Script)
                .AddParameter("$SCRIPT_DESC", SqliteType.Text, card.ScriptDesc)
                .AddParameter("$CHAPTER", SqliteType.Integer, card.Chapter)
                .AddParameter("$SPECIAL_EFFECT", SqliteType.Text, card.SpecialEffect)
                .AddParameter("$SKIN_CHANGE", SqliteType.Text, card.SkinChange)
                .AddParameter("$SKIN_CHANGE_TYPE", SqliteType.Integer, card.SkinChangeType)
                .AddParameter("$SKIN_HEIGHT", SqliteType.Integer, card.SkinHeight)
                .AddParameter("$MAP_CHANGE", SqliteType.Text, card.MapChange)
                .AddParameter("$PRIORITY", SqliteType.Integer, card.Priority)
                .AddParameter("$PRIORITY_SCRIPT", SqliteType.Text, card.PriorityScript)
                .AddParameter("$CATEGORY", SqliteType.Integer, card.Category)
                .AddParameter("$MAX_COOLTIME_FOR_EGO", SqliteType.Integer, card.MaxCooltimeForEgo)
                .AddParameter("$MAX_NUM", SqliteType.Integer, card.MaxNum);

            command.ExecuteNonQuery();
        }

        foreach (var (option, index) in card.Option.Select((o, i) => (o, i)))
        {
            using var command = connection.CreateCommand(Resources.InsertOrReplaceCardOption);

            command
                .AddParameter("$ID", SqliteType.Integer, card.Id)
                .AddParameter("$INDEX", SqliteType.Integer, index)
                .AddParameter("$VALUE", SqliteType.Integer, option);

            command.ExecuteNonQuery();
        }

        foreach (var (keyword, index) in card.Keyword.Select((k, i) => (k, i)))
        {
            using var command = connection.CreateCommand(Resources.InsertOrReplaceCardKeyword);

            command
                .AddParameter("$ID", SqliteType.Integer, card.Id)
                .AddParameter("$INDEX", SqliteType.Integer, index)
                .AddParameter("$VALUE", SqliteType.Text, keyword);

            command.ExecuteNonQuery();
        }

        foreach (var (behaviour, index) in card.Behaviour.Select((b, i) => (b, i)))
        {
            using var command = connection.CreateCommand(Resources.InsertOrReplaceCardBehaviour);

            command
                .AddParameter("$ID", SqliteType.Integer, card.Id)
                .AddParameter("$INDEX", SqliteType.Integer, index)
                .AddParameter("$MIN", SqliteType.Integer, behaviour.Min)
                .AddParameter("$DICE", SqliteType.Integer, behaviour.Dice)
                .AddParameter("$TYPE", SqliteType.Integer, behaviour.Type)
                .AddParameter("$DETAIL", SqliteType.Integer, behaviour.Detail)
                .AddParameter("$MOTION", SqliteType.Integer, behaviour.Motion)
                .AddParameter("$MOTION_DEFAULT", SqliteType.Integer, behaviour.MotionDefault)
                .AddParameter("$EFFECT_RES", SqliteType.Text, behaviour.EffectRes)
                .AddParameter("$SCRIPT", SqliteType.Text, behaviour.Script)
                .AddParameter("$ACTION_SCRIPT", SqliteType.Text, behaviour.ActionScript)
                .AddParameter("$DESC", SqliteType.Text, behaviour.Desc);

            command.ExecuteNonQuery();
        }

        transaction.Commit();
    }
}
