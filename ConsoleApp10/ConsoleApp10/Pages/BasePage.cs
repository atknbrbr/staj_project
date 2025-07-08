using ConsoleApp10.Utils;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Threading;
using Winium.Cruciatus.Elements;
using static ConsoleApp10.Drivers.WinumDriverFactory;

namespace ConsoleApp10.Pages
{
    //
    // Tüm sayfaların miras aldığı Base sınıf. Bu sınıfta driverlar, driverların tanımlanması
    // ve dışarıdan CruciatusElement bilgisi olmadan ekran görüntüsü alınabilmesi için TakeScreenshot sınıfı bulunmaktadır
    //
    public class BasePage
    {
        protected WiniumDriver winiumDriver;
        protected CruciatusElement cruciatusElement;
        protected Actions actions;

        public BasePage() 
        {
            winiumDriver = GetWiniumDriver();
            actions = GetActions();
            cruciatusElement = GetCruciatusElement();
            Thread.Sleep(1500);
            SetAppWindow();
        }

        public void TakeScreenshot(String description, int mainHeader, int sub1 = -1, int sub2 = -1)
        {
            MainHeaders.CreateSubFolders(description, cruciatusElement, mainHeader, sub1, sub2);
        }

    }
}
