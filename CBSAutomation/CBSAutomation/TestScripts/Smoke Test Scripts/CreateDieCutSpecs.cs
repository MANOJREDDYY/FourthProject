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
using log4net.Config;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{

    
    [TestFixture,SingleThreaded]
  
    [Order(4)]
    public class CreateDieCutSpecs:Driver
    {
     ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {
            
            string reportname = "Create Die Cut Specification ";
           extendtreports.SetupReporting(reportname);
             }

        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
            public void CreateProductSpecDieCutTest1()
            {
           test = extendtreports.CreateTestwrap("create a product for D/C joined product with diecut tool");
           
            Thread.Sleep(5000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
                string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
                string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECPRODSTYLE");
                string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

                string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECSUPPLIER");
                string Spec_ID = "DieCutAutoSpecID_" + CommonFunctions.RandomString(2);

           
                excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID", Spec_ID);
                SpecificationPage.CreateProductSpecification(this.driver,test,Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

            }

        [Test]
       public void CreateProductSpecDieCutTest2()
        {
      // test = extendtreports.CreateTestwrap("create a business spec for D/C joined product with diecut tool");
           string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
           string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
          string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
           string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
          string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "D/C Joined", "SPECSUPPLIER");
            string PrintToolID = "12941";
           string DiecutToolID = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            SpecificationPage.CreateProductSpecificationForDiecut(this.driver,test,Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID, DiecutToolID);
            SpecificationPage.CreateProductBusinessSpecificationNext(this.driver,test);

       }


       [Test]
        public void CreateProductSpecDieCutTest3()

        {
            Thread.Sleep(2000);
            string CostModel = "default";
            test = extendtreports.CreateTestwrap("create a business spec for D/C joined product with diecut tool");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
           string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
           SpecificationPage.CreateBusinessSpecificationReset(this.driver,test,CostModel, Qty, Unitization);
        SpecificationPage.SaveBusinessSpecification(this.driver,test);
        }



        [OneTimeTearDown]
            public void BrowserLogout()
            {
            try
            {

               
                extendtreports.LogTestStatus("Create diecut specification ");
                extendtreports.GenerateReport();
                test.Log(Status.Pass, "Report generated");
            }
            finally
            {
                Driver.CloseBrowser();
            }
            }

            


        }
    }


