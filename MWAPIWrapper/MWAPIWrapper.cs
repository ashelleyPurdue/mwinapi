﻿using ManagedWinapi.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MWAPIWrapper
{
    public class ColoredLV
    {
        //public ColoredLV(IntPtr hwnd)
        //{

        //}
    }

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