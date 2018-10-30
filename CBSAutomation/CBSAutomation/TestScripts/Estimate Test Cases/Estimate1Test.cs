
        
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

namespace CBSAutomation.TestScripts.Estimate_Test_Cases
{
    [TestFixture]
   [Order(1)]
    public  class Estimate1Test:Driver
    {
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Estimate validation covering Range PricingBuy board,Tools,Job level materials,Split cost Utilization";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateEstimate1ProductSpecTest1()
        {
            test = extendtreports.CreateTestwrap("Create Product Specfications choosing Product style = Diecut,Enter unique 'SpecID");

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
        public void CreateEstimate1ProductSpecTest2()
        {
            test = extendtreports.CreateTestwrap("Create Product Specfications choosing die cut tool and add strapping operation");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            // string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string PrintToolID = "12941";
            string strappingmat = "Strapping";
            string MaterialName= "Strapping" + CommonFunctions.RandomString(2);
            string MaterialCost = "2000";
            string DiecutToolID = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            SpecificationPage.CreateProductSpecificationForDiecut(this.driver,test,Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID, DiecutToolID);
            SpecificationPage.CreateProductSpecificationAndAddBundleStrapping(this.driver,test,strappingmat, MaterialCost, MaterialName);
            //  SpecificationPage.CreateProductBusinessSpecificationNext();

        }


        [Test]
        public void CreateEstimate1ProductSpecTest3()

        {
            test = extendtreports.CreateTestwrap("create range pricing type for range 1000-2499,2500-5000 cost estimate and validate ");
            string CostModel = "default";
            //  string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            string PricingMtericValue = "25";
            SpecificationPage.CreateBusinessSpecificationwithPricingType(this.driver,test,CostModel, Qty, Unitization);

        }



        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create diecut specification ");
                extendtreports.GenerateReport();
                test.Log(Status.Info, "Report generated");
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }






    }
}

