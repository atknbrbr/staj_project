using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Utils
{
    public class MainHeaders
    {
        public static String rootPath;
        static MainHeaders()
        {
            rootPath = Directory.GetCurrentDirectory() + "/Uygulama - " + DateTime.Now.ToString("dd MM yyyy - HH.mm");
            Directory.CreateDirectory(rootPath);
        }

        public static List<String> mainHeaders;
        public static List<String> subheader1;
        public static List<String> subheader2;


        public static void GetMainHeaders(CruciatusElement cruciatusElement)
        {
            List<String> _mainHeaders = new List<String>();
            var headerButtons = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("//*[@ClassName='Button']"))
                                                .ToList()
                                                .Where(x => x.Properties.BoundingRectangle.Top == 29);

            foreach (var headerButton in headerButtons) 
            {
                _mainHeaders.Add(headerButton.Properties.Name);
            }

            mainHeaders = _mainHeaders;
        }

        public static void CreateSubFolders(CruciatusElement cruciatusElement, int mainHeader, int sub1, int sub2, String description)
        {
            subheader1 = new List<String>();
            subheader2 = new List<String>();

            if (subheader1 != new List<String>() ||subheader2 != new List<String>())
            {
                if (subheader2.Any())
                {
                    TakeScreenshot.CaptureApp(mainHeaders[mainHeader] + "-" + subheader1[sub1] + "-" + subheader2[sub2] + "-" + description);
                    return;
                }
                TakeScreenshot.CaptureApp(mainHeaders[mainHeader] + "-" + subheader1[sub1] + "-" + description);
                return;
            }


            var subHeader1 = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("//*[@ClassName='Button']"))
                                            .ToList()
                                            .Where(x => x.Properties.BoundingRectangle.Top == 85);

            if (subHeader1.Any())
            {
                foreach (var header1 in subHeader1)
                {
                    subheader1.Add(header1.Properties.Name);
                }

                var subHeader2 = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("//*[@ClassName='Button']"))
                                                                            .ToList()
                                                                            .Where(x => x.Properties.BoundingRectangle.Top == 137);

                if (subHeader2.Any())
                {
                    foreach (var header2 in subHeader2)
                    {
                        subheader2.Add(header2.Properties.Name);
                    }
                    TakeScreenshot.CaptureApp(mainHeaders[mainHeader] + "-" + subheader1[sub1] + "-" + subheader2[sub2] + "-" + description);
                    return;
                }
                TakeScreenshot.CaptureApp(mainHeaders[mainHeader] + "-" + subheader1[sub1] + "-" + description);
                return;
            }
            TakeScreenshot.CaptureApp(mainHeaders[mainHeader] +  "-" + description);
            return;


        }


    }
}
