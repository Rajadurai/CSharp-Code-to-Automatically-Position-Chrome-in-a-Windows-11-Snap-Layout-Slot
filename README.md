# CSharp Code to Automatically Position Chrome in a Windows 11 Snap Layout Slot
This C# code demonstrates how to programmatically move and resize the Google Chrome browser window to fit into a specific snap layout position on Windows 11 (e.g., left half, right half, top-right quadrant, etc.)

Windows 11 Snap Layouts are built on top of standard window positioning APIs. This code uses the Windows API via P/Invoke to find the Chrome window and set its position/size to mimic a snap layout behavior — for example, docking Chrome to the left half of the screen.
