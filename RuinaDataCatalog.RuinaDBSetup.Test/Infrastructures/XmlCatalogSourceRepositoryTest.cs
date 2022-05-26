using RuinaDataCatalog.RuinaDBSetup.Infrastructures;

namespace RuinaDataCatalog.RuinaDBSetup.Test.Infrastructures;

[TestFixture]
public class XmlCatalogSourceRepositoryTest
{
    [Test]
    public void TestNew_ThorwsArgumentNullException()
    {
        Assert.That(() => new XmlCatalogSourceRepository(null!),
            Throws.ArgumentNullException);
    }

    [Test]
    public void TestNew_ThrowsDirectoryNotFound()
    {
        Assert.That(() => new XmlCatalogSourceRepository(@"存在しないフォルダー\"),
            Throws.Exception.TypeOf<DirectoryNotFoundException>());
    }

    [Test]
    public void TestNew()
    {
        var repo = new XmlCatalogSourceRepository(@"TestInputData\");
        Assert.That(repo.Cards.Count(), Is.EqualTo(3));
    }
}
