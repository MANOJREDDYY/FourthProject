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
    [Order(3)]
 
    public class ToolCreation:Driver
    {
        public String Toolid;

        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;

        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Tool Creation ,approve and receive ";
            extendtreports.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


        }
        [Test]
        public void CreateToolAndApproveTest1()
        {
            test = extendtreports.CreateTestwrap("Create tool ");
            Thread.Sleep(3000);
            Toolid = "AutoToolID_" + CommonFunctions.RandomString(2);
          excelFile.UpdateCellValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID", Toolid);
          //  excelFile = BrowserLaunch.getExcelFile();
            string tooltype = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLTYPE");
            string toollicplate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLLICPLATE");
            string homeloc = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_HOMELOC");
            string currentloc = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_CURRLOC");
            string ImpresCount = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_IMPRESCOUNT");
            string ImpresCountExp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_IMPRESCOUNTEXP");
            CreateTools.CreateToolAndApprove(this.driver, test, Toolid, tooltype, toollicplate, homeloc, currentloc, ImpresCount, ImpresCountExp);
           }

        [Test]
       public void CreateToolAndApproveTest2()
        {
            test = extendtreports.CreateTestwrap("Approve tool ");
            string Toolsupply = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLSUPP");
            // string CreatedDate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_CREATEDATE");
           
            DateTime startDatenow = DateTime.Today;
            string CreatedDate = startDatenow.ToString("MM/dd/yyyy");
          

            DateTime startDate = DateTime.Today.AddDays(8);
            string DueDate = startDate.ToString("MM/dd/yyyy");
         //   string DueDate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_DUEDATE");
            string Toolcost = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLCOST");

            string ToolAvailDate = startDatenow.ToString("MM/dd/yyyy");
          //  string ToolAvailDate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLAVAILDATE");
            string PurchaseGL = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_PURCHASEGL");
            string SuppDescription = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SUPPDESCP");
            CreateTools.CreateToolAndApprove2(this.driver, test, Toolsupply, CreatedDate, DueDate, Toolcost, ToolAvailDate, PurchaseGL, SuppDescription);

      }
      [Test]
       public void CreateToolAndApproveTest3()
       {
            test = extendtreports.CreateTestwrap("Create tool ");
            string Pricingtype = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_PRICINGTYPE");
            string ToolCust = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLCUST");
            string Salesprice = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALESPRICE");
            string SalesGL = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALEGL");

            string SalesRep = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALEREP");
           // string SalesRep = "ToolPO_" + CommonFunctions.RandomString(2);
            string CustInvoiceDesp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_CUSTINVDESCP");
            string Invoicegeneration = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_INVTYPE");
            CreateTools.CreateToolAndApprove3(this.driver, test, Pricingtype,  ToolCust,  Salesprice,  SalesGL, SalesRep, CustInvoiceDesp,Invoicegeneration);
        }

        [Test]
        public void CreateToolAndApproveTest4()
        {
            test = extendtreports.CreateTestwrap("Approve tool ");
            //  String Toolidapp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            //String  CustomerPOnum="ToolPO_" + CommonFunctions.RandomString(2);
            CreateTools.CreateToolAndApprove4(this.driver, test, Toolid);
       }



        [Test]
        public void CreateToolAndApproveTest5()
        {
            test = extendtreports.CreateTestwrap("Process PO tool ");
            Thread.Sleep(3000);
         //   String Toolidrec = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");

            POProcessingPage.ProcessToolPO(this.driver,Toolid);
        
            
    }

       [Test]
        public void CreateToolAndApproveTest6()
        {
            test = extendtreports.CreateTestwrap("receive tool ");

            Thread.Sleep(2000);
            //String Toolidrec1 = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            String CustomerPOnum = "ToolPO_" + CommonFunctions.RandomString(2);
            String ReceiptNum = "ReceiptToolNum_" + CommonFunctions.RandomString(2);
            String ReceiptDate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_RECEIPTDATE");
            CreateTools.ValidateToolApproveAndReceive(this.driver, test, Toolid, CustomerPOnum, ReceiptNum,ReceiptDate);


        }

        
       [OneTimeTearDown]
            public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("create a die cut tool create dicee ut tool, order, approve and recive");
                extendtreports.GenerateReport();
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }




    }
}