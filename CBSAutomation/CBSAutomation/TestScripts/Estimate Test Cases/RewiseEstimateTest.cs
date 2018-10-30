  
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
 
    [Order(9)]
    class RewiseEstimateTest:Driver
        {
        public string validateestimatecost;
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
            public void reportGeneration()
            {

                string reportname = "Create a rewised Estimate ";
            extendtreports.SetupReporting(reportname);

        }




        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }

        [Test]
            public void RewiseEstimateTest1()
            {
            test = extendtreports.CreateTestwrap("Create a product spec for RSC product style ");
            Thread.Sleep(3000);
                string Spec_MaterialGrade = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECMATERIALGRADE");
                string Spec_CustName = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECCUSTNAME");
                string Spec_prodStyle = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPRODSTYLE");
                string Spec_GLcode = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECGLCODE");

                string Spec_Supplier = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECSUPPLIER");
                string Spec_ID = "RSCAutoSpecID_" + CommonFunctions.RandomString(2);

                excelFile.UpdateCellValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID", Spec_ID);
                SpecificationPage.CreateProductSpecification(this.driver, test, Spec_CustName, Spec_ID, Spec_prodStyle, Spec_GLcode, Spec_MaterialGrade, Spec_Supplier);

            }
            [Test]
            public void RewiseEstimateTest2()
            {
            test = extendtreports.CreateTestwrap("Create Business Estimate for the product spec ");
            string Spec_Length = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECLENGTH");
                string Spec_Width = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECWIDTH");
                string Spec_Depth = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECPDEPTH");

                SpecificationPage.CreateProductSpecificationsimple(this.driver, test, Spec_Length, Spec_Width, Spec_Depth);
                SpecificationPage.CreateProductBusinessSpecificationNext(this.driver, test);

            }


            [Test]
            public void RewiseEstimateTest3()

            {
            test = extendtreports.CreateTestwrap("Save the estimate created for the product ");
            string CostModel = "default";
                // string CostModel = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "COSTMODEL");
                string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
                string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
                SpecificationPage.CreateBusinessSpecificationReset(this.driver, test, CostModel, Qty, Unitization);
             SpecificationPage.SaveBusinessSpecification(this.driver, test);
            }

        [Test]
        public void RewiseEstimateTest4()
        {
            test = extendtreports.CreateTestwrap("create an open order for the estimate created ");
            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "SHIPTOADD");
           
            string POnumber = CommonFunctions.RandomString(4);
          excelFile.UpdateCellValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUST_PO", POnumber);
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUSTOMER_NAME");
            CreateNewOrder.CreateNewOrderEntry(this.driver, test, CustomerName, POnumber, ShipToAdd);


            string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string OrdDueDate = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDER_DUEDATE");

            string OrderSpecID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID");
            CreateNewOrder.eneterNewOrderEntry(this.driver, test, Qty, OrdDueDate, OrderSpecID);
            CreateNewOrder.SaveOrder(this.driver, test);
        }

        [Test]
        public void RewiseEstimateTest5()

        {
            test = extendtreports.CreateTestwrap("Create Business Estimate for the same  product spec andwith same pricing strategy but for different Quantity");
            string filterSpecID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID");
            SpecificationPage.RewiseEstimateForExsistingEstimate(this.driver, test, filterSpecID);

      }


      [Test]
     public void RewiseEstimateTest6()

     {
            test = extendtreports.CreateTestwrap("Save and approve the estimate and validate the alert box for open exisiting orders ");
            string CostModel = "default";
           
            //  string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
            string Qty = "2000";
             string Unitization = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "UNITIZATION");
           SpecificationPage.CreateBusinessSpecificationReset(this.driver, test, CostModel, Qty, Unitization);
            string validateestimatecost = SpecificationPage.SaveBusinessSpecificationAlertValidation(this.driver, test);
        }

        [Test]
        public void RewiseEstimateTest7()
        {
            test = extendtreports.CreateTestwrap("Create order for the revised estimate ");
            string  filterorderid=excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID");
            CreateNewOrder.FilterOrder(this.driver, test, filterorderid, validateestimatecost);
        }


        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Rewise estimate specification ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }



    }
}

