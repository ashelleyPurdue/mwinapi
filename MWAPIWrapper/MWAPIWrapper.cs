using ManagedWinapi.Hooks;
using ManagedWinapi.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MWAPIWrapper
{
    // Wrapper for a ListView that allows coloring of rows
    public class ColoredLV
    {
        private SystemListView lv;
        private SystemWindow lvWindow;
        private Hook MyHook;

        public void Add(string _hwnd)
        {
            IntPtr hwnd = (IntPtr)Convert.ToInt32(_hwnd, 16);
            lvWindow = new SystemWindow(hwnd);
            lv = SystemListView.FromSystemWindow(lvWindow);

            MyHook = new Hook(HookType.WH_CALLWNDPROC, false, false);
            MyHook.Callback += MyHookCallback;
            MyHook.StartHook();
        }

        public void SetRowColor(int row, uint color)
        {
            var rect = lv.ClientRect;
            rect.Top = lv[row].Position.Y;
            rect.Bottom = lv[row + 1].Position.Y;
            lvWindow.FillRect(rect, color);
        }

        // Reference: https://stackoverflow.com/questions/2880160/listening-to-another-window-resize-events-in-c-sharp
        private static int MyHookCallback(int code, IntPtr wParam, IntPtr lParam, ref bool callNext)
        {
            if (code >= 0)
            {
                // You will need to define the struct
                var message = (CWPSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPSTRUCT));
                switch (message.message)
                {
                    case 0x0014: // WM_ERASEBKGND
                        var a = 1;
                        break;
                    case 0x000F: // WM_PAINT
                        var b = 1;
                        break;
                }
                // Do something with the data
            }
            return 0; // Return value is ignored unless you set callNext to false
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPSTRUCT
        {
            public IntPtr lparam;
            public IntPtr wparam;
            public int message;
            public IntPtr hwnd;
        }
    }

    public static class Helpers
    {
        /// <summary>
        /// Helper method to let test app find the LV in the AHK test script
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public static SystemWindow GetFirstLV(SystemWindow sw)
        {
            foreach (var window in sw.AllChildWindows)
            {
                if (window.PreviewContent.ComponentType == "DetailsListView")
                {
                    return window;
                }
            }
            return null;
        }

        /// <summary>
        /// Helper method to let test app find the AHK test script window
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static SystemWindow GetWindowFromTitle(string title)
        {
            foreach (var window in SystemWindow.AllToplevelWindows)
            {
                if (window.Title == "Test AHK LV")
                {
                    return window;
                }
            }
            return null;
        }
    }
}
