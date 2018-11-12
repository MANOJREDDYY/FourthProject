
$NunitDir="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\CBSAutomation"+ "\Nunit\nunit3-console.exe"

                           
$extentReportDir=$currentDir + "\ExtentReports\"
$TestDLL="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\CBSAutomation" +"\bin\Debug\CBSAutomation.dll"

$TestResult="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\CBSAutomation" +"\Reports\"
Write-Host "starting Nunit Test"
$reportNunitDir="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\packages\ReportUnit.1.5.0-beta1\tools\ReportUnit.exe"
$reportNunitInputpath ="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\xmlTestResults"
$reportNunitOutputpath ="C:\Users\manojred\.jenkins\workspace\FourthProject\CBSAutomation\HtmlTestResults"
$NumArray = ("CreateMaterial","CreateCustomer")

$i=1
Foreach ($Item in $NumArray) {
Write-Host "hello"
Write-Host $i
$i++
&$NunitDir  $TestDLL --where class==CBSAutomation.TestScripts.Smoke_Test_Scripts.$Item --labels=off --work=$reportNunitInputpath --result="Project.SmokeCases.Test.xml;format=nunit3"
&$reportpat $reportNunitInputpath
}


&$reportNunitDir $reportpat $reportNunitOutputpath 
Write-Host "Test Completed"
Write-Host "report Generation"






