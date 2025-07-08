using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Winium.Cruciatus.Elements;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp10.Pages
{
    public class Konfigurasyon : BasePage
    {
        private int imageName = 1;
        private List<CruciatusElement> comboBoxes;
        private CruciatusElement comboListView;
        private CruciatusElement comboPopUp;
        private CruciatusElement comboSekme;
        private bool isClicked = false;

        private IWebElement BtKonfigurasyon => winiumDriver.FindElementById("Konfigurasyon");
        private IWebElement BtInfoYesil => winiumDriver.FindElementById("InfoYesil");
        private IWebElement BtInfoSari => winiumDriver.FindElementById("InfoSari");
        private IWebElement BtInfoKirmizi => winiumDriver.FindElementById("InfoKirmizi");
        private IWebElement BtKonfigurasyonGonder => winiumDriver.FindElementById("GonderButton3");

        //
        // Konfigürasyon kısmında yer alan ComboBox'lar belirli bir hiyerarşide olduğu için, konfigürasyon başlığına basıldığında bu metod çalışarak
        // ekranda yer alan ComboBox'lar tespit edilip diğer test metodlarında kullanılmak üzere kaydediliyor
        //
        public void ReadComboBoxes()
        {
            comboBoxes = cruciatusElement.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']"))
                        .FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            comboListView = comboBoxes[0];
            comboPopUp = comboBoxes[1];
            comboSekme = comboBoxes[2];

            Thread.Sleep(500);
        }

        //
        // Konfigürasyon başlığına tıklama
        //
        public void ClickKonfigurasyonMenu(bool beCalledInKamera)
        {
            BtKonfigurasyon.Click();
            isClicked = true;
            if (!beCalledInKamera) TakeScreenshot("Konfigurasyon", 4);
            ReadComboBoxes();
        }

        //
        // Tüm seçenekler "Yok"'tayken Konfigürasyon gönderme
        //
        public void KonfigurasyonGonderHepsiYok()
        {
            if (!isClicked) return;
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("Konfigurasyon gönder(Tüm seçenekler yok)", 4);
            
        }

        //
        // ListView var Konfigürasyonunu gönderme
        //
        public void KonfigurasyonGonderListviewVar(bool beCalledInKamera)
        {
            if (!isClicked) return;
            comboListView.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboListView.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            if (!beCalledInKamera) TakeScreenshot("ListView Konfigurasyon", 4);

        }

        //
        // ListView var Konfigürasyonunu gönderme sonrasında ekrana gelen ListView nesnesinin incelenmesi
        //
        public void KonfigurasyonListviewGoruntu()
        {
            if (!isClicked) return;
            int pageDownName = 1;
            comboListView.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboListView.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();


            TakeScreenshot($"ListView-listview{pageDownName}", 4);
            pageDownName++;

            IWebElement PageDown = winiumDriver.FindElementById("ListeScroll")
                                                .FindElement(By.Id("VerticalScrollBar"))
                                                .FindElement(By.Id("PageDown"));

            var x = Array.ConvertAll(PageDown.GetAttribute("BoundingRectangle").Split(',').ToArray(), int.Parse);
            actions = new Actions(winiumDriver)
                        .MoveToElement(PageDown, (x[2] / 2), x[3] - 2);
            actions.Click().Perform();

            TakeScreenshot($"ListView-listview{pageDownName}", 4);
            pageDownName++;

            actions.Click().Perform();

            TakeScreenshot($"ListView-listview{pageDownName}", 4);
            pageDownName++;
            
        }


        //
        // Pop up Konfigürasyonunu gönderme
        //
        public void KonfigurasyonGonderPopUpVar()
        {
            if (!isClicked) return;
            comboPopUp.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboPopUp.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("Pop Up Konfigurasyon", 4);
            
        }

        //
        // Sekme Gönder Konfigürasyonunu gönderme
        //
        public void KonfigurasyonGonderSekmeVar(bool beCalledInKamera)
        {
            if (!isClicked) return;
            comboSekme.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboSekme.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click(); BtKonfigurasyonGonder.Click();
            if (!beCalledInKamera) TakeScreenshot("Sekme Gonder Konfigurasyon", 4);
        }

        //
        // Pop up Konfigürasyonunu gönderme sonrasında ekrana gelen "Durum Bilgilendirme" kısmını kontrol etme
        //
        public void KonfigurasyonDurumBilgilendirme()
        {

            if (!isClicked) return;
            comboPopUp.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboPopUp.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot($"Pop up{imageName}", 4);
            imageName++;
            BtInfoYesil.Click();
            TakeScreenshot($"Pop up{imageName}", 4);
            imageName++;
            BtInfoSari.Click();
            TakeScreenshot($"Pop up{imageName}", 4);
            imageName++;
            BtInfoKirmizi.Click();
            TakeScreenshot($"Pop up{imageName}", 4);
            imageName++;
            
        }
    }
}
