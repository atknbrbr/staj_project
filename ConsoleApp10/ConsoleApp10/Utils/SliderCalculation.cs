using ConsoleApp10.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Utils
{
    public static class SliderCalculation
    {
        private static int ustLimit, altLimit, guncelDeger;
        private static int fileName = 1;

        public static void CheckSliders(CruciatusElement cruciatusElement, Actions actions, IWebElement slider1, int a, int b, int c)
        {
            MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
            fileName++;
            //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
            ustLimit = a;
            altLimit = b;
            guncelDeger = c;

            if (guncelDeger < 0)
            {
                if (ustLimit < 0)
                {
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                
                else if (ustLimit > 0)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 0; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (ustLimit > 80)
                {
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
            }

            else if (guncelDeger >= 0 && guncelDeger < 80)
            {
                if (altLimit < 0)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;

                }
                if (ustLimit > 80)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 80; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (ustLimit > 200)
                {
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;

                }
            }
            else if (guncelDeger > 80 && guncelDeger < 200)
            {
                if (ustLimit > 200)
                {
                    actions.MoveToElement(slider1, 5, 10).Perform();
                    for (; guncelDeger <= 200; guncelDeger++)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;

                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (altLimit < 0)
                {
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
            }
            else
            {
                if (altLimit < 200)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 200; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (altLimit < 80)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 80; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
                if (altLimit < 0)
                {
                    actions.MoveToElement(slider1, 5, 190).Perform();
                    for (; guncelDeger >= 0; guncelDeger--)
                    {
                        actions.Click().Perform();
                    }
                    MainHeaders.CreateSubFolders(cruciatusElement, 1, 0, 1, "Diagnostik-" + fileName.ToString());
                    //TakeScreenshot.CaptureApp("Motor-MotorDegerler-Diagnostik-" + fileName.ToString());
                    fileName++;
                }
            }
        }
    }
}
