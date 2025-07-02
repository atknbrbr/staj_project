//using ConsoleApp10.Utils;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Winium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace ConsoleApp10.Pages
//{
//    public class Guc
//    {
//        private readonly WiniumDriver winiumDriver;
//        private readonly Actions actions;
//        private String headerName;

//        public Guc(WiniumDriver _winiumDriver)
//        {
//            winiumDriver = _winiumDriver;
//            actions = new Actions(winiumDriver);
//        }

//        //
//        // Güç başlığına tıklama
//        //
//        public void ClickGucMenu()
//        {
//            winiumDriver.FindElementById("Güc").Click();
//            TakeScreenshot.CaptureApp("Güç");
//        }

//        //
//        // Güç => Güç sistemi kısmında yer alan batarya ile ilgili işlemler
//        //
//        public void GucSistemBataryasi()
//        {
//            TakeScreenshot.CaptureApp("Güç-Güç Sistemi-Batarya-1");
//            Thread.Sleep(100);
//            for (int i = 0; i < 62; i++)
//            {
//                IWebElement gucSlider = winiumDriver.FindElementById("bataryaSecimi");
//                actions.MoveToElement(gucSlider, 85, 10).Perform();
//                actions.Click().Perform();
//                switch (i)
//                {
//                    case (1):
//                        TakeScreenshot.CaptureApp("Güç-Güç Sistemi-Batarya-2");
//                        Thread.Sleep(100);
//                        continue;

//                    case (31):
//                        TakeScreenshot.CaptureApp("Güç-Güç Sistemi-Batarya-3");
//                        Thread.Sleep(100);
//                        continue;

//                    case (61):
//                        TakeScreenshot.CaptureApp("Güç-Güç Sistemi-Batarya-4");
//                        Thread.Sleep(100);
//                        continue;

//                    default:
//                        break;
//                }
//            }
//        }

//        //
//        // Güç => Güç Sistemi alt menüsüne tıklama
//        //
//        public void ClickGucSistemiMenu()
//        {
//            winiumDriver.FindElementById("Güc_Sistemi").Click();
//        }

//        //
//        // Güç => Güç Ayarlar alt menüsüne tıklama
//        //
//        public void ClickGucAyarlarMenu()
//        {
//            winiumDriver.FindElementById("Güc_Ayarlar").Click();
//        }

//        //
//        // Güç => Güç Ayarlar alt menüsündeki işlemler
//        //
//        public void GucAyarlarMenu()
//        {
//            TakeScreenshot.CaptureApp("Güç-Güç Ayarlar-Devam Et.");
//            Thread.Sleep(2500);
//            winiumDriver.FindElementById("duraklatToggle").Click();
//            TakeScreenshot.CaptureApp("Güç-Güç Ayarlar-Durdur.");

//        }

//    }
//}
