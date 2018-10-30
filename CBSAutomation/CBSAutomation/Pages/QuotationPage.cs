
using AventStack.ExtentReports;
using CBSAutomation.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBSAutomation.Pages
{
 public   class QuotationPage
    {

        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       


        public static void CreateQuotaion(IWebDriver driver, ExtentTest test, string QouteCustname,string Qoutespec,string saluation,string BussStatus, string Approvestatus ) 
        

        {
        
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
           driver.FindElement(By.Id(PropertyReader.GetProperty(Property.quotationMenuLInk_ID, QuotationProperty.Default))).Click();
            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.Create_New_LINK, QuotationProperty.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CuatomerName_ID, QuotationProperty.Default))).SendKeys(QouteCustname);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.CustomerSelectDropdown_XPATH, QuotationProperty.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Salutation_ID, QuotationProperty.Default))).SendKeys(saluation);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.QuotationBusinessStatus_ID, QuotationProperty.Default))).SendKeys(BussStatus);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.QuotationApprovedStatus_ID, QuotationProperty.Default))).SendKeys(Approvestatus);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.findquotationestimateprices_ID, QuotationProperty.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filterBySpecId_ID, QuotationProperty.Default))).SendKeys(Qoutespec);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.estimatessearchfilter_ID, QuotationProperty.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Tablelist_XPATH, QuotationProperty.Default))).Click();
        

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("document.body.style.zoom='70%';");
            Thread.Sleep(2000);
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

          
            IWebElement DIVelement = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.addquotationestimates_ID, QuotationProperty.Default)));
            


            jse.ExecuteScript("arguments[0].scrollIntoView(true);",DIVelement);
            Thread.Sleep(2000);
           IWebElement elem= driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.searchquotationdialog_CSS, QuotationProperty.Default)));
          
            jse.ExecuteScript("arguments[0].click();", elem);
            Thread.Sleep(2000);
            IList<IWebElement> DIVelement1 = driver.FindElements(By.CssSelector(PropertyReader.GetProperty(Property.Save_Link, QuotationProperty.Default)));
           IList<IWebElement>fewfw= DIVelement1[1].FindElements(By.TagName("button"));

            jse.ExecuteScript("arguments[0].click();", fewfw[0]);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.QuotationReport_ID, QuotationProperty.Default))).Click();
            Thread.Sleep(2000);
          
            List<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            driver.Close();
            driver.SwitchTo().Window(tabs2[0]);
            Thread.Sleep(2000);
        }
    }
}
