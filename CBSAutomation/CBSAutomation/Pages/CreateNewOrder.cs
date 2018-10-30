using AventStack.ExtentReports;
using CBSAutomation;
using CBSAutomation.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CBSAutomation.Pages
{
    public class CreateNewOrder

    {
        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       

        public static void CreateNewOrderEntry(IWebDriver driver, ExtentTest test, String CustomerName, String POnumber, String ShipToAdd)
        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.orderManag_ID, Orders.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Orderentry_ID, Orders.Default))).Click();


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ordercustomer_ID, Orders.Default))).SendKeys(CustomerName);

            CommonFunctions.isElementPresent(driver,By.XPath(PropertyReader.GetProperty(Property.dropdown_XPATH, Orders.Default)));

            // action.MoveToElement(driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.dropdown_XPATH, Orders.Default))));
            // action.Perform();
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.dropdown_XPATH, Orders.Default))).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ordernetryPO_XPATH, Orders.Default))).SendKeys(POnumber);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Shipto_XPATH, Orders.Default))).Click();
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Shipto_XPATH, Orders.Default))).SendKeys(ShipToAdd);

            //  CommonFunctions.isElementPresent( By.XPath(PropertyReader.GetProperty(Property.ShipToDropDown_XPATH, Orders.Default)));

            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ShipToDropDown_XPATH, Orders.Default))).Click();

        }
        public static void eneterNewOrderEntry(IWebDriver driver, ExtentTest test, String Qty, String OrdDueDate, String OrderSpecID)
        {

            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.DileverySpec_XPATH, Orders.Default))).SendKeys(OrderSpecID);

            Thread.Sleep(3000);
            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.DileverySpecdropdown_XPATH, Orders.Default)));

            Thread.Sleep(3000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.orderQty_XPATH, Orders.Default))).SendKeys(Qty);
            IWebElement web1 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderDueDate_XPATH, Orders.Default)));
            web1.SendKeys(OrdDueDate);
            web1.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            web1.SendKeys(Keys.Tab);
            Thread.Sleep(2000);
            //    driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderSave_XPATH, Orders.Default))).Click();
            //   ExtentReportGeneration.isElementPresent(driver, By.XPath(PropertyReader.GetProperty(Property.OrderId_XPATH, Orders.Default)), 5000);
            //   string orderids = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderId_XPATH, Orders.Default))).Text;

            // excelFile.UpdateCellValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID", orderids);


        }
        public static void eneterAnotherSalesLine(IWebDriver driver, ExtentTest test, String Qtyline1, String OrdDueDateline1, String OrderSpecIDline1)
        {

            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.AddSalesLine_CSS, Orders.Default))).Click();
            //driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AddSalesLine_XPATH, Orders.Default))).Click();

            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.DileverySpecLine2_XPATH, Orders.Default))).SendKeys(OrderSpecIDline1);
            Thread.Sleep(2000);


            CommonFunctions.WaitAndClickDropDown(driver,By.XPath(PropertyReader.GetProperty(Property.DileverySpecdropdownLine2_XPATH, Orders.Default)));
            // driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.DileverySpecdropdownLine2_XPATH, Orders.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.orderQtyLine2_XPATH, Orders.Default))).SendKeys(Qtyline1);

             IWebElement web2 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderDueDateLine2_XPATH, Orders.Default)));
            //  Thread.Sleep(2000);
            //  web2.SendKeys(OrdDueDateline1);
            //  web2.SendKeys(Keys.Enter);
            //  Thread.Sleep(2000);
             web2.SendKeys(Keys.Tab);
          
         //   driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderSave_XPATH, Orders.Default))).Click();



        }

        public static void SaveOrder(IWebDriver driver,ExtentTest test)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.OrderSave_XPATH, Orders.Default))).Click();
            Thread.Sleep(2000);
           string OrderIDgeneerated= driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.OrderList_CSS, Orders.Default))).Text;
            excelFile.UpdateCellValue("ORDERS", "CREATEORDER", "create_makeship_order", "ORDERID", OrderIDgeneerated);
            excelFile.UpdateCellValue("ORDERS", "CREATEORDER", "create_makeship_order_2", "ORDERID", OrderIDgeneerated);
        }


        public static void FilterOrder(IWebDriver driver, ExtentTest test, string filterorderid, string validateestimatecost)
        {
            Thread.Sleep(2000);
            string  filterorderid1= filterorderid.Remove(filterorderid.Length - 2);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.orderManag_ID, Orders.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.subMenuLiOrders_ID, Orders.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filterbyorder_ID, Orders.Default))).SendKeys(filterorderid1);
           
CommonFunctions.WaitTillElementPresent(driver,By.XPath(PropertyReader.GetProperty(Property.FilterOrderDropdown_XPATH, Orders.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filtersalelines_ID, Orders.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filtersalelines_ID, Orders.Default))).Click();
           string orderprice= driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.orderTableList_XPATH, Orders.Default))).Text;
            Assert.IsTrue(validateestimatecost.Equals(orderprice));
        }
    }
}

        