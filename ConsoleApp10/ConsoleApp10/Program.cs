using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Winium.Cruciatus.Extensions;
using System.Windows.Automation;
using System.Windows.Forms;
using Winium.Cruciatus;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Core;

//using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;
using System.Runtime.InteropServices;

namespace ConsoleApp10
{
    public class Program
    {
        static void Main(string[] args)
        {

            //
            // Driver ve uygulama ile ilgili tanımlamalar
            //
            WiniumDriver winiumDriver;
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = "C:/Users/PC_7583/Desktop/Debug/net8.0-windows/wpfuygulamasi.exe";
            
            
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
            }

            else
            {
            }
            
            winiumDriver = new WiniumDriver(new Uri("http://localhost:9999"), options, TimeSpan.FromSeconds(360));

            var winFinder = Winium.Cruciatus.Core.By.Name("Sekmeli Arayüz").AndType(ControlType.Window);
            var cruciatusElement = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);

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
            //SetFullscreen.Fullscreen();



            MainHeaders.GetMainHeaders(cruciatusElement);

            //var headerButtons = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("//*[@ClassName='Button']"))
            //                                    .ToList()
            //                                    .Where(x => x.Properties.BoundingRectangle.Top == 36);


            //List<Headers> headers = new List<Headers>();
            //foreach (var element in headerButtons1) {
            //    headers.Add(new Headers(element.Properties.Name, null));
            //    var leght = headerButtons1.Count();
            //    var x = element.Properties.Name;
            //}

            //
            // Her bir sekme için objeler oluşturulur.
            //
            //Hazirlik hazirlik = new Hazirlik(winiumDriver);
            Motor motor = new Motor(winiumDriver, cruciatusElement);
            //Yakit yakit = new Yakit(winiumDriver);
            //Guc guc = new Guc(winiumDriver);
            //Konfigurasyon konfigurasyon = new Konfigurasyon(winiumDriver, cruciatusElement);
            //Thread.Sleep(2000);

            motor.ClickMotorDiagnostikMenu();
            //motor.ClickMotorMenu();
            //MainHeaders.CreateSubFolders("Motor Ana ekran", cruciatusElement, 1);


            //konfigurasyon.ClickKonfigurasyonMenu();
            //konfigurasyon.KonfigurasyonGonderSekmeVar();


            //winiumDriver.FindElementById("Konfigurasyon").Click();
            //var listOfCombos = cruciatusElement.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListView']"))
            //                                .FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            //foreach (CruciatusElement x in listOfCombos)
            //{
            //   // x.FindElementByUid("KonfigurasyonCombobox").Click();
            //    Thread.Sleep(1000);
            //    var secenekler = x.FindElement(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ComboBox']"));
            //    var cocuklar = secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']")).ToList();
            //    cocuklar[0].Click();
            //    Thread.Sleep(1000);
            //    //secenekler.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ScrollViewer']"));
            //    Thread.Sleep(1000);
            //}


            //            .FindElement(Winium.Cruciatus.Core.By.XPath("*[@AutomationId='DropDownScrollViewer']"))
            //.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='ListBoxItem']"))

            //
            // HAZIRLIK İŞLEMLERİ
            //
            //hazirlik.ClickHazirlikMenu();
            //Thread.Sleep(350);
            //hazirlik.GorevHazirlikGuncelle();
            //Thread.Sleep(350);
            //hazirlik.UcusHazirlikGuncelle();
            //Thread.Sleep(350);
            //hazirlik.UcusHazirlikSıfırlaPopUp();
            //Thread.Sleep(350);


            //var x = winiumDriver.FindElements(By.Name(""));

            //
            // MOTOR İŞLEMLERİ
            //
            //motor.ClickMotorMenu();
            //Thread.Sleep(350);
            //motor.ClickMotorGostergelerTablo();
            //Thread.Sleep(350);
            //motor.ClickMotorGostergelerSecim("irtifa_radiobuton");
            //Thread.Sleep(350);
            //motor.ClickMotorGostergelerMotorAyarlari();
            //Thread.Sleep(350);
            //motor.ClickMotorDiagnostikMenu(cruciatusElement);
            //Thread.Sleep(350);
            //motor.ClickMotorAyarlarMenu();
            //Thread.Sleep(350);



            //
            // YAKIT İŞLEMLERİ
            //
            //yakit.ClickYakitMenu();
            //yakit.ClickYakitRadioButtons();
            //yakit.ClickYakitYukle();

            //
            // GÜÇ İŞLEMLERİ
            //
            //guc.ClickGucMenu();
            //guc.GucSistemBataryasi();
            //guc.ClickGucAyarlarMenu();
            //guc.GucAyarlarMenu();


        }
    }
}


