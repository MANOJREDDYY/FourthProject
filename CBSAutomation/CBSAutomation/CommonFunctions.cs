
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using CBSAutomation.Locators;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace CBSAutomation
{

    public static class CommonFunctions
    {
        private static Random random = new Random();
       
        
        
      

        public static Boolean isElementPresent(this IWebDriver driver,By by)
        {
            try
            {

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(by);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return true;
            }
            catch (NoSuchElementException)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                return false;
            }
        }

        public static void assertElementIsDisplayed(IWebElement element)

        {

            if (!element.Displayed)
            {
                throw new Exception("Element " + element + " is not displayed");
            }
        }

        public static void assertElementIsPresent(this IWebDriver driver,By locator)
        {
            System.Drawing.Size size = (driver.FindElement(locator)).Size;
            if (size.IsEmpty)
            {
                throw new Exception("Did not find an element: " + locator);
            }
        }



        public static void WaitAndClickDropDown(this IWebDriver driver , By locator)
        {


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(10));
            IWebElement selectElement = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            selectElement.Click();

        }


        public static void fetchlist(this IWebDriver driver,By locator)

        {
            Actions action = new Actions(driver);
            // IList <IWebElement> ele1 = driver.FindElements(locator);
            //  action.MoveToElement(ele1).Build().Perform();
            IWebElement listvlaue = driver.FindElement(locator);
            IList<IWebElement> listvlaue1 = listvlaue.FindElements(By.TagName("li"));
            int Sizevalue = listvlaue1.Count;
            foreach (IWebElement eachlist in listvlaue1)
            {

                if (Sizevalue == 1)
                {

                    string valueString = eachlist.FindElement(By.TagName("a")).Text;
                    Console.Write(valueString);

                    IWebElement elem2 = eachlist.FindElement(By.TagName("a"));
                    action.MoveToElement(elem2).Build().Perform();

                    elem2.Click();

                }
            }
        }





        public static void WaitTillElementPresent(this IWebDriver driver,By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (NoSuchElementException)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            }
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomInteger(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static Boolean IfexistsElement(this IWebDriver driver,By by)
        {
            IWebElement exists = driver.FindElement(by);

            if (exists.Displayed)
            {
                return false;
            }
            else
                return true;



        }


        public static bool IsElementDisplayed(this IWebDriver driver, By element)
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Displayed;
            }
            return false;
        }

        public static bool TryFindElement(this IWebDriver driver, By by)
        {
            IWebElement element;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                element = driver.FindElement(by);
              
                return true;
            }
            catch (Exception ex)
            {
                if (ex is TimeoutException || ex is NoSuchElementException || ex is WebDriverException)
                {
                    element = null;

                    return false;
                }
                throw;

            }
        }
    }
}
  


       













