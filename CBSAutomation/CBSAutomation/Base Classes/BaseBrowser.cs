using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSAutomation
{

    public class BaseBrowser
    {
        public static IWebDriver driver { get; set; }

        public void launchapplication(String url)
        {
            driver.Url = url;
        }


    } 
      
}
