#tool "nuget:?package=xunit.runner.console"

Task("Xunit2")
  .Description("Run xUnit tests")
  .Does(() => {
    var tests = GetTestFiles("./src");
    XUnit2(tests);
  });

private IEnumerable<string> GetTestFiles(string rootPath)
{
    return System.IO.Directory.GetDirectories(rootPath)
        .Where(x => x.Contains("Test"))
        .Select(x => x.Replace("src\\", ""))
        .Select(x => "./src/" + x + "/bin/Debug/" + x + ".dll")
        .Where(x => FileExists(x));
}
