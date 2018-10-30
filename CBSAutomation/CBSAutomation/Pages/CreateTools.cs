
using AventStack.ExtentReports;
using CBSAutomation.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBSAutomation.Pages
{
  public  class CreateTools 
    {
        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       

        public static void CreateToolAndApprove(IWebDriver driver, ExtentTest test, String Toolid, String tooltype, String toollicplate, String homeloc, String currentloc, String ImpresCount, String ImpresCountExp)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolMenu_ID, Tools.Default))).Click();
            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.CreateTool_LINK, Tools.Default))).Click();


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Tool_ID, Tools.Default))).SendKeys(Toolid);

            IWebElement tooltypeselect = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Tool_Type, Tools.Default)));
            SelectElement drpCountry = new SelectElement(tooltypeselect);
            drpCountry.SelectByText(tooltype);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolLicensePlate_ID, Tools.Default))).SendKeys(toollicplate);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.HomeLocation_ID, Tools.Default))).SendKeys(homeloc);
          //  Thread.Sleep(2000);
            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.HomeLocationDropdown_XPATH, Tools.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CurrentLocation_ID, Tools.Default))).SendKeys(currentloc); 
          //  Thread.Sleep(2000);
            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.CurrLocationDropdown_XPATH, Tools.Default)));


            String toolStatus = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolStatus_ID, Tools.Default))).Text;


            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ImpressionCount_ID, Tools.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ImpressionCount_ID, Tools.Default))).SendKeys(ImpresCount);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ImpressionExpected_ID, Tools.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ImpressionExpected_ID, Tools.Default))).SendKeys(ImpresCountExp);
            Thread.Sleep(2000);
        }


        public static void CreateToolAndApprove2(IWebDriver driver, ExtentTest test, String Toolsupply, String CreatedDate, String DueDate, String Toolcost, String ToolAvailDate, String PurchaseGL, String SuppDescription)
        {

            Thread.Sleep(2000);
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolSupplier_ID, Tools.Default))).SendKeys(Toolsupply);
            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.SupplierDropdown_XPATH, Tools.Default)));


            //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolPOnumber_ID, Tools.Default)));

            IWebElement POfromDateBox = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POCreatedDate_ID, Tools.Default)));

            POfromDateBox.Clear();
            POfromDateBox.SendKeys(CreatedDate);
            action.SendKeys(Keys.Enter).Build().Perform();

            IWebElement PODueDateBox = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PODateDue_ID, Tools.Default)));

            PODueDateBox.Clear();
            PODueDateBox.SendKeys(DueDate);
            action.SendKeys(Keys.Enter).Build().Perform();


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolCost_ID, Tools.Default))).SendKeys(Toolcost);
            IWebElement POavailDateBox = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AvailableDate_ID, Tools.Default)));

            POavailDateBox.Clear();
            POavailDateBox.SendKeys(ToolAvailDate);

            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolGLcode_ID, Tools.Default))).SendKeys(PurchaseGL);


            Thread.Sleep(2000);
            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.PurchasingGLCode_XPATH, Tools.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SupplierPurchaseDescription_ID, Tools.Default))).Click();

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SupplierPurchaseDescription_ID, Tools.Default))).SendKeys(SuppDescription);

        }



        public static void CreateToolAndApprove3(IWebDriver driver, ExtentTest test, String Pricingtype, String ToolCust, String Salesprice, String SalesGL, String SalesRep, String CustInvoiceDesp, String Invoicegeneration)
        {
            //// IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            // jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PricingType_ID, Tools.Default))).SendKeys(Pricingtype);
            Thread.Sleep(2000);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.PricingTypeDropdown_XPATH, Tools.Default)));
            //  CommonFunctions.WaitAndClickDropDown(By.CssSelector(PropertyReader.GetProperty(Property.PricingTypeDropdown_CSS, Tools.Default)));
            Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.InvoiceCustomer_ID, Tools.Default))).SendKeys(ToolCust);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.CustomerDropdown_XPATH, Tools.Default)));


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SalesPrice_ID, Tools.Default))).SendKeys(Salesprice);



            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaleToolGLcode_ID, Tools.Default))).SendKeys(SalesGL);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.SalesGLDropdown_XPATH, Tools.Default)));


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SalesRep_ID, Tools.Default))).SendKeys(SalesRep); ;
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.SalesRepDropdown_XPATH, Tools.Default)));


            IWebElement Invoicegentype = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Invocicegeneration_ID, Tools.Default)));

            SelectElement selectype = new SelectElement(Invoicegentype);
            selectype.SelectByText(Invoicegeneration);
            Thread.Sleep(2000);
            //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customerPO_ID, Tools.Default))).SendKeys(CustomerPOnum);
            //  Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerInvoiceDescription_ID, Tools.Default))).SendKeys(CustInvoiceDesp);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Save_ID, Tools.Default))).Click();
            Thread.Sleep(2000);

            //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SetExisting_ID, Tools.Default)));
            //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Cancel_ID, Tools.Default)));


        }


        public static void CreateToolAndApprove4(IWebDriver driver, ExtentTest test, String Toolidapp)// String CustomerPOnum)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterToolID_ID, Tools.Default))).SendKeys(Toolidapp);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolFilter_ID, Tools.Default))).Click();
            Thread.Sleep(2000);
            IWebElement tooltable = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.tooltable_CSS, Tools.Default)));
            Thread.Sleep(2000);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
   "arguments[0].dispatchEvent(evt);", tooltable);
            Thread.Sleep(2000);
            //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customerPO_ID, Tools.Default))).SendKeys(CustomerPOnum);
            //    Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Order_ID, Tools.Default))).Click();
            Thread.Sleep(2000);
            List<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            driver.Close();
            driver.SwitchTo().Window(tabs2[0]);
        }



        public static void ValidateToolApproveAndReceive(IWebDriver driver, ExtentTest test, String Toolidrec1, String CustomerPOnum,String ReceiptNum,String ReceiptDate)
        {
            Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolMenu_ID, Tools.Default))).Click();
            Thread.Sleep(2000);
         //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterToolID_ID, Tools.Default))).SendKeys(Toolidrec1);

            IWebElement filtertextbox1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterToolID_ID, Tools.Default)));
            filtertextbox1.Clear();
            filtertextbox1.SendKeys(Toolidrec1);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolFilter_ID, Tools.Default))).Click();
            Thread.Sleep(2000);
            IWebElement tooltable1 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.tooltable_CSS, Tools.Default)));
            IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
            jse2.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
   "arguments[0].dispatchEvent(evt);", tooltable1);

           


            Thread.Sleep(2000);
          string ToolPO=  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolPOnumber_ID, Tools.Default))).GetAttribute("value");

            excelFile.UpdateCellValue("TOOLS", "Create_tool", "Create_ToolandReceive", "T_TOOLPO", ToolPO);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ReceiptNumber_ID, Tools.Default))).SendKeys(ReceiptNum);
           IWebElement ReceiptDateBox= driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ReceiptDate_ID, Tools.Default)));
            ReceiptDateBox.Clear();
            ReceiptDateBox.SendKeys(ReceiptDate);

            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customerPO_ID, Tools.Default))).SendKeys(CustomerPOnum);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Receive_ID, Tools.Default))).Click();
            Thread.Sleep(2000);

            String toolStatus = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ToolStatusReceive_XPATH, Tools.Default))).Text;
            Assert.IsTrue(toolStatus.Contains("Received"), toolStatus + " doesn't contains 'Received'");





        }


        public static void ValidateToolStatus(IWebDriver driver, ExtentTest test, string Toolidvalidate)
        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolMenu_ID, Tools.Default))).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterToolID_ID, Tools.Default))).SendKeys(Toolidvalidate);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolFilter_ID, Tools.Default))).Click();
            Thread.Sleep(1000);
            IWebElement tooltable = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.tooltable_CSS, Tools.Default)));
            Thread.Sleep(1000);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
   "arguments[0].dispatchEvent(evt);", tooltable);
            Thread.Sleep(1000);

          string pricingtypevalue= driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PricingType_ID, Tools.Default))).Text;
            Assert.IsTrue(pricingtypevalue.Equals("Buy and Bill"));
            Thread.Sleep(1000);

           string customerpovalue= driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customerPO_ID, Tools.Default))).Text;
           
            Assert.IsNotNull(customerpovalue);
            Thread.Sleep(1000);

        }
        }
}