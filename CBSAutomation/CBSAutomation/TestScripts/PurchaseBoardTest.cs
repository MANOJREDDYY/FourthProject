
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

    class PurchaseBoardTest
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        public string BoardOrderID;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Purcahse Board ";
            extent.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void CreateBoardPurchaseOrdert1()
        {
             BoardOrderID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");

          //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            PurchaseBoardPage.POforBoard(BoardOrderID);
                }

        [Test, Order(2)]
        public void CreateBoardPurchaseOrdert2()
        {
            BoardOrderID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            POProcessingPage.ProcessBoardPO(BoardOrderID);
        }

        [Test, Order(3)]
        public void ReceivePurchaseOrdert2()
        {
            string receivesupplier = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");
            string units = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("RECEVING", "Receive_PO", "Receive_Board", "VENDORBOARD", receiveshipmentID);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceiveBoardPO(receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);
        }




        [OneTimeTearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Purchase Board for a product ", "Purchase Board for a product and receive it");
            extent.GenerateReport();
            BrowserLaunch.CloseBrowser();

        }

      

    }
}
