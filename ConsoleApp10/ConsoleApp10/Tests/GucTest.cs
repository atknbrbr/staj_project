using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10.Tests
{
    public class GucTest : BaseTest
    {
        private Guc guc;

        [SetUp]
        public void GucSetup()
        {
            guc = new Guc(driver, cruciatusElement);
        }

        [Test]
        public void ClickGucMenuTest()
        {
            guc.ClickGucMenu();
            TakeScreenshot.CaptureApp("Güç");
            Thread.Sleep(500);
        }

        [Test]
        public void GucSistemBataryasiTest()
        {
            guc.GucSistemBataryasi();
            TakeScreenshot.CaptureApp("Güç");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickGucSistemiMenuTest()
        {
            guc.ClickGucSistemiMenu();
            TakeScreenshot.CaptureApp("Güç-Güç Sistemi");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickGucAyarlarMenuTest()
        {
            guc.ClickGucAyarlarMenu();
            TakeScreenshot.CaptureApp("Güç-Güç Ayarlar");
            Thread.Sleep(500);
        }

        [Test]
        public void GucAyarlarMenuTest()
        {
            guc.GucAyarlarMenu();
            TakeScreenshot.CaptureApp("Güç");
            Thread.Sleep(500);
        }
    }
}
