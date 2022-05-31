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
        return Array.Empty<CardInfo>();
    }
}
