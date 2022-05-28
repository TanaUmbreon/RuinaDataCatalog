using RuinaDataCatalog.RuinaDBSetup.Infrastructures.Sqlite;

namespace RuinaDataCatalog.RuinaDBSetup.Test.Infrastructures;

[TestFixture]
public class SqliteCatalogSetupRepositoryTest
{
    [Test]
    public void New_ThorwsArgumentNullException()
    {
        Assert.That(() => new SqliteCatalogSetupRepository(null!, true),
            Throws.ArgumentNullException);
        Assert.That(() => new SqliteCatalogSetupRepository(null!, false),
            Throws.ArgumentNullException);
    }

    [Test]
    public void New_ThrowsInvalidOperationException()
    {
        const string DBPath = "Ruina.db";
        try
        {
            File.Create(DBPath).Dispose();

            Assert.That(() => new SqliteCatalogSetupRepository(DBPath, true),
                Throws.Nothing);
            Assert.That(() => new SqliteCatalogSetupRepository(DBPath, false),
                Throws.Exception.TypeOf<InvalidOperationException>());
        }
        finally
        {
            if (File.Exists(DBPath))
            {
                File.Delete(DBPath);
            }
        }
    }
}
