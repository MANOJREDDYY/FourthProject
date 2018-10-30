
using CBSAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CBSAutomation.TestScripts
{
    class CreateCustomer
    {

        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private  extendtreports extent = new extendtreports();
        [OneTimeSetUp]
        public void reportGeneration()
        {
            string reportname = "Create Customer ";
            extent.SetupReporting(reportname);
           
        


        }


        [SetUp]
        public void BrowserLogin()
        {
           BrowserLaunch.StartBrowser();


        }
      
        [Test] 
        public void CreateCustomerTest1()
        {



         
            string sCustID = "AutoCustID_" + CommonFunctions.RandomString(2);
            string sCustName = "AutoCustomername_" + CommonFunctions.RandomString(2);
            string sShortname ="AutoShortName_" + CommonFunctions.RandomString(2);
            string sCustType = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "CUSTOMER_TYPE");
            string sBillAdd = "AutoBillToAdd_" + CommonFunctions.RandomString(2);
            string sBillCity = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "BILLTOCITY");
            string sZipCode =  CommonFunctions.RandomInteger(7);
            string sCountry = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "BILLCOUNTRY");
            string sState = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "BILLSTATE");
         //   string sContact = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "CONTACT");
            string sContact = "AutoContactName_" + CommonFunctions.RandomString(2);
            string sContph =  CommonFunctions.RandomInteger(10);
            string sContEmail = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "CONACTEMAIL");
            string sPrimaryRep = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "PRIMARYREP");
            string sQouteRep = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "QOUTEREP");
            //******************************************************************************************************************************
            string sShipAdd = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPTOADD");
            string sShipShortname = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPSHORTNAME");
            string sShipCity = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPCITY");
            string sShipZipCode = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPZIPCODE");
            string sShipCountry = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPCOUNTRY");
            string sShipState = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPSTATE");
            string sShipMtd = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "SHIPMTD");
            string sMaxShip = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "MAXSHIP");
            string sMinShip = excelFile.GetTestInputValue("CUSTOMER", "CREATECUST", "create_active_customer", "MINSHIP");


            CreateCustomerPage.CreateCustomerInput(sCustID,sCustName, sCustType, sShortname,  sBillAdd,  sBillCity,  sZipCode,  sCountry,  sState );
            CreateCustomerPage.CreateCustomerContactinfo(sContact,sContph, sContEmail,sPrimaryRep,sQouteRep);
            CreateCustomerPage.CreateCustomerShipToString(sShipShortname, sShipAdd, sShipCity, sShipZipCode, sShipCountry, sShipState, sShipMtd, sMaxShip, sMinShip);





       }



      

        [TearDown]
        public void BrowserLogout()
        {
            extent.CreateTest("Create customer ", "Create a new customer and make active");
           // BrowserLaunch.CloseBrowser();
           
        }
        
        [OneTimeTearDown]
        public void FlushReport()
        {
            extent.GenerateReport();
        }


    }
}
