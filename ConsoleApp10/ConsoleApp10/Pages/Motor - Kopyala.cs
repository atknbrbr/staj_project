//using ConsoleApp10.Utils;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Winium;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Diagnostics;
//using System.Drawing.Imaging;
//using System.Linq;
//using System.Net.Configuration;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Automation;
//using WindowsInput;
//using Winium.Elements.Desktop.Extensions;

//namespace ConsoleApp10.Pages
//{
//    public class Motor
//    {
//        private readonly WiniumDriver winiumDriver;
//        private readonly Actions actions;
//        //private String headerName;

//        private IWebElement BtMotor => winiumDriver.FindElementById("Motor");
//        private IWebElement CheckboxMotorTablo => winiumDriver.FindElementById("tablo_goster");
//        private IWebElement ComboGosterge => winiumDriver.FindElementById("DinamikComboBox");
//        private IWebElement ComboMotorAyar1 => winiumDriver.FindElementById("ComboBox1");
//        private IWebElement ComboMotorAyar2 => winiumDriver.FindElementById("ComboBox2");

//        private IWebElement ElemComboMotor1 => winiumDriver.FindElementById("combobox_500");
//        private IWebElement ElemComboMotor2 => winiumDriver.FindElementById("combobox_230");
//        private IWebElement BtGostergeler => winiumDriver.FindElementById("Gostergeler");


//        public Motor(WiniumDriver _winiumDriver)
//        {
//            winiumDriver = _winiumDriver;
//            actions = new Actions(winiumDriver);
//        }

//        public void ClickMotorMenu()
//        {
//            BtMotor.Click();
//            TakeScreenshot.CaptureApp("Motor");
//            Thread.Sleep(500);
//        }

//        public void ClickMotorGostergeler()
//        {
//            BtGostergeler.Click();
//            Thread.Sleep(500);
//        }

//        public void ClickMotorGostergelerTablo()
//        {
//            CheckboxMotorTablo.Click();
//            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-TabloGoster");
//            Thread.Sleep(500);
//            CheckboxMotorTablo.Click();
//        }

//        public bool ClickMotorGostergelerSecim(String btnName)
//        {
//            try
//            {
//                IWebElement radioBtn = winiumDriver.FindElementById(btnName);
//                radioBtn.Click();
//                //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-Secim");
//                Thread.Sleep(200);
//                ComboGosterge.Click();
//                Thread.Sleep(200);
//                TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-SecilenDeger");
//                Thread.Sleep(500);
//                //winiumDriver.FindElementById("irtifa_radiobuton").Click();
//                return true;
//            }
//            catch (Exception ex) 
//            { 
//                return false;
//            }
            
//        }

//        public bool ClickMotorGostergelerMotorAyarlari()
//        {
//            try
//            {
//                ComboMotorAyar1.Click();
//                TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-MotorAyarlari-1");
//                Thread.Sleep(500);
//                ElemComboMotor1.Click();
//                Thread.Sleep(200);
//                ComboMotorAyar2.Click();
//                TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-MotorAyarlari-2");
//                Thread.Sleep(500);
//                ElemComboMotor2.Click();
//                Thread.Sleep(200);
//                TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-MotorAyarlari-3");
//                Thread.Sleep(500);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public void ClickMotorDiagnostikMenu()
//        {
//            Thread.Sleep(500);
//            winiumDriver.FindElementById("Diagnostik").Click();
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik");
//            Thread.Sleep(200);
//            IWebElement slider1 = winiumDriver.FindElementById("sliderHava");
//            actions.MoveToElement(slider1, 5, 190).Perform();
//            actions.Click().Perform();
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-1");
//            Thread.Sleep(200);

//            slider1 = winiumDriver.FindElementById("sliderRuzgar");
//            actions.MoveToElement(slider1, 5, 10).Perform();
//            for (int i = 0; i < 110; i++)
//            {
//                actions.Click().Perform();
//            }
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-2");
//            Thread.Sleep(200);

//            slider1 = winiumDriver.FindElementById("sliderSicaklik");
//            actions.MoveToElement(slider1, 5, 190).Perform();
//            actions.Click().Perform();
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-3");
//            Thread.Sleep(200);

//            slider1 = winiumDriver.FindElementById("sliderMotor");
//            actions.MoveToElement(slider1, 5, 10).Perform();
//            for (int i = 0; i < 70; i++)
//            {
//                actions.Click().Perform();
//            }
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-4");
//            Thread.Sleep(200);

//            for (int i = 0; i < 70; i++)
//            {
//                actions.Click().Perform();
//            }
//            TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-5");
//            Thread.Sleep(200);

           

//        }

//        public void ClickMotorAyarlarMenu()
//        {
//            winiumDriver.FindElementById("Motor_Ayarlar").Click();
//            TakeScreenshot.CaptureApp("Motor-MotorAyar");
//            Thread.Sleep(200);
//        }

//    }
//}
