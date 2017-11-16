using ManagedWinapi.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Tries to alter the colours of rows in a ListView from another application
/// Be sure to run TestWindow.exe (Or TestWindow.ahk if you have AutoHotkey installed) before running!
/// </summary>
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemWindow testWindow = null;
            SystemWindow lvWindow = null;

            foreach (var window in SystemWindow.AllToplevelWindows)
            {
                if (window.Title == "Test AHK LV")
                {
                    testWindow = window;
                    break;
                }
            }

            if (testWindow == null)
            {
                Console.WriteLine("Test window not found");
                return;
            }

            foreach (var window in testWindow.AllChildWindows)
            {
                if (window.PreviewContent.ComponentType == "DetailsListView")
                {
                    lvWindow = window;
                    break;
                }
            }

            if (lvWindow == null)
            {
                Console.WriteLine("ListView not found in Test window");
                return;
            }

            var lv = SystemListView.FromSystemWindow(lvWindow);

            var rect = lv.ClientRect;
            var iItems = lv.CountPerPage;
            var iTop = lv.TopIndex;

            var pt = lv[iTop].Position;
            for (int i = iTop; i <= iTop + iItems; i++)
            {
                rect.Top = pt.Y;
                rect.Bottom = lv[i + 1].Position.Y;
                var result = lvWindow.FillRect(rect, 0x0000FF);
            }
        }


    }
}
