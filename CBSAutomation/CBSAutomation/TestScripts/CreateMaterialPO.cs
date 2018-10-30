using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Threading;

namespace CBSAutomation.TestScripts
{
    class CreateMaterialPO { 
     private ExcelFile excelFile = BrowserLaunch.getExcelFile();
    private extendtreports extent = new extendtreports();
        public  string materialid;
    [OneTimeSetUp]
    public void reportGeneration()
    {
        string reportname = "Create Material Purchase Order";
        extent.SetupReporting(reportname);
    }



    [OneTimeSetUp]
    public void BrowserLogin()
    {
        BrowserLaunch.StartBrowser();


    }

   // [Test, Order(1)]
  //  public void CreateInkColourMaterial()
  //  {


     //    materialid = "#Auto*MaterialID&INK_" + CommonFunctions.RandomString(2);
        // string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
     //   string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALDESCP");
      //  string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALTYPE");
      //  string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "CURRENTCOST");

     //   CreateMaterialPage.CreateNewMaterial(materialid, materialdescp, Materialtype, Currentcost);



  //  }


        [Test, Order(1)]
        public void CreateMaterialPOTest()
        {


            string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            string MatSupplier = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATSUPPLIER");
            string MatWarehouse = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATWAREHOUSE");
            string Mattransport = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATTRANSPORT");

            PurchaseMaterialPage.CreateNewMaterialPO( MatSupplier,  MatWarehouse,  Mattransport, materialid);



        }


        [Test, Order(2)]
        public void ProcessMaterialAndApproveTest4()
        {

            Thread.Sleep(2000);
            string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            POProcessingPage.ProcessMaterialPO(materialid);


        }

        [Test, Order(3)]
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

            RecevingPOPage.ReceivePO(receivesupplier, receivePo, units, unitqty, lastunitqty, receivevendorID, receiveshipmentID);

        }





        [TearDown]
    public void BrowserLogout()
    {
        extent.CreateTest("Create Purchase order for material", "for Oreder specific and purchase good type material create PO ,process PO and receive PO");
        BrowserLaunch.CloseBrowser();

    }

    [OneTimeTearDown]
    public void FlushReport()
    {
        extent.GenerateReport();
    }


}
}
