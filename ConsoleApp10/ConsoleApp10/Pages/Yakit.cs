using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Pages
{
    public class Yakit : BasePage
    {

        private IWebElement BtYakit => winiumDriver.FindElementById("Yakıt");
        private IWebElement BtRadio1 => winiumDriver.FindElementById("radio1");
        private IWebElement BtRadio2 => winiumDriver.FindElementById("radio2");
        private IWebElement BtRadio3 => winiumDriver.FindElementById("radio3");
        private IWebElement TxtPART => winiumDriver.FindElementById("PART_TextBox");
        private IWebElement TxtEminyet => winiumDriver.FindElementById("Emniyet");
        private IWebElement BtYakitGonder => winiumDriver.FindElementById("btnGonder");

        //
        // Yakıt başlığına tıklama
        //
        public void ClickYakitMenu()
        {
            BtYakit.Click();
            TakeScreenshot("Yakıt", 2);
            Thread.Sleep(500);
        }

        //
        // Yakıt radio button güncellemesi
        //
        public void ClickYakitRadioButtons()
        {
            BtYakit.Click();
            BtRadio1.Click();
            Thread.Sleep(100);
            BtRadio2.Click();
            Thread.Sleep(100);
            BtRadio3.Click();
            Thread.Sleep(250);
            TakeScreenshot("Radio Buton", 2);
        }

        //
        // Yakıt kısmında emniyeti açıp yakıt yükleme işlemi
        //
        public void ClickYakitYukle(String yakit)
        {
            BtYakit.Click();
            TxtPART.SendKeys(yakit);
            Thread.Sleep(100);
            TxtEminyet.Click();
            Thread.Sleep(50);
            TakeScreenshot("Emniyet Acik", 2);
            Thread.Sleep(100);
            BtYakitGonder.Click();
            Thread.Sleep(100);
            TakeScreenshot("Aktarim Yapiliyor", 2);
            Thread.Sleep(10000);
            TakeScreenshot("Aktarim Yapildi", 2);
            Thread.Sleep(250);
        }
    }
}
