        
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
    [Order(2)]
    class Estimate2Test:Driver
    {

        ExtentTest test;

        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        public string Spec_CustName;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Estimate qauntity pricing with validation covering  Prices,Buy board,Tools,ink clour";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void CreateProductSpecEstimate21()
        {
            Thread.Sleep(5000);
            test = extendtreports.CreateTestwrap("Create Product Specfications choosing Product style = Diecut,Enter unique 'SpecID");
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
             Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);
          
            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(this.driver,test, Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test]
        public void CreateProductSpecEstimate22()
        {
            test = extendtreports.CreateTestwrap("Create Product Specfications choosing InkColour ");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            //string SpecMaterialType = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            string SpecMaterialType = "InkColor";



            string MaterialCost = "2000";
          
            SpecificationPage.CreateProductSpecificationForRSCestimate2(this.driver,test, Spec_Length,  Spec_Width,  Spec_Depth,  SpecMaterialType, MaterialCost);
        
        }


        [Test]
        public void CreateProductSpecEstimate23()

        {
            // string Spec_CustName = "Kaweah Inventory Resale";

            test = extendtreports.CreateTestwrap("create Quatitiy  pricing type for  1000 and 2000 cost estimate and validate ");
            string CostModel = "default";
         
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            string PricingMtericValue = "25";
            Thread.Sleep(2000);
        Tuple<String,String, String> listofstring = CreateCustomerPage.CreateCustomerShiptoShipMtd(this.driver, test,Spec_CustName);
            string shipmtdvalue= listofstring.ToString();
            string[] words = shipmtdvalue.Split(',');
            string bussDisc = words[0];
            string shipcust = words[1];
            string shipmtd = words[2];
            Thread.Sleep(2000);
            SpecificationPage.CreateBusinessSpecificationEstimate2(this.driver,test,CostModel, Qty, Unitization,PricingMtericValue, bussDisc,shipcust, shipmtd);
        }




        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create diecut specification ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }



    }
}


