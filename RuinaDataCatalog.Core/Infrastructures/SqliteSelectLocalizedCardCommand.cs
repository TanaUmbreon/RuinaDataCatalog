using Microsoft.Data.Sqlite;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Properties;
using static System.Convert;

namespace RuinaDataCatalog.Core.Infrastructures;

/// <summary>
/// ローカライズされたバトル ページ情報を取得するコマンドです。
/// </summary>
public static class SqliteSelectLocalizedCardCommand
{
    /// <summary>
    /// 指定した接続を使用して、指定したバトル ページ情報を追加するコマンドを実行します。
    /// </summary>
    /// <param name="connection">コマンドの実行対象となるデータベースへの接続。</param>
    public static IEnumerable<LocalizedCardInfo> Execute(SqliteConnection connection)
    {
        if (connection == null) { throw new ArgumentNullException(nameof(connection)); }

        var cards = new List<LocalizedCardInfo>();

        using (SqliteCommand command = connection.CreateCommand(Resources.SelectLocalizedCard))
        {
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cards.Add(new LocalizedCardInfo()
                {
                    Id = ToInt32(reader["ID"]),
                    Name = reader["NAME"].ToString() ?? "",
                    Artwork = reader["ARTWORK"].ToString() ?? "",
                    Rarity = ToInt32(reader["RARITY"]),
                    RarityName = reader["RARITY_NAME"].ToString() ?? "",
                    Range = ToInt32(reader["RANGE"]),
                    RangeName = reader["RANGE_NAME"].ToString() ?? "",
                    Cost = ToInt32(reader["COST"]),
                    Chapter = ToInt32(reader["CHAPTER"]),
                });
            }
        }

        return cards;
    }
}
