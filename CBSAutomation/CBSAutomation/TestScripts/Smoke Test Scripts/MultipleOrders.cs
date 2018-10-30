using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Threading;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{
    [TestFixture, SingleThreaded]
    [Order(7)]
   
    public   class MultipleOrders:Driver
   
        {

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
            public void reportGeneration()
            {
                string reportname = "Multiple Orderline Orders Creation";
            extendtreports.SetupReporting(reportname);
        }


        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }
        [Test]
        public void CreateOneOrderLineTest()
            {
            test = extendtreports.CreateTestwrap("Create multiple order for same customerwith different  specification");
            string POnumber = CommonFunctions.RandomString(4);

           // string POnumber = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUST_PO");
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUSTOMER_NAME");
            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "SHIPTOADD");
            CreateNewOrder.CreateNewOrderEntry(this.driver, test, CustomerName, POnumber, ShipToAdd);

             
                string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
        
            DateTime startDate = DateTime.Today.AddDays(8);
          string OrdDuetDate = startDate.ToString("MM/dd/yyyy");
           
            string OrderSpecID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID");
            CreateNewOrder.eneterNewOrderEntry(this.driver, test, Qty, OrdDuetDate, OrderSpecID);
  
  
                string Qtyline1 = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "QTY");
                string OrdDueDateline1 = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order_2", "ORDER_DUEDATE");
           
                string OrderSpecIDline1 = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID");
                CreateNewOrder.eneterAnotherSalesLine(this.driver, test, Qtyline1, OrdDueDateline1, OrderSpecIDline1);

            CreateNewOrder.SaveOrder(this.driver, test);

            }





         
            [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus(" Multiple Orderline Orders Creation Create RSC Order with ink material and Create order with D/C joined and die cut tool ");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }

    }
    }

