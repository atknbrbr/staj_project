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
            motor = new Motor();
        }

        [Test]
        public void ClickMotorMenuTest()
        {
            motor.ClickMotorMenu();
            //TakeScreenshot.CaptureApp("Motor");

            MainHeaders.CreateSubFolders("Motor", cruciatusElement, 1);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickMotorGostergelerTabloTest()
        {
            motor.ClickMotorGostergelerTablo();
            MainHeaders.CreateSubFolders("Tablo Göster", cruciatusElement, 1, 0, 0);
            Thread.Sleep(500);
        }

        [Test]
        public void ClickMotorGostergelerSecimTest()
        {
            motor.ClickMotorGostergelerSecim("irtifa_radiobuton");
            MainHeaders.CreateSubFolders("Seçilen Değer", cruciatusElement, 1, 0, 0);
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
            MainHeaders.CreateSubFolders("Motor Ayarlar", cruciatusElement, 1, 1);
            Thread.Sleep(500);
        }
    }
}
