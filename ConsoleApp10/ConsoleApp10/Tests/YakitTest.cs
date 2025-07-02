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
    [TestFixture]
    public class YakitTest : BaseTest
    {
        private Yakit yakit;

        [SetUp]
        public void YakitSetup() 
        {
            yakit = new Yakit(driver, cruciatusElement);
            yakit.ClickYakitMenu();
        }

        [Test]
        public void ClickYakitMenuTest()
        {
            MainHeaders.CreateSubFolders("Yakıt", cruciatusElement, 2);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickYakitRadioButtonsTest()
        {
            yakit.ClickYakitRadioButtons();
            MainHeaders.CreateSubFolders("Radio Buton", cruciatusElement, 2);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickYakitYukleTest()
        {
            yakit.ClickYakitYukle("50");
            Thread.Sleep(500);
        }
    }
}
