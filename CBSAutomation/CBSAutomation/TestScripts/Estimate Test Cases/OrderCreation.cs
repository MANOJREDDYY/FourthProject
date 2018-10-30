
using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CBSAutomation.TestScripts.Estimate_Test_Cases
{
    class OrderCreation:Driver
    {

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;
        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "OrderReport";
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

            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "SHIPTOADD");
            string POnumber = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUST_PO");
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUSTOMER_NAME");
            CreateNewOrder.CreateNewOrderEntry(this.driver, test,CustomerName, POnumber, ShipToAdd);

           
            string Qty = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "QTY");
            string OrdDueDate = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDER_DUEDATE");
           
            string OrderSpecID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERSPEC");
            CreateNewOrder.eneterNewOrderEntry(this.driver, test,Qty, OrdDueDate,OrderSpecID);
            CreateNewOrder.SaveOrder(this.driver, test);
        }






        
       [OneTimeTearDown]
            public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create Order for make and ship Create order with make and ship");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }


    }
}
