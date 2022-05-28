using RuinaDataCatalog.RuinaDBSetup.Infrastructures.Xml;

namespace RuinaDataCatalog.RuinaDBSetup.Test.Infrastructures;

[TestFixture]
public class XmlCatalogSourceRepositoryTest
{
    [Test]
    public void New_ThorwsArgumentNullException()
    {
        Assert.That(() => new XmlCatalogSourceRepository(null!),
            Throws.ArgumentNullException);
    }

    [Test]
    public void New_ThrowsDirectoryNotFound()
    {
        Assert.That(() => new XmlCatalogSourceRepository(@"存在しないフォルダー\"),
            Throws.Exception.TypeOf<DirectoryNotFoundException>());
    }

    [Test]
    public void New()
    {
        var repo = new XmlCatalogSourceRepository(@"TestInputData\");
        Assert.That(repo.Cards.Count(), Is.EqualTo(3));
    }
}
