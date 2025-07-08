using NUnit.Framework;
using OpenQA.Selenium.Winium;
using System.Threading;
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
            cruciatusElement = GetCruciatusElement();
            actions = GetActions();
            Thread.Sleep(1500);
            SetAppWindow();
        }

        //[TearDown]
        //public void Teardown() 
        //{ 
        //    driver.Quit();
        //}

    }
}
