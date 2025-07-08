using OpenQA.Selenium;
using System;
using System.Threading;

namespace ConsoleApp10.Pages
{
    public class Hazirlik : BasePage
    {
        private bool isClicked = false;
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
            isClicked = true;
            TakeScreenshot("Hazırlık ana ekran", 0);
            Thread.Sleep(500);
        }

        //
        // Hazırlık=>Görev hazırlık kısmının güncellenmesi
        //
        public void GorevHazirlikGuncelle(String text)
        {
            if (!isClicked) return;
            TxtboxGorev.Click();
            TxtboxGorev.SendKeys(text);
            TakeScreenshot("Görev Hazırlık", 0);
            Thread.Sleep(500);
        }

        //
        // Hazırlık=>Uçuş hazırlık kısmının güncellenmesi
        //
        public void UcusHazirlikGuncelle(String test)
        {
            if (!isClicked) return;
            TxtboxKalkis.Click();
            TxtboxKalkis.SendKeys(test);
            TakeScreenshot("Uçuş Hazırlık", 0);
            Thread.Sleep(500);
        }

        //
        // Hazırlık=>Uçuş hazırlık kısmında Hayır seçildikten sonra Pop Up'ın yakalanması
        //
        public void UcusHazirlikSıfırlaPopUp()
        {
            if (!isClicked) return;
            BtKalkisSifirla.Click();
            TakeScreenshot("Uçuş Hazırlık-Sıfırla Pop Up", 0);
            Thread.Sleep(300);
            BtKalkisSifirlaHayir.Click();

        }
    }
}
