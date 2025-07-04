﻿using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10.Pages
{
    public class Hazirlik : BasePage
    {
        private IWebElement BtHazirlık => winiumDriver.FindElementById("Hazırlık");
        private IWebElement TxtboxGorev => winiumDriver.FindElementById("txtAAlt");
        private IWebElement BtGorevSifirla => winiumDriver.FindElementById("Sıfırla");
        private IWebElement TxtboxKalkis => winiumDriver.FindElementById("kalkis");
        private IWebElement BtKalkisSifirla => winiumDriver.FindElementById("sifirla_buton");
        private IWebElement BtKalkisSifirlaHayir => winiumDriver.FindElementById("hayır");

        public void ClickHazirlikMenu()
        {
            BtHazirlık.Click();
            //TakeScreenshot.CaptureApp("Hazırlık");
            //Thread.Sleep(500);
        }

        public void GorevHazirlikGuncelle(String text)
        {
            BtHazirlık.Click();
            TxtboxGorev.Click();
            TxtboxGorev.SendKeys(text);
            //TakeScreenshot.CaptureApp("Hazırlık-GörevHazırlık");
            //Thread.Sleep(500);
            //BtGorevSifirla.Click();
        }

        public void UcusHazirlikGuncelle(String test)
        {
            BtHazirlık.Click();
            TxtboxKalkis.Click();
            TxtboxKalkis.SendKeys(test);
            //TakeScreenshot.CaptureApp("Hazırlık-UçuşHazırlık");
            //Thread.Sleep(500);
            //BtKalkisSifirla.Click();
        }

        public void UcusHazirlikSıfırlaPopUp()
        {
            BtHazirlık.Click();
            BtKalkisSifirla.Click();
            //TakeScreenshot.CaptureApp("Hazırlık-UçuşHazırlık-SıfırlaPopUp");
            Thread.Sleep(500);
            //Thread.Sleep(300);
            //BtKalkisSifirlaHayir.Click();

        }
    }
}
