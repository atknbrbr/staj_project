using ConsoleApp10.Utils;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Extensions;

namespace ConsoleApp10.Pages
{
    public class Konfigurasyon : BasePage
    {
        private int imageName = 1;
        private List<CruciatusElement> comboBoxes;
        private CruciatusElement comboListView;
        private CruciatusElement comboPopUp;
        private CruciatusElement comboSekme;

        private IWebElement BtKonfigurasyon => winiumDriver.FindElementById("Konfigurasyon");
        private IWebElement BtKameraKontrol => winiumDriver.FindElementById("KameraTabControl");
        private IWebElement BtKamera => winiumDriver.FindElementById("Kamera");
        private IWebElement BtInfoYesil => winiumDriver.FindElementById("InfoYesil");
        private IWebElement BtInfoSari => winiumDriver.FindElementById("InfoSari");
        private IWebElement BtInfoKirmizi => winiumDriver.FindElementById("InfoKirmizi");
        private IWebElement BtKonfigurasyonGonder => winiumDriver.FindElementById("GonderButton3");

        public void ReadComboBoxes()
        {
            comboBoxes = cruciatusElement.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']"))
                        .FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            comboListView = comboBoxes[0];
            comboPopUp = comboBoxes[1];
            comboSekme = comboBoxes[2];

            Thread.Sleep(500);
        }

        public void ClickKonfigurasyonMenu()
        {
            BtKonfigurasyon.Click();
            TakeScreenshot("Konfigurasyon", 4);
            ReadComboBoxes();
        }

        public void KonfigurasyonGonderHepsiYok()
        {
            BtKonfigurasyon.Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("Konfigurasyon gönder(Tüm seçenekler yok)", 4);
        }

        public void ClickKameraHepsiYok()
        {
            BtKonfigurasyon.Click();
            BtKamera.Click();
            BtKameraKontrol.Click();
            TakeScreenshot("Kamera Test(Tum konfigurasyonlar kapalı)", 4);
        }

        public void KonfigurasyonGonderListviewVar()
        {
            BtKonfigurasyon.Click();
            comboListView.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboListView.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("ListView Konfigurasyon", 4);
        }

        public void KonfigurasyonListviewGoruntu()
        {
            int pageDownName = 1;
            BtKonfigurasyon.Click();
            comboListView.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboListView.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();


            TakeScreenshot("ListView-" + pageDownName.ToString(), 4);
            pageDownName++;

            IWebElement PageDown = winiumDriver.FindElementById("ListeScroll")
                                                .FindElement(OpenQA.Selenium.By.Id("VerticalScrollBar"))
                                                .FindElement(OpenQA.Selenium.By.Id("PageDown"));

            var x = Array.ConvertAll(PageDown.GetAttribute("BoundingRectangle").Split(',').ToArray(), int.Parse);
            actions = new Actions(winiumDriver)
                        .MoveToElement(PageDown, (x[2] / 2), x[3] - 2);
            actions.Click().Perform();

            TakeScreenshot("ListView-" + pageDownName.ToString(), 4);
            pageDownName++;

            actions.Click().Perform();

            TakeScreenshot("ListView-" + pageDownName.ToString(), 4);
            pageDownName++;


        }

        public void KonfigurasyonGonderPopUpVar()
        {
            BtKonfigurasyon.Click();
            comboPopUp.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboPopUp.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("Pop Up Konfigurasyon", 4);
        }

        public void KonfigurasyonGonderSekmeVar()
        {
            BtKonfigurasyon.Click();
            comboSekme.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboSekme.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click(); BtKonfigurasyonGonder.Click();
            TakeScreenshot("Sekme Gonder Konfigurasyon", 4);
        }

        public void KonfigurasyonDurumBilgilendirme()
        {
            BtKonfigurasyon.Click();
            comboPopUp.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboPopUp.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click();
            BtKonfigurasyonGonder.Click();
            TakeScreenshot("Pop Up-" + imageName.ToString(), 4);
            imageName++;
            BtInfoYesil.Click();
            TakeScreenshot("Pop Up-" + imageName.ToString(), 4);
            imageName++;
            BtInfoSari.Click();
            TakeScreenshot("Pop Up-" + imageName.ToString(), 4);
            imageName++;
            BtInfoKirmizi.Click();
            TakeScreenshot("Pop Up-" + imageName.ToString(), 4);
            imageName++;
        }


        public void ClickKameraListViewAcik()
        {
            BtKonfigurasyon.Click();

            KonfigurasyonGonderListviewVar();
            KonfigurasyonGonderSekmeVar();
            BtKamera.Click();
            BtKameraKontrol.Click();
            TakeScreenshot("ListView Açıkken Kamera Bağlantı", 4);
        }
    }
}
