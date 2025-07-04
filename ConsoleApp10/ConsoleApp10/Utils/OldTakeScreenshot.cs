using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp10.Utils.PInvoke;

namespace ConsoleApp10.Utils
{   /*
    internal class OldTakeScreenshot
    {
        private void OldSS()
        {
            IntPtr handle = FindWindow(null, "Sekmeli Arayüz");

            // get te hDC of the target window

            //IntPtr hdcSrc = GetWindowDC(handle);

            // get the size
            RECT windowRect = new RECT();
            GetWindowRect(handle, ref windowRect);
            int width = windowRect.Right - windowRect.Left;
            int height = windowRect.Bottom - windowRect.Top;
            // create a device context we can copy to



            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            const int PW_CLIENTONLY = 0x1;
            const int PW_RENDERFULLCONTENT = 0x2;

            bool succeeded = PrintWindow(handle, hdcBitmap, PW_CLIENTONLY | PW_RENDERFULLCONTENT);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            if (!succeeded)
            {
                bmp.Dispose();
                return;
            }
        }
    }
    */
}
