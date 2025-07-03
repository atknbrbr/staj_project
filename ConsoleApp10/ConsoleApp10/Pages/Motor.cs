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
        private static int ustLimit, altLimit, guncelDeger;
        private static int fileName = 1;

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
            TakeScreenshot("Motor", 1);
            Thread.Sleep(500);
        }

        public void ClickMotorGostergeler()
        {
            BtMotor.Click();
            BtGostergeler.Click();
            TakeScreenshot("", 1, 0, 0);
            Thread.Sleep(500);
        }

        public void ClickMotorGostergelerTablo()
        {
            BtMotor.Click();
            BtGostergeler.Click();
            CheckboxMotorTablo.Click();
            TakeScreenshot("Tablo Göster", 1, 0, 0);
            Thread.Sleep(500);
        }

        public bool ClickMotorGostergelerSecim(String btnName)
        {
            BtMotor.Click();
            BtGostergeler.Click();
            try
            {
                IWebElement radioBtn = winiumDriver.FindElementById(btnName);
                radioBtn.Click();
                TakeScreenshot("Seçilen Değer-1", 1, 0, 0);
                Thread.Sleep(200);
                ComboGosterge.Click();
                Thread.Sleep(200);
                TakeScreenshot("Seçilen Değer-2", 1, 0, 0);
                Thread.Sleep(500);
                return true;
            }
            catch (Exception)
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
                TakeScreenshot("Motor Ayarları-1", 1, 0, 0);
                ComboMotorAyar1.Click();
                Thread.Sleep(500);
                TakeScreenshot("Motor Ayarları-2", 1, 0, 0);
                ElemComboMotor1.Click();
                Thread.Sleep(200);
                TakeScreenshot("Motor Ayarları-3", 1, 0, 0);
                ComboMotorAyar2.Click();
                Thread.Sleep(500);
                TakeScreenshot("Motor Ayarları-4", 1, 0, 0);
                ElemComboMotor2.Click();
                Thread.Sleep(200);
                TakeScreenshot("Motor Ayarları-5", 1, 0, 0);

                Thread.Sleep(500);
                return true;
            }
            catch (Exception)
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
                            CheckSliders(SliderHava, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Rüzgar Hızı
                        case 4:
                            CheckSliders(SliderRuzgar, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Ortam Sıcaklığı
                        case 8:
                            CheckSliders(SliderSicaklık, ustLimit, altLimit, guncelDeger);
                            continue;
                        
                        // Motor Devri
                        case 12:
                            CheckSliders(SliderMotor, ustLimit, altLimit, guncelDeger);
                            continue;

                        default:
                            break;
                    }
                }
            }
            Thread.Sleep(200);
        }


        public void CheckSliders(IWebElement slider1, int a, int b, int c)
        {
            if (fileName == 1)
            {
                TakeScreenshot(fileName.ToString(), 1, 0, 1); 
                fileName++;
            }

            ustLimit = a;
            altLimit = b;
            guncelDeger = c;

            if (guncelDeger < 0)
            {
                if (ustLimit < 0)
                {
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }

                else if (ustLimit >= 0)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 0; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 80)
                {
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
            }

            else if (guncelDeger >= 0 && guncelDeger < 80)
            {
                if (altLimit < 0)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;

                }
                if (ustLimit > 80)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;

                }
            }
            else if (guncelDeger > 81 && guncelDeger < 200)
            {
                if (ustLimit > 200)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;

                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 0)
                {
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
            }
            else
            {
                if (altLimit < 200)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 200; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 0)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot(fileName.ToString(), 1, 0, 1);
                    fileName++;
                }
            }
        }

        public void ClickMotorAyarlarMenu()
        {
            BtMotor.Click();
            BtMotorAyarlar.Click();
            Thread.Sleep(200);
        }
    }
}
