        
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

    class Estimate2Test
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Estimate validation covering  Prices,Buy board,Tools,ink clour";
            extent.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void CreateProductSpecEstimate21()
        {
            Thread.Sleep(5000);

            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);
          
            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test, Order(2)]
        public void CreateProductSpecEstimate22()
        {
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            //string SpecMaterialType = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            string SpecMaterialType = "InkColor";



            string MaterialCost = "2000";
          
            SpecificationPage.CreateProductSpecificationForRSCestimate2( Spec_Length,  Spec_Width,  Spec_Depth,  SpecMaterialType, MaterialCost);
          //  SpecificationPage.CreateProductSpecificationAndAddInk(MaterialCost);
            //  SpecificationPage.CreateProductBusinessSpecificationNext();

        }


        [Test, Order(3)]
        public void CreateProductSpecEstimate23()

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
            extent.CreateTest("Create estimate for ink and tool  ", "creating Tool and Inks on the fly while estimating( do not create these material before estimating.)");
            extent.GenerateReport();
            BrowserLaunch.CloseBrowser();

        }

        //    [OneTimeTearDown]
        //  public void FlushReport()
        //  {

        //  }


    }
}


