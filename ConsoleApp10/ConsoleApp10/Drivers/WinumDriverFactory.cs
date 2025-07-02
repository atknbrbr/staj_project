using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Extensions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Threading;

namespace ConsoleApp10.Drivers
{
    public class WinumDriverFactory
    {
        public static WiniumDriver getWiniumDriver() {

            DesktopOptions options = new DesktopOptions();

            options.ApplicationPath = "C:/Users/PC_3462/Desktop/KullanıcıArayüz/net8.0-windows/wpfuygulamasi.exe";

            WiniumDriver winiumDriver = new WiniumDriver("C:/Users/PC_3462/Desktop/Winium.Desktop.Driver", options, TimeSpan.FromSeconds(360));

            Thread.Sleep(2000);

            return winiumDriver;
        }
    }
}
