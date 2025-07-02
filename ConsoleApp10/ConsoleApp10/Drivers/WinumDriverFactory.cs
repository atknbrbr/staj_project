using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using Winium.Cruciatus.Core;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Extensions;
using OpenQA.Selenium.Interactions;

namespace ConsoleApp10.Drivers
{
    public class WinumDriverFactory
    {
        private static WiniumDriver driver;
        private static CruciatusElement cruciatusElement;
        private static Actions actions;
        public static WiniumDriver GetWiniumDriver() {

            if (driver == null) 
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
            }
            return driver;
        }

        public static CruciatusElement GetCruciatusElement()
        {
            if (cruciatusElement == null) 
            {
                var winFinder = Winium.Cruciatus.Core.By.Name("Sekmeli Arayüz").AndType(ControlType.Window);
                cruciatusElement = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);
            }
            return cruciatusElement;
        }

        public static Actions GetActions()
        {
            if (actions == null)
            {
                actions = new Actions(driver);
            }
            return actions;
        }
    }
}
