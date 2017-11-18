using ManagedWinapi.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWAPIWrapper
{
    // Wrapper for a ListView that allows coloring of rows
    public class ColoredLV
    {
        private SystemListView lv;
        private SystemWindow lvWindow;

        public void Add(string _hwnd)
        {
            IntPtr hwnd = (IntPtr)Convert.ToInt32(_hwnd, 16);
            lvWindow = new SystemWindow(hwnd);
            lv = SystemListView.FromSystemWindow(lvWindow);
        }

        public void SetRowColor(int row, uint color)
        {
            var rect = lv.ClientRect;
            rect.Top = lv[row].Position.Y;
            rect.Bottom = lv[row + 1].Position.Y;
            lvWindow.FillRect(rect, color);
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
