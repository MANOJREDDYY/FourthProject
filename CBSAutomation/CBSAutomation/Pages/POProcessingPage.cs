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
   public class POProcessingPage
    {
        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
        
       
        public static void ProcessToolPO(IWebDriver driver,String Toolidrec) {
      
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AccountingMenu_ID, POProcessing.Default))).Click();
            Thread.Sleep(2000);
             driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POProcessing_ID, POProcessing.Default))).Click();
            IWebElement POfilter = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterTool_ID, POProcessing.Default)));

            SelectElement drpCountry = new SelectElement(POfilter);
            drpCountry.SelectByText("Tooling");
            Thread.Sleep(2000);

           IWebElement filtertextbox= driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterToolID_ID, Tools.Default)));
            filtertextbox.Clear();
               filtertextbox.SendKeys(Toolidrec);
         //   Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterPO_ID, POProcessing.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Table_toolgrid_XPATH, POProcessing.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProcessPO_ID, POProcessing.Default))).Click();
            Thread.Sleep(3000);
           String POtoolStatus= driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.POstatus_XPATH, POProcessing.Default))).Text;
            Assert.IsTrue(POtoolStatus.Contains("Approved"), POtoolStatus + " doesn't contains 'Approved'");
            Thread.Sleep(3000);
            String POtoolid = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ProcessPOID_XPATH, POProcessing.Default))).Text;

            

        }
    
    public static void ProcessBoardPO(IWebDriver driver,String BoardOrderlid)
    {

        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AccountingMenu_ID, POProcessing.Default))).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POProcessing_ID, POProcessing.Default))).Click();
        IWebElement POfilter = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterTool_ID, POProcessing.Default)));

        SelectElement drpCountry = new SelectElement(POfilter);
        drpCountry.SelectByText("Board");
        Thread.Sleep(2000);
            string  BoardOrderID1 = BoardOrderlid.Remove(BoardOrderlid.Length - 2);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterOrderid_ID, POProcessing.Default))).SendKeys(BoardOrderID1);
           
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterPO_ID, POProcessing.Default))).Click();
        Thread.Sleep(2000);
       driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.selectBoadPrint_XPATH, PurchaseBoard.Default))).Click();
        Thread.Sleep(2000);
            String POboardid = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.selectBoadPOValue_XPATH, PurchaseBoard.Default))).Text;
            Thread.Sleep(2000);
            excelFile.UpdateCellValue("RECEVING", "Receive_PO", "Receive_Board", "RECEIVEPO", POboardid);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProcessPO_ID, POProcessing.Default))).Click();
        Thread.Sleep(3000);
            //   String POtoolStatus = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.POstatus_XPATH, POProcessing.Default))).Text;
            // Assert.IsTrue(POtoolStatus.Contains("Approved"), POtoolStatus + " doesn't contains 'Approved'");
            List<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            driver.Close();
            driver.SwitchTo().Window(tabs2[0]);
            Thread.Sleep(2000);
          //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PrintOrderPOReport_ID, POProcessing.Default))).Click();
          //  Thread.Sleep(3000);
         //   driver.SwitchTo().Window(tabs2[1]);
          //  driver.Close();
        }


        public static void ProcessMaterialPO(IWebDriver driver,String materialid)
        {

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AccountingMenu_ID, POProcessing.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.POProcessing_ID, POProcessing.Default))).Click();
            IWebElement POfilter = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterTool_ID, POProcessing.Default)));

            SelectElement drpCountry = new SelectElement(POfilter);
            drpCountry.SelectByText("Materials");
            Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterByMaterial_ID, POProcessing.Default))).SendKeys(materialid);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.FilterPO_ID, POProcessing.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Material_toolgrid_XPATH, POProcessing.Default))).Click();
            Thread.Sleep(2000);
            String POMaterialid = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.MaterialProcessPOID_XPATH, POProcessing.Default))).Text;
            Thread.Sleep(2000);
            excelFile.UpdateCellValue("RECEVING", "Receive_Material", "Receive_Material", "RECEIVEPO", POMaterialid);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProcessPO_ID, POProcessing.Default))).Click();
            Thread.Sleep(3000);
            //   String POtoolStatus = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.POstatus_XPATH, POProcessing.Default))).Text;
            // Assert.IsTrue(POtoolStatus.Contains("Approved"), POtoolStatus + " doesn't contains 'Approved'");
            List<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            driver.Close();
            driver.SwitchTo().Window(tabs2[0]);
            Thread.Sleep(2000);
         //   driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PrintOrderPOReport_ID, POProcessing.Default))).Click();
         //   Thread.Sleep(3000);
          //  driver.SwitchTo().Window(tabs2[1]);
          //  driver.Close();
        }
    }
}


