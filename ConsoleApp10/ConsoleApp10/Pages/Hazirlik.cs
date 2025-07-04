using ConsoleApp10.Utils;
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
        private IWebElement TxtboxKalkis => winiumDriver.FindElementById("kalkis");
        private IWebElement BtKalkisSifirla => winiumDriver.FindElementById("sifirla_buton");
        private IWebElement BtKalkisSifirlaHayir => winiumDriver.FindElementById("hayır");

        //
        // Hazırlık başlığına tıklama
        //
        public void ClickHazirlikMenu()
        {
            BtHazirlık.Click();
            TakeScreenshot("Hazırlık ana ekran", 0);
            Thread.Sleep(500);
        }

        //
        // Hazırlık=>Görev hazırlık kısmının güncellenmesi
        //
        public void GorevHazirlikGuncelle(String text)
        {
            BtHazirlık.Click();
            TxtboxGorev.Click();
            TxtboxGorev.SendKeys(text);
            TakeScreenshot("Görev Hazırlık", 0);
            Thread.Sleep(500);
            //BtGorevSifirla.Click();
        }

        //
        // Hazırlık=>Uçuş hazırlık kısmının güncellenmesi
        //
        public void UcusHazirlikGuncelle(String test)
        {
            BtHazirlık.Click();
            TxtboxKalkis.Click();
            TxtboxKalkis.SendKeys(test);
            TakeScreenshot("Uçuş Hazırlık", 0);
            Thread.Sleep(500);
            //BtKalkisSifirla.Click();
        }

        //
        // Hazırlık=>Uçuş hazırlık kısmında Hayır seçildikten sonra Pop Up'ın yakalanması
        //
        public void UcusHazirlikSıfırlaPopUp()
        {
            BtHazirlık.Click();
            BtKalkisSifirla.Click();
            TakeScreenshot("Uçuş Hazırlık-Sıfırla Pop Up", 0);
            Thread.Sleep(300);
            BtKalkisSifirlaHayir.Click();

        }
    }
}
