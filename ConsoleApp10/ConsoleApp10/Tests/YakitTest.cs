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
        }

        [Test]
        public void ClickYakitMenuTest()
        {
            yakit.ClickYakitMenu();
            TakeScreenshot.CaptureApp("Yakıt");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickYakitRadioButtonsTest()
        {
            yakit.ClickYakitRadioButtons();
            TakeScreenshot.CaptureApp("Yakıt-RadioButon");
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
