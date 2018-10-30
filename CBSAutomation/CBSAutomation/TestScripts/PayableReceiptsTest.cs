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

namespace CBSAutomation.TestScripts
{
    class PayableReceiptsTest
    {
         

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Payable Receipts For processed PO";
            extent.SetupReporting(reportname);



        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void ReceivePurchaseOrdertBoard1()
        {
           
            
         
            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string receiptIDfilter =excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "VENDORBOARD");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable  = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Board";
           PayableReceiptsPage.PayableReceiptsCreation( Vendorid, receiptIDfilter, dateofpayable, Receiptypes);
        }
        [Test, Order(2)]
        public void ReceivePurchaseOrdertMaterial1()
        {



            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string receiptIDfilter = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "VENDORBOARD");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Materials";
            PayableReceiptsPage.PayableReceiptsCreation(Vendorid, receiptIDfilter, dateofpayable, Receiptypes);
        }
        [Test, Order(3)]
        public void ReceivePurchaseOrdertTool1()
        {



            string Vendorid = "AutoVendorID_" + CommonFunctions.RandomString(2);
            string receiptIDfilter = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "VENDORBOARD");
            DateTime startDatenow = DateTime.Today;
            string dateofpayable = startDatenow.ToString("MM/dd/yyyy");
            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Receiptypes = "Tools";
            PayableReceiptsPage.PayableReceiptsCreation(Vendorid, receiptIDfilter, dateofpayable, Receiptypes);
        }



        [OneTimeTearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Process the payable receipts ", "process the payables receipts generated for material and board");
            extent.GenerateReport();
            BrowserLaunch.CloseBrowser();



        }

        [OneTimeTearDown]
        public void FlushReport()
        {

         }


    }
}


  