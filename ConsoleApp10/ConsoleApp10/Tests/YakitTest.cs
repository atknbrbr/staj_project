﻿using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp10.Tests
{
    [TestFixture]
    public class YakitTest : BaseTest
    {
        private Yakit yakit;

        [SetUp]
        public void YakitSetup() 
        {
            yakit = new Yakit();
        }

        [Test]
        public void ClickYakitMenuTest()
        {
            yakit.ClickYakitMenu();
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
