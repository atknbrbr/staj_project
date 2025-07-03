using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winium.Cruciatus;
using static ConsoleApp10.Utils.PInvoke;
using System.Threading;

namespace ConsoleApp10.Utils
{
    public class ScreenCapture
    {
        private const int SW_RESTORE = 9;
        private static String path;


        public static Image CaptureApp(String fileName)
        {
            path = MainHeaders.rootPath;

            String[] words = fileName.Split('-').ToArray();

            foreach (string word in words)
            {
                Directory.CreateDirectory(path + "/" + word);
                path = path + "/" + word;

                if (Int32.TryParse(word, out int test) || word == null || word == words[words.Length - 2])
                {
                    break;
                }

            }

            Image img = null;
            Process[] mainProcess = Process.GetProcessesByName("wpfuygulamasi");
            if (mainProcess.Length != 0)
            {
                IntPtr process = mainProcess[0].MainWindowHandle;

                Thread t = new Thread(() =>
                {
                    if (PInvoke.IsIconic(process))
                    {
                        PInvoke.ShowWindowAsync(process, PInvoke.SHOWNORMAL);
                    }

                    PInvoke.SetForegroundWindow(process);

                    SendKeys.SendWait("%({PRTSC})");
                    Thread.Sleep(1000);

                    img = System.Windows.Forms.Clipboard.GetImage();

                    IntPtr clipWindow = PInvoke.GetOpenClipboardWindow();
                    PInvoke.OpenClipboard(clipWindow);
                    PInvoke.EmptyClipboard();
                    PInvoke.CloseClipboard();
                    Thread.Sleep(150);

                });

                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();

                String date = path + "/" + words.Last() + ".png";

                img.Save(date, ImageFormat.Png);
                return img;
            }
            else
            {
                return null;
            }
        }
    }
}
