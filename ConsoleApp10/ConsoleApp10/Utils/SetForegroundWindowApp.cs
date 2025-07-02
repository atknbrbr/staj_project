using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp10.Utils.PInvoke;

namespace ConsoleApp10.Utils
{
    public static class SetForegroundWindowApp
    {
        public static void setWindow() {
            IntPtr mainProcess = FindWindow(null, "Sekmeli Arayüz");
            SetForegroundWindow(mainProcess);
        }
    }
}
