
using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CBSAutomation.TestScripts
{
    class CreateQuotation
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "Create Quation for DC joined  specification ";
            extent.SetupReporting(reportname);

           

        }


        [SetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test]
        public void CreateQuotationTest1()
        {
                 string QouteCustname = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Qoutespec = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID");
                 string saluation ="CBSAutomation Qoutation";
                 string BussStatus = "2";
                 string Approvestatus = "2";

            QuotationPage.CreateQuotaion( QouteCustname,  Qoutespec,  saluation,  BussStatus,  Approvestatus);






        }





        [TearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Create Quation for DC joined  specification ", "Create Quation for D/C joined  specification and validate the report generations");
            BrowserLaunch.CloseBrowser();

        }

        [OneTimeTearDown]
        public void FlushReport()
        {
            extent.GenerateReport();
        }


    }
}
