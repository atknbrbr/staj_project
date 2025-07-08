using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp10.Tests
{
    public class KameraTest : BaseTest
    {
        private Kamera kamera;

        [SetUp]
        public void KameraSetup()
        {
            kamera = new Kamera();
        }

        [Test]
        public void ClickKameraListViewAcikTest()
        {
            kamera.ClickKameraListViewAcik();
            MainHeaders.CreateSubFolders("ListView Açıkken Kamera Bağlantı", cruciatusElement, 4);
            //TakeScreenshot.CaptureApp("Konfigurasyon-ListView Açıkken Kamera Bağlantı");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickKameraHepsiYokTest()
        {
            kamera.ClickKameraHepsiYok();
            MainHeaders.CreateSubFolders("Kamera Test(Tum konfigurasyonlar kapalı)", cruciatusElement, 4);
            Thread.Sleep(500);
        }
    }
}
