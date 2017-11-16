#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#SingleInstance force

Gui, Add, ListView, w100 h200 -Hdr -Multi hwndhwnd, A

Loop 200 {
	LV_Add("", "Line " A_Index)
}
Gui, Show, w200, Test AHK LV
return

GuiClose:
	ExitApp