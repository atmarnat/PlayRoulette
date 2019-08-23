using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TheGame;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleWnd = Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 375, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            Console.SetWindowSize(105, 44);
            Console.WriteLine("\t\t\t\t\t$~$~$~$~$~$~$");
            Console.WriteLine("\t\t\t\t\t$ ROULETTE! $");
            Console.WriteLine("\t\t\t\t\t$~$~$~$~$~$~$\n");
            
            Play.Game();

            Console.WriteLine("\n\t\t\t\t   $~$~$~$~$~$~$~$~$~$~$~$~$");
            Console.WriteLine("\t\t\t\t   $ Thank's for playing!! $");
            Console.WriteLine("\t\t\t\t   $~$~$~$~$~$~$~$~$~$~$~$~$\n");
            Console.ReadKey();
        }

        //a fun bit of code that sets the console window position
        //https://stackoverflow.com/questions/32418918/reposition-console-window-relative-to-screen
        //pulled directly from stack overflow link above
        static class Imports
        {
            public static IntPtr HWND_BOTTOM = (IntPtr)1;
            // public static IntPtr HWND_NOTOPMOST = (IntPtr)-2;
            public static IntPtr HWND_TOP = (IntPtr)0;
            // public static IntPtr HWND_TOPMOST = (IntPtr)-1;

            public static uint SWP_NOSIZE = 1;
            public static uint SWP_NOZORDER = 4;

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);
        }

    }
}
