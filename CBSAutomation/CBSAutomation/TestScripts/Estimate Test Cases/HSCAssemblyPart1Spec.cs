
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
 
   [Order(11)]
    class HSCAssemblyPart1Spec:Driver
    {

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "HSC product Spec as part1 for Assembled set Report";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }
        [Test]
        public void CreateHSCspecTest1()
        {
            test = extendtreports.CreateTestwrap("Create HSC  Product Specfications with a  unique 'SpecID");
            Thread.Sleep(3000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_HSC_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            
            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);
          
            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification( this.driver,test, Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test]
        public void CreateHSCspecTest2()
        {
            test = extendtreports.CreateTestwrap("Create business Specfications for the product");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            string PartialDieToolID = "ZSL3-064";
            string SpecMaterial = "Apply Tooling";

            SpecificationPage.CreateHSCProduct(this.driver, test,Spec_Length,  Spec_Width,  Spec_Depth,SpecMaterial,  PartialDieToolID);
            SpecificationPage.CreateProductBusinessSpecificationNext(this.driver, test);

        }
       

        [Test]
        public void CreateHSCspecTest3()

        {
            test = extendtreports.CreateTestwrap("save the Business specification with a estiate  ");
            Thread.Sleep(3000);
            string CostModel = "default";
          // string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            SpecificationPage.CreateBusinessSpecificationReset(this.driver, test,CostModel, Qty, Unitization);
            SpecificationPage.SaveBusinessSpecification(this.driver, test);
            
        }


        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create Order for RSC style spec create a spec for product with external material and RSC product style");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }


    }
}
