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
   [Order(7)]
    class MarktoAnyShiptoInvtMfgTest:Driver
    {
        public string Spec_ID;
        public string Spec_CustName;
        public string shiptoadd;
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Mark to any ship to for Inventory Mfg";
            extendtreports.SetupReporting(reportname);

        }

        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
        public void MarktoAnyShiptoInvtMfgTest1()
        {
            test = extendtreports.CreateTestwrap("Create Product Specfications choosing Product style,Enter unique 'SpecID");
            Thread.Sleep(3000);
            string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
            string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
            string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPRODSTYLE");
            string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
             Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);

            excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
            SpecificationPage.CreateProductSpecification(this.driver,test, Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

        }
        [Test]
        public void MarktoAnyShiptoInvtMfgTest2()
        {
            test = extendtreports.CreateTestwrap("Create Business Estimate for the product spec with inventory wearehouse ");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
            string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
            string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");
            // string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");
            //  string mdsd = "AutoSpecID_" + CommonFunctions.RandomString(2);
            string SpecMaterial = excelFile.GetTestInputValue("Material", "Create_Material", "Create_InkColour_Material", "MATERIALID");
            string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
            string PrintToolID = "12941";
            string DiecutToolid = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");

            Thread.Sleep(3000);
            string CostModel = "default";
            // string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
            SpecificationPage.CreateProductSpecificationNext(this.driver, test, Spec_Length, Spec_Width, Spec_Depth, SpecMaterial, PrintToolID);
            SpecificationPage.CreateProductBusinessSpecificationNext(this.driver, test);

         shiptoadd= SpecificationPage.CreateBussSpecWithoutApproveEst3(this.driver, test, CostModel, Qty, Unitization);
           
        }
        [Test]
        public void MarktoAnyShiptoInvtMfgTest3()
        {
            test = extendtreports.CreateTestwrap("Create Business Estimate for the product spec and mark the estimate for AnyShipto and validate  at the Order ");
            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_MultipleShipto", "SHIPTOADD");
            Assert.IsFalse(ShipToAdd.Equals(shiptoadd));
            string POnumber = CommonFunctions.RandomString(4);
            // string POnumber = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_MultipleShipto", "CUST_PO");
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_MultipleShipto", "CUSTOMER_NAME");
            CreateNewOrder.CreateNewOrderEntry(this.driver, test, CustomerName, POnumber, ShipToAdd);


            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string OrdDueDate = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_MultipleShipto", "ORDER_DUEDATE");

      string OrderSpecID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID");
            CreateNewOrder.eneterNewOrderEntry(this.driver, test, Qty, OrdDueDate, OrderSpecID);
            CreateNewOrder.SaveOrder(this.driver, test);
        }


       
         [OneTimeTearDown]
            public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus(" Create spec  for RSC style spec and  for product and validate for mark for any ship to for any inventory order ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }



    }
}
      