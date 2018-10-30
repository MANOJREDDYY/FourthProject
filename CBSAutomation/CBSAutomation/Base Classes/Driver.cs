using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.IO;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using CBSAutomation.Locators;
using System.Threading;
using OpenQA.Selenium.Remote;
namespace CBSAutomation
{

  
    public class Driver
    {
        private static String URL = null;

        private static String VERSION = null;


        public static String browser;
    
        private  static IWebDriver driver { get; set; }

        public static IWebDriver getDriver()
        {
            return driver;
        }


     //   [TestInitialize()]
     
        public static IWebDriver Initialize() 
        {
            if (driver == null)
            {
                browser = PropertyReader.GetProperty(Property.BROWSER, GeneralProperties.Default);
                if (browser.ToLower().Equals("chrome"))
                {
                    URL = Driver.getUrl();

                    var currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    currentDirectory = currentDirectory.Remove(currentDirectory.IndexOf("\\CBSAutomation\\bin\\Debug"));
                    var currentDirectory1 = (currentDirectory + "\\packages\\Selenium.WebDriver.ChromeDriver.2.41.0\\driver\\win32\\");
                 //  var currentDirectorystandalone = (currentDirectory + "\\packages\\selenium-server-standalone.3.9.1.1\\jar\\chromedriver.exe");

                    //  System.Environment.SetEnvironmentVariable("WebDriver.chrome.driver", currentDirectory1);
                    System.Environment.SetEnvironmentVariable("WebDriver.chrome.driver", currentDirectory1);

                    ChromeOptions options = new ChromeOptions();
                  
                
                    DesiredCapabilities capsnew = options.ToCapabilities() as DesiredCapabilities;
                    capsnew.SetCapability(CapabilityType.BrowserName, "chrome");
                    capsnew.SetCapability(CapabilityType.TakesScreenshot, true);
                    capsnew.SetCapability("platform", "WINDOWS");
                   capsnew.SetCapability("version", "{whatever}");
                    capsnew.SetCapability("deviceName", "");
                    capsnew.SetCapability(ChromeOptions.Capability, options);

                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-infobars");
                options.AddArgument("--disable-extensions");
                    //  options.AddArgument("--window-size=1200,900");
                    //  options.AddArgument("--disable-browser-side-navigation");
             
                  options.SetLoggingPreference(LogType.Browser,LogLevel.All);

              //      driver= new RemoteWebDriver(new Uri("http://localhost:8650/wd/hub"),
                //   capsnew);
                    
                  driver = new ChromeDriver(@currentDirectory1, options, TimeSpan.FromSeconds(500));
                  driver.Url = URL;
                   
                    driver.Manage().Window.Maximize();


                }
                else if (browser.ToLower().Equals("internetexplorer"))
                {
                   // DesiredCapabilities capsbrowserIE = DesiredCapabilities.InternetExplorer();
                    //capsbrowserIE.SetCapability(CapabilityType.BrowserName, browser);
                    //capsbrowserIE.SetCapability(CapabilityType.TakesScreenshot, true);

                    InternetExplorerOptions options = new InternetExplorerOptions();
                   // capsbrowserIE.SetCapability(InternetExplorerOptions.Capability, options);

                    driver = new InternetExplorerDriver(options);
                    driver.Url = URL;
                    driver.Manage().Window.Maximize();
                }


                else if (browser.ToLower().Equals("firefox"))
                {
                    FirefoxOptions options = new FirefoxOptions();

                    options.LogLevel = FirefoxDriverLogLevel.Info;
                    options.UseLegacyImplementation = false;
                    driver = new FirefoxDriver(options);
                    driver.Url = URL;
                    driver.Manage().Window.Maximize();
                }
            }
            return driver;
        }

         public static void CloseBrowser()
          {

         if (driver != null)
            {
                Thread.Sleep(2000);
                driver.Close();
                driver.Quit();
              

                driver = null;
                
                Thread.Sleep(2000);
           }

        }

        public static String getUrl()
        {
            if (URL == null)
            {
                try
                {
                    URL = PropertyReader.GetProperty(Property.BASEURL, GeneralProperties.Default);

                }
                catch
                {
                }
            }
            return URL;
        }

    }


}



