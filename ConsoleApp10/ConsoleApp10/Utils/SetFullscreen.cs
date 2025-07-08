using System;
using static ConsoleApp10.Utils.PInvoke;

//
// Uygulama isminden yaralanılarak pencereyi tam ekran yapma işlemleri, user32.dll deki metodlardan yararlanılarak burada sağlanır
//

namespace ConsoleApp10.Utils
{
    public class SetFullscreen
    {
        public static void Fullscreen(String appName)
        {
            IntPtr mainProcess = FindWindow(null, appName);
            PInvoke.ShowWindow(mainProcess, SHOWMAXIMIZED);
        }
    }
}
