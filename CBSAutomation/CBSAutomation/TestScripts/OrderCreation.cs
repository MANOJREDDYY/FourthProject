
using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace CBSAutomation.TestScripts
{
    class OrderCreation
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private  extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "OrderReport";
            extent.SetupReporting(reportname);
        }


        [SetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }
        [Test]
        public void CreateOneOrderLineTest()
        {

            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "SHIPTOADD");
            string POnumber = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUST_PO");
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUSTOMER_NAME");
            CreateNewOrder.CreateNewOrderEntry(CustomerName, POnumber, ShipToAdd);

           
            string Qty = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "QTY");
            string OrdDueDate = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDER_DUEDATE");
           
            string OrderSpecID = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERSPEC");
            CreateNewOrder.eneterNewOrderEntry(Qty, OrdDueDate,OrderSpecID);
            CreateNewOrder.SaveOrder();
        }
    
    



      

        [TearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Create Order for make and ship ", "Create order with make and ship");
            BrowserLaunch.CloseBrowser();
           
        }
        
        [OneTimeTearDown]
        public void FlushReport()
        {
            extent.GenerateReport();
        }


    }
}
