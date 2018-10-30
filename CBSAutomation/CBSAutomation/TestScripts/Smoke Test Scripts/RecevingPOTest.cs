using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Threading;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Common
{
    [TestFixture, SingleThreaded]
    
    [Category("SmokeTest")]
    public class RecevingPOTest:Driver
    {
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Receive PO for Material";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

    /*    [Test]
        public void ReceivePurchaseOrdert1()
        {
            test = extendtreports.CreateTestwrap("Receive PO of the Order");
            string receivesupplier = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEPO");
            string units = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceivePO(this.driver, test, receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);
        }*/
        [Test]
        public void ReceivePurchaseOrdert2()
        {
            string receivesupplier = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEPO");
            string units = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceiveBoardPO(this.driver, test, receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);
        }



        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Receive Purchase order Create order with make and ship");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }

    }
}