using AventStack.ExtentReports.Utils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;



//using System.Drawing.Imaging;

namespace CBSAutomation
{
    public class extendtreports
    {
        public static  Status logStatus;
        public static   ExtentReports extent;
        public static ExtentHtmlReporter htmlreporter;
        public static  ExtentTest test;
        public static string ScreenreportPath;
        //   private static IWebDriver driver = Driver.getDriver();


        public  static void SetupReporting(string reportname)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath; // project path of your solution

            string reportPath = projectPath + "Reports\\" + reportname + ".html";
            ScreenreportPath = projectPath + "Reports\\" + reportname + "screenshot.PNG";
           
            // initialize the HtmlReporter


            htmlreporter = new ExtentHtmlReporter(reportPath);
            htmlreporter.AppendExisting = true;

            // create ExtentReports and attach reporter(s)
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);

            extent.AddSystemInfo("Host Name", "Veena");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "Veena");
     
        }


        public static void GenerateReport()
        {
            extent.Flush();
        }

        public static ExtentTest CreateTestwrap(string description)
        {
           test = extent.CreateTest(description,"");
            IMarkup m = MarkupHelper.CreateLabel(description,ExtentColor.Red);
           
            return test;
        }

              public static void LogTestStatus(string name)
             {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                                 ? ""
                                 : $"{TestContext.CurrentContext.Result.StackTrace}";

            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                              ? ""
                              : $"{TestContext.CurrentContext.Result.Message}";
   // public Status logStatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;
            }

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {

                test.Log(logStatus, MarkupHelper.CreateLabel(name + " Test case FAILED due to below issues:", ExtentColor.Red));
                test.Log(logStatus, "<b>" + "ERROR MESSAGE: " + "</b>" + message);
                test.Log(logStatus, "<b>" + "STACKTRACE: " + "</b>" + stacktrace);
                var screenshot = ((ITakesScreenshot)Driver.getDriver()).GetScreenshot();
                screenshot.SaveAsFile(ScreenreportPath, ScreenshotImageFormat.Jpeg);
                // log with snapshot

                test.Fail("details", MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenreportPath).Build());
                //  test with snapshot
                test.AddScreenCaptureFromPath(ScreenreportPath);


            }

            else
            {
                test.Log(logStatus, MarkupHelper.CreateLabel(name + " Test Case PASSED", ExtentColor.Green));


            }




        }
    }
}



