using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace MoveChromeToLeftHalf
{
    internal class Program
    {
        const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOP = IntPtr.Zero;
        private const uint SWP_SHOWWINDOW = 0x0040;

        static void Main(string[] args)
        {
            string ProcessName = "chrome";  // Process name without .exe
            var chromeProcesses = Process.GetProcessesByName(ProcessName);
            if (chromeProcesses.Length == 0)
            {
                Console.WriteLine("chrome browser is not running");
                return;
            }
            else { }


            // Get the primary screen size
            int screenWidth = GetSystemMetrics(0);
            int screenHeight = GetSystemMetrics(1);

            // Define snap layout - Left half of the screen
            int snapX = 0;
            int snapY = 0;
            int snapWidth = screenWidth/2;
            int snapHeight = screenHeight;
            Console.WriteLine(chromeProcesses.Length);
            foreach (var process in chromeProcesses)
            {
                IntPtr hWnd = process.MainWindowHandle;
                if(hWnd == IntPtr.Zero)
                {
                    continue;
                }
                // Restore window if minimized
                ShowWindow(hWnd, SW_RESTORE);

                //Position the window
                SetWindowPos(hWnd, HWND_TOP, snapX, snapY, snapWidth, snapHeight, SWP_SHOWWINDOW);

                Console.WriteLine("Chrome browser move to left half of the window screen");
                break;
            }

        }

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);
    }
}
