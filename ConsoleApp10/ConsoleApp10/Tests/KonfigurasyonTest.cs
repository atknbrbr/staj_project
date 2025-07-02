using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10.Tests
{
    public class KonfigurasyonTest : BaseTest
    {
        private Konfigurasyon konfigurasyon;

        [SetUp]
        public void KonfigurasyonSetup()
        {
            konfigurasyon = new Konfigurasyon();
        }


        [Test]
        public void ClickKonfigurasyonMenuTest()
        {
            konfigurasyon.ClickKonfigurasyonMenu();
            MainHeaders.CreateSubFolders("Konfigurasyon", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickKameraHepsiYokTest()
        {
            konfigurasyon.ClickKameraHepsiYok();
            MainHeaders.CreateSubFolders("Kamera Test(Tum konfigurasyonlar kapalı)", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderListviewVarTest()
        {
            konfigurasyon.KonfigurasyonGonderListviewVar();
            MainHeaders.CreateSubFolders("ListView Konfigurasyon", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderPopUpVarTest()
        {
            konfigurasyon.KonfigurasyonGonderPopUpVar();
            MainHeaders.CreateSubFolders("Pop Up Konfigurasyon", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderSekmeVarTest()
        {
            konfigurasyon.KonfigurasyonGonderSekmeVar();
            MainHeaders.CreateSubFolders("Sekme Gonder Konfigurasyon", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonDurumBilgilendirmeTest()
        {
            konfigurasyon.KonfigurasyonDurumBilgilendirme();
            //TakeScreenshot.CaptureApp("Konfigurasyon");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickKameraListViewAcikTest()
        {
            konfigurasyon.ClickKameraListViewAcik();
            MainHeaders.CreateSubFolders("ListView Açıkken Kamera Bağlantı", cruciatusElement, 4);
            //TakeScreenshot.CaptureApp("Konfigurasyon-ListView Açıkken Kamera Bağlantı");
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderHepsiYokTest()
        {
            konfigurasyon.KonfigurasyonGonderHepsiYok();
            MainHeaders.CreateSubFolders("Konfigurasyon gönder(Tüm seçenekler yok)", cruciatusElement, 4);
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonListviewGoruntuTest()
        {
            konfigurasyon.KonfigurasyonListviewGoruntu();
            Thread.Sleep(500);
        }
    }
}
