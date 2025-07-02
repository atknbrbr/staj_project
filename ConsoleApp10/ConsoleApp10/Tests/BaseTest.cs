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

namespace ConsoleApp10.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected WiniumDriver driver;
        protected CruciatusElement cruciatusElement;

        [SetUp]
        public void Setup()
        {
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = "C:\\Users\\PC_7583\\Desktop\\Debug\\net8.0-windows\\wpfuygulamasi.exe";


            //
            // Uygulamanın sıfırdan çalışıp çalışmayacağına karar verilir.
            //
            Process[] appProcesses = Process.GetProcessesByName("wpfuygulamasi");
            if (appProcesses.Length == 0)
            {
                options.DebugConnectToRunningApp = false;
            }

            else
            {
                options.DebugConnectToRunningApp = true;
            }

            //
            // Driverın sıfırdan çalışıp çalışmayacağına karar verilir.
            //

            Process[] driverProcesses = Process.GetProcessesByName("Winium.Desktop.Driver");
            if (driverProcesses.Length == 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:/Users/PC_7583/Desktop/Winium.Desktop.Driver.exe"; 
                startInfo.Arguments = "";  
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;  
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;  

                Process process = Process.Start(startInfo);

                //driver = new WiniumDriver("C:/Users/PC_7583/Desktop/Winium.Desktop.Driver.exe", options, TimeSpan.FromSeconds(360));
            }

            driver = new WiniumDriver(new Uri("http://localhost:9999"), options, TimeSpan.FromSeconds(360));


            var winFinder = By.Name("Sekmeli Arayüz").AndType(ControlType.Window);
            cruciatusElement = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);

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
