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
            // Get the HWND of the LV in the Test AHK script
            var sw = MWAPIWrapper.Helpers.GetWindowFromTitle("Test AHK LV");
            var lvWindow = MWAPIWrapper.Helpers.GetFirstLV(sw);

            // Test normal usage from AHK

            // Instantiate class on lv...
            var clv = new MWAPIWrapper.ColoredLV(lvWindow.HWnd);

            // Set the row color
            clv.SetRowColor(1, 0xFF0000);
        }
    }
}
