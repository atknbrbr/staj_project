using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Extensions;

namespace ConsoleApp10.Drivers
{
    public class WinumDriverFactory
    {
        private static WiniumDriver driver;
        private static CruciatusElement cruciatusElement;
        private static Actions actions;
        private static bool windowCheck = false;

        //
        // WiniumDriver objesi çağırma metodu
        //
        public static WiniumDriver GetWiniumDriver() {

            if (driver == null) 
            {
                DesktopOptions options = new DesktopOptions();
                options.ApplicationPath = "C:\\Users\\PC_7583\\Desktop\\Debug\\net8.0-windows\\wpfuygulamasi.exe";


                //
                // Uygulamanın sıfırdan çalışıp çalışmama durumu kontrol edilip aksiyon alınır.
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
                // Driverın sıfırdan çalışıp çalışmama durumu kontrol edilip aksiyon alınır.
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
                }

                driver = new WiniumDriver(new Uri("http://localhost:9999"), options, TimeSpan.FromSeconds(360));
            }
            return driver;
        }

        //
        // Bazı element bulma işlemlerinı kolaylaştırdığı için aynı zamanda WiniumCruciatus'dan CruciatusElement nesnesi de kullanılıyor.
        // CruciatusElement objesi çağırma metodu
        //
        public static CruciatusElement GetCruciatusElement()
        {
            if (cruciatusElement == null) 
            {
                var winFinder = Winium.Cruciatus.Core.By.Name("Sekmeli Arayüz").AndType(ControlType.Window);
                cruciatusElement = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);
            }
            return cruciatusElement;
        }

        //
        // İmleci hareket ettirebilmek için Selenium'dan gelen Actions objesi gerekiyor.
        // Actions objesi çağırma metodu
        //
        public static Actions GetActions()
        {
            if (actions == null)
            {
                actions = new Actions(driver);
            }
            return actions;
        }

        public static void SetAppWindow()
        {
            if (!windowCheck)
            {
                //
                // Çalışan uygulama işlemlerin yapılabilmesi için uygulama öne alınır
                //
                Thread.Sleep(1000);
                SetForegroundWindowApp.setWindow("Sekmeli Arayüz");
                Thread.Sleep(750);
                SetForegroundWindowApp.setWindow("Sekmeli Arayüz");


                //
                // Uygulama, tam ekran hale getirilir.
                //
                SetFullscreen.Fullscreen("Sekmeli Arayüz");
                windowCheck = true;


                //
                // Uygulama üzerinden ana butonlar okunur.
                //
                MainHeaders.GetMainHeaders(cruciatusElement);
            }
        }
    }
}
