using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Threading;

namespace CBSAutomation.TestScripts
{
    class ToolCreation
    {
        public String Toolid;
       
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {

            string reportname = "Tool Creation ,approve and receive ";
            extent.SetupReporting(reportname);

        }



        [OneTimeSetUp]
        public void BrowserLogin()
        {
            BrowserLaunch.StartBrowser();


        }

        [Test, Order(1)]
        public void CreateToolAndApproveTest1()
        {
             Toolid = "AutoToolID_" + CommonFunctions.RandomString(2);
            excelFile.UpdateCellValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID", Toolid);
            string tooltype = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLTYPE");
            string toollicplate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLLICPLATE");
            string homeloc = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_HOMELOC");
            string currentloc = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_CURRLOC");
            string ImpresCount = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_IMPRESCOUNT");
            string ImpresCountExp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_IMPRESCOUNTEXP");
            CreateTools.CreateToolAndApprove(Toolid, tooltype, toollicplate, homeloc, currentloc, ImpresCount, ImpresCountExp);
            }

        [Test, Order(2)]
        public void CreateToolAndApproveTest2()
        {

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
            CreateTools.CreateToolAndApprove2(Toolsupply, CreatedDate, DueDate, Toolcost, ToolAvailDate, PurchaseGL, SuppDescription);

        }
        [Test, Order(3)]
        public void CreateToolAndApproveTest3()
        {

            string Pricingtype = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_PRICINGTYPE");
            string ToolCust = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLCUST");
            string Salesprice = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALESPRICE");
            string SalesGL = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALEGL");

            string SalesRep = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_SALEREP");
           // string SalesRep = "ToolPO_" + CommonFunctions.RandomString(2);
            string CustInvoiceDesp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_CUSTINVDESCP");
            string Invoicegeneration = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_INVTYPE");
            CreateTools.CreateToolAndApprove3( Pricingtype,  ToolCust,  Salesprice,  SalesGL, SalesRep, CustInvoiceDesp,Invoicegeneration);
        }

        [Test, Order(4)]
        public void CreateToolAndApproveTest4()
        {
            String Toolidapp = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
           //String  CustomerPOnum="ToolPO_" + CommonFunctions.RandomString(2);
            CreateTools.CreateToolAndApprove4(Toolidapp);
        }



        [Test, Order(5)]
        public void ProcessToollAndApproveTest4()
        {
          
            Thread.Sleep(3000);
            String Toolidrec = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");

            POProcessingPage.ProcessToolPO(Toolidrec);
        
            
    }

        [Test, Order(6)]
        public void ProcessToollAndReceiveTest5()
        {

            Thread.Sleep(2000);
            String Toolidrec1 = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLID");
            String CustomerPOnum = "ToolPO_" + CommonFunctions.RandomString(2);
            String ReceiptNum = "ReceiptToolNum_" + CommonFunctions.RandomString(2);
            String ReceiptDate = excelFile.GetTestInputValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_RECEIPTDATE");
            CreateTools.ValidateToolApproveAndReceive(Toolidrec1, CustomerPOnum, ReceiptNum,ReceiptDate);


        }


        [OneTimeTearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("create a die cut tool ", "create dicee ut tool ,order ,approve and recive");
            extent.GenerateReport();
            BrowserLaunch.CloseBrowser();

        }

        //    [OneTimeTearDown]
        //  public void FlushReport()
        //  {

        //  }


    }
}



