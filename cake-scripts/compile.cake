Task("Compile")
    .Description("Compiles debug and release modes")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("CompileRelease");

Task("CompileDebug")
    .Description("Compiles in debug mode")
    .Does(() => {
      Compile("Debug");
    });

Task("CompileRelease")
    .Description("Compiles in release mode")
    .Does(() => {
      Compile("Release");
    });

private void Compile(string mode)
{
    string solution = "./src/TestProject.sln";
    if (IsRunningOnWindows()) {
      MSBuild(solution, settings =>
          settings.SetConfiguration(mode)
          .SetVerbosity(Verbosity.Minimal)
          .UseToolVersion(MSBuildToolVersion.NET46)
          .WithTarget("Build"));
    } else {
      XBuild(solution, settings => settings
          .SetConfiguration(Argument("configuration", "Release")
          .SetVerbosity(Verbosity.Minimal)
          .WithTarget("Build")));
    }

}
