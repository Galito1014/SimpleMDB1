Write-Host "[SimpleMDB] Starting servers..." -ForegroundColor Cyan
Write-Host ""

# Start API server in background
Start-Process -NoNewWindow -FilePath "dotnet" -ArgumentList "run","--project","src/Smdb.Api/Smdb.Api.csproj","--urls","http://127.0.0.1:5000"
Start-Sleep -Seconds 2

# Start CSR server (this one stays in foreground)
Write-Host "[SimpleMDB] API: http://127.0.0.1:5000" -ForegroundColor Green
Write-Host "[SimpleMDB] Web: http://127.0.0.1:5001" -ForegroundColor Green  
Write-Host "[SimpleMDB] Press Ctrl+C to stop all servers" -ForegroundColor Yellow
Write-Host ""

dotnet run --project src/Smdb.Csr/Smdb.Csr.csproj --urls http://127.0.0.1:5001
