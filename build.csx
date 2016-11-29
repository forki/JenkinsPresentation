#load "./cake-scripts/paket.csx"
#load "./cake-scripts/compile.csx"

var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!")
    .IsDependentOn("PaketInstall")
    .IsDependentOn("Compile");

RunTarget(target);
