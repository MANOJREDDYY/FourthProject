using System;
using CBSAutomation.Locators;
using log4net;
using OpenQA.Selenium;

namespace CBSAutomation
{

    public class BrowserLaunch
    {
       
        public static String URL;
  
        private static ExcelFile ExcelFileInstance = null;
        //  public static IWebDriver driver { get; set; } = null;
      
      //  public static IWebDriver driver;
        public static void StartBrowser()
        {

            
        URL = Driver.getUrl();
        Driver.Initialize();
           

        }
        
        public static ExcelFile getExcelFile()
        {
            if(ExcelFileInstance == null)
                {
                    ExcelFileInstance = ExcelUtility.LoadExcel();
                }
            return ExcelFileInstance;

        }

       

        
    

    
}
}

