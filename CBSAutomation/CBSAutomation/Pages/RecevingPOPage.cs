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
   public class RecevingPOPage
    {

        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       

        public static void ReceivePO(IWebDriver driver, ExtentTest test, String receivesupplier, String receivePo,String units,String unitqty,String lastunitqty,String receivevendorID,String receiveshipmentID)

        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POReceving_ID, RecevingPO.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.receiveSpplier_ID, RecevingPO.Default))).SendKeys(receivesupplier);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ReceiveSupplierPO_XPATH, RecevingPO.Default)));
           
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.AddRecepietLine_CSS, RecevingPO.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.POinputReceive_CSS, RecevingPO.Default))).SendKeys(receivePo);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ReceivePOid_XPATH, RecevingPO.Default)));
            
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ReceiveUnit_ID, RecevingPO.Default))).SendKeys(units);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitQty_ID, RecevingPO.Default))).SendKeys(unitqty);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.LatUnitQty_ID, RecevingPO.Default))).SendKeys(lastunitqty);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.VendorID_ID, RecevingPO.Default))).SendKeys(receivevendorID);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shipment_ID, RecevingPO.Default))).SendKeys(receiveshipmentID);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveReceivePO_ID, RecevingPO.Default))).Click();
        }


        public static void ReceiveBoardPO(IWebDriver driver, ExtentTest test, string receivesupplier, String receivePo, String units, String unitqty, string lastunitqty, String receivevendorID, String receiveshipmentID)

        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POReceving_ID, RecevingPO.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.receiveSpplier_ID, RecevingPO.Default))).SendKeys(receivesupplier);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ReceiveSupplierPO_XPATH, RecevingPO.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ReceiveBoard_ID, RecevingPO.Default))).Click();
            

            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.AddRecepietLine_CSS, RecevingPO.Default))).Click();
            Thread.Sleep(2000);
            string receivePo1 = receivePo.Remove(receivePo.Length - 2);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.POinputReceive_CSS, RecevingPO.Default))).SendKeys(receivePo1);
            Thread.Sleep(2000);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ReceivePOid_XPATH, RecevingPO.Default)));

            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ReceiveUnit_ID, RecevingPO.Default))).SendKeys(units);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.UnitQty_ID, RecevingPO.Default))).SendKeys(unitqty);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.LatUnitQty_ID, RecevingPO.Default))).SendKeys(lastunitqty);

            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.VendorID_ID, RecevingPO.Default))).SendKeys(receivevendorID);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shipment_ID, RecevingPO.Default))).SendKeys(receiveshipmentID);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveReceivePO_ID, RecevingPO.Default))).Click();
        }
    }
}
