#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!")
    .IsDependentOn("PaketInstall")
    .IsDependentOn("Compile");
    .IsDependentOn("Xunit2");

Task("PaketInstall")
    .Description("Paket Install...")
    .IsDependentOn("BootstrapPaket")
    .Does(() =>
    {
      if (IsRunningOnWindows())
      {
        if(StartProcess(".paket/paket.exe", "install") != 0)
        {
          Error("Paket install failed");
        }
      }
      else
      {
        if(StartProcess("mono", ".paket/paket.exe install") != 0)
        {
          Error("Paket install failed");
        }
      }
    });

Task("BootstrapPaket")
    .Description("Bootstrap Paket...")
    .WithCriteria(!FileExists(".paket/paket.exe"))
    .Does(() =>
    {
        if (IsRunningOnWindows())
        {
          if(StartProcess(".paket/paket.bootstrapper.exe") != 0)
          {
            Error("Paket bootstrap failed");
          }
        }
        else
        {
          if(StartProcess("mono", ".paket/paket.bootstrapper.exe") != 0)
          {
            Error("Paket bootstrap failed on Mac");
          }
        }
    });

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


Task("Xunit2")
  .Description("Run xUnit tests")
  .Does(() => {
    XUnit2("./src/Sample.Test/bin/Debug/Sample.Test.dll");
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
          .SetConfiguration(mode));
    }

}
RunTarget(target);
