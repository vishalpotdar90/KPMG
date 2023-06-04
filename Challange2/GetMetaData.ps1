# This powershell script to Get the instance data
param
(
  # Parameter help description
  [Parameter(Mandatory)]
  [string] $ResourceName
)

Write-Host ("Get the matadata of the instance -" -f $ResourceName)
Invoke-RestMethod -Headers @{"Metadata"="true"} -Method GET -NoProxy -Uri "http://169.254.169.254/metadata/instance/$($ResourceName)?api-version=2017-08-01" | ConvertTo-Json -Depth 64