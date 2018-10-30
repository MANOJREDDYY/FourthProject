
        
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

    class Estimate1Test
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Estimate validation covering Range Pricing,Compare Prices,Buy board,Tools,Job level materials,Split cost Utilization";
            extent.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void CreateProductSpecTest1()
        {


            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "DieCutAutoSpecID_" + CommonFunctions.RandomString(2);


            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test, Order(2)]
        public void CreateProductSpecTest2()
        {
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            // string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string PrintToolID = "12941";
            string strappingmat = "Strapping";
            string MaterialCost = "2000";
            string DiecutToolID = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            SpecificationPage.CreateProductSpecificationForDiecut(Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID, DiecutToolID);
            SpecificationPage.CreateProductSpecificationAndAddBundleStrapping(strappingmat, MaterialCost);
            //  SpecificationPage.CreateProductBusinessSpecificationNext();

        }


        [Test, Order(3)]
        public void CreateBusinessSpecTest()

        {
            string CostModel = "default";
            //  string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            string PricingMtericValue = "25";
            SpecificationPage.CreateBusinessSpecificationwithPricingType(CostModel, Qty, Unitization, PricingMtericValue);
        }
    



        [OneTimeTearDown]
            public void BrowserLogout()
            {
                extent.CreateTest("Create Order for make and ship ", "Create order with make and ship");
                extent.GenerateReport();
                BrowserLaunch.CloseBrowser();

            }

            //    [OneTimeTearDown]
            //  public void FlushReport()
            //  {

            //  }


        }
    }

