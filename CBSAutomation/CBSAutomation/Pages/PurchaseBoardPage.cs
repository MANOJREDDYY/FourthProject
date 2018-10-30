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
    public  class PurchaseBoardPage 
    {

        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
       
        public static void POforBoard(IWebDriver driver, ExtentTest test, String BoardOrderID)
        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahsingMenu_ID, PurchaseMaterial.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurcahseboardMenu_ID, PurchaseBoard.Default))).Click(); ;
            BoardOrderID = BoardOrderID.Remove(BoardOrderID.Length - 2);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PrucaseboardOrderID_ID, PurchaseBoard.Default))).SendKeys(BoardOrderID);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PurchaseBoardSearch_ID, PurchaseBoard.Default))).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.BoardList_XPATH, PurchaseBoard.Default))).Click();
         //   driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.BoardList_XPATH, PurchaseBoard.Default))).Click();
            if (CommonFunctions.TryFindElement(driver, (By.Id(PropertyReader.GetProperty(Property.BoardList_ID, PurchaseBoard.Default)))))
            {
                Thread.Sleep(2000);
                IWebElement SUPP= driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.BoradSupplier_CSS, PurchaseBoard.Default)));
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

                jse.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
       "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
       "arguments[0].dispatchEvent(evt);", SUPP);

                IWebElement SUPP1 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.BoardListOrder_XPATH, PurchaseBoard.Default)));

           
                jse.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
       "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
       "arguments[0].dispatchEvent(evt);", SUPP1);
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CreateBoardPO_CSS, PurchaseBoard.Default))).Click();
                driver.FindElement(By.Id(PropertyReader.GetProperty(Property.BoardProcessPO_ID, PurchaseBoard.Default))).Click();
                
            }
    }
    }
}
