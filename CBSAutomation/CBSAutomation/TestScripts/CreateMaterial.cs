
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
   
    class CreateMaterial
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();


        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "Create material for INK,Glue,Coating";
            extent.SetupReporting(reportname);
        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test,Order(1)]
        public void CreateInkColourMaterial()
        {


            string materialid = CommonFunctions.RandomString(2)+ "Auto*MaterialID&INK_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID", materialid);
            // string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            string materialdescp = "Auto*MaterialID&INKDescription_" + CommonFunctions.RandomString(2);
            string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALTYPE");
            string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(materialid, materialdescp, Materialtype, Currentcost);
          


        }

        [Test, Order(2)]
        public void CreateCoatingColourMaterial()
        {


            Thread.Sleep(3000);
            string materialid = CommonFunctions.RandomString(2) +"Auto*MaterialID&Coating_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALID", materialid);
            //   string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALID");
        //    string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALDESCP");
            string materialdescp = "Auto*MaterialID&CoatingDescription_" + CommonFunctions.RandomString(2);
            string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALTYPE");
            string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(materialid, materialdescp, Materialtype, Currentcost);
           


        }

        [Test, Order(3)]
        public void CreateGlueColourMaterial()
        {


            Thread.Sleep(3000);
            string materialid = CommonFunctions.RandomString(2) +"Auto*MaterialID&Glue_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID", materialid);
            //  string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID");
          //  string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALDESCP");
            string materialdescp = "Auto * MaterialID & GluegDescription_" + CommonFunctions.RandomString(2);
            string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALTYPE");
            string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(materialid, materialdescp, Materialtype, Currentcost);

      


        }






        [TearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Create material for INK,Glue,Coating  ", "with price fixed cost");
            BrowserLaunch.CloseBrowser();
           
        }
        
        [OneTimeTearDown]
        public void FlushReport()
        {
            extent.GenerateReport();
        }


    }
}
