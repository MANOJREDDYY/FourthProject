using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using System.Drawing;
using System.Globalization;
using System.Drawing.Imaging;
using ImageMagick;
using NUnit.Framework;

namespace CBSAutomation.Base_Classes
{
    public static class ImageComparision
    {

        public static void ImageComparisonDiffrance(String File1, String File2, String Difference)
        {
            string cDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            cDirectory = cDirectory.Remove(cDirectory.IndexOf("\\bin\\Debug"));
            string filePath = (cDirectory + "\\ImageComparision\\CBSInputTestData.xls");
            String ImageMagick_Loc = filePath;


            string sFile1 = cDirectory + "\\ImageComparision\\ScreenshotImages\\" + File1;//+".Png";
              string sFile2 = cDirectory + "\\ImageComparision\\BeforeImages\\" + File2 + ".PNG";
            //  string Differencepath = "\\ImageComparision\\DiiferanceImages\\" + Difference + ".PNG";
          //  string sFile1 = "C:\\Temp\\" + File1 + ".Png";
         //   string sFile2 = "C:\\Temp\\" + File2;// + ".Png";
           string Differencepath = "C:\\Temp\\" + Difference + ".Png";
           


            var imgDiff = new MagickImage();
            MagickImage img1 = new MagickImage(sFile1);
            MagickImage img2 = new MagickImage(sFile2);
         
            // MagickImage img2 = new MagickImage("C:\\Temp\\cap1.Png");
            double result;
           
            img1.Crop(img2.BaseWidth, img2.BaseHeight, Gravity.Northwest);
         //   img2.Crop(img1.BaseWidth, img1.BaseHeight, Gravity.Northwest);
           img1.Write("C:\\Temp\\qqqq.Png");
            img2.Write("C:\\Temp\\eeee.Png");

            result = img1.CompareTo(img2);
            Assert.AreEqual(0, result);
            double distortion = img1.Compare(img2, ErrorMetric.Absolute, imgDiff);
            double distortionsqured = img1.Compare(img2, ErrorMetric.RootMeanSquared, imgDiff);
            imgDiff.Write(Differencepath);

            MagickErrorInfo error = img1.Compare(img2);
            //   Assert.AreEqual(0, error.MeanErrorPerPixel, "Images are not of same reslution");
           
            if (error != null)
            {
                if (error.NormalizedMaximumError < 0.98)
                {
                    imgDiff.Write(Differencepath);
                    Assert.Fail("NormalizedMaximumError = " + error.NormalizedMaximumError);
                }

            }
            //Assert.AreEqual(0, distortion);

            imgDiff.Write(Differencepath);




        }



        public static string ScreenShotRegionwithPath(this IWebDriver driver, By locator, String ScreenshotName)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom='90%';");
            string dateformat = System.DateTime.Now.ToString("dd:MM:yy hh:mm").Replace(':', '_');

            string cDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            cDirectory = cDirectory.Remove(cDirectory.IndexOf("\\bin\\Debug"));
             string NewFileNamePath = cDirectory + "\\ImageComparision\\ScreenshotImages\\";

            string Filenamevalcrop = ScreenshotName + "_" + dateformat + "_crop.Png";
            string NewFileNamePathCrop = NewFileNamePath + "\\" + Filenamevalcrop;
            string Filenameval = ScreenshotName + "_" + dateformat + ".Png";
         
            string NewFileNamePath1 = NewFileNamePath + "\\" + Filenameval;
           

            IWebElement element = driver.FindElement(locator);
            //   jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            Thread.Sleep(1000);

            //Get the entire Screenshot from the driver of passed WebElement


            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(NewFileNamePath1);

            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom='100%';");

            //Create an instance of Buffered Image from captured screenshot


            Image img = Image.FromFile(NewFileNamePath1);
          //  Bitmap bmp = new Bitmap(img);

            // Get the Width and Height of the WebElement using

            int elementWidth = element.Size.Width;
            Int64 value = (Int64)jse.ExecuteScript("return window.scrollY;");
            int iScrollHeight = Convert.ToInt32(value);

            int elementHeight = element.Size.Height;

            //Get the Location of WebElement in a Point.
            //This will provide X & Y co-ordinates of the WebElement
            //Create a rectangle using Width and Height
            Point p = element.Location;
            Bitmap bmp = new Bitmap(elementWidth, elementHeight);
            Rectangle rect = new Rectangle(p.X, p.Y, elementWidth, elementHeight);

            Graphics gph = Graphics.FromImage(bmp);
            gph.DrawImage(img, new Rectangle(0, 0, elementWidth, elementHeight), rect, GraphicsUnit.Pixel);

            // Image cropedImag = bmp.Clone(rect, bmp.PixelFormat);

            //    System.IO.File.Delete(NewFileNamePath1);

            //   cropedImag.Save(NewFileNamePathCrop);

            //Create image by for element using its location and size.
            //This will give image data specific to the WebElement
           
         

            img.Save(NewFileNamePathCrop);

            img.Dispose();
            bmp.Dispose();
            System.IO.File.Delete(NewFileNamePath1);
            return Filenamevalcrop;
        }



    }
}

