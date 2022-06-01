using Microsoft.Data.Sqlite;
using RuinaDataCatalog.Core.Models;
using RuinaDataCatalog.Core.Repositories;

namespace RuinaDataCatalog.Core.Infrastructures;

public class SqliteCatalogCardRepository : ICatalogCardRepository
{
    private readonly FileInfo _dbFile;

    /// <summary>
    /// <see cref="SqliteCatalogCardRepository"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="dbFilePath"></param>
    public SqliteCatalogCardRepository(string dbFilePath)
    {
        if (dbFilePath == null) { throw new ArgumentNullException(nameof(dbFilePath)); }

        _dbFile = new FileInfo(dbFilePath);
    }

    public IEnumerable<CardInfo> GetCards()
    {
        using var connection = CreateOpenConnection();
        var cards = SqliteSelectCardCommand.Execute(connection);

        return cards;
    }

    /// <summary>
    /// SQLite データベースの接続を生成して開きます。
    /// </summary>
    /// <returns></returns>
    private SqliteConnection CreateOpenConnection()
    {
        SqliteConnection? connection = null;
        try
        {
            var builder = new SqliteConnectionStringBuilder()
            {
                DataSource = _dbFile.FullName,
            }.ToString();

            connection = new SqliteConnection(builder.ToString());
            connection.Open();

            return connection;
        }
        catch
        {
            connection?.Dispose();
            throw;
        }
    }
}
