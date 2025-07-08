using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp10.Pages
{
    public class Motor : BasePage
    {
        private static int ustLimit, altLimit, guncelDeger;
        private static int fileName = 1;
        private bool isClicked = false;

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

        //
        // Motor başlığına tıklama
        //
        public void ClickMotorMenu()
        {
            BtMotor.Click();
            isClicked = true;
            TakeScreenshot("Motor", 1);
            Thread.Sleep(500);
        }

        //
        // Motor=>Göstergeler başlığına tıklama
        //
        public void ClickMotorGostergeler()
        {
            if (!isClicked) return;
            BtGostergeler.Click();
            TakeScreenshot("Gostergeler", 1, 0, 0);
            Thread.Sleep(500);
        }

        //
        // Göstergelerdeki tabloyu açma
        //
        public void ClickMotorGostergelerTablo()
        {
            if (!isClicked) return;
            CheckboxMotorTablo.Click();
            TakeScreenshot("Tablo Göster", 1, 0, 0);
            Thread.Sleep(500);
        }

        //
        // Göstergelerdeki seçim kısmının testi
        //
        public void ClickMotorGostergelerSecim(String btnName)
        {
            if (!isClicked) return;
            IWebElement radioBtn = winiumDriver.FindElementById(btnName);
            radioBtn.Click();
            TakeScreenshot("Seçilen Değer-deger1", 1, 0, 0);
            Thread.Sleep(200);
            ComboGosterge.Click();
            Thread.Sleep(200);
            TakeScreenshot("Seçilen Değer-deger2", 1, 0, 0);
            Thread.Sleep(500);
        }

        //
        // Göstergelerdeki "Motor ayarları" kısmının test edilmesi
        //
        public void ClickMotorGostergelerMotorAyarlari()
        {
            if (!isClicked) return;
            TakeScreenshot("Motor Ayarları-motor1", 1, 0, 0);
            ComboMotorAyar1.Click();
            Thread.Sleep(500);
            TakeScreenshot("Motor Ayarları-motor2", 1, 0, 0);
            ElemComboMotor1.Click();
            Thread.Sleep(200);
            TakeScreenshot("Motor Ayarları-motor3", 1, 0, 0);
            ComboMotorAyar2.Click();
            Thread.Sleep(500);
            TakeScreenshot("Motor Ayarları-motor4", 1, 0, 0);
            ElemComboMotor2.Click();
            Thread.Sleep(200);
            TakeScreenshot("Motor Ayarları-motor5", 1, 0, 0);

            Thread.Sleep(500);
        }

        //
        // Diagnostik test edilmesi
        //
        public void ClickMotorDiagnostikMenu()
        {
            if (!isClicked) return;
            Thread.Sleep(500);
            BtDiagnostik.Click();
            var elements = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='TextBlock']")).ToList();

            //
            // Ekrandaki textBox'lar elde edilir. Elde edilen textbox'lar:
            // "slider1Name - slider1UstLimit - slider1AltLimit - slider1GuncelDeger - slider2Name - ....."
            // şeklinde bir liste oluşturur. bu yapı kullanılarak textbox'lar 4 lü ele alınır. ilgili güncellemeler slider'a CheckSliders fonksiyonu ile yapılır.
            //

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

        //
        // Slider elementleri, ekrandaki değerler ve bilinen limit değerler doğrultusunda tüm olasılıklar kontrol edilerek güncellenir
        //
        public void CheckSliders(IWebElement slider1, int a, int b, int c)
        {
            if (fileName == 1)
            {
                TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                fileName++;
            }

            ustLimit = a;
            altLimit = b;
            guncelDeger = c;

            if (guncelDeger < 0)
            {
                if (ustLimit < 0)
                {
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }

                else if (ustLimit >= 0)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 0; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 80)
                {
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
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
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;

                }
                if (ustLimit > 80)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
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
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;

                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 0)
                {
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
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
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
                if (altLimit < 0)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    TakeScreenshot($"diagnostik{fileName}", 1, 0, 1);
                    fileName++;
                }
            }
        }

        //
        // Motor ayarları butonuna tıklama
        //
        public void ClickMotorAyarlarMenu()
        {
            if (!isClicked) return;
            BtMotorAyarlar.Click();
            TakeScreenshot("Motor Ayarlar", 1, 1);
            Thread.Sleep(200);
        }
    }
}
