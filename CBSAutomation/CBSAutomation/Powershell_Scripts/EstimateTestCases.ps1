﻿
$NunitDir="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation"+ "\Nunit\nunit3-console.exe"

                           
$extentReportDir=$currentDir + "\ExtentReports\"
$TestDLL="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation" +"\bin\Debug\CBSAutomation.dll"

$TestResult="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\CBSAutomation" +"\Reports\"
Write-Host "starting Nunit Test"



#$fullnamestr =$Preqfullnamestr | ForEach-Object{"CBSAutomation.TestScripts.$_,"}



 $reportNunitDir="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\packages\ReportUnit.1.5.0-beta1\tools\ReportUnit.exe"
$reportNunitInputpath ="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\xmlTestResults"
$reportNunitOutputpath ="C:\GitCBS\cti-pbs\DEV\NET4\SeleniumAutomation\CBSAutomation\HtmlTestResults"

&$NunitDir  $TestDLL --where namespace==CBSAutomation.TestScripts.Estimate_Test_Cases  --labels=off --work=$reportNunitInputpath --result="Project.EstimateModule.Test.xml;format=nunit3" 



&$reportNunitDir $reportNunitInputpath $reportNunitOutputpath 
Write-Host "Test Completed"
Write-Host "report Generation"






