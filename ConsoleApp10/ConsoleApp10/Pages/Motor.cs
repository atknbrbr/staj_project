using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Xml.Linq;
using WindowsInput;
using Winium;
using Winium.Cruciatus.Elements;
using Winium.Elements.Desktop;
using Winium.Elements.Desktop.Extensions;

namespace ConsoleApp10.Pages
{
    public class Motor : BasePage
    {
        
        //private String headerName;

        private IWebElement BtMotor => winiumDriver.FindElementById("Motor");
        private IWebElement CheckboxMotorTablo => winiumDriver.FindElementById("tablo_goster");
        private IWebElement ComboGosterge => winiumDriver.FindElementById("DinamikComboBox");
        private IWebElement BtDiagnostik => winiumDriver.FindElementById("Diagnostik");
        private IWebElement ComboMotorAyar1 => winiumDriver.FindElementById("ComboBox1");
        private IWebElement ComboMotorAyar2 => winiumDriver.FindElementById("ComboBox2");
        private IWebElement ElemComboMotor1 => winiumDriver.FindElementById("combobox_500");
        private IWebElement ElemComboMotor2 => winiumDriver.FindElementById("combobox_230");
        private IWebElement BtGostergeler => winiumDriver.FindElementById("Gostergeler");
        private IWebElement SliderHava => winiumDriver.FindElementById("sliderHava");
        private IWebElement SliderRuzgar => winiumDriver.FindElementById("sliderRuzgar");
        private IWebElement SliderSicaklık => winiumDriver.FindElementById("sliderSicaklik");
        private IWebElement SliderMotor => winiumDriver.FindElementById("sliderMotor");
        private IWebElement BtMotorAyarlar=> winiumDriver.FindElementById("Motor_Ayarlar");


        public void ClickMotorMenu()
        {
            BtMotor.Click();
            Thread.Sleep(500);
        }

        public void ClickMotorGostergeler()
        {
            BtMotor.Click();
            BtGostergeler.Click();
            Thread.Sleep(500);
        }

        public void ClickMotorGostergelerTablo()
        {
            BtMotor.Click();
            BtGostergeler.Click();
            CheckboxMotorTablo.Click();
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-TabloGoster");
            Thread.Sleep(500);
            //CheckboxMotorTablo.Click();
        }

        public bool ClickMotorGostergelerSecim(String btnName)
        {
            BtMotor.Click();
            BtGostergeler.Click();
            try
            {
                IWebElement radioBtn = winiumDriver.FindElementById(btnName);
                radioBtn.Click();
                //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Gostergeler-Secim");
                Thread.Sleep(200);
                ComboGosterge.Click();
                Thread.Sleep(200);
                MainHeaders.CreateSubFolders("Seçilen Değer", cruciatusElement, 1, 0, 0);
                Thread.Sleep(500);
                //winiumDriver.FindElementById("irtifa_radiobuton").Click();
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
            
        }

        public bool ClickMotorGostergelerMotorAyarlari()
        {
            BtMotor.Click();
            BtGostergeler.Click();
            try
            {
                MainHeaders.CreateSubFolders("Motor Ayarları-1", cruciatusElement, 1, 0, 0);
                ComboMotorAyar1.Click();
                Thread.Sleep(500);
                ElemComboMotor1.Click();
                Thread.Sleep(200);
                ComboMotorAyar2.Click();
                MainHeaders.CreateSubFolders("Motor Ayarları-2", cruciatusElement, 1, 0, 0);
                Thread.Sleep(500);
                ElemComboMotor2.Click();
                Thread.Sleep(200);
                MainHeaders.CreateSubFolders("Motor Ayarları-3", cruciatusElement, 1, 0, 0);

                Thread.Sleep(500);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ClickMotorDiagnostikMenu()
        {
            BtMotor.Click();
            Thread.Sleep(500);
            BtDiagnostik.Click();
            var elements = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='TextBlock']")).ToList();

            foreach (var element in elements)
            {
                if (elements.IndexOf(element) % 4 == 0)
                {
                    int ustLimit = Int32.Parse(elements[elements.IndexOf(element) + 1].Properties.Name);
                    int altLimit = Int32.Parse(elements[elements.IndexOf(element) + 2].Properties.Name);
                    int guncelDeger = Int32.Parse(elements[elements.IndexOf(element) + 3].Properties.Name);

                    switch (elements.IndexOf(element))
                    {
                        // Hava hızı
                        case 0:
                            SliderCalculation.CheckSliders(cruciatusElement, actions, SliderHava, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Rüzgar Hızı
                        case 4:
                            SliderCalculation.CheckSliders(cruciatusElement, actions, SliderRuzgar, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Ortam Sıcaklığı
                        case 8:
                            SliderCalculation.CheckSliders(cruciatusElement, actions, SliderSicaklık, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Motor Devri
                        case 12:
                            SliderCalculation.CheckSliders(cruciatusElement, actions, SliderMotor, ustLimit, altLimit, guncelDeger);
                            continue;

                        default:
                            break;
                    }
                }
            }


            //ReadOnlyCollection<IWebElement> texts = winiumDriver.FindElementsByClassName("TextBlock");
            //foreach (IWebElement text in texts) 
            //{
            //    String x = text.GetAttribute("type");
            //    if (x == "Motor Gücü")
            //    {
            //        Console.WriteLine("test");
            //    }
            //}


            //Thread.Sleep(500);
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik");
            //Thread.Sleep(200);
            //IWebElement slider1 = winiumDriver.FindElementById("sliderHava");
            //actions.MoveToElement(slider1, 5, 190).Perform();
            //actions.Click().Perform();
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-1");
            //Thread.Sleep(200);

            //slider1 = winiumDriver.FindElementById("sliderRuzgar");
            //actions.MoveToElement(slider1, 5, 10).Perform();
            //for (int i = 0; i < 110; i++)
            //{
            //    actions.Click().Perform();
            //}
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-2");
            //Thread.Sleep(200);

            //slider1 = winiumDriver.FindElementById("sliderSicaklik");
            //actions.MoveToElement(slider1, 5, 190).Perform();
            //actions.Click().Perform();
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-3");
            //Thread.Sleep(200);

            //slider1 = winiumDriver.FindElementById("sliderMotor");
            //actions.MoveToElement(slider1, 5, 10).Perform();
            //for (int i = 0; i < 70; i++)
            //{
            //    actions.Click().Perform();
            //}
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-4");
            //Thread.Sleep(200);

            //for (int i = 0; i < 70; i++)
            //{
            //    actions.Click().Perform();
            //}
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-5");
            Thread.Sleep(200);
        }

        public void ClickMotorAyarlarMenu()
        {
            BtMotor.Click();
            BtMotorAyarlar.Click();
            Thread.Sleep(200);
        }

    }
}
