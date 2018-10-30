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

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{
    [TestFixture, SingleThreaded]
    [Order(10)]
 
    public  class PayableReceiptsTest:Driver
    {
        private new IWebDriver driver;

        ExtentTest test;

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;


        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "payable receipt generation";
            extendtreports.SetupReporting(reportname);
        }

        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }



        [Test]
        public void ReceivePurchaseOrdertBoard1()
        {


            test = extendtreports.CreateTestwrap("create payable receipts for Board Purcahsed orders");
            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string PONumberfilter = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEPO");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Board";
            PayableReceiptsPage.PayableReceiptsCreation(this.driver, test, Vendorid, PONumberfilter, dateofpayable, Receiptypes);
        }
        [Test]
        public void ReceivePurchaseOrdertMaterial1()
        {


            test = extendtreports.CreateTestwrap("create payable receipts for material Purcahsed orders");
            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string PONumberfilter = excelFile.GetTestInputValue("RECEVING", "Receive_Material", "Receive_Material", "RECEIVEPO");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Materials";
            PayableReceiptsPage.PayableReceiptsCreation(this.driver, test, Vendorid, PONumberfilter, dateofpayable, Receiptypes);
        }
        [Test]
        public void ReceivePurchaseOrdertTool1()
        {

            test = extendtreports.CreateTestwrap("create payable receipts for tool Purcahsed orders");

            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string PONumberfilter = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLPO");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Tools";
            PayableReceiptsPage.PayableReceiptsCreation(this.driver, test, Vendorid, PONumberfilter, dateofpayable, Receiptypes);
        }




        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Process the payable receipts process the payables receipts generated for material and board");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }
    }
}



  