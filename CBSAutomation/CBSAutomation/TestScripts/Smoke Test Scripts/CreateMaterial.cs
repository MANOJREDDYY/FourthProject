
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
    [Order(2)]
   
    public  class CreateMaterial : Driver
    {
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;

        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "Create material for INK,Glue,Coating";
            extendtreports.SetupReporting(reportname);
        }


        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateAInkColourMaterialTest1()
        {
            test = extendtreports.CreateTestwrap("Create Ink Colour Material");
            Thread.Sleep(3000);
            string materialid = CommonFunctions.RandomString(2) + "Auto*MaterialID&INK_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID", materialid);
            // string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            string materialdescp = "Auto*MaterialID&INKDescription_" + CommonFunctions.RandomString(2);
            string Materialtype = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALTYPE");
            string Currentcost = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(this.driver,test,materialid, materialdescp, Materialtype, Currentcost);
        }
          
            

  

       [Test]
        public void CreateBCoatingColourMaterialTest2()
       {

            test = extendtreports.CreateTestwrap("Create Coating Material");
            Thread.Sleep(3000);
            string materialid1 = CommonFunctions.RandomString(2) +"Auto*MaterialID&Coating_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALID", materialid1);
            //   string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALID");
        //    string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALDESCP");
            string materialdescp1 = "Auto*MaterialID&CoatingDescription_" + CommonFunctions.RandomString(2);
            string Materialtype1 = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "MATERIALTYPE");
            string Currentcost1 = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Coating _Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(this.driver, test, materialid1, materialdescp1, Materialtype1, Currentcost1);
           


        }

        [Test]
        public void CreateCGlueColourMaterialTest3()
        {

            test = extendtreports.CreateTestwrap("Create Glue Material");
            Thread.Sleep(3000);
            string materialid2 = CommonFunctions.RandomString(2) +"Auto*MaterialID&Glue_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID", materialid2);
            //  string materialid = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALID");
          //  string materialdescp = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALDESCP");
            string materialdescp2 = "Auto * MaterialID & GluegDescription_" + CommonFunctions.RandomString(2);
            string Materialtype2 = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "MATERIALTYPE");
            string Currentcost2 = excelFile.GetTestInputValue("Material", "Create_Material", "Create_Glue_Material", "CURRENTCOST");

            CreateMaterialPage.CreateNewMaterial(this.driver, test,materialid2, materialdescp2, Materialtype2, Currentcost2);

      


        }
        





       

       [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create material for INK, Glue, Coating with price fixed cost");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }



    }
}
