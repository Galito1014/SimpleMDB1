using System.Diagnostics;

Console.WriteLine("[SimpleMDB] Starting servers...");
Console.WriteLine();

// Start API server in background
var apiProcess = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "run --project src/Smdb.Api/Smdb.Api.csproj --urls http://127.0.0.1:5000",
        UseShellExecute = false,
        CreateNoWindow = false
    }
};

apiProcess.Start();
await Task.Delay(2000);

// Start CSR server
var csrProcess = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "run --project src/Smdb.Csr/Smdb.Csr.csproj --urls http://127.0.0.1:5001",
        UseShellExecute = false,
        CreateNoWindow = false
    }
};

csrProcess.Start();

Console.WriteLine();
Console.WriteLine("[SimpleMDB] Servers started!");
Console.WriteLine("[SimpleMDB] API: http://127.0.0.1:5000");
Console.WriteLine("[SimpleMDB] Web: http://127.0.0.1:5001");
Console.WriteLine();
Console.WriteLine("[SimpleMDB] Press Ctrl+C to stop all servers");

await Task.WhenAny(apiProcess.WaitForExitAsync(), csrProcess.WaitForExitAsync());
