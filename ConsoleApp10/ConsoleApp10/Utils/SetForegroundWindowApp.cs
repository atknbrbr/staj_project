using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp10.Utils.PInvoke;

namespace ConsoleApp10.Utils
{
    //
    // Uygulamayı ön ekrana alıp işlem görmesini sağlar
    //
    public static class SetForegroundWindowApp
    {
        public static void setWindow(String appName) {
            IntPtr mainProcess = FindWindow(null, appName);
            SetForegroundWindow(mainProcess);
        }
    }
}
