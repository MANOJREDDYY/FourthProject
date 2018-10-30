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
    public  class CreateMaterialPage 
    {
        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
      
        
        public static void CreateNewMaterial(IWebDriver driver, ExtentTest test, String materialid, String materialdescp, String Materialtype, String Currentcost)
        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MatrerialMenu_ID, Material.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateNewmaterial_ID, Material.Default))).Click();

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Materail_ID, Material.Default))).SendKeys(materialid);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MaterialDescription_ID, Material.Default))).SendKeys(materialdescp);


            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MaterialType_ID, Material.Default))));
            oSelect.SelectByText(Materialtype);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CostCurrent_ID, Material.Default))).SendKeys(Currentcost);
            IWebElement checkboxrealmaterial = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.IsRealMaterial_ID, Material.Default)));


            checkboxrealmaterial.Click();

            // if (checkboxrealmaterial.Selected) {
            //     Assert.Pass("ActiveMaterial checked");
            //       }
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Save_CSS, Material.Default))).Click();
            Thread.Sleep(3000);
         //   CommonFunctions.WaitTillElementPresent(By.Id(PropertyReader.GetProperty(Property.FilterMateriall1_ID, Material.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterMateriall1_ID, Material.Default))).Clear();
      
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterMateriall1_ID, Material.Default))).SendKeys(materialid);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filter_ID, Material.Default))).Click();
            Thread.Sleep(2000);
            // CommonFunctions.WaitTillElementPresent(By.XPath(PropertyReader.GetProperty(Property.Material_table_XPATH, Material.Default)));
            //string materialname= driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Material_table_XPATH, Material.Default))).Text;

            //   Assert.IsTrue(materialname.Contains(materialid), materialname + " is created '");
        }


        public static void ValidateMaterialStatus(IWebDriver driver, ExtentTest test, String materialid)
        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MatrerialMenu_ID, Material.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterMateriall1_ID, Material.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterMateriall1_ID, Material.Default))).SendKeys(materialid);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filter_ID, Material.Default))).Click();
            Thread.Sleep(2000);
          
            Thread.Sleep(2000);
            String Materialstatus = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Activestatus_XPATH, Material.Default))).Text;
            Assert.IsTrue(Materialstatus.Equals("Active"));
        }
    }
}
    

