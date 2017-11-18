#Persistent
#include CLR.ahk

Gui, Add, ListView, w100 h200 -Hdr -Multi hwndhwnd, A

Loop 200 {
	LV_Add("", "Line " A_Index)
}
Gui, Show, w200, Test AHK LV

asm := CLR_LoadLibrary("MWAPIWrapper.dll")
test := asm.CreateInstance("MWAPIWrapper.ColoredLV")
;~ msgbox % test.Test(hwnd)
test.Add(hwnd)
test.SetRowColor(1, 0xFF0000)
;~ MsgBox % test.Blah()
return
