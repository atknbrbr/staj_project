using ConsoleApp10.Utils;
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
    public class Guc
    {
        private readonly WiniumDriver winiumDriver;
        private readonly CruciatusElement winiumCruciatus;
        private readonly Actions actions;

        private IWebElement BtGuc => winiumDriver.FindElementById("Güc");
        private IWebElement SliderGuc => winiumDriver.FindElementById("bataryaSecimi");
        private IWebElement BtGucSistemi => winiumDriver.FindElementById("Güc_Sistemi");
        private IWebElement BtGucAyarlar => winiumDriver.FindElementById("Güc_Ayarlar");
        private IWebElement BtDurklat => winiumDriver.FindElementById("duraklatToggle");

        public Guc(WiniumDriver _winiumDriver, CruciatusElement _winiumCruciatus)
        {
            winiumDriver = _winiumDriver;
            winiumCruciatus = _winiumCruciatus;
            actions = new Actions(winiumDriver);
        }

        //
        // Güç başlığına tıklama
        //
        public void ClickGucMenu()
        {
            BtGuc.Click();
        }

        //
        // Güç => Güç sistemi kısmında yer alan batarya ile ilgili işlemler
        //
        public void GucSistemBataryasi()
        {
            int imageName = 1;
            MainHeaders.CreateSubFolders("Batarya-" + imageName.ToString(), winiumCruciatus, 3, 0);
            imageName++;
            Thread.Sleep(100);
            for (int i = 0; i < 62; i++)
            {
                actions.MoveToElement(SliderGuc, 85, 10).Perform();
                actions.Click().Perform();
                switch (i)
                {
                    case (1):
                        MainHeaders.CreateSubFolders("Batarya-" + imageName.ToString(), winiumCruciatus, 3, 0);
                        imageName++;
                        Thread.Sleep(100);
                        continue;

                    case (31):
                        MainHeaders.CreateSubFolders("Batarya-" + imageName.ToString(), winiumCruciatus, 3, 0);
                        imageName++;
                        Thread.Sleep(100);
                        continue;

                    case (61):
                        MainHeaders.CreateSubFolders("Batarya-" + imageName.ToString(), winiumCruciatus, 3, 0);
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
            BtGucSistemi.Click();
        }

        //
        // Güç => Güç Ayarlar alt menüsüne tıklama
        //
        public void ClickGucAyarlarMenu()
        {
            BtGucAyarlar.Click();
        }

        //
        // Güç => Güç Ayarlar alt menüsündeki işlemler
        //
        public void GucAyarlarMenu()
        {
            MainHeaders.CreateSubFolders("Devam Et", winiumCruciatus, 3, 1);
            Thread.Sleep(2500);
            BtDurklat.Click();
            MainHeaders.CreateSubFolders("Durdur", winiumCruciatus, 3, 1);
        }
    }
}
