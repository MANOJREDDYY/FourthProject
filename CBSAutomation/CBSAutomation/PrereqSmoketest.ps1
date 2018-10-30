$NunitDir="E:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation"+ "\Nunit\nunit3-console.exe"

                           
$extentReportDir=$currentDir + "\ExtentReports\"
$TestDLL="E:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation" +"\bin\Debug\CBSAutomation.dll"

$TestResult="E:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation" +"\Reports\"
Write-Host "starting Nunit Test"
$fullnamestr ="CreateCustomer","CreateMaterial","ToolCreation"
$fullnamestr =$fullnamestr | ForEach-Object{"CBSAutomation.TestScripts.$_,"}
&$NunitDir $TestDLL --test=$fullnamestr 
Write-Host "Test Completed"
Write-Host "report Generation"