
using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{
    [TestFixture, SingleThreaded]
    [Order(6)]
  
    public class CreateQuotation:Driver 
    {
        ExtentTest test;
        private  IWebDriver driver;
       private ExcelFile excelFile = BrowserLaunch.getExcelFile();
       // private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "Create Quation for DC joined  specification ";
            extendtreports.SetupReporting(reportname);
            


    }


        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateQuotationTest1 ()  
        {
            test = extendtreports.CreateTestwrap("Create Qoutation for selected product Specification");
            string QouteCustname = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Qoutespec = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID");
                 string saluation ="CBSAutomation Qoutation";
                 string BussStatus = "2";
                 string Approvestatus = "2";

            QuotationPage.CreateQuotaion(this.driver, test, QouteCustname,  Qoutespec,  saluation,  BussStatus,  Approvestatus);






        }

        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create Quation for DC joined  specification Create Quation for D/C joined  specification and validate the report generations ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }

    }
}
