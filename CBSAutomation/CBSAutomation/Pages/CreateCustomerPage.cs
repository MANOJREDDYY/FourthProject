using AventStack.ExtentReports;
using CBSAutomation.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBSAutomation
{
    public  class CreateCustomerPage
    {

    

        public static void CreateCustomerInput(IWebDriver driver, ExtentTest test, String sCustID, String sCustName, String sCustType, String sShortname, String sBillAdd, String sBillCity, String sZipCode, String sCountry, String sState)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerMenu_ID, CustomerLocators.Default))).Click();

            driver.FindElement(By.PartialLinkText(PropertyReader.GetProperty(Property.CreateCustomer_LINK, CustomerLocators.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerID_ID, CustomerLocators.Default))).SendKeys(sCustID);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerName_ID, CustomerLocators.Default))).SendKeys(sCustName);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerType_ID, CustomerLocators.Default))).SendKeys(sCustType);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CustomerTypedropDown_CSS, CustomerLocators.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CustId_Save_CSS, CustomerLocators.Default))).Click();
            Thread.Sleep(2000);
            //  CommonFunctions.WaitTillElementPresent(By.XPath(PropertyReader.GetProperty(Property.CustShortname_ID, CustomerLocators.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustShortname_ID, CustomerLocators.Default))).SendKeys(sShortname);
            String CustomerStatus = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Customer_Status_ID, CustomerLocators.Default))).GetAttribute("value");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddressBillTo_ID, CustomerLocators.Default))).SendKeys(sBillAdd);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CityBillto_ID, CustomerLocators.Default))).SendKeys(sBillCity);
            IWebElement selectCountry = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CountryBillTo_ID, CustomerLocators.Default)));
            SelectElement sel1 = new SelectElement(selectCountry);
            sel1.SelectByValue(sCountry);
            IWebElement selectState = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.BilltoState_ID, CustomerLocators.Default)));
            SelectElement sel = new SelectElement(selectState);
            sel.SelectByValue(sState);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ZipBillto_ID, CustomerLocators.Default))).SendKeys(sZipCode);
            test.Log(Status.Info, "Create customer with adding shipto add");
        }


        public static void CreateCustomerContactinfo(IWebDriver driver, ExtentTest test, String sContact, String sContph, String sContEmail, String sPrimaryRep, String sQouteRep)
        {
            driver.FindElement(By.PartialLinkText(PropertyReader.GetProperty(Property.CustomerContact_LINK, CustomerLocators.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Contact_ID, CustomerLocators.Default))).SendKeys(sContact);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ContPh_ID, CustomerLocators.Default))).SendKeys(sContph);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Cont_Email_ID, CustomerLocators.Default))).SendKeys(sContEmail);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PrimaryRep_ID, CustomerLocators.Default))).SendKeys(sPrimaryRep);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.PrimaryRepDropdown_CSS, CustomerLocators.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.QouteRep_ID, CustomerLocators.Default))).SendKeys(sQouteRep);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.QouteRepDropDown_CSS, CustomerLocators.Default)));
            Thread.Sleep(2000);
            //driver.FindElement(By.Id(PropertyReader.GetProperty(Property.QouteRep_ID, CustomerLocators.Default))).SendKeys(sQouteRep);;
            driver.FindElement(By.PartialLinkText(PropertyReader.GetProperty(Property.Commercial_LINK, CustomerLocators.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.BillingTerms_ID, CustomerLocators.Default))).SendKeys("Bill of Lading");
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.BillingTermsDropdown_CSS, CustomerLocators.Default)));

            test.Log(Status.Info, "Create customer with Contact info");



        }

        public static void CreateCustomerShipToString(IWebDriver driver, ExtentTest test, String sShortname, String sShipAdd, String sShipCity, String sShipZipCode, String sShipCountry, String sShipState, String sShipMtd, String sMaxShip, String sMinShip)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, 350);");
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ShipCustShortName_CSS, CustomerLocators.Default))).SendKeys(sShortname);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shipto_Add_ID, CustomerLocators.Default))).SendKeys(sShipAdd);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shipto_City_ID, CustomerLocators.Default))).SendKeys(sShipAdd);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ShipTo_Zip_ID, CustomerLocators.Default))).SendKeys(sShipZipCode);
            IWebElement Shipcountry = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CountryShipto_ID, CustomerLocators.Default)));
            SelectElement sel3 = new SelectElement(Shipcountry);
            sel3.SelectByText(sShipCountry);

            IWebElement ShipState = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shipto_State_ID, CustomerLocators.Default)));
            SelectElement sel4 = new SelectElement(ShipState);
            sel4.SelectByText(sShipState);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shippingmtd_ID, CustomerLocators.Default))).SendKeys(sShipMtd);

            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ShippingMtddropdown_CSS, CustomerLocators.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MaxShipOver_ID, CustomerLocators.Default))).SendKeys(sMaxShip);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.MinShipOver_ID, CustomerLocators.Default))).SendKeys(sMinShip);
            Thread.Sleep(2000);
            jse.ExecuteScript("scroll(0, -100);");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Unittization_ID, CustomerLocators.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationType_ID, CustomerLocators.Default))).SendKeys("B 4 Down");
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.Untitypedropdown_CSS, CustomerLocators.Default)));
            test.Log(Status.Info, "Create customer with Ship tp adress creation");




            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustSave_ID, CustomerLocators.Default))).Click();
            // IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            driver.FindElement(By.PartialLinkText(PropertyReader.GetProperty(Property.Make_Active_LINK, CustomerLocators.Default))).Click();





        }


        public static Tuple<string,string ,string> CreateCustomerShiptoShipMtd(IWebDriver driver, ExtentTest test, String Spec_CustName)
        {
            Actions action = new Actions(driver);
            Thread.Sleep(3000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();

            
        IWebElement  customertab = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CustomerMenu_ID, CustomerLocators.Default)));
            Thread.Sleep(3000);
            action.KeyDown(Keys.Control).MoveToElement(customertab).Click().KeyUp(Keys.Control).Perform();


            List<String> tabs2 = new List<String>(driver.WindowHandles);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(1000);
            


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filterByName_ID, CustomerLocators.Default))).SendKeys(Spec_CustName);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.searchCustomer_ID, CustomerLocators.Default))).Click();
            Thread.Sleep(3000);
            IWebElement liList1= driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.customerListtable_CSS, CustomerLocators.Default)));
          
            IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
            jse2.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
   "arguments[0].dispatchEvent(evt);", liList1);

            Thread.Sleep(2000);
            driver.FindElement(By.PartialLinkText(PropertyReader.GetProperty(Property.Commercial_LINK, CustomerLocators.Default))).Click();
            string BusinessDiscount = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AutoBusinessDiscount_ID, CustomerLocators.Default))).GetAttribute("value");
            string  customerShipto = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CustomerDefShipto_ID, CustomerLocators.Default))).Text;
           string  customerShiptomtd = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Shippingmtd_ID, CustomerLocators.Default))).GetAttribute("value");

            driver.Close();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[0]);

            driver.Navigate().Refresh();
            test.Log(Status.Info, "return customer ship to address and shipping method");
            return Tuple.Create(BusinessDiscount,customerShipto, customerShiptomtd);
            


        }
    }
}

