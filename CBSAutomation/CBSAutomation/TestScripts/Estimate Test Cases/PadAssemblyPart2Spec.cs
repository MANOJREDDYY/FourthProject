
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
 
    [Order(12)]
    class PadAssemblyPart2Spec:Driver
    {

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Pad Product style spec as part2 for assembld parent product ";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreatePadproductEstimateTest1()
        {
            test = extendtreports.CreateTestwrap("Create Pad  Product Specfications with a  unique 'SpecID");
            Thread.Sleep(3000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Pad_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            
            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);
           
            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(this.driver,test,Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test]
        public void CreatePadproductEstimateTest2()
        {
            test = extendtreports.CreateTestwrap("Create business Specfications for the product");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
      
            SpecificationPage.CreateProductSpecificationsimple(this.driver, test, Spec_Length,  Spec_Width,  Spec_Depth);
            SpecificationPage.CreateProductBusinessSpecificationNext(this.driver, test);

        }
       

        [Test]
        public void CreatePadproductEstimateTest3()

        {
            test = extendtreports.CreateTestwrap("save the Business specification with a estimate  ");
            Thread.Sleep(3000);
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


                extendtreports.LogTestStatus("Create Pad product style specification ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }

    }
}
