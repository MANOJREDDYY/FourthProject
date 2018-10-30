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
    class MultipleOrders
   
        {

            private ExcelFile excelFile = BrowserLaunch.getExcelFile();
            private extendtreports extent = new extendtreports();
            [OneTimeSetUp]
            public void reportGeneration()
            {
                string reportname = "Multiple Orderline Orders Creation";
                extent.SetupReporting(reportname);
            }


            [SetUp]
            public void BrowserLogin()
            {
                BrowserLaunch.StartBrowser();


            }
        [Test, Order(1)]
        public void CreateOneOrderLineTest()
            {

            string POnumber = CommonFunctions.RandomString(4);

           // string POnumber = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUST_PO");
            string CustomerName = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "CUSTOMER_NAME");
            string ShipToAdd = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order", "SHIPTOADD");
            CreateNewOrder.CreateNewOrderEntry(CustomerName, POnumber, ShipToAdd);

             
                string Qty = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "QTY");
        
            DateTime startDate = DateTime.Today.AddDays(8);
          string OrdDuetDate = startDate.ToString("MM/dd/yyyy");
           
            string OrderSpecID = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_RSC_makeBoard", "SPECID");
            CreateNewOrder.eneterNewOrderEntry(Qty, OrdDuetDate, OrderSpecID);
  
  
                string Qtyline1 = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "QTY");
                string OrdDueDateline1 = excelFile.GetTestInputValue("ORDERS", "CREATEORDER", "create_makeship_order_2", "ORDER_DUEDATE");
           
                string OrderSpecIDline1 = excelFile.GetTestInputValue("SPECIFICATION", "Create_Specification", "Create_Diecut_makeBoard", "SPECID");
                CreateNewOrder.eneterAnotherSalesLine(Qtyline1, OrdDueDateline1, OrderSpecIDline1);

            CreateNewOrder.SaveOrder();

            }





            [TearDown]
            public void BrowserLogout()
            {
                extent.CreateTest(" Multiple Orderline Orders Creation", "Create RSC Order with ink material and Create order with D/C joined and die cut tool ");
                BrowserLaunch.CloseBrowser();
           
            }

            [OneTimeTearDown]
            public void FlushReport()
            {
                extent.GenerateReport();
            }


        }
    }

