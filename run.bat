@echo off
echo [SimpleMDB] Starting servers...
echo.
start /B dotnet run --project src\Smdb.Api\Smdb.Api.csproj --urls http://127.0.0.1:5000
timeout /t 2 /nobreak >nul
start /B dotnet run --project src\Smdb.Csr\Smdb.Csr.csproj --urls http://127.0.0.1:5001
echo.
echo [SimpleMDB] Servers started!
echo [SimpleMDB] API: http://127.0.0.1:5000
echo [SimpleMDB] Web: http://127.0.0.1:5001
echo.
echo Press Ctrl+C to stop all servers
pause >nul
