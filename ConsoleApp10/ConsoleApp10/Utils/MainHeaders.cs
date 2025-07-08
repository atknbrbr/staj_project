using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Winium.Cruciatus.Elements;

namespace ConsoleApp10.Utils
{
    public class MainHeaders
    {
        public static String rootPath;
        private static List<String> mainHeaders;
        private static List<String> subheader1;
        private static List<String> subheader2;

        //
        // Ana başlık için butonlardan isim bilgisi çekilir
        //
        static MainHeaders()
        {
            subheader1 = new List<String>();
            subheader2 = new List<String>();
            mainHeaders = new List<String>();

            rootPath = Directory.GetCurrentDirectory() + "/Uygulama - " + DateTime.Now.ToString("dd MM yyyy - HH.mm");
            Directory.CreateDirectory(rootPath);
        }

        //
        // Alt başlık(lar) için butonlardan isim bilgisi çekilir
        //
        public static void GetMainHeaders(CruciatusElement cruciatusElement)
        {
            var headerButtons = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='Button']"))
                                                .ToList()
                                                .Where(x => x.Properties.BoundingRectangle.Top == 29);

            foreach (var headerButton in headerButtons) 
            {
                mainHeaders.Add(headerButton.Properties.Name);
            }
        }

        //
        // Başka bir başlığa geçildiğinde değişkenleri yeni başlığa hazır getirmek amacıyla temizlemek için kullanılır
        //
        public static void ResetSubHeaders()
        {
            subheader1.Clear();
            subheader2.Clear();
        }

        //
        // Alt başlık(lar) için butonlardan isim bilgisi çekilir, işlenir ve ekran görüntü alma metodları çağırılır
        //
        public static void CreateSubFolders(String description, CruciatusElement cruciatusElement, int mainHeader, int sub1 = -1, int sub2 = -1)
        {
            String fullPath = mainHeaders[mainHeader] + "-";

            if (sub1 < 0)
            {
                ScreenCapture.CaptureApp(fullPath + description);
                return;
            }

            if (subheader1.Count == 0)
            {
                // Belirli yatak eksene göre buton arama işlemi
                var subHeader1 = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("*[@ClassName='Button']"))
                                            .ToList()
                                            .Where(y => y.Properties.BoundingRectangle.Top == 85);


                foreach (var header1 in subHeader1)
                {
                    subheader1.Add(header1.Properties.Name);
                }

            }
            fullPath += subheader1[sub1] + "-";

            if (sub2 < 0)
            {
                ScreenCapture.CaptureApp(fullPath + description);
                return;
            }

            if (subheader2.Count == 0)
            {
                // Belirli yatak eksene göre buton arama işlemi
                var subHeader2 = cruciatusElement.FindElements(Winium.Cruciatus.Core.By.XPath("//*[@ClassName='Button']"))
                                                                        .ToList()
                                                                        .Where(z => z.Properties.BoundingRectangle.Top == 137);
                // Buton bilgilerini(isimlerini) kaydetme
                foreach (var header2 in subHeader2)
                {
                    subheader2.Add(header2.Properties.Name);
                }
            }
            fullPath += subheader2[sub2] + "-";
            ScreenCapture.CaptureApp(fullPath + description);
            return;
        }
    }
}
