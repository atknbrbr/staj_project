//using ConsoleApp10.Utils;
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
//    public class Yakit
//    {
//        private readonly WiniumDriver winiumDriver;
//        private readonly Actions actions;
//        private String headerName;

//        public Yakit(WiniumDriver _winiumDriver)
//        {
//            winiumDriver = _winiumDriver;
//            actions = new Actions(winiumDriver);
//        }

//        public void ClickYakitMenu()
//        {
//            winiumDriver.FindElementById("Yakıt").Click();
//            TakeScreenshot.CaptureApp("Yakıt");
//            Thread.Sleep(500);
//        }

//        public void ClickYakitRadioButtons()
//        {
//            winiumDriver.FindElementById("radio1").Click();
//            Thread.Sleep(100);
//            winiumDriver.FindElementById("radio2").Click();
//            Thread.Sleep(100);
//            winiumDriver.FindElementById("radio3").Click();
//            Thread.Sleep(100);
//            TakeScreenshot.CaptureApp("Yakıt-RadioButon");
//            Thread.Sleep(250);
//        }

//        public void ClickYakitYukle()
//        {
//            winiumDriver.FindElementById("PART_TextBox").SendKeys("50");
//            Thread.Sleep(100);
//            winiumDriver.FindElementById("Emniyet").Click();
//            Thread.Sleep(50);
//            TakeScreenshot.CaptureApp("Yakıt-EmniyetAcik");
//            Thread.Sleep(100);
//            winiumDriver.FindElementById("btnGonder").Click();
//            Thread.Sleep(100);
//            TakeScreenshot.CaptureApp("Yakıt-AktarimYapiliyor");
//            Thread.Sleep(10000);
//            TakeScreenshot.CaptureApp("Yakıt-AktarimYapildi");
//            Thread.Sleep(250);
//        }


//    }
//}
