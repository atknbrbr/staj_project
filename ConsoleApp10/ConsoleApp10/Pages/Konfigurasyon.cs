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
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Pages
{
    public class Konfigurasyon
    {
        private readonly WiniumDriver winiumDriver;
        private readonly CruciatusElement winiumCruciatus;
        private readonly Actions actions;
        private int imageName;
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




        public Konfigurasyon(WiniumDriver _winiumDriver, CruciatusElement _winiumCruciatus)
        {
            imageName = 1;
            winiumDriver = _winiumDriver;
            winiumCruciatus = _winiumCruciatus;
            actions = new Actions(winiumDriver);
        }

        public void ClickKonfigurasyonMenu()
        {
            BtKonfigurasyon.Click();
            comboBoxes = winiumCruciatus.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']"))
                        .FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            comboListView = comboBoxes[0];
            comboPopUp = comboBoxes[1];
            comboSekme = comboBoxes[2];

            Thread.Sleep(500);
        }

        public void KonfigurasyonGonderHepsiYok()
        {
            BtKonfigurasyon.Click();
            BtKonfigurasyonGonder.Click();
        }

        public void ClickKameraHepsiYok()
        {
            BtKonfigurasyon.Click();
            BtKamera.Click();
            BtKameraKontrol.Click();
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
        }

        public void KonfigurasyonGonderSekmeVar()
        {
            BtKonfigurasyon.Click();
            comboSekme.FindElementByUid("KonfigurasyonCombobox").Click();
            Thread.Sleep(1000);
            var secenekler = comboSekme.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            var varYok = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            varYok[0].Click(); BtKonfigurasyonGonder.Click();
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
            TakeScreenshot.CaptureApp("Konfigürasyon-Pop Up-" + imageName.ToString());
            imageName++;
            BtInfoYesil.Click();
            TakeScreenshot.CaptureApp("Konfigürasyon-Pop Up-" + imageName.ToString());
            imageName++;
            BtInfoSari.Click();
            TakeScreenshot.CaptureApp("Konfigürasyon-Pop Up-" + imageName.ToString());
            imageName++;
            BtInfoKirmizi.Click();
            TakeScreenshot.CaptureApp("Konfigürasyon-Pop Up-" + imageName.ToString());
            imageName++;
        }


        public void ClickKameraListViewAcik()
        {
            BtKonfigurasyon.Click();

            KonfigurasyonGonderListviewVar();
            KonfigurasyonGonderSekmeVar();


            BtKamera.Click();
            BtKameraKontrol.Click();
        }



        //var listOfCombos = cruciatusElement.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']"))
        //                                .FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
        //foreach (CruciatusElement x in listOfCombos)
        //{
        //    x.FindElementByUid("KonfigurasyonCombobox").Click();
        //    Thread.Sleep(1000);
        //    var secenekler = x.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
        //    var cocuklar = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
        //    cocuklar[0].Click();
        //    Thread.Sleep(1000);
        //    //secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ScrollViewer']"));
        //    Thread.Sleep(1000);
        //}



        //var listOfCombos = cruciatusElement.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']")).FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']"));
        //    foreach (CruciatusElement x in listOfCombos)
        //    {
        //        x.FindElementByUid("KonfigurasyonCombobox").Click();
        //Thread.Sleep(1000);
        //    }
    }
}
