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
 public   class PayableReceiptsPage
    {

        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
      

        public static void PayableReceiptsCreation(IWebDriver driver, ExtentTest test, String Vendorid, String PONumberfilter, string dateofpayable,string Receiptypes)

        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AcountingMenu_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Payablereceipts_ID, PayableReceipts.Default))).Click();

            // driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterByPOid_ID, PayableReceipts.Default))).SendKeys(PayablePo);
            //   CommonFunctions.WaitAndClickDropDown(By.XPath(PropertyReader.GetProperty(Property.PayableDropdown_XPATH, PayableReceipts.Default)));
            Thread.Sleep(2000);
            IWebElement selectBytype = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.TypeOfreceipt_ID, PayableReceipts.Default)));//.SendKeys("");
            SelectElement dropdown = new SelectElement(selectBytype);
            dropdown.SelectByText(Receiptypes);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterByPO_ID, PayableReceipts.Default))).SendKeys(PONumberfilter);
            //  CommonFunctions.WaitAndClickDropDown(By.XPath(PropertyReader.GetProperty(Property.PayableCustomerDropdown_XPATH, PayableReceipts.Default)));
            Thread.Sleep(1000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SerachReceipt_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
            //  String POinTable=driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.POvalue_XPATH, PayableReceipts.Default))).Text;
            //  Assert.IsTrue(POinTable.Equals(PayablePo));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.receiptTable_ID, PayableReceipts.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.VendorIDReceipt_ID, PayableReceipts.Default))).SendKeys(Vendorid);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.InvoiceDate_ID, PayableReceipts.Default))).SendKeys(dateofpayable);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Beginpayable_ID, PayableReceipts.Default))).Click();
            IWebElement tablevalue=  driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ReceiptTable_XPATH, PayableReceipts.Default)));
            

            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
   "arguments[0].dispatchEvent(evt);", tablevalue);
            jse1.ExecuteScript("document.body.style.zoom='70%';");
            Thread.Sleep(2000);
            IWebElement elem1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePayable_ID, PayableReceipts.Default)));

            jse1.ExecuteScript("arguments[0].click();", elem1);
            Thread.Sleep(3000);

            jse1.ExecuteScript("document.body.style.zoom='100%';");
            Thread.Sleep(2000);

  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CompletePay_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
       IWebElement receipttable= driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ReceiptTable_XPATH, PayableReceipts.Default)));
            jse1.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
  "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
  "arguments[0].dispatchEvent(evt);", receipttable);
            jse1.ExecuteScript("document.body.style.zoom='100%';");
            Thread.Sleep(2000);
            
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePayable_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CompletePay_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.closebatchReceipt_ID, PayableReceipts.Default))).Click();

            Thread.Sleep(2000);

            IWebElement selectBystatus = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filterByStatus_ID, PayableReceipts.Default)));
            SelectElement dropdown1 = new SelectElement(selectBystatus);
            dropdown1.SelectByText("Payable Generated");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterByPOid_ID, PayableReceipts.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterByPO_ID, PayableReceipts.Default))).SendKeys(PONumberfilter);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SerachReceipt_ID, PayableReceipts.Default))).Click();
            Thread.Sleep(2000);
            String POinTableafter = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.POvalue_XPATH, PayableReceipts.Default))).Text;
            Assert.IsTrue(POinTableafter.Equals(PONumberfilter));



        }


        
    }

}
