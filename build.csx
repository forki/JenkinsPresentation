#load "./cake-scripts/paket.csx"
#load "./cake-scripts/compile.csx"
#load "./cake-scripts/xunit.csx"


var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!")
    .IsDependentOn("PaketInstall")
    .IsDependentOn("Compile")
    .IsDependentOn("Xunit2");

RunTarget(target);
