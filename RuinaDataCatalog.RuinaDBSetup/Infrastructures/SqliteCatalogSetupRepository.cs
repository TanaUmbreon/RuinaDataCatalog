using RuinaDataCatalog.RuinaDBSetup.Models;
using RuinaDataCatalog.RuinaDBSetup.Repositries;

namespace RuinaDataCatalog.RuinaDBSetup.Infrastructures;

public class SqliteCatalogSetupRepository : ICatalogSetupRepository
{
    /// <summary>
    /// <see cref="SqliteCatalogSetupRepository"/> の新しいインスタンスを生成します。
    /// </summary>
    /// <param name="writingFilePath"></param>
    /// <param name="overwrites"></param>
    public SqliteCatalogSetupRepository(string writingFilePath, bool overwrites)
    {
    }

    public void SetupCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions)
    {
        throw new NotImplementedException();
    }

    public void SetupCards(IEnumerable<CardInfo> cards)
    {
        throw new NotImplementedException();
    }

    public void SetupEnumDescriptions()
    {
        throw new NotImplementedException();
    }
}
