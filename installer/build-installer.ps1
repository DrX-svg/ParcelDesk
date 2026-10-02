$ErrorActionPreference = "Stop"

$root =
    Resolve-Path (
        Join-Path $PSScriptRoot ".."
    )

Set-Location $root

Write-Host ""
Write-Host "Building ParcelDesk installer..."
Write-Host ""

$apiPublish =
    Join-Path $root "publish\Api"

$winFormsPublish =
    Join-Path $root "publish\WinForms"

$dist =
    Join-Path $root "dist"

Remove-Item `
    $apiPublish `
    -Recurse `
    -Force `
    -ErrorAction SilentlyContinue

Remove-Item `
    $winFormsPublish `
    -Recurse `
    -Force `
    -ErrorAction SilentlyContinue

New-Item `
    -ItemType Directory `
    -Path $apiPublish `
    -Force |
    Out-Null

New-Item `
    -ItemType Directory `
    -Path $winFormsPublish `
    -Force |
    Out-Null


Write-Host "Publishing API..."

dotnet publish `
    ".\src\ParcelDesk.Api\ParcelDesk.Api.csproj" `
    -c Release `
    -r win-x64 `
    --self-contained true `
    -o $apiPublish

if ($LASTEXITCODE -ne 0) {
    throw "API publish failed."
}


Write-Host ""
Write-Host "Publishing WinForms..."

dotnet publish `
    ".\src\ParcelDesk.WinForms\ParcelDesk.WinForms.csproj" `
    -c Release `
    -r win-x64 `
    --self-contained true `
    -o $winFormsPublish

if ($LASTEXITCODE -ne 0) {
    throw "WinForms publish failed."
}


$isccCandidates = @(
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe",
    "$env:LOCALAPPDATA\Programs\Inno Setup 6\ISCC.exe"
)

$iscc =
    $isccCandidates |
    Where-Object {
        $_ -and (Test-Path $_)
    } |
    Select-Object -First 1

if (-not $iscc) {
    throw @"
Inno Setup compiler was not found.

Install it with:

winget install --id JRSoftware.InnoSetup -e
"@
}


New-Item `
    -ItemType Directory `
    -Path $dist `
    -Force |
    Out-Null


Write-Host ""
Write-Host "Compiling installer..."

& $iscc `
    ".\installer\ParcelDesk.iss"

if ($LASTEXITCODE -ne 0) {
    throw "Installer compilation failed."
}


$setupPath =
    Join-Path `
        $dist `
        "ParcelDesk-Setup.exe"

Write-Host ""
Write-Host "======================================"
Write-Host " ParcelDesk installer created"
Write-Host "======================================"
Write-Host ""
Write-Host $setupPath
Write-Host ""