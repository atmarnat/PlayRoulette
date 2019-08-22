using System;
using System.Diagnostics;
using TheGame;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
