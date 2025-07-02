using ConsoleApp10.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Winium.Cruciatus.Core;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Elements;
using OpenQA.Selenium.Interactions;
using static ConsoleApp10.Drivers.WinumDriverFactory;

namespace ConsoleApp10.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected WiniumDriver driver;
        protected CruciatusElement cruciatusElement;
        protected Actions actions;

        [SetUp]
        public void Setup()
        {
            driver = GetWiniumDriver();
            Thread.Sleep(1000);
            cruciatusElement = GetCruciatusElement();
            Thread.Sleep(750);
            actions = new Actions(driver);

            //
            // Çalışan uygulama işlemlerin yapılabilmesi için öne alınır
            //
            Thread.Sleep(1000);
            SetForegroundWindowApp.setWindow();
            Thread.Sleep(750);
            SetForegroundWindowApp.setWindow();


            //
            // Uygulama, tam ekran hale getirilir.
            //
            SetFullscreen.Fullscreen();

            MainHeaders.GetMainHeaders(cruciatusElement);
        }

        //[TearDown]
        //public void Teardown() 
        //{ 
        //    driver.Quit();
        //}

    }
}
