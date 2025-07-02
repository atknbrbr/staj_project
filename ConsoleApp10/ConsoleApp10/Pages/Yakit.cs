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
    public class Yakit
    {
        private readonly WiniumDriver winiumDriver;
        private readonly CruciatusElement winiumCruciatus;
        private String headerName;

        private IWebElement BtYakit => winiumDriver.FindElementById("Yakıt");
        private IWebElement BtRadio1 => winiumDriver.FindElementById("radio1");
        private IWebElement BtRadio2 => winiumDriver.FindElementById("radio2");
        private IWebElement BtRadio3 => winiumDriver.FindElementById("radio3");
        private IWebElement TxtPART => winiumDriver.FindElementById("PART_TextBox");
        private IWebElement TxtEminyet => winiumDriver.FindElementById("Emniyet");
        private IWebElement BtYakitGonder => winiumDriver.FindElementById("btnGonder");
        private IWebElement ElemComboMotor2 => winiumDriver.FindElementById("combobox_230");


        public Yakit(WiniumDriver _winiumDriver, CruciatusElement _winiumCruciatus)
        {
            winiumDriver = _winiumDriver;
            winiumCruciatus = _winiumCruciatus;
        }

        public void ClickYakitMenu()
        {
            BtYakit.Click();
            Thread.Sleep(500);
        }

        public void ClickYakitRadioButtons()
        {
            BtRadio1.Click();
            Thread.Sleep(100);
            BtRadio2.Click();
            Thread.Sleep(100);
            BtRadio3.Click();
            Thread.Sleep(250);
        }

        public void ClickYakitYukle(String yakit)
        {
            TxtPART.SendKeys(yakit);
            Thread.Sleep(100);
            TxtEminyet.Click();
            Thread.Sleep(50);
            TakeScreenshot.CaptureApp("Yakıt-EmniyetAcik");
            Thread.Sleep(100);
            BtYakitGonder.Click();
            Thread.Sleep(100);
            TakeScreenshot.CaptureApp("Yakıt-AktarimYapiliyor");
            Thread.Sleep(10000);
            TakeScreenshot.CaptureApp("Yakıt-AktarimYapildi");
            Thread.Sleep(250);
        }
    }
}
