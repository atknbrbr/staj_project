using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Pages
{
    public class Kamera : BasePage
    {
        private Konfigurasyon konfigurasyon;
        private IWebElement BtKameraKontrol => winiumDriver.FindElementById("KameraTabControl");
        private IWebElement BtKamera => winiumDriver.FindElementById("Kamera");

        public Kamera()
        {
            konfigurasyon = new Konfigurasyon();
        }

        //
        // Tüm seçenekler "Yok"'tayken Kamera testi
        //
        public void ClickKameraHepsiYok()
        {
            konfigurasyon.ClickKonfigurasyonMenu();
            BtKamera.Click();
            BtKameraKontrol.Click();
            TakeScreenshot("Kamera Test(Tum konfigurasyonlar kapalı)", 5);
        }

        //
        // Kameranın çalışması için gereken ayarlar yapıldıktan sonra Kamera nın çalışma durumu
        //
        public void ClickKameraListViewAcik()
        {
            konfigurasyon.ClickKonfigurasyonMenu();
            konfigurasyon.KonfigurasyonGonderListviewVar();
            konfigurasyon.KonfigurasyonGonderSekmeVar();
            BtKamera.Click();
            BtKameraKontrol.Click();
            TakeScreenshot("ListView Açıkken Kamera Bağlantı", 5);
        }
    }
}
