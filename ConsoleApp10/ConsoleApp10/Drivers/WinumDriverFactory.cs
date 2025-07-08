using ConsoleApp10.Utils;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Automation;
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Drivers
{
    //
    // BasePage'in constructor'ında nesneleri çağırdığı sınıf.
    //
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

                //
                // Uygulamanın sıfırdan çalışıp çalışmama durumu kontrol edilip aksiyon alınır.
                //
                Process[] appProcesses = Process.GetProcessesByName("wpfuygulamasi");
                
                // Arkada çalışan uygulama yoksa, uygulama dizini önceden verilmelidir.
                if (appProcesses.Length == 0)
                {
                    options.ApplicationPath = "C:\\Users\\PC_7583\\Desktop\\uygulamaV2\\net8.0-windows\\wpfuygulamasi.exe";
                    options.DebugConnectToRunningApp = false;
                }
                else
                {
                    // Arkada çalışan birden fazla uygulama varsa, fazladan çalışan uygulamalar kapatılır, sadece 1 uygulama çalışır duruma gelir.
                    if (appProcesses.Length > 1)
                    {
                        for (int i = appProcesses.Length - 1; i>0; i--)
                        {
                            appProcesses[i].Kill();
                        }
                    }

                    // Burada çalışan uygulama dair dizin bulma işlemi gerçekleşir (WMI (Windows Management Instrumentation) kullanır.)
                    var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
                    using (var searcher = new ManagementObjectSearcher(wmiQueryString))
                    using (var results = searcher.Get())
                    {
                        var query = from p in Process.GetProcesses()
                                    join mo in results.Cast<ManagementObject>()
                                    on p.Id equals (int)(uint)mo["ProcessId"]
                                    select new
                                    {
                                        Process = p,
                                        Path = (string)mo["ExecutablePath"],
                                    };
                        foreach (var item in query)
                        {
                            if (item.Process.ProcessName == appProcesses[0].ProcessName)
                            {
                                options.ApplicationPath = item.Path;                       
                                break;
                            }
                        }
                    }
                    options.DebugConnectToRunningApp = true;
                }
                //
                // Driverın sıfırdan çalışıp çalışmama durumu kontrol edilip aksiyon alınır.
                //
                Process[] driverProcesses = Process.GetProcessesByName("Winium.Desktop.Driver");
                
                // Bu kısımda, driver cmd ekranı açılmayacak şekilde sıfırdan process çalıştırılır. 
                if (driverProcesses.Length == 0)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"C:/Winium.Desktop.Driver/Winium.Desktop.Driver.exe";
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

        //
        // Uygulama penceresi düzenlenme işlemleri
        //
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
