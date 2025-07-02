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
    public class MotorTest : BaseTest
    {
        private Motor motor;

        [SetUp]
        public void MotorSetup()
        {
            motor = new Motor(driver, cruciatusElement);
        }

        [Test]
        public void ClickMotorMenuTest()
        {
            motor.ClickMotorMenu();
            //TakeScreenshot.CaptureApp("Motor");
            MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 0, "Motor");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickMotorGostergelerTabloTest()
        {
            motor.ClickMotorGostergelerTablo();
            MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 0, "Tablo Göster");
            Thread.Sleep(500);
        }

        [Test]
        public void ClickMotorGostergelerSecimTest()
        {
            motor.ClickMotorGostergelerSecim("irtifa_radiobuton");
            MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 0, "Seçilen Değer");
            Thread.Sleep(500);
        }


        [Test]
        public void ClickMotorGostergelerMotorAyarlariTest()
        {
            motor.ClickMotorGostergelerMotorAyarlari();
            Thread.Sleep(500);
        }

        [Test]
        public void ClickMotorDiagnostikMenuTest()
        {
            motor.ClickMotorDiagnostikMenu();
            Thread.Sleep(500);
        }
        [Test]
        public void ClickMotorAyarlarMenuTest()
        {
            motor.ClickMotorAyarlarMenu();
            MainHeaders.CreateSubFolders(cruciatusElement, 1, 1, 0, "Motor Ayarlar");
            Thread.Sleep(500);
        }
    }
}
