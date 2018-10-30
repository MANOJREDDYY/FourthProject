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

    class RecevingPOTest
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Receive PO for Material";
            extent.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void ReceivePurchaseOrdert1()
        {
            string receivesupplier = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Material", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Material", "RECEIVEPO");
            string units = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Material", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Material", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Material", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceivePO( receivesupplier,  receivePo,  units,  unitqty,  lastunitqty,  receivevendorID,  receiveshipmentID);
        }
        [Test, Order(2)]
        public void ReceivePurchaseOrdert2()
        {
            string receivesupplier = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Board", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Board", "RECEIVEPO");
            string units = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Board", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Board", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("SPECIFICATION", "Receive_PO", "Receive_Board", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceiveBoardPO(receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);
        }


        [OneTimeTearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Receive Purchase order ", "Create order with make and ship");
            extent.GenerateReport();
            BrowserLaunch.CloseBrowser();

        }

        //    [OneTimeTearDown]
        //  public void FlushReport()
        //  {

        //  }


    }
}

