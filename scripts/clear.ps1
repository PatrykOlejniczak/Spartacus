# Define files and directories to delete
$include = @("*.suo","*.user","*.cache","*.docstates","bin","obj","build")

# Define files and directories to exclude
$exclude = @()

$items = Get-ChildItem . -recurse -force -include $include -exclude $exclude

if ($items) {
    foreach ($item in $items) {
        Remove-Item $item.FullName -Force -Recurse -ErrorAction SilentlyContinue
        Write-Host "Deleted" $item.FullName
    }
}