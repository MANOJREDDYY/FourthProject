using CBSAutomation.Pages;
using NUnit.Framework;
using System;
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
   
    [Order(8)]
    public  class CreateMaterialPO :Driver { 
   
   
        public  string materialid;
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
    public void reportGeneration()
    {
        string reportname = "Create Material Purchase Order";
            extendtreports.SetupReporting(reportname);
        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        // [Test, Order(1)]
        //  public void CreateInkColourMaterial()
        //  {


        //    materialid = "#Auto*MaterialID&INK_" + CommonFunctions.RandomString(2);
        // string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
        //   string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALDESCP");
        //  string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALTYPE");
        //  string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "CURRENTCOST");

        //   CreateMaterialPage.CreateNewMaterial(this.driver,materialid, materialdescp, Materialtype, Currentcost);



        //  }


        [Test]
        public void CreateMaterialPOTest()
        {

            test = extendtreports.CreateTestwrap("Create Material PO");
            string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID");
            string MatSupplier = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATSUPPLIER");
            string MatWarehouse = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATWAREHOUSE");
            string Mattransport = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATTRANSPORT");

            PurchaseMaterialPage.CreateNewMaterialPO(this.driver, test, MatSupplier,  MatWarehouse,  Mattransport, materialid);



        }


        [Test]
        public void ProcessMaterialAndApproveTest4()
        {
            test = extendtreports.CreateTestwrap("Process Material PO");
            Thread.Sleep(2000);
            string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID");
            POProcessingPage.ProcessMaterialPO(this.driver,materialid);


        }

      /*  [Test]
        public void ReceivePurchaseOrdert1()
        {
            test = extendtreports.CreateTestwrap("receive Material PO");
            string receivesupplier = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVESUPPLIER");
            string receivePo = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEPO");
            string units = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEUNITS");
            string unitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVEQTY");
            string lastunitqty = excelFile.GetTestInputValue("RECEVING", "Receive_PO", "Receive_Material", "RECEIVELASTQTY");
            string receivevendorID = "AutoReceiveVendorID_" + CommonFunctions.RandomString(2);
            string receiveshipmentID = "AutoReceiveShipmentID_" + CommonFunctions.RandomString(2);

            //  string BoardOrderID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");

            RecevingPOPage.ReceivePO(this.driver, test,receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);

        }*/






        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create Purchase order for material for Oreder specific and purchase good type material create PO ,process PO and receive PO ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }



    }
}
