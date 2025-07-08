using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace ConsoleApp10.Utils
{
    //
    // Ekran yakalama işlemini gerçekleştiren sınıf
    //
    public class ScreenCapture
    {
        private static String path;

        //
        // Dosya yolu düzenlenir, sonrasında "ALT+PRINT" tuş kombinasyonu uygulanır, yakalanan görüntü, önceden belirlenen dosya yoluna kaydedilir.
        //
        public static Image CaptureApp(String fileName)
        {
            path = MainHeaders.rootPath;

            String[] words = fileName.Split('-').ToArray();

            foreach (string word in words)
            {
                Directory.CreateDirectory(path + "/" + word);
                path = path + "/" + word;

                if (word == null || word == words[words.Length - 2])
                {
                    break;
                }

            }

            Image img = null;
            Process[] mainProcess = Process.GetProcessesByName("wpfuygulamasi");
            if (mainProcess.Length != 0)
            {
                IntPtr process = mainProcess[0].MainWindowHandle;

                // Ekran görüntüsü alma thread i oluşturulur.
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

                    // Aşağıdaki kısım, panonun temizlenmesi için çalışır.
                    IntPtr clipWindow = PInvoke.GetOpenClipboardWindow();
                    PInvoke.OpenClipboard(clipWindow);
                    PInvoke.EmptyClipboard();
                    PInvoke.CloseClipboard();
                    Thread.Sleep(150);

                });

                t.SetApartmentState(ApartmentState.STA);        // Thread yapılandırılır
                t.Start();                                      // Thread çalıştırılır
                t.Join();                                       // Ana thread, t threadinin bitmesini bekler 

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
