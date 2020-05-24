Get-ChildItem -Path (Join-Path $PSScriptRoot "\data") -Directory | ForEach-Object {
    $dataPath = $_.FullName
    Get-ChildItem -Path $dataPath -Exclude ".gitkeep" -Recurse | Remove-Item -Force -Recurse
}
Write-Host "Cleaned \data." -fore Green

Get-ChildItem -Path (Join-Path $PSScriptRoot "\deploy") -Directory | ForEach-Object {
    $dataPath = $_.FullName
    Get-ChildItem -Path $dataPath -Exclude ".gitkeep" -Recurse | Remove-Item -Force -Recurse
}
Write-Host "Cleaned \deploy." -fore Green
