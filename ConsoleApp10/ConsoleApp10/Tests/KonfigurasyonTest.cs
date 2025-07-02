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
            konfigurasyon = new Konfigurasyon(driver, cruciatusElement);
            konfigurasyon.ClickKonfigurasyonMenu();
        }


        [Test]
        public void ClickKonfigurasyonMenuTest()
        {
            konfigurasyon.ClickKonfigurasyonMenu();
            TakeScreenshot.CaptureApp("Konfigurasyon");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickKameraHepsiYokTest()
        {
            konfigurasyon.ClickKameraHepsiYok();
            MainHeaders.CreateSubFolders(cruciatusElement, 4, 0, 0, "Kamera1");
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderListviewVarTest()
        {
            konfigurasyon.KonfigurasyonGonderListviewVar();
            TakeScreenshot.CaptureApp("Konfigurasyon-ListView Var");
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderPopUpVarTest()
        {
            konfigurasyon.KonfigurasyonGonderPopUpVar();
            TakeScreenshot.CaptureApp("Konfigurasyon-Pop Up Var");
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderSekmeVarTest()
        {
            konfigurasyon.KonfigurasyonGonderSekmeVar();
            TakeScreenshot.CaptureApp("Konfigurasyon-Sekme Gönderme Var");
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
            TakeScreenshot.CaptureApp("Konfigurasyon-ListView Açıkken Kamera Bağlantı");
            Thread.Sleep(500);
        }

        [Test]
        public void KonfigurasyonGonderHepsiYokTest()
        {
            konfigurasyon.KonfigurasyonGonderHepsiYok();
            TakeScreenshot.CaptureApp("Konfigurasyon-Konfigurasyon gönder(Tüm seçenekler yok)");
            Thread.Sleep(500);
        }

    }
}
