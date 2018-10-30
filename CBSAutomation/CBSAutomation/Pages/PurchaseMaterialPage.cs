using AventStack.ExtentReports;
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
    public  class PurchaseMaterialPage
    {

        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       

        public static void CreateNewMaterialPO (IWebDriver driver, ExtentTest test, String MatSupplier,String MatWarehouse,String Mattransport,String MattID)
        {
            
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurchaseMaterial_ID, PurchaseMaterial.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreatePOMaterial_ID, PurchaseMaterial.Default))).Click();
         
       
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Supplier_ID, PurchaseMaterial.Default))).SendKeys(MatSupplier);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.MaterialSupplierDropdown_XPATH, PurchaseMaterial.Default)));


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Warehouse_ID, PurchaseMaterial.Default))).SendKeys(MatWarehouse);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.WarehousDropdown_XPATH, PurchaseMaterial.Default)));
          
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.TrasportMode_ID, PurchaseMaterial.Default))).SendKeys(Mattransport);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.TrasportModeDropdown_XPATH, PurchaseMaterial.Default)));


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectMaterial_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
             driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.MaterialIDSearch_CSS, PurchaseMaterial.Default))).SendKeys(MattID);

         //   IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
          //  jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
          IWebElement supplierdropdown=  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MaterialMode_ID, PurchaseMaterial.Default)));
            SelectElement dropdown = new SelectElement(supplierdropdown);
            dropdown.SelectByText("Stocked Materials");

            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.MaterialFilter_CSS, PurchaseMaterial.Default))).Click();
            Thread.Sleep(3000);
          
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.MaterialSelectCheckbox_CSS, PurchaseMaterial.Default))).Click();
            
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMaterialPO_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
             jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePO_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            List<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            driver.Close();
            driver.SwitchTo().Window(tabs2[0]);
            Thread.Sleep(2000);








        }
    }
}
