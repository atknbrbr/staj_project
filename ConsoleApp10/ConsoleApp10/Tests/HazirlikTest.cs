using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10.Tests
{
    [TestFixture]
    public class HazirlikTest : BaseTest
    {
        private Hazirlik hazirlik;

        [SetUp]
        public void HazirlikSetup()
        {
            hazirlik = new Hazirlik(driver);
        }

        [Test]
        public void ClickHazirlikMenuTest()
        {
            hazirlik.ClickHazirlikMenu();
            //TakeScreenshot.CaptureApp("Hazırlık");
            MainHeaders.CreateSubFolders(cruciatusElement,0,0,0,"Hazırlık ana ekran");
            Thread.Sleep(500);
        }

        [Test]
        public void GorevHazirlikGuncelle()
        {
            hazirlik.GorevHazirlikGuncelle("123");
            MainHeaders.CreateSubFolders(cruciatusElement, 0, 0, 0, "Görev Hazırlık");
            Thread.Sleep(500);
        }

        [Test]
        public void UcusHazirlikGuncelle()
        {
            hazirlik.UcusHazirlikGuncelle("123");
            MainHeaders.CreateSubFolders(cruciatusElement, 0, 0, 0, "Uçuş Hazırlık");
            Thread.Sleep(500);
        }


        [Test]
        public void UcusHazirlikSıfırlaPopUp()
        {
            hazirlik.UcusHazirlikSıfırlaPopUp();
            MainHeaders.CreateSubFolders(cruciatusElement, 0, 0, 0, "Uçuş Hazırlık-Sıfırla Pop Up");
            Thread.Sleep(500);

        }

    }
}
