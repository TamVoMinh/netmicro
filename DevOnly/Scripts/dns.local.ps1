function setHostEntries([hashtable] $entries) {
    $hostsFile = "$env:windir\System32\drivers\etc\hosts"
    $newLines = @()

    $c = Get-Content -Path $hostsFile
    foreach ($line in $c) {
        $bits = [regex]::Split($line, "\s+")
        if ($bits.count -eq 2) {
            $match = $NULL
            ForEach($entry in $entries.GetEnumerator()) {
                if($bits[1] -eq $entry.Key) {
                    $newLines += ($entry.Value + '     ' + $entry.Key)
                    Write-Host Replacing HOSTS entry for $entry.Key
                    $match = $entry.Key
                    break
                }
            }
            if($match -eq $NULL) {
                $newLines += $line
            } else {
                $entries.Remove($match)
            }
        } else {
            $newLines += $line
        }
    }

    foreach($entry in $entries.GetEnumerator()) {
        Write-Host Adding HOSTS entry for $entry.Key
        $newLines += $entry.Value + '     ' + $entry.Key
    }

    Write-Host Saving $hostsFile
    Clear-Content $hostsFile
    foreach ($line in $newLines) {
        $line | Out-File -encoding ASCII -append $hostsFile
    }
}

$entries = @{
    'nmro.local' = "127.0.0.1"
    'oidc.nmro.local' = "127.0.0.1"
    'api.nmro.local' = "127.0.0.1"
    'docs.nmro.local' = "127.0.0.1"
    'isys.nmro.local' = "127.0.0.1"
    'engage.nmro.local' = "127.0.0.1"
    'control-centre.nmro.local' = "127.0.0.1"
};
setHostEntries($entries)
