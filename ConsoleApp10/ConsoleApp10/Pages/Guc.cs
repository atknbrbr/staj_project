using ConsoleApp10.Utils;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Winium.Cruciatus.Elements;


namespace ConsoleApp10.Pages
{
    public class Guc : BasePage
    {
        private IWebElement BtGuc => winiumDriver.FindElementById("Güc");
        private IWebElement SliderGuc => winiumDriver.FindElementById("bataryaSecimi");
        private IWebElement BtGucSistemi => winiumDriver.FindElementById("Güc_Sistemi");
        private IWebElement BtGucAyarlar => winiumDriver.FindElementById("Güc_Ayarlar");
        private IWebElement BtDurklat => winiumDriver.FindElementById("duraklatToggle");

        //
        // Güç başlığına tıklama
        //
        public void ClickGucMenu()
        {
            BtGuc.Click();
            TakeScreenshot("Güç", 3, 0);
        }

        //
        // Güç => Güç sistemi kısmında yer alan batarya ile ilgili işlemler
        //
        public void GucSistemBataryasi()
        {
            BtGuc.Click();
            BtGucSistemi.Click();
            int imageName = 1;
            TakeScreenshot("Batarya-" + imageName.ToString(), 3, 0);
            imageName++;
            Thread.Sleep(100);
            for (int i = 0; i < 62; i++)
            {
                actions.MoveToElement(SliderGuc, 85, 10).Perform();
                actions.Click().Perform();
                switch (i)
                {
                    case (1):
                        TakeScreenshot("Batarya-" + imageName.ToString(), 3, 0);
                        imageName++;
                        Thread.Sleep(100);
                        continue;

                    case (31):
                        TakeScreenshot("Batarya-" + imageName.ToString(), 3, 0);
                        imageName++;
                        Thread.Sleep(100);
                        continue;

                    case (61):
                        TakeScreenshot("Batarya-" + imageName.ToString(), 3, 0);
                        imageName++;
                        Thread.Sleep(100);
                        continue;

                    default:
                        break;
                }
            }
        }

        //
        // Güç => Güç Sistemi alt menüsüne tıklama
        //
        public void ClickGucSistemiMenu()
        {
            BtGuc.Click();
            BtGucSistemi.Click();
            TakeScreenshot("Güç Sistemi", 3, 0);

        }

        //
        // Güç => Güç Ayarlar alt menüsüne tıklama
        //
        public void ClickGucAyarlarMenu()
        {
            BtGuc.Click();
            BtGucAyarlar.Click();
            TakeScreenshot("Güç Ayarlar", 3, 0);
        }

        //
        // Güç => Güç Ayarlar alt menüsündeki işlemler
        //
        public void GucAyarlarMenu()
        {
            BtGuc.Click();
            BtGucAyarlar.Click();
            TakeScreenshot("Devam Et", 3, 1);
            Thread.Sleep(2500);
            BtDurklat.Click();
            TakeScreenshot("Durdur", 3, 1);
        }
    }
}
