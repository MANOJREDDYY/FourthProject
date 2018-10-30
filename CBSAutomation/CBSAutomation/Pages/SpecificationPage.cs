using AventStack.ExtentReports;
using CBSAutomation.Base_Classes;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CBSAutomation.Pages
{


    public class SpecificationPage 
    {
        
        private static ExcelFile excelFile = BrowserLaunch.getExcelFile();
        
        public static void CreateProductSpecification(IWebDriver driver,ExtentTest test, String Spec_CustName, String Spec_ID, String Spec_prodStyle, String Spec_GLcode, String Spec_MaterialGrade, String Spec_Supplier)
        {
           
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SpecificationMenu_ID, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateNew, Specification.Default))).Click();

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customer_ID, Specification.Default))).SendKeys(Spec_CustName);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.CutomerDropdwon_XPATH, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.specID_ID, Specification.Default))).SendKeys(Spec_ID);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.productstyle_ID, Specification.Default))).SendKeys(Spec_prodStyle);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ProductStyleDropdown_ID, Specification.Default)));
            Thread.Sleep(2000);
         driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.productGL_CSS, Specification.Default))).Clear();
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.productGL_CSS, Specification.Default))).SendKeys(Spec_GLcode);

            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.GL_code_IDDropdown_XPATH, Specification.Default)));

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.materialGrade_ID, Specification.Default))).SendKeys(Spec_MaterialGrade);

            //  jse.ExecuteScript("scroll(0, 350)");
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.Material_grade_dropdown_XPATH, Specification.Default)));
            IWebElement eledropdown = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Spec_supplier_ID, Specification.Default)));
            SelectElement dropdown = new SelectElement(eledropdown);
            dropdown.SelectByText(Spec_Supplier);
            test.Log(Status.Info, "Product creation with Spec ID:" + Spec_ID);

        }


       
        public static void CreateProductSpecificationsimple(IWebDriver driver,ExtentTest test,String Spec_Length, String Spec_Width, String Spec_Depth)
        {

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.lenght_ID, Specification.Default))).SendKeys(Spec_Length);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Width_ID, Specification.Default))).SendKeys(Spec_Width);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Depth_ID, Specification.Default))).SendKeys(Spec_Depth);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            string operation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_grid_XPATH, Specification.Default))).Text;
            Assert.IsTrue(operation.Equals("Make Board"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");




        }




        
        public static void CreateProductSpecificationForDiecut(IWebDriver driver,ExtentTest test, String Spec_Length, String Spec_Width, String Spec_Depth, String SpecMaterial, String PrintToolID, String DiecutToolID)
        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.lenght_ID, Specification.Default))).SendKeys(Spec_Length);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Width_ID, Specification.Default))).SendKeys(Spec_Width);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Depth_ID, Specification.Default))).SendKeys(Spec_Depth);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            string operation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_grid_XPATH, Specification.Default))).Text;
            // Assert.IsTrue(operation.Equals("Make Board"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

            jse.ExecuteScript("scroll(0, -300);");
            Thread.Sleep(2000);
            IList<IWebElement> listofOperation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllOperation_grid_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            foreach (IWebElement opelist in listofOperation)
            {
                IList<IWebElement> listofOperationtd = opelist.FindElements(By.TagName("td"));
                string operationtext = listofOperationtd[3].Text;
                if (operationtext.Equals("Die Cut"))
                {
                    IWebElement elelment = listofOperationtd[3];
                    action.DoubleClick(elelment).Build().Perform();
                    Thread.Sleep(2000);
                    //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Suppliersubmit_ID, Specification.Default))).Click();
                    //  Thread.Sleep(3000);
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ToolLink_CSS, Specification.Default))).SendKeys(DiecutToolID);
                    //  Thread.Sleep(2000);
                    CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.ToolLinkDropdown_CSS, Specification.Default)));
                    Thread.Sleep(2000);
                    //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.DieCutNumberUP_CSS, Specification.Default))).Clear();
                    // Thread.Sleep(1000);
                    //    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.DieCutNumberUP_CSS, Specification.Default))).SendKeys("1");
                    //  Thread.Sleep(2000);
                    //   driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.DieCutNumberOUT_CSS, Specification.Default))).Clear();
                    //   Thread.Sleep(1000);
                    //   driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.DieCutNumberOUT_CSS, Specification.Default))).SendKeys("1");
                    jse.ExecuteScript("scroll(0, 150);");
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitTool_CSS, Specification.Default))).Click();
                    Thread.Sleep(2000);
                    test.Log(Status.Info, "Add the Die cut tool to dicut operation with tool id:" + DiecutToolID);


                }
            }
        }

        public static void CreateProductSpecificationNext(IWebDriver driver, ExtentTest test, String Spec_Length, String Spec_Width, String Spec_Depth, String SpecMaterial, String PrintToolID)
        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.lenght_ID, Specification.Default))).SendKeys(Spec_Length);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Width_ID, Specification.Default))).SendKeys(Spec_Width);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Depth_ID, Specification.Default))).SendKeys(Spec_Depth);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            string operation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_grid_XPATH, Specification.Default))).Text;
            //  Assert.IsTrue(operation.Equals("Make Board"));
            Assert.IsTrue(operation.Equals("Buy Board"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            //****************************
            jse.ExecuteScript("scroll(0, -300);");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMatrial_ID, Specification.Default))).SendKeys(SpecMaterial);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.AddMatrialDropdown_CSS, Specification.Default)));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);
            IList<IWebElement> listofOperation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllOperation_grid_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            foreach (IWebElement opelist in listofOperation)
            {
                IList<IWebElement> listofOperationtd = opelist.FindElements(By.TagName("td"));
                string operationtext = listofOperationtd[3].Text;
                if (operationtext.Equals("Purchase Product") || operationtext.Equals("Drop Ship"))
                {
                    listofOperationtd[3].Click();
                    driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_Delete_XPATH, Specification.Default))).Click();

                }
                else if (operationtext.Equals("Purchase Goods"))
                {

                    IWebElement elelment = listofOperationtd[3];
                    action.DoubleClick(elelment).Build().Perform();
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Suppliersubmit_ID, Specification.Default))).Click();
                    Thread.Sleep(2000);
                }

                else if (operationtext.Equals("Print"))
                {

                    IWebElement elelment = listofOperationtd[3];
                    action.DoubleClick(elelment).Build().Perform();
                    Thread.Sleep(2000);
                    //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Suppliersubmit_ID, Specification.Default))).Click();
                    //  Thread.Sleep(3000);
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ToolLink_CSS, Specification.Default))).SendKeys(PrintToolID);

                    //  Thread.Sleep(2000);
                    CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.ToolLinkDropdown_CSS, Specification.Default)));
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.NUmberOfColour_ID, Specification.Default))).Clear();
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.NUmberOfColour_ID, Specification.Default))).SendKeys("1");
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitTool_CSS, Specification.Default))).Click();
                    Thread.Sleep(2000);
                    jse.ExecuteScript("window.scrollBy(2500, 0)");
                    Thread.Sleep(1000);

                    IWebElement listofMaterialgrid = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllMaterial_grid_XPATH, Specification.Default)));

                    IList<IWebElement> listofMaterial = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllMaterial_grid_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
                    foreach (IWebElement matlist in listofMaterial)
                    {
                        IList<IWebElement> listofMattd = matlist.FindElements(By.TagName("td"));
                        string Materialtext = listofMattd[3].Text;
                        if (Materialtext.Equals(SpecMaterial))
                        {
                            // jse.ExecuteScript("window.scrollTo(10, 0)");
                            //   Thread.Sleep(1000);

                            IWebElement elementvalue = listofMattd[3];
                            //  action.DoubleClick(elementvalue).Perform();
                            new Actions(driver).DoubleClick(elementvalue).Build().Perform();
                            Thread.Sleep(2000);


                            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ColourPercentage_ID, Specification.Default))).Clear();
                            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ColourPercentage_ID, Specification.Default))).SendKeys("1");
                            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ColourUnitsWasted_ID, Specification.Default))).Clear();
                            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ColourUnitsWasted_ID, Specification.Default))).SendKeys("1");

                            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ColourPercentageSubmit_CSS, Specification.Default))).Click();
                            Thread.Sleep(2000);
                        }

                    }
                }
            }
        }




        public static void CreateProductBusinessSpecificationNext(IWebDriver driver,ExtentTest test)
        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IWebElement elerouets = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CheckRoutings_CSS, Specification.Default)));
            if (elerouets.Enabled)
            {

                elerouets.Click();
                Thread.Sleep(3000);
            }
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default)));
            int routeslist = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default))).FindElements(By.TagName("li")).Count;
            Assert.IsNotNull(routeslist);
            IWebElement closeroute = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RouteCLose_ID, Specification.Default)));
            closeroute.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            IWebElement BussSpec = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            if (BussSpec.Enabled)
            {
                BussSpec.Click();


                Thread.Sleep(2000);
            }



            if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.ProductDataestimate_ID, Specification.Default))))
            {

                if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.MaterialAddonInSpec_ID, Specification.Default))))

                {
                    IWebElement materialaddon = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.MaterialAddon_XPATH, Specification.Default)));
                    action.DoubleClick(materialaddon).Build().Perform();
                    ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('ui-datepicker-div').removeAttribute('readonly',0);"); // Enables the from date box

                    IWebElement fromDateBox = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Datpicker_ID, Specification.Default)));
                    fromDateBox.Clear();
                    DateTime startDate = DateTime.Today;
                    string OrdDuetDate = startDate.ToString("MM/dd/yyyy");
                    fromDateBox.SendKeys(OrdDuetDate);
                }
            }
            if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))))

            {
                driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))).Click();

            }

        }





        public static void CreateBusinessSpecificationReset(IWebDriver driver, ExtentTest test, String CostModel, String Qty, String Unitization)

        {
            Actions action = new Actions(driver);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click(); ;

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);

                    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            IWebElement tablelist = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
        }

        //*****&&&&
        public static void SaveBusinessSpecification(IWebDriver driver,ExtentTest test)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jse9 = (IJavaScriptExecutor)driver;
            jse9.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(3000);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ApprovePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(4000);

            Boolean check = false;
            string approve = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Approvetest_CSS, Specification.Default))).Text;
            if (approve.Equals("Price Approved successfully"))
            {
                check = true;

            }
            if (check)
            {
                driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
                Thread.Sleep(2000);


               
                    IWebElement setmanf= driver.FindElement(By.Id(PropertyReader.GetProperty(Property.setasManufacturable_ID, Specification.Default)));
                    Thread.Sleep(2000);
                if (setmanf.Enabled) { 
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.setasManufacturable_ID, Specification.Default))).Click();
                IAlert alertmanufact = driver.SwitchTo().Alert();

                    alertmanufact.Accept();
                    Thread.Sleep(2000);

                }
               
               
            }

            Thread.Sleep(1000);

            jse9.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            // string estimatecost = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.EstimateTable_XPATH, Specification.Default))).Text;


            // return estimatecost;
        }

        //***&&&


        public static string SaveBusinessSpecificationAlertValidation(IWebDriver driver, ExtentTest test)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(3000);
            IAlert alertWarning = driver.SwitchTo().Alert();
            alertWarning.Accept();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ApprovePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IAlert alertWarning1 = driver.SwitchTo().Alert();
            alertWarning1.Accept();
            Thread.Sleep(2000);
            IAlert alertWarning2 = driver.SwitchTo().Alert();
            alertWarning2.Accept();
            Thread.Sleep(2000);



            Boolean check = false;
            string approve = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Approvetest_CSS, Specification.Default))).Text;
            if (approve.Equals("Price Approved successfully"))
            {
                check = true;

            }
            if (check)
            {
                driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id(PropertyReader.GetProperty(Property.setasManufacturable_ID, Specification.Default))).Click();
                Thread.Sleep(2000);
                IAlert alertmanufact = driver.SwitchTo().Alert();
                alertmanufact.Accept();
            }

            Thread.Sleep(1000);

            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            string estimatecost = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.EstimateTable_XPATH, Specification.Default))).Text;


            return estimatecost;
        }










        public static void CreateProductSpecificationAndAddBundleStrapping(IWebDriver driver,ExtentTest test, String strappingmat, string MaterialCost, string MaterialName)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //   jse.ExecuteScript("scroll(0, -300);");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMatrial_ID, Specification.Default))).SendKeys(strappingmat);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.Bundlestarpping_CSS, Specification.Default)));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IWebElement elerouets = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CheckRoutings_CSS, Specification.Default)));
            if (elerouets.Enabled)
            {
                // action.MoveToElement(elerouets).Build().Perform();
                elerouets.Click();
                Thread.Sleep(3000);
            }
            CommonFunctions.WaitTillElementPresent(driver, By.Id( PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default)));
            int routeslist = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default))).FindElements(By.TagName("li")).Count;
            Assert.IsNotNull(routeslist);
            IWebElement closeroute = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RouteCLose_ID, Specification.Default)));
            closeroute.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            IWebElement BussSpec = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            test.Log(Status.Info, "Add the bundle trapping operation with new strapping material");
            if (BussSpec.Enabled)
            {
                BussSpec.Click();
                //  action.MoveToElement(BussSpec).Click().Perform();

                Thread.Sleep(2000);
            }

            //  public static void CreateSpecProductDataEstimate() {

            if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.ProductDataforEstimateMat_ID, Specification.Default))))
            {

                if (CommonFunctions.TryFindElement(driver, By.XPath(PropertyReader.GetProperty(Property.StrappingprodData_ID, Specification.Default))))
                //  if (CommonFunctions.IsElementDisplayed(driver, By.Id(PropertyReader.GetProperty(Property.MaterialAddonInSpec_ID, Specification.Default))))
                //  if (CommonFunctions.IfexistsElement(By.XPath(PropertyReader.GetProperty(Property.MaterialAddon_XPATH, Specification.Default)))) 

                {

                    IWebElement Bundlematerialaddon = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.StrappingprodData_ID, Specification.Default)));
                    jse.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
           "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
           "arguments[0].dispatchEvent(evt);", Bundlematerialaddon);

                    //action.DoubleClick(Bundlematerialaddon).Build().Perform();
                    Thread.Sleep(2000);
                    // Enables the from date box
                    IWebElement fmatid = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Bundlestrappingmaterial_ID, Specification.Default)));
                    fmatid.Clear();
                    fmatid.SendKeys(MaterialName);

                    IWebElement fromDateBoxx = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.StappingCost_ID, Specification.Default)));
                    fromDateBoxx.Clear();

                    fromDateBoxx.SendKeys(MaterialCost);
                    IWebElement fromDateBox1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CostStartDate_ID, Specification.Default)));
                    fromDateBox1.Clear();
                    DateTime startDate = DateTime.Today;
                    string OrdDuetDate = startDate.ToString("MM/dd/yyyy");
                    fromDateBox1.SendKeys(OrdDuetDate);
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CostSubmit_CSS, Specification.Default))).Click();
                }
                if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))))

                {
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))).Click();
                   
                }
                test.Log(Status.Info, "Add the cost to  new strapping material and save the product");
            }
        }


        public static string CreateBusinessSpecificationwithPricingType(IWebDriver driver,ExtentTest test, String CostModel, String Qty, String Unitization)

        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);
            Thread.Sleep(2000);
            string shipstr2 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ShipToCustomer_ID, Specification.Default))).GetAttribute("value");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click(); ;

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);
                    IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
                    jse2.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
           "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
           "arguments[0].dispatchEvent(evt);", liList1[2]);


                    //    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //****************pricing type******************************
            IWebElement Selectlist = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.PricingType_CSS, Specification.Default)));
            SelectElement dropdown = new SelectElement(Selectlist);
            dropdown.SelectByText("Range Pricing");
            Thread.Sleep(2000);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("window.scrollBy(0,300)", "");
            Thread.Sleep(2000);
            // driver.FindElement(By.Id(PropertyReader.GetProperty(Property.businesdiscount_ID, Specification.Default))).Click();

            // IWebElement DIVelement2 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PricingMetricvalue_ID, Specification.Default)));

            // DIVelement2.Clear();
            // DIVelement2.SendKeys(PricingMtericValue);
            Thread.Sleep(2000);
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement DIVelement1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.addqty_ID, Specification.Default)));

            jse.ExecuteScript("arguments[0].click();", DIVelement1);

            Thread.Sleep(2000);
            IWebElement FromTo = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));
            IList<IWebElement> FromTolist = FromTo.FindElements(By.TagName("tr"));
            //  foreach(IWebElement FromListEach in FromTolist)
            //   {
            IList<IWebElement> FromTolisttd = FromTolist[0].FindElements(By.TagName("td"));
            FromTolisttd[0].FindElement(By.TagName("input")).Clear();
            FromTolisttd[0].FindElement(By.TagName("input")).SendKeys("1000");
            FromTolisttd[1].FindElement(By.TagName("input")).SendKeys("2499");
            IList<IWebElement> FromTolisttd1 = FromTolist[1].FindElements(By.TagName("td"));
            FromTolisttd1[0].FindElement(By.TagName("input")).SendKeys("2500");
            FromTolisttd1[1].FindElement(By.TagName("input")).SendKeys("5000");

            //   }
            //****************pricing type*end *****************************

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
            Thread.Sleep(2000);
            string pricevalue = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CosttableValues_CSS, Specification.Default))).Text;
           string pricevalue1 = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CosttableValues1_CSS, Specification.Default))).Text;
            Assert.IsTrue(pricevalue.Contains("1000"));
           Assert.IsTrue(pricevalue1.Contains("2500"));
           
            Thread.Sleep(2000);

          
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            jse.ExecuteScript("window.scrollBy(0,-400)", "");
            Thread.Sleep(1000);
            string Capturefilename = ImageComparision.ScreenShotRegionwithPath(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)), "Estimate1ForRnagePrice");
            ImageComparision.ImageComparisonDiffrance(Capturefilename, "Estimate2ForRangePrice", "DiffEstimate1ForRangePrice");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ApprovePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(1000);

            test.Log(Status.Info, "save the estimate cost with Range of quantities for Estimate pricing");



            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.FactoryTicket_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            List<String> tabs2 = new List<String>(driver.WindowHandles);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(1000);
            driver.Close();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[0]);
            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.EstimateCost_LINK, Specification.Default))).Click();
            Thread.Sleep(2000);
            IWebElement Esttable = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CostEstimate_XPATH, Specification.Default)));
         string  RouteCostFixed=  Esttable.FindElements(By.TagName("td"))[4].Text;
           string RouteCostVariable = Esttable.FindElements(By.TagName("td"))[5].Text;

            IJavaScriptExecutor jse3 = (IJavaScriptExecutor)driver;
            jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
    "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
    "arguments[0].dispatchEvent(evt);", Esttable);
            jse3.ExecuteScript("window.scrollBy(0,300)", "");
            IWebElement Esttable2 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.RouteList_XPATH, Specification.Default)));
                IList<IWebElement> Esttable2list = Esttable2.FindElements(By.TagName("tr"));
            foreach (IWebElement elem3 in Esttable2list.Skip(1))
            {

                jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
                   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
                   "arguments[0].dispatchEvent(evt);", elem3);
                jse3.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                IWebElement Esttable3 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.materialList_XPATH, Specification.Default)));
                IList<IWebElement> Esttable3list = Esttable3.FindElements(By.TagName("tr"));
                foreach (IWebElement elem4 in Esttable3list.Skip(1))
                {
                    jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
                       "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
                       "arguments[0].dispatchEvent(evt);", elem4);
                    jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    IWebElement Esttable4 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CostMaterialList_XPATH, Specification.Default)));
                    IList<IWebElement> Esttable4list = Esttable4.FindElements(By.TagName("td"));
                    string materialnameCost = Esttable4list[1].Text;
                    string materialCostfixed = Esttable4list[2].Text;
                    string materialCostVariable = Esttable4list[3].Text;

                }

            }
            return shipstr2;
        }


        public static void CreateProductSpecificationForRSCestimate2(IWebDriver driver,ExtentTest test, String Spec_Length, String Spec_Width, String Spec_Depth, String SpecMaterialType, string MaterialCost)
        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.lenght_ID, Specification.Default))).SendKeys(Spec_Length);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Width_ID, Specification.Default))).SendKeys(Spec_Width);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Depth_ID, Specification.Default))).SendKeys(Spec_Depth);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            string operation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_grid_XPATH, Specification.Default))).Text;
            // Assert.IsTrue(operation.Equals("Make Board"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);

            jse.ExecuteScript("scroll(0, -350);");
            Thread.Sleep(2000);

        
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMatrial_ID, Specification.Default))).SendKeys(SpecMaterialType);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.InkColourMaterial_XPATH, Specification.Default)));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);
            //*****************************************


            IWebElement toolmaterial = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ProductMaterialInk_XPATH, Specification.Default)));
            IList<IWebElement> toolmateriallist = toolmaterial.FindElements(By.TagName("tr"));
            foreach (IWebElement forele in toolmateriallist)
            {
                IList<IWebElement> toolmateriallist1 = forele.FindElements(By.TagName("td"));
                foreach (IWebElement forele1 in toolmateriallist1)
                {
                    string inkname = forele1.Text;
                    if (inkname.Contains("InkColor"))
                    {
                        action.DoubleClick(forele1).Build().Perform();
                        Thread.Sleep(3000);
                      
                        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PercentCoverage_ID, Specification.Default))).Clear();
                        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PercentCoverage_ID, Specification.Default))).SendKeys("1");
                        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.NumberOfCostUnitWasted_ID, Specification.Default))).Clear();
                        driver.FindElement(By.Id(PropertyReader.GetProperty(Property.NumberOfCostUnitWasted_ID, Specification.Default))).SendKeys("1");
                        driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitCoverage_CSS, Specification.Default))).Click();

                    }
                }

            }
            test.Log(Status.Pass, "Add InkColor material and print operation");
            //***********************


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IWebElement elerouets = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CheckRoutings_CSS, Specification.Default)));
            if (elerouets.Enabled)
            {
                // action.MoveToElement(elerouets).Build().Perform();
                elerouets.Click();
                Thread.Sleep(3000);
            }
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default)));
            int routeslist = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RoutingList_ID, Specification.Default))).FindElements(By.TagName("li")).Count;
            Assert.IsNotNull(routeslist);
            IWebElement closeroute = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.RouteCLose_ID, Specification.Default)));
            closeroute.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            IWebElement BussSpec = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Bussiness_Spec_CSS, Specification.Default)));
            if (BussSpec.Enabled)
            {
                BussSpec.Click();


                Thread.Sleep(2000);
            }
           


            if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.ProductDataforEstimateMat_ID, Specification.Default))))
            {

                if (CommonFunctions.TryFindElement(driver, By.XPath(PropertyReader.GetProperty(Property.StrappingprodData_ID, Specification.Default))))
                //  if (CommonFunctions.IsElementDisplayed(driver, By.Id(PropertyReader.GetProperty(Property.MaterialAddonInSpec_ID, Specification.Default))))
                //  if (CommonFunctions.IfexistsElement(By.XPath(PropertyReader.GetProperty(Property.MaterialAddon_XPATH, Specification.Default)))) 

                {

                    IWebElement Bundlematerialaddon = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.StrappingprodData_ID, Specification.Default)));
                    jse.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
           "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
           "arguments[0].dispatchEvent(evt);", Bundlematerialaddon);

                    //action.DoubleClick(Bundlematerialaddon).Build().Perform();
                    Thread.Sleep(2000);
                    // Enables the from date box

                    IWebElement fromDateBoxx = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.StappingCost_ID, Specification.Default)));
                    fromDateBoxx.Clear();

                    fromDateBoxx.SendKeys(MaterialCost);
                    IWebElement fromDateBox1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CostStartDate_ID, Specification.Default)));
                    fromDateBox1.Clear();
                    DateTime startDate = DateTime.Today;
                    string OrdDuetDate = startDate.ToString("MM/dd/yyyy");
                    fromDateBox1.SendKeys(OrdDuetDate);
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CostSubmit_CSS, Specification.Default))).Click();
                    Thread.Sleep(2000);


                    string toolname = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ProdDataToolName_ID, Specification.Default))).Text;
                    IWebElement Toolmaterialaddon = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.ProdDataToolType_ID, Specification.Default)));
                    jse.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
           "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
           "arguments[0].dispatchEvent(evt);", Toolmaterialaddon);


                    Thread.Sleep(2000);


                    IWebElement toolfromDateBoxx1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProdDataToolID_ID, Specification.Default)));
                    //  if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.ProdDataToolID_ID, Specification.Default))))
                    //  {
                    toolfromDateBoxx1.Clear();
                    toolfromDateBoxx1.SendKeys(toolname);
                    IWebElement toolfromDateBoxxcost = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.StappingCost_ID, Specification.Default)));
                    toolfromDateBoxxcost.Clear();
                    toolfromDateBoxxcost.SendKeys(MaterialCost);

                    Thread.Sleep(2000);
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ToolPricingType_ID, Specification.Default))).SendKeys("Buy and Bill");

                    CommonFunctions.WaitTillElementPresent(driver, By.CssSelector(PropertyReader.GetProperty(Property.ToolPricingTypeDropDown_ID, Specification.Default)));
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ToolPricingTypeSubmit_ID, Specification.Default))).Click();
                    // }

                }
                if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))))

                {
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveProdEstimate_ID, Specification.Default))).Click();

                }

                test.Log(Status.Pass, "add cost and date to new InkColor material ");
            }
        }


        public static void CreateBusinessSpecificationEstimate2(IWebDriver driver,ExtentTest test, String CostModel, String Qty, String Unitization, String PricingMtericValue, string bussDisc, string shipcust, string shipmtd)

        {
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.warehouse_ID, Specification.Default))).SendKeys("GOS");
            CommonFunctions.WaitTillElementPresent(driver, By.XPath(PropertyReader.GetProperty(Property.WarehouseDropdown_XPATH, Specification.Default)));
            string shipstr = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ShipToCustomer_ID, Specification.Default))).GetAttribute("value");


            IWebElement SelectShipmtd = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.shipmentMethod_ID, Specification.Default)));
            SelectElement dropdown11 = new SelectElement(SelectShipmtd);
            string shipmtdstr = dropdown11.SelectedOption.Text;
            Assert.IsTrue(shipstr.Contains(shipcust.TrimStart(' ')));
            string shipmtd1 = shipmtd.TrimStart(' ');
            Assert.IsTrue(shipmtdstr.Contains(shipmtd1.TrimEnd(')')));
test.Log(Status.Pass, "shipping mtd and shipping address is same from customer");

            Thread.Sleep(2000);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click();


            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);
                    IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
                    jse2.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
           "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
           "arguments[0].dispatchEvent(evt);", liList1[2]);


                    //    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //****************pricing type******************************
            IWebElement Selectlist = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.PricingType_CSS, Specification.Default)));
            SelectElement dropdown = new SelectElement(Selectlist);
            dropdown.SelectByText("Quantity Pricing");
            Thread.Sleep(2000);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("window.scrollBy(0,300)", "");
            Thread.Sleep(2000);
            // driver.FindElement(By.Id(PropertyReader.GetProperty(Property.businesdiscount_ID, Specification.Default))).Click();

            // IWebElement DIVelement2 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PricingMetricvalue_ID, Specification.Default)));

            // DIVelement2.Clear();
            // DIVelement2.SendKeys(PricingMtericValue);
            string businessdicspec = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.businesdiscountinspec_ID, Specification.Default))).GetAttribute("value");
            Assert.IsTrue(businessdicspec.Contains(bussDisc.TrimStart('(')));
            

            Thread.Sleep(2000);
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement DIVelement1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.addqty_ID, Specification.Default)));

            jse.ExecuteScript("arguments[0].click();", DIVelement1);

            Thread.Sleep(2000);
            IWebElement FromTo = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));
            IList<IWebElement> FromTolist = FromTo.FindElements(By.TagName("tr"));
            //  foreach(IWebElement FromListEach in FromTolist)
            //   {
            IList<IWebElement> FromTolisttd = FromTolist[0].FindElements(By.TagName("td"));

            IList<IWebElement> FromTolisttd1 = FromTolist[1].FindElements(By.TagName("td"));
            FromTolisttd1[0].FindElement(By.TagName("input")).SendKeys("2000");

            test.Log(Status.Pass, "estimate genrated for Qauntitiy pricing for 1000 and 2000  ");
            //   }
            //****************pricing type*end *****************************

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
            Thread.Sleep(2000);
           // string pricevalue = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CosttableValues_CSS, Specification.Default))).Text;
           // string pricevalue1 = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.CosttableValues1_CSS, Specification.Default))).Text;
          //  Assert.IsTrue(pricevalue.Contains("1000"));
          //  Assert.IsTrue(pricevalue1.Contains("2000"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ApprovePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.FactoryTicket_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            List<String> tabs2 = new List<String>(driver.WindowHandles);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(1000);
            driver.Close();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[0]);

            driver.FindElement(By.LinkText(PropertyReader.GetProperty(Property.EstimateCost_LINK, Specification.Default))).Click();
            Thread.Sleep(2000);
            IWebElement Esttable = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CostEstimate_XPATH, Specification.Default)));
            string RouteCostFixed = Esttable.FindElements(By.TagName("td"))[3].Text;
            string RouteCostVariable = Esttable.FindElements(By.TagName("td"))[4].Text;

            IJavaScriptExecutor jse3 = (IJavaScriptExecutor)driver;
            jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
    "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
    "arguments[0].dispatchEvent(evt);", Esttable);
            jse3.ExecuteScript("window.scrollBy(0,300)", "");
            IWebElement Esttable2 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.RouteList_XPATH, Specification.Default)));
            IList<IWebElement> Esttable2list = Esttable2.FindElements(By.TagName("tr"));
            foreach (IWebElement elem3 in Esttable2list.Skip(1))
            {

                jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
                   "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
                   "arguments[0].dispatchEvent(evt);", elem3);
                jse3.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                IWebElement Esttable3 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.materialList_XPATH, Specification.Default)));
                IList<IWebElement> Esttable3list = Esttable3.FindElements(By.TagName("tr"));
                foreach (IWebElement elem4 in Esttable3list.Skip(1))
                {
                    jse3.ExecuteScript("var evt = document.createEvent('MouseEvents');" +
                       "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" +
                       "arguments[0].dispatchEvent(evt);", elem4);
                    jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    IWebElement Esttable4 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.CostMaterialList_XPATH, Specification.Default)));
                    IList<IWebElement> Esttable4list = Esttable4.FindElements(By.TagName("td"));
                    string materialnameCost = Esttable4list[1].Text;
                    string materialCostfixed = Esttable4list[2].Text;
                    string materialCostVariable = Esttable4list[3].Text;

                }
            }







                }





        public static void CreateBusinessSpecificationSameCustomer(IWebDriver driver, ExtentTest test, string Spec_CustName)
        {Actions action = new Actions(driver);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.createsameproduct_ID, Specification.Default))).Click();
            string samecustomername = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customer_ID, Specification.Default))).GetAttribute("value");
            Assert.IsTrue(samecustomername.Equals(Spec_CustName));
        }


        public static void CreateBusinessSpecificationNewCustomer(IWebDriver driver, ExtentTest test)
        {

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.createnewproduct_ID, Specification.Default))).Click();
            string samecustomername = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customer_ID, Specification.Default))).GetAttribute("value");
            Assert.IsTrue(samecustomername.Equals(""));
        }




        public static string CreateBussSpecWithoutApproveEst3(IWebDriver driver, ExtentTest test, String CostModel, String Qty, String Unitization)

        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.warehouse_ID, Specification.Default))).SendKeys("GOS");
            Thread.Sleep(2000);
            string shipstr1 = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ShipToCustomer_ID, Specification.Default))).GetAttribute("value");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);

                    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            IWebElement Selectlist = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.PricingType_CSS, Specification.Default)));
            SelectElement dropdown = new SelectElement(Selectlist);
            dropdown.SelectByText("Flat Pricing");
            Thread.Sleep(2000);

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
            Thread.Sleep(2000);
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SavePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ApprovePriceList_ID, Specification.Default))).Click();
            Thread.Sleep(1000);


            Thread.Sleep(12000);
            Boolean check = false;
            string approve = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Approvetest_CSS, Specification.Default))).Text;
            if (approve.Equals("Price Approved successfully"))
            {
                check = true;
            }
            if (check)
            {
                driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.SaveAlert_XPATH, Specification.Default))).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id(PropertyReader.GetProperty(Property.setasManufacturable_ID, Specification.Default))).Click();
                Thread.Sleep(2000);
                IAlert alertmanufact = driver.SwitchTo().Alert();
                alertmanufact.Accept();
            }

            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AllBusinessSpec_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            IJavaScriptExecutor jse5 = (IJavaScriptExecutor)driver;
            jse5.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //**************approve price*****************************************
            IWebElement listofSpec = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllbusinesspsecApprove_XPATH, Specification.Default)));


            // IList<IWebElement> listofSpec1= listofSpec.FindElements(By.TagName("tr"));
            // IWebElement listofSpec2 = listofSpec1.Last();
            // IList <IWebElement> listofSpectd = listofSpec2.FindElements(By.TagName("td"));
            // listofSpectd.First().FindElement(By.TagName("a")).FindElement(By.TagName("span")).Click();
            //  listofSpectd.Last().FindElement(By.TagName("button")).Click();
            //  Thread.Sleep(2000);

            //  listofSpectd.First().FindElement(By.CssSelector("td.ui-sgcollapsed.sgcollapsed > a > span.ui-icon.ui-icon-plus")).Click();




            // IList <IWebElement> listofSpec1again = listofSpec.FindElements(By.TagName("tr"));
            // IWebElement listofSpec2again = listofSpec1again.Last();
            //listofSpec2again.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.allspectable_CSS, Specification.Default)));

            //**************approve price end *****************************************


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.allowAnyShipTo_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.createestimatebutton_ID, Specification.Default))).Click();
            return shipstr1;

        }




        public static void RewiseEstimateForExsistingEstimate(IWebDriver driver, ExtentTest test,string filterSpecID)
        {

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SpecificationMenu_ID, Specification.Default))).Click();

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.filterByProduct_ID, Specification.Default))).SendKeys(filterSpecID);
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Estimatefilter_ID, Specification.Default))).Click();

            Thread.Sleep(2000);
            IWebElement estimtelist = driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SpecFilterTable_CSS, Specification.Default)));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            estimtelist.Click();

            if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.ProductDataestimate_ID, Specification.Default))))
            {

                if (CommonFunctions.TryFindElement(driver, By.Id(PropertyReader.GetProperty(Property.Save_ProductEstimate_ID, Specification.Default))))

                {
                    driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Save_ProductEstimate_ID, Specification.Default))).Click();
                    Thread.Sleep(2000);

                }
            }
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.createestimatebutton_ID, Specification.Default))).Click();

            List<String> tabs2 = new List<String>(driver.WindowHandles);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(1000);

        }


        public static void CopyBusinessSpec(IWebDriver driver, ExtentTest test, String CostModel, String Qty, String Unitization)

        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);



            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click();




            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);

                    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            IWebElement tablelist = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));

            jse.ExecuteScript("scroll(0, -500);");
            Thread.Sleep(2000);
            string posturl = driver.Url;
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CopyExsistingEstimate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            string presenturl = driver.Url;

            var pattern = "=";
            var match = Regex.Match(presenturl, pattern, RegexOptions.RightToLeft);
            if (match.Success)
            {
                var result1 = posturl.Substring(7, match.Index);
                string substr1 = result1.Substring(result1.Length - 6);
                // int linkvalue1= Convert.ToInt32(substr1);
                int linkvalue1 = int.Parse(substr1);

                int linkvalueAdd = linkvalue1 + 1;
                var result = presenturl.Substring(7, match.Index);
                string substr = result.Substring(result.Length - 6);

                //  int linkvalue2 = Convert.ToInt32(substr);
                int linkvalue2 = int.Parse(substr);
                if (linkvalue2 == linkvalueAdd)
                {
                    Assert.Pass();
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            IWebElement tablelist1 = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
        }




        public static void CreateHSCProduct(IWebDriver driver, ExtentTest test,String Spec_Length, String Spec_Width, String Spec_Depth, String SpecMaterial, String PartialDieToolID)
        {
            Actions action = new Actions(driver);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.lenght_ID, Specification.Default))).SendKeys(Spec_Length);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Width_ID, Specification.Default))).SendKeys(Spec_Width);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Depth_ID, Specification.Default))).SendKeys(Spec_Depth);


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.NumberPerBundle_ID, Specification.Default))).SendKeys("2");


            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

            string operation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_grid_XPATH, Specification.Default))).Text;
            Assert.IsTrue(operation.Equals("Make Board"));
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            //****************************
            jse.ExecuteScript("scroll(0, -300);");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMatrial_ID, Specification.Default))).SendKeys(SpecMaterial);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.AddMatrialDropdown_CSS, Specification.Default)));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);
            IList<IWebElement> listofOperation = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.AllOperation_grid_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            foreach (IWebElement opelist in listofOperation)
            {
                IList<IWebElement> listofOperationtd = opelist.FindElements(By.TagName("td"));
                string operationtext = listofOperationtd[3].Text;
                if (operationtext.Equals("Purchase Product") || operationtext.Equals("Drop Ship"))
                {
                    listofOperationtd[3].Click();
                    driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.Operation_Delete_XPATH, Specification.Default))).Click();

                }


                else if (operationtext.Equals("Apply Tooling"))
                {

                    IWebElement elelment = listofOperationtd[3];
                    action.DoubleClick(elelment).Build().Perform();
                    Thread.Sleep(2000);
                    //  driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Suppliersubmit_ID, Specification.Default))).Click();
                    //  Thread.Sleep(3000);
                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.ToolLink_CSS, Specification.Default))).SendKeys(PartialDieToolID);
                    //  Thread.Sleep(2000);
                    CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.ToolLinkDropdown_CSS, Specification.Default)));
                    Thread.Sleep(2000);

                    driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitTool_CSS, Specification.Default))).Click();
                    Thread.Sleep(2000);
                }


            }
}

        public static void CreateAssemledProductSpecification(IWebDriver driver,ExtentTest test, String Spec_CustName, String Spec_ID, String Spec_prodStyle, String Spec_GLcode, String Spec_MaterialGrade, String Spec_Supplier,String Child1SpecID,String Child2SpecID)
        {
           
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ProductMenu_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SpecificationMenu_ID, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateNew, Specification.Default))).Click();

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.customer_ID, Specification.Default))).SendKeys(Spec_CustName);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.CutomerDropdwon_XPATH, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.specID_ID, Specification.Default))).SendKeys(Spec_ID);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.productstyle_ID, Specification.Default))).SendKeys(Spec_prodStyle);
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.ProductStyleDropdown_ID, Specification.Default)));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.productGL_CSS, Specification.Default))).SendKeys(Spec_GLcode);

            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.GL_code_IDDropdown_XPATH, Specification.Default)));

       

            //  jse.ExecuteScript("scroll(0, 350)");
           
           

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Recalculate_ID, Specification.Default))).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,300)", "");
            test.Log(Status.Info, "Product creation with Spec ID:" + Spec_ID);
            //&&&&&4444
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.AddMatrial_ID, Specification.Default))).SendKeys("Glue");
            CommonFunctions.WaitAndClickDropDown(driver, By.XPath(PropertyReader.GetProperty(Property.Bundlestarpping_CSS, Specification.Default)));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.AssembledProductKit_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.addproductKit_ID, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ChildProductSpec_ID, Specification.Default))).SendKeys(Child1SpecID);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.ChildSpec_CSS, Specification.Default)));
            
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CostPercentage_ID, Specification.Default))).SendKeys("50");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PartMultiplier_ID, Specification.Default))).SendKeys("1");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PartDivider_ID, Specification.Default))).SendKeys("1");
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitChildPart_CSS, Specification.Default))).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.addproductKit_ID, Specification.Default))).Click();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.ChildProductSpec_ID, Specification.Default))).SendKeys(Child2SpecID);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.ChildSpec_CSS, Specification.Default)));

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CostPercentage_ID, Specification.Default))).SendKeys("50");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PartMultiplier_ID, Specification.Default))).SendKeys("1");
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.PartDivider_ID, Specification.Default))).SendKeys("1");
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.SubmitChildPart_CSS, Specification.Default))).Click();
            Thread.Sleep(2000);
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.validate_Save_Button_ID, Specification.Default))).Click();
            Thread.Sleep(2000);

        }


        public static void CreateAssemblyBusinessSpecificationReset(IWebDriver driver, ExtentTest test, String CostModel, String Qty, String Unitization)

        {
            Actions action = new Actions(driver);

            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).Clear();
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.costmodel_ID, Specification.Default))).SendKeys(CostModel);
            CommonFunctions.WaitAndClickDropDown(driver, By.CssSelector(PropertyReader.GetProperty(Property.costmodeldropdown_CSS, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Qauntity_ID, Specification.Default))).SendKeys(Qty);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SelectUnitization_ID, Specification.Default))).Click(); ;

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.UnitizationGrid_ID, Specification.Default)));
            IList<IWebElement> liList = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.UnitizationTable_XPATH, Specification.Default))).FindElements(By.TagName("tr"));
            int countlist = liList.Count;
            for (int i = 1; i < liList.Count; i++)
            {
                IList<IWebElement> liList1 = liList[i].FindElements(By.TagName("td"));
                string boxpattern = liList1[1].Text;
                if (boxpattern.Equals(Unitization))
                {
                    Thread.Sleep(2000);

                    action.DoubleClick(liList1[2]).Build().Perform();
                }
                else
                    break;


            }
            IWebElement unitele = driver.FindElement(By.Id(PropertyReader.GetProperty(Property.UnitizationModel_ID, Specification.Default)));
            unitele.SendKeys(Keys.Escape);
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.SaveAndGenerateRoutes_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.RoutesGenrated_ID, Specification.Default)));
            driver.FindElement(By.CssSelector(PropertyReader.GetProperty(Property.Split_CSS, Specification.Default))).Click();
            IList<IWebElement> splitlist = driver.FindElements(By.XPath(PropertyReader.GetProperty(Property.AssembleSplit_XPATH, Specification.Default)));
          
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.CreateEstimatePrice_ID, Specification.Default))).Click();
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
           
            IWebElement tablelist = driver.FindElement(By.XPath(PropertyReader.GetProperty(Property.FromToTable_XPATH, Specification.Default)));

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.calculate_price_ID, Specification.Default)));
            driver.FindElement(By.Id(PropertyReader.GetProperty(Property.Calculate_Price_ID, Specification.Default))).Click();

            CommonFunctions.WaitTillElementPresent(driver, By.Id(PropertyReader.GetProperty(Property.EstimatePriceList_ID, Specification.Default)));
        }

    }
}

            
        
    




