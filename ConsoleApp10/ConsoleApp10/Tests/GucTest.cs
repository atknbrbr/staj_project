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
            guc = new Guc();
        }

        [Test]
        public void ClickGucMenuTest()
        {
            guc.ClickGucMenu();
            MainHeaders.CreateSubFolders("Güç", cruciatusElement, 3, 0);
            //MainHeaders.CreateSubFolders("Güç", cruciatusElement, 3, 0);
            Thread.Sleep(500);
        }

        [Test]
        public void GucSistemBataryasiTest()
        {
            guc.GucSistemBataryasi();
            Thread.Sleep(500);
        }

        [Test]
        public void ClickGucSistemiMenuTest()
        {
            guc.ClickGucSistemiMenu();
            MainHeaders.CreateSubFolders("Güç Sistemi", cruciatusElement, 3, 0);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickGucAyarlarMenuTest()
        {
            guc.ClickGucAyarlarMenu();
            MainHeaders.CreateSubFolders("Güç Ayarlar", cruciatusElement, 3, 1);
            Thread.Sleep(500);
        }

        [Test]
        public void GucAyarlarMenuTest()
        {
            guc.GucAyarlarMenu();
            Thread.Sleep(500);
        }
    }
}
