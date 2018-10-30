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
    class CreateDieCutSpecs
    {



    

            private ExcelFile excelFile = BrowserLaunch.getExcelFile();
            private extendtreports extent = new extendtreports();
            [OneTimeSetUp]
            public void reportGeneration()
            {

                string reportname = "Create Die Cut Specification ";
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

            Thread.Sleep(5000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
                string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
                string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECPRODSTYLE");
                string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

                string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECSUPPLIER");
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
             string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "D/C Joined", "SPECSUPPLIER");
            string PrintToolID = "12941";
                string DiecutToolID = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
                SpecificationPage.CreateProductSpecificationForDiecut(Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID, DiecutToolID);
            SpecificationPage.CreateProductBusinessSpecificationNext();

            }


            [Test, Order(3)]
            public void CreateBusinessSpecTest()

            {
            string CostModel = "default";
          //  string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
                string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
                string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
                SpecificationPage.CreateBusinessSpecification(CostModel, Qty, Unitization);
            }



            [OneTimeTearDown]
            public void BrowserLogout()
            {
                extent.CreateTest("Create diecut specification ", "create a spec for D/C joined product with diecut tool");
                extent.GenerateReport();
               BrowserLaunch.CloseBrowser();

            }

            //    [OneTimeTearDown]
            //  public void FlushReport()
            //  {

            //  }


        }
    }


