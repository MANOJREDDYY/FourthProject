$currentDir= (Get-Item -Path ".\"-Verbose).FullName
$NunitDir=$currentDir + "\Nunit\nunit3-console.exe"

                           
$extentReportDir=$currentDir + "\ExtentReports\"
$TestDLL="C:\Users\veenahon\Documents\Visual Studio 2015\Projects\CBSAutomation\CBSAutomation\bin\Debug\CBSAutomation.dll"

$TestResult="C:\Users\veenahon\Documents\visual studio 2015\Projects\CBSAutomation\CBSAutomation\Reports\"
Write-Host "starting Nunit Test"
&$NunitDir $TestDLL
Write-Host "Test Completed"
Write-Host "report Generation"

Copy-Item $TestResult-include "*.html" -Destination $extentReportDir