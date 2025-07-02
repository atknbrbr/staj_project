using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winium.Cruciatus.Elements;
using static ConsoleApp10.Drivers.WinumDriverFactory;

namespace ConsoleApp10.Pages
{
    public class BasePage
    {
        protected WiniumDriver winiumDriver;
        protected CruciatusElement cruciatusElement;
        protected Actions actions;

        public BasePage() 
        {
            winiumDriver = GetWiniumDriver();
            actions = new Actions(winiumDriver);
            cruciatusElement = GetCruciatusElement();
        }
    }
}
