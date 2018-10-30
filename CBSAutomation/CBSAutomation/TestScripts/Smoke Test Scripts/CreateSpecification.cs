
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
using log4net;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{
    [TestFixture, SingleThreaded]
    [Order(5)]
    
    public  class CreateSpecification:Driver
    {
        ExtentTest test;
        private new IWebDriver driver;
      private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]



        public void reportGeneration()
        {
            

        string reportname = "RSC product Spec Report";
            extendtreports.SetupReporting(reportname);

        }


        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateProductRSCSpecTest1()
        {
            test = extendtreports.CreateTestwrap("create a product for RSC product style ");

            Thread.Sleep(3000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            
            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);
            
            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(this.driver,test, Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);
           
        }
        [Test]
        public void CreateProductRSCSpecTest2()
        {
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
           //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            // string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
          //  string PrintToolID = "1234567890";
            string PrintToolID = "100118";
            string DiecutToolid = excelFile.GetTestInputValue("TOOLS","Create_tool", "Create_ToolandReceive", "T_TOOLID") ;
            SpecificationPage.CreateProductSpecificationNext(this.driver, test, Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID);
            SpecificationPage.CreateProductBusinessSpecificationNext(this.driver, test);

        }
       

        [Test]
        public void CreateProductRSCSpecTest3()

        {
            test = extendtreports.CreateTestwrap("create a business spec for RSC product");
            Thread.Sleep(3000);
            string CostModel = "default";
          // string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            SpecificationPage.CreateBusinessSpecificationReset(this.driver, test,CostModel, Qty, Unitization);
            SpecificationPage.SaveBusinessSpecification(this.driver, test);
        }



       
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create Order for RSC style spec create a spec for product with external material and RSC product style ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }




    }
}
