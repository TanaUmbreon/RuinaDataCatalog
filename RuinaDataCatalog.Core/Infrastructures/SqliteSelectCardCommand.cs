using Microsoft.Data.Sqlite;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Properties;
using static System.Convert;

namespace RuinaDataCatalog.Core.Infrastructures;

/// <summary>
/// バトル ページ情報を取得するコマンドです。
/// </summary>
public static class SqliteSelectCardCommand
{
    /// <summary>
    /// 指定した接続を使用して、指定したバトル ページ情報を追加するコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    public static IEnumerable<CardInfo> Execute(SqliteConnection connection)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }

        var cards = new List<CardInfo>();

        using (SqliteCommand command = connection.CreateCommand(Resources.SelectCard))
        {
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cards.Add(new CardInfo()
                {
                    Id = ToInt32(reader["ID"]),
                    Name = reader["NAME"].ToString() ?? "",
                    TextId = ToInt32(reader["TEXT_ID"]),
                    Artwork = reader["ARTWORK"].ToString() ?? "",
                    Rarity = ToInt32(reader["RARITY"]),
                    Range = ToInt32(reader["RANGE"]),
                    Cost = ToInt32(reader["COST"]),
                    Affection = ToInt32(reader["AFFECTION"]),
                    EmotionLimit = ToInt32(reader["EMOTION_LIMIT"]),
                    Script = reader["SCRIPT"].ToString() ?? "",
                    ScriptDesc = reader["SCRIPT_DESC"].ToString() ?? "",
                    Chapter = ToInt32(reader["CHAPTER"]),
                    SpecialEffect = reader["SPECIAL_EFFECT"].ToString() ?? "",
                    SkinChange = reader["SKIN_CHANGE"].ToString() ?? "",
                    SkinChangeType = ToInt32(reader["SKIN_CHANGE_TYPE"]),
                    SkinHeight = ToInt32(reader["SKIN_HEIGHT"]),
                    MapChange = reader["MAP_CHANGE"].ToString() ?? "",
                    Priority = ToInt32(reader["PRIORITY"]),
                    PriorityScript = reader["PRIORITY_SCRIPT"].ToString() ?? "",
                    Category = ToInt32(reader["CATEGORY"]),
                    MaxCooltimeForEgo = ToInt32(reader["MAX_COOLTIME_FOR_EGO"]),
                    MaxNum = ToInt32(reader["MAX_NUM"]),
                });
            }
        }

        return cards;
    }
}
