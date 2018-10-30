        
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
using OpenQA.Selenium.Remote;

namespace CBSAutomation.TestScripts.Estimate_Test_Cases
{
    [TestFixture]
    [Order(4)]
    class Manufacturable:Driver
    {
        public string MaterialID;
        public string PrintToolID;
        ExtentTest test;

        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        public string Spec_CustName;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Set as manufacturable ";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }
        [Test]
        public void ManufacturableSpecEstimateTest1()
        {
            test = extendtreports.CreateTestwrap("Validate the material status of the tool to be incuded in  the product");
            PrintToolID = "12941";
            CreateTools.ValidateToolStatus(this.driver, test,PrintToolID);

        }

        [Test]
        public void ManufacturableSpecEstimateTest2()
        {

            test = extendtreports.CreateTestwrap("Validate the material status of the material to be incuded in  the product");
            MaterialID = "234 : Strapping";
            CreateMaterialPage.ValidateMaterialStatus(this.driver, test,MaterialID);

        }

        [Test]
        public void ManufacturableSpecEstimateTest3()
        {


            test = extendtreports.CreateTestwrap("create a product for a new product incuding the the material and tool");
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "DieCutAutoSpecID_" + CommonFunctions.RandomString(2);


            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(this.driver,test,Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
    
        [Test]
        public void ManufacturableSpecEstimateTest4()
        {

            test = extendtreports.CreateTestwrap("create a estimate for the product specification");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            // string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
             PrintToolID = "12941";
            string strappingmat = "234 : Strapping";
            string MaterialName = "";
            string MaterialCost = "2000";
            string DiecutToolID = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            SpecificationPage.CreateProductSpecificationForDiecut(this.driver,test, Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID, DiecutToolID);
            SpecificationPage.CreateProductSpecificationAndAddBundleStrapping(this.driver, test, strappingmat, MaterialCost, MaterialName);
           

        }
       
         
       
        [Test]
        public void ManufacturableSpecEstimateTest5()

        {
            // string Spec_CustName = "Kaweah Inventory Resale";

            test = extendtreports.CreateTestwrap("Save the estimate and validate for set a manufacturable for the product created");
            string CostModel = "default";
         
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            SpecificationPage.CreateBusinessSpecificationReset(this.driver, test, CostModel, Qty, Unitization);
            SpecificationPage.SaveBusinessSpecification(this.driver, test);
        }



       
         [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create estimate with starpping material and print tool and validate the set as manufacturable status  ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }




    }
}


