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
    public class TakeScreenshot
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
                    Thread.Sleep(200);

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
            




            

            /*
            // Cater for cases when the process can't be located.
            try
            {
                proc = Process.GetProcessesByName(windowTitle)[0];
            }
            catch (IndexOutOfRangeException e)
            {
                return;
            }

            // You need to focus on the application
            PInvoke.SetForegroundWindow(proc.MainWindowHandle);
            PInvoke.ShowWindow(proc.MainWindowHandle, SW_RESTORE);

            // You need some amount of delay, but 1 second may be overkill
            Thread.Sleep(1000);

            RECT rect = new RECT();
            IntPtr error = GetWindowRect(proc.MainWindowHandle, ref rect);

            // sometimes it gives error.
            while (error == IntPtr.Zero)
            {
                error = GetWindowRect(proc.MainWindowHandle, ref rect);
                break;
            }

            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(bmp).CopyFromScreen(rect.Left,
                                                   rect.Top,
                                                   0,
                                                   0,
                                                   new Size(width, height),
                                                   CopyPixelOperation.SourceCopy);

            bmp.Save("test2.png", ImageFormat.Png);



            /*
            IntPtr hWnd = PInvoke.FindWindow(null, windowTitle);

            PInvoke.RECT rect;
            if (!PInvoke.GetWindowRect(hWnd, out rect))
            {
                Console.WriteLine("Pencere boyutları alınamadı.");
                return;
            }

            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics gfxBmp = Graphics.FromImage(bmp))
                {
                    IntPtr hdcBitmap = gfxBmp.GetHdc();
                    // Ekran görüntüsünü al
                    PInvoke.PrintWindow(hWnd, hdcBitmap, 0);
                    gfxBmp.ReleaseHdc(hdcBitmap);
                }

                // Dosyaya kaydet
                bmp.Save("testSs.png", ImageFormat.Png);

            */

        }
        
    }
}
