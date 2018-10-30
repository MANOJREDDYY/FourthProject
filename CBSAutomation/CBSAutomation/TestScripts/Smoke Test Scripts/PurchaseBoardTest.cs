
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
    [Order(9)]
  
    public  class PurchaseBoardTest:Driver
    {

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        public string BoardOrderID;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Purcahse Board ";
            extendtreports.SetupReporting(reportname);

        }

        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateBoardPurchaseOrdert1()
        {

            test = extendtreports.CreateTestwrap("create PO for Board");
            BoardOrderID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");

          //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            PurchaseBoardPage.POforBoard(this.driver, test, BoardOrderID);
                }

        [Test]
        public void CreateBoardPurchaseOrdert2()
        {
            test = extendtreports.CreateTestwrap("Process PO for Board");
            BoardOrderID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            POProcessingPage.ProcessBoardPO(this.driver,BoardOrderID);
        }

        [Test]
        public void ReceivePurchaseOrdert2()
        {
            test = extendtreports.CreateTestwrap("receive PO for Board");
            string receivesupplier = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");
            string units = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("RECEVING", "Receive_PO", "Receive_Board", "VENDORBOARD", receiveshipmentID);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceiveBoardPO(this.driver, test, receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);
        }




       
          [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Purchase Board for a product Purchase Board for a product and receive it") ;
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }




    }
}


