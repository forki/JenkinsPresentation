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
    MSBuild("./src/TestProject.sln", settings =>
      settings.SetConfiguration(mode)
        .SetVerbosity(Verbosity.Minimal)
        .UseToolVersion(MSBuildToolVersion.NET45)
        .WithTarget("Build"));
}
