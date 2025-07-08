using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp10.Tests
{
    [TestFixture]
    public class HazirlikTest : BaseTest
    {
        private Hazirlik hazirlik;

        [SetUp]
        public void HazirlikSetup()
        {
            hazirlik = new Hazirlik();
        }

        [Test]
        public void ClickHazirlikMenuTest()
        {
            hazirlik.ClickHazirlikMenu();
            //TakeScreenshot.CaptureApp("Hazırlık");
            //MainHeaders.CreateSubFolders("Hazırlık ana ekran", cruciatusElement, 0);
            Thread.Sleep(500);
        }

        [Test]
        public void GorevHazirlikGuncelle()
        {
            hazirlik.GorevHazirlikGuncelle("123");
            //MainHeaders.CreateSubFolders("Görev Hazırlık", cruciatusElement, 0);
            Thread.Sleep(500);
        }

        [Test]
        public void UcusHazirlikGuncelle()
        {
            hazirlik.UcusHazirlikGuncelle("123");
            MainHeaders.CreateSubFolders("Uçuş Hazırlık", cruciatusElement, 0);
            Thread.Sleep(500);
        }


        [Test]
        public void UcusHazirlikSıfırlaPopUp()
        {
            hazirlik.UcusHazirlikSıfırlaPopUp();
            MainHeaders.CreateSubFolders("Uçuş Hazırlık-Sıfırla Pop Up", cruciatusElement, 0);
            Thread.Sleep(500);

        }

    }
}
