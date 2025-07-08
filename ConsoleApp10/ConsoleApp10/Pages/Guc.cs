using OpenQA.Selenium;
using System.Threading;

namespace ConsoleApp10.Pages
{
    public class Guc : BasePage
    {
        private bool isClicked = false;
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
            isClicked = true;
            TakeScreenshot("Güç", 3, 0);
        }

        //
        // Güç => Güç sistemi kısmında yer alan batarya ile ilgili işlemler
        //
        public void GucSistemBataryasi()
        {
            if (!isClicked) return;
            BtGucSistemi.Click();
            int imageName = 1;
            TakeScreenshot($"Batarya{imageName}", 3, 0);
            imageName++;
            Thread.Sleep(100);
            for (int i = 0; i < 62; i++)
            {
                actions.MoveToElement(SliderGuc, 85, 10).Perform();
                actions.Click().Perform();
                if (i > 0 && (i - 1) % 30 == 0)
                {
                    TakeScreenshot($"Batarya{imageName}", 3, 0);
                    imageName++;
                    Thread.Sleep(100);
                }
            }
        }

        //
        // Güç => Güç Sistemi alt menüsüne tıklama
        //
        public void ClickGucSistemiMenu()
        {
            if (!isClicked) return;
            BtGucSistemi.Click();
            TakeScreenshot("Güç Sistemi", 3, 0);
        }

        //
        // Güç => Güç Ayarlar alt menüsüne tıklama
        //
        public void ClickGucAyarlarMenu()
        {
            if (!isClicked) return;
            BtGucAyarlar.Click();
            TakeScreenshot("Güç Ayarlar", 3, 0);
        }

        //
        // Güç => Güç Ayarlar alt menüsündeki işlemler
        //
        public void GucAyarlarMenu()
        {
            if (!isClicked) return;
            BtGucAyarlar.Click();
            TakeScreenshot("Devam Et", 3, 1);
            Thread.Sleep(2500);
            BtDurklat.Click();
            TakeScreenshot("Durdur", 3, 1);
        }
    }
}
