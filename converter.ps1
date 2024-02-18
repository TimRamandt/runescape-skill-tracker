# Get the file path from the argument
if ($args.Count -ne 1) {
    Write-Host "no argument passed"
    exit
}

$file = $args[0]

if (-not (Test-Path -Path $file -PathType Leaf)) {
    Write-Host "File '$file' not found."
    exit
}

$content = Get-Content -Path $file -Raw

# Replace \r\n with \n
$newContent = $content -replace "\r\n", "`n"

Set-Content -Path $file -Value $newContent

Write-Host "Completed!"