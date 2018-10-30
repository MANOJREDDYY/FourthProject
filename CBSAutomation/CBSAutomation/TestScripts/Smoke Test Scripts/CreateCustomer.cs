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

namespace CBSAutomation.TestScripts.Smoke_Test_Scripts
{
    [TestFixture,SingleThreaded]
    [Order(1)]
   
    public class CreateCustomer:Driver
    {
        ExtentTest test;
        private new IWebDriver driver;
        private ExcelFile excelFile = BrowserLaunch.getExcelFile();
        private static ExtentReports extent;

        [OneTimeSetUp]

        public void reportGeneration()
        {
            string reportname = "Create Active Customer ";
            extendtreports.SetupReporting(reportname);




        }


        [OneTimeSetUp]
        public void BrowserLogin()
        {
            this.driver = Initialize();


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

            test = extendtreports.CreateTestwrap("Create an active customer :" + sCustName);
            CreateCustomerPage.CreateCustomerInput(this.driver,test,sCustID,sCustName, sCustType, sShortname,  sBillAdd,  sBillCity,  sZipCode,  sCountry,  sState );
            CreateCustomerPage.CreateCustomerContactinfo(this.driver,test,sContact,sContph, sContEmail,sPrimaryRep,sQouteRep);
            CreateCustomerPage.CreateCustomerShipToString(this.driver,test,sShipShortname, sShipAdd, sShipCity, sShipZipCode, sShipCountry, sShipState, sShipMtd, sMaxShip, sMinShip);





       }






        [OneTimeTearDown]
        public void BrowserLogout()
        {
            try
            {


                extendtreports.LogTestStatus("Create a new customer and make active");
                extendtreports.GenerateReport();
                test.Log(Status.Pass, "Report generated");
            }
            finally
            {
                Driver.CloseBrowser();
            }
        }

    }
}
