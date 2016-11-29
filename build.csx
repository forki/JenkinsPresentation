#load "./cake-scripts/paket.csx"

var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!")
    .IsDependentOn("PaketInstall");

RunTarget(target);
