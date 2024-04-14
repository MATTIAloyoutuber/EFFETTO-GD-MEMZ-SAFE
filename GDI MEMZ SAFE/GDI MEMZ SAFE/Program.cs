using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ScreenBlinker
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, uint dwRop);

        static void Main(string[] args)
        {
            int screenWidth = 1920;
            int screenHeight = 1080;

            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            IntPtr hdc = desktopPtr;

            while (true)
            {
                PatBlt(hdc, 0, 0, screenWidth, screenHeight, 0x005A0049);
                Thread.Sleep(100);
                PatBlt(hdc, 0, 0, screenWidth, screenHeight, 0x005A0049);
                Thread.Sleep(100);
            }

            ReleaseDC(IntPtr.Zero, desktopPtr);
        }
    }
}
