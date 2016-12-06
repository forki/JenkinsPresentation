Task("PaketInstall")
    .Description("Paket Install...")
    .IsDependentOn("BootstrapPaket")
    .Does(() => {
        if(StartProcess(".paket/paket.exe", "install") != 0) {
          Error("Paket install failed");
        }
    });

Task("BootstrapPaket")
    .Description("Bootstrap Paket...")
    .WithCriteria(!FileExists(".paket/paket.exe"))
    .Does(() => {
        if(StartProcess(".paket/paket.bootstrapper.exe") != 0) {
          Error("Paket bootstrap failed");
        }
    });
