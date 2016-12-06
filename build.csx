#l "./cake-scripts/paket.cake"
#l "./cake-scripts/compile.cake"
#l "./cake-scripts/xunit.cake"

var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!");
     .IsDependentOn("PaketInstall")
     .IsDependentOn("Compile")
     .IsDependentOn("Xunit2");

RunTarget(target);
