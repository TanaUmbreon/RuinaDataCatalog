namespace RuinaDataCatalog.RuinaDBSetup.Test;

[TestFixture]
public class CommandLineOptionTest
{
    /// <summary>
    /// <see cref="FromArgs_NoRequiredOption"/> テスト メソッドの引数に渡すテスト ケースを列挙します。
    /// </summary>
    private static IEnumerable<string[]> GetNoRequiredOptionTestCases()
    {
        yield return new string[] { };
        yield return new string[] { "--read-xml-from" };
        yield return new string[] { "--write-db-to" };
        yield return new string[] { "--read-xml-from", "--write-db-to" };
        yield return new string[] { "ruina.db" };
        yield return new string[] { "--write-to", "ruina.db" };
        yield return new string[] { "--write-db-to", "ruina.db", "--umbreon" };
    }

    [TestCaseSource(nameof(GetNoRequiredOptionTestCases))]
    public void FromArgs_NoRequiredOption(string[] args)
    {
        Assert.That(() => CommandLineOption.FromArgs(args), Throws.ArgumentException);
    }

    [Test(Description = "全てのオプションを指定")]
    public void FromArgs1()
    {
        var args = new[]
        {
            "--read-xml-from", @".\StaticInfo\",
            "--write-db-to", @".\ruina.db",
            "--overwrite",
        };
        var option = CommandLineOption.FromArgs(args);
        Assert.That(option.ReadXmlFromPath, Is.EqualTo(@".\StaticInfo\"));
        Assert.That(option.WriteDatabaseToPath, Is.EqualTo(@".\ruina.db"));
        Assert.That(option.OverwritesDatabase, Is.EqualTo(true));
    }

    [Test(Description = "並び順を変えて全てのオプションを指定")]
    public void FromArgs2()
    {
        var args = new[]
        {
            "--overwrite",
            "--write-db-to", @".\ruina.db",
            "--read-xml-from", @".\StaticInfo\",
        };
        var option = CommandLineOption.FromArgs(args);
        Assert.That(option.ReadXmlFromPath, Is.EqualTo(@".\StaticInfo\"));
        Assert.That(option.WriteDatabaseToPath, Is.EqualTo(@".\ruina.db"));
        Assert.That(option.OverwritesDatabase, Is.EqualTo(true));
    }

    [Test(Description = "オプションでない余分な引数を含めて全てのオプションを指定")]
    public void FromArgs3()
    {
        var args = new[]
        {
            "bulbasaur",
            "--read-xml-from", @".\StaticInfo\",
            "bulbasaur", "No. 001",
            "--write-db-to", @".\ruina.db",
            "--overwrite",
            "umbreon",
        };
        var option = CommandLineOption.FromArgs(args);
        Assert.That(option.ReadXmlFromPath, Is.EqualTo(@".\StaticInfo\"));
        Assert.That(option.WriteDatabaseToPath, Is.EqualTo(@".\ruina.db"));
        Assert.That(option.OverwritesDatabase, Is.EqualTo(true));
    }

    [Test(Description = "--overwriteを省略")]
    public void FromArgs4()
    {
        var args = new[]
        {
            "--read-xml-from", "StaticInfo",
            "--write-db-to", "ruina.db",
        };
        var option = CommandLineOption.FromArgs(args);
        Assert.That(option.ReadXmlFromPath, Is.EqualTo("StaticInfo"));
        Assert.That(option.WriteDatabaseToPath, Is.EqualTo("ruina.db"));
        Assert.That(option.OverwritesDatabase, Is.EqualTo(false));
    }
}
