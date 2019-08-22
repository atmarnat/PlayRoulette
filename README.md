# PlayRoulette
A simple console-based roulette game, now with a "wheel" like object that goes while you are placing bets, and an executable to play wherever you want! (on windows)

Not required, but adds some immersion to the game: (read notes at bottom first, so you understand)
The game uses an executable in order to run a "wheel-like" object. In order to create this executable, I took part of the code from https://github.com/gerard-rappa/Roulette and made a few modifications. By default, this executable does not exist and must be created in order to be used. These are the steps that you need in order to get it to work:
  1. Clone https://github.com/atmarnat/PlayRoulette.git in Visual Studio
  1. Build the project (or just debug it)
  1. Close the project
  1. Create a new .NET Framework C# project in VS named Spinner
  1. Replace the default file with the code below
  1. Build the project, but DO NOT DEBUG IT. Debugging will cause it to crash
  1. Locate the executable Spinner.exe under \bin\Debug
  1. Move the executable to \PlayRoulette\bin\Debug, in the PlayRoulette project
  1. Close the spinner project, open the PlayRoulette project
  1. Either run the PlayRoulette from VS or just use the executable.
  
Note: Both executables must be in the same directory for them to work together. PlayRoulette will work on its own, but Spinner will not.

**__IMPORTANT: Do not run the PlayRoulette executable in a directory with file called "Spinner.exe" unless you know exactly what it does. PlayRoulette blindly calls any executable called "Spinner.exe", so if there is a malicious version, there could be horrible consequences.__**

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spinner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(45, 20);
            Console.SetWindowPosition(01, 01);
            
            int[] arr = new int[] {0, 18, 37, 14, 33, 10, 29, 6, 25, 2, 21, 5, 24, 17, 36, 13, 32, 9, 28, 26, 7, 30, 11, 34, 15, 22, 3, 20, 1, 23, 4, 27, 8, 31, 12, 35, 16, 19};
            int i = arr[Int32.Parse(args[0])]; //Get the input from the arguments. This converts the real result to the case form.
            int spin = 0;
            int speed = 300;
            Console.ForegroundColor = ConsoleColor.White;
            while (spin <= 38*20)//make length a random WHILE SPIN < 59
            {
                Console.Clear();
                Number x = new Number(i);
                Console.WriteLine();
                Console.BackgroundColor = x.background;
                Console.WriteLine(x.representation);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                // USE THESE IF STATEMENTS TO MAKE SMOOTH SLOWDOWN and make wheel spin for about 60 seconds
                if (spin < 646) speed = 25;
                if (spin >= 646 && spin < 722) speed = 100;
                if (spin >= 722 && spin < 741) speed = 175;
                if (spin >= 741 && spin < 750) speed = 300;
                if (spin >= 750 && spin < 755) speed = 400;
                if (spin >= 755) speed = 525;
                spin++;

                System.Threading.Thread.Sleep(speed);
                if (i < 37) i++;
                else i = 0;
            }
            Console.ReadLine();
        }
    }
    public class Number
    {
        public string representation;
        public ConsoleColor background;

        public Number(int number)//numbers don't match case because roulette table is not in order
        {
            switch (number)
            {
                case 0:
                    this.background = ConsoleColor.DarkGreen;
                    this.representation = "|                000000000               |\n|              00:::::::::00             |\n|            00:::::::::::::00           |\n|           0:::::::000:::::::0          |\n|           0::::::0   0::::::0          |\n|           0:::::0     0:::::0          |\n|           0:::::0     0:::::0          |\n|           0:::::0 000 0:::::0          |\n|           0:::::0 000 0:::::0          |\n|           0:::::0     0:::::0          |\n|           0:::::0     0:::::0          |\n|           0::::::0   0::::::0          |\n|           0:::::::000:::::::0          |\n|            00:::::::::::::00           |\n|              00:::::::::00             |\n|                000000000               |";
                    break;

                case 18:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|                1111111                 |\n|               1::::::1                 |\n|              1:::::::1                 |\n|              111:::::1                 |\n|                 1::::1                 |\n|                 1::::1                 |\n|                 1::::1                 |\n|                 1::::l                 |\n|                 1::::l                 |\n|                 1::::l                 |\n|                 1::::l                 |\n|                 1::::l                 |\n|              111::::::111              |\n|              1::::::::::1              |\n|              1::::::::::1              |\n|              111111111111              |";
                    break;

                case 37:
                    this.background = ConsoleColor.Black;
                    this.representation = "|           222222222222222              |\n|          2:::::::::::::::22            |\n|          2::::::222222:::::2           |\n|          2222222     2:::::2           |\n|                      2:::::2           |\n|                      2:::::2           |\n|                   2222::::2            |\n|              22222::::::22             |\n|            22::::::::222               |\n|           2:::::22222                  |\n|          2:::::2                       |\n|          2:::::2                       |\n|          2:::::2       222222          |\n|          2::::::2222222:::::2          |\n|          2::::::::::::::::::2          |\n|          22222222222222222222          |";
                    break;

                case 14:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|            333333333333333             |\n|           3:::::::::::::::33           |\n|           3::::::33333::::::3          |\n|           3333333     3:::::3          |\n|                       3:::::3          |\n|                       3:::::3          |\n|               33333333:::::3           |\n|               3:::::::::::3            |\n|               33333333:::::3           |\n|                       3:::::3          |\n|                       3:::::3          |\n|                       3:::::3          |\n|           3333333     3:::::3          |\n|           3::::::33333::::::3          |\n|           3:::::::::::::::33           |\n|            333333333333333             |";
                    break;

                case 33:
                    this.background = ConsoleColor.Black;
                    this.representation = "|                  444444444             |\n|                 4::::::::4             |\n|                4:::::::::4             |\n|               4::::44::::4             |\n|              4::::4 4::::4             |\n|             4::::4  4::::4             |\n|            4::::4   4::::4             |\n|           4::::444444::::444           |\n|           4::::::::::::::::4           |\n|           4444444444:::::444           |\n|                     4::::4             |\n|                     4::::4             |\n|                     4::::4             |\n|                   44::::::44           |\n|                   4::::::::4           |\n|                   4444444444           |";
                    break;

                case 10:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|           555555555555555555           |\n|           5::::::::::::::::5           |\n|           5::::::::::::::::5           |\n|           5:::::555555555555           |\n|           5:::::5                      |\n|           5:::::5                      |\n|           5:::::5555555555             |\n|           5:::::::::::::::5            |\n|           555555555555:::::5           |\n|                       5:::::5          |\n|                       5:::::5          |\n|           5555555     5:::::5          |\n|           5::::::55555::::::5          |\n|            55:::::::::::::55           |\n|              55:::::::::55             |\n|                555555555               |";
                    break;

                case 29:
                    this.background = ConsoleColor.Black;
                    this.representation = "|                   66666666             |\n|                  6::::::6              |\n|                 6::::::6               |\n|                6::::::6                |\n|               6::::::6                 |\n|              6::::::6                  |\n|             6::::::6                   |\n|            6::::::::66666              |\n|           6::::::::::::::66            |\n|           6::::::66666:::::6           |\n|           6:::::6     6:::::6          |\n|           6:::::6     6:::::6          |\n|           6::::::66666::::::6          |\n|            66:::::::::::::66           |\n|              66:::::::::66             |\n|                666666666               |";
                    break;

                case 6:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|          77777777777777777777          |\n|          7::::::::::::::::::7          |\n|          7::::::::::::::::::7          |\n|          777777777777:::::::7          |\n|                     7::::::7           |\n|                    7::::::7            |\n|                   7::::::7             |\n|                  7::::::7              |\n|                 7::::::7               |\n|                7::::::7                |\n|               7::::::7                 |\n|              7::::::7                  |\n|             7::::::7                   |\n|            7::::::7                    |\n|           7::::::7                     |\n|          77777777                      |";
                    break;

                case 25:
                    this.background = ConsoleColor.Black;
                    this.representation = "|                888888888               |\n|              88:::::::::88             |\n|            88:::::::::::::88           |\n|           8::::::88888::::::8          |\n|           8:::::8     8:::::8          |\n|           8:::::8     8:::::8          |\n|            8:::::88888:::::8           |\n|             8:::::::::::::8            |\n|            8:::::88888:::::8           |\n|           8:::::8     8:::::8          |\n|           8:::::8     8:::::8          |\n|           8:::::8     8:::::8          |\n|           8::::::88888::::::8          |\n|            88:::::::::::::88           |\n|              88:::::::::88             |\n|                888888888               |";
                    break;

                case 2:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|                999999999               |\n|              99:::::::::99             |\n|            99:::::::::::::99           |\n|           9::::::99999::::::9          |\n|           9:::::9     9:::::9          |\n|           9:::::9     9:::::9          |\n|            9:::::99999::::::9          |\n|             99::::::::::::::9          |\n|               99999::::::::9           |\n|                    9::::::9            |\n|                   9::::::9             |\n|                  9::::::9              |\n|                 9::::::9               |\n|                9::::::9                |\n|               9::::::9                 |\n|              99999999                  |";
                    break;

                case 21:
                    this.background = ConsoleColor.Black;
                    this.representation = "|     1111111           000000000        |\n|    1::::::1         00:::::::::00      |\n|   1:::::::1       00:::::::::::::00    |\n|   111:::::1      0:::::::000:::::::0   |\n|      1::::1      0::::::0   0::::::0   |\n|      1::::1      0:::::0     0:::::0   |\n|      1::::1      0:::::0     0:::::0   |\n|      1::::l      0:::::0 000 0:::::0   |\n|      1::::l      0:::::0 000 0:::::0   |\n|      1::::l      0:::::0     0:::::0   |\n|      1::::l      0:::::0     0:::::0   |\n|      1::::l      0::::::0   0::::::0   |\n|   111::::::111   0:::::::000:::::::0   |\n|   1::::::::::1    00:::::::::::::00    |\n|   1::::::::::1      00:::::::::00      |\n|   111111111111        000000000        |";
                    break;

                case 5:
                    this.background = ConsoleColor.Black;
                    this.representation = "|       1111111           1111111        |\n|      1::::::1          1::::::1        |\n|     1:::::::1         1:::::::1        |\n|     111:::::1         111:::::1        |\n|        1::::1            1::::1        |\n|        1::::1            1::::1        |\n|        1::::1            1::::1        |\n|        1::::l            1::::l        |\n|        1::::l            1::::l        |\n|        1::::l            1::::l        |\n|        1::::l            1::::l        |\n|        1::::l            1::::l        |\n|     111::::::111      111::::::111     |\n|     1::::::::::1      1::::::::::1     |\n|     1::::::::::1      1::::::::::1     |\n|     111111111111      111111111111     |";
                    break;

                case 24:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|    1111111        222222222222222      |\n|   1::::::1       2:::::::::::::::22    |\n|  1:::::::1       2::::::222222:::::2   |\n|  111:::::1       2222222     2:::::2   |\n|     1::::1                   2:::::2   |\n|     1::::1                   2:::::2   |\n|     1::::1                2222::::2    |\n|     1::::l           22222::::::22     |\n|     1::::l         22::::::::222       |\n|     1::::l        2:::::22222          |\n|     1::::l       2:::::2               |\n|     1::::l       2:::::2               |\n|  111::::::111    2:::::2       222222  |\n|  1::::::::::1    2::::::2222222:::::2  |\n|  1::::::::::1    2::::::::::::::::::2  |\n|  111111111111    22222222222222222222  |";
                    break;

                case 17:
                    this.background = ConsoleColor.Black;
                    this.representation = "|     1111111       333333333333333      |\n|    1::::::1      3:::::::::::::::33    |\n|   1:::::::1      3::::::33333::::::3   |\n|   111:::::1      3333333     3:::::3   |\n|      1::::1                  3:::::3   |\n|      1::::1                  3:::::3   |\n|      1::::1          33333333:::::3    |\n|      1::::l          3:::::::::::3     |\n|      1::::l          33333333:::::3    |\n|      1::::l                  3:::::3   |\n|      1::::l                  3:::::3   |\n|      1::::l                  3:::::3   |\n|   111::::::111   3333333     3:::::3   |\n|   1::::::::::1   3::::::33333::::::3   |\n|   1::::::::::1   3:::::::::::::::33    |\n|   111111111111    333333333333333      |";
                    break;

                case 36:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|      1111111            444444444      |\n|     1::::::1           4::::::::4      |\n|    1:::::::1          4:::::::::4      |\n|    111:::::1         4::::44::::4      |\n|       1::::1        4::::4 4::::4      |\n|       1::::1       4::::4  4::::4      |\n|       1::::1      4::::4   4::::4      |\n|       1::::l     4::::444444::::444    |\n|       1::::l     4::::::::::::::::4    |\n|       1::::l     4444444444:::::444    |\n|       1::::l               4::::4      |\n|       1::::l               4::::4      |\n|    111::::::111            4::::4      |\n|    1::::::::::1          44::::::44    |\n|    1::::::::::1          4::::::::4    |\n|    111111111111          4444444444    |";
                    break;

                case 13:
                    this.background = ConsoleColor.Black;
                    this.representation = "|     1111111      555555555555555555    |\n|    1::::::1      5::::::::::::::::5    |\n|   1:::::::1      5::::::::::::::::5    |\n|   111:::::1      5:::::555555555555    |\n|      1::::1      5:::::5               |\n|      1::::1      5:::::5               |\n|      1::::1      5:::::5555555555      |\n|      1::::l      5:::::::::::::::5     |\n|      1::::l      555555555555:::::5    |\n|      1::::l                  5:::::5   |\n|      1::::l                  5:::::5   |\n|      1::::l      5555555     5:::::5   |\n|   111::::::111   5::::::55555::::::5   |\n|   1::::::::::1    55:::::::::::::55    |\n|   1::::::::::1      55:::::::::55      |\n|   111111111111        555555555        |";
                    break;

                case 32:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|     1111111              66666666      |\n|    1::::::1             6::::::6       |\n|   1:::::::1            6::::::6        |\n|   111:::::1           6::::::6         |\n|      1::::1          6::::::6          |\n|      1::::1         6::::::6           |\n|      1::::1        6::::::6            |\n|      1::::l       6::::::::66666       |\n|      1::::l      6::::::::::::::66     |\n|      1::::l      6::::::66666:::::6    |\n|      1::::l      6:::::6     6:::::6   |\n|      1::::l      6:::::6     6:::::6   |\n|   111::::::111   6::::::66666::::::6   |\n|   1::::::::::1    66:::::::::::::66    |\n|   1::::::::::1      66:::::::::66      |\n|   111111111111        666666666        |";
                    break;

                case 9:
                    this.background = ConsoleColor.Black;
                    this.representation = "|    1111111       77777777777777777777  |\n|   1::::::1       7::::::::::::::::::7  |\n|  1:::::::1       7::::::::::::::::::7  |\n|  111:::::1       777777777777:::::::7  |\n|     1::::1                  7::::::7   |\n|     1::::1                 7::::::7    |\n|     1::::1                7::::::7     |\n|     1::::l               7::::::7      |\n|     1::::l              7::::::7       |\n|     1::::l             7::::::7        |\n|     1::::l            7::::::7         |\n|     1::::l           7::::::7          |\n|  111::::::111       7::::::7           |\n|  1::::::::::1      7::::::7            |\n|  1::::::::::1     7::::::7             |\n|  111111111111    77777777              |";
                    break;

                case 28:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|     1111111           888888888        |\n|    1::::::1         88:::::::::88      |\n|   1:::::::1       88:::::::::::::88    |\n|   111:::::1      8::::::88888::::::8   |\n|      1::::1      8:::::8     8:::::8   |\n|      1::::1      8:::::8     8:::::8   |\n|      1::::1       8:::::88888:::::8    |\n|      1::::l        8:::::::::::::8     |\n|      1::::l       8:::::88888:::::8    |\n|      1::::l      8:::::8     8:::::8   |\n|      1::::l      8:::::8     8:::::8   |\n|      1::::l      8:::::8     8:::::8   |\n|   111::::::111   8::::::88888::::::8   |\n|   1::::::::::1    88:::::::::::::88    |\n|   1::::::::::1      88:::::::::88      |\n|   111111111111        888888888        |";
                    break;

                case 26:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|      1111111         999999999         |\n|     1::::::1       99:::::::::99       |\n|    1:::::::1     99:::::::::::::99     |\n|    111:::::1    9::::::99999::::::9    |\n|       1::::1    9:::::9     9:::::9    |\n|       1::::1    9:::::9     9:::::9    |\n|       1::::1     9:::::99999::::::9    |\n|       1::::l      99::::::::::::::9    |\n|       1::::l        99999::::::::9     |\n|       1::::l             9::::::9      |\n|       1::::l            9::::::9       |\n|       1::::l           9::::::9        |\n|    111::::::111       9::::::9         |\n|    1::::::::::1      9::::::9          |\n|    1::::::::::1     9::::::9           |\n|    111111111111    99999999            |";
                    break;

                case 7:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222          000000000     |\n|2:::::::::::::::22      00:::::::::00   |\n|2::::::222222:::::2   00:::::::::::::00 |\n|2222222     2:::::2  0:::::::000:::::::0|\n|            2:::::2  0::::::0   0::::::0|\n|            2:::::2  0:::::0     0:::::0|\n|         2222::::2   0:::::0     0:::::0|\n|    22222::::::22    0:::::0 000 0:::::0|\n|  22::::::::222      0:::::0 000 0:::::0|\n| 2:::::22222         0:::::0     0:::::0|\n|2:::::2              0:::::0     0:::::0|\n|2:::::2              0::::::0   0::::::0|\n|2:::::2       222222 0:::::::000:::::::0|\n|2::::::2222222:::::2  00:::::::::::::00 |\n|2::::::::::::::::::2    00:::::::::00   |\n|22222222222222222222      000000000     |";
                    break;

                case 30:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "|   222222222222222          1111111     |\n|  2:::::::::::::::22       1::::::1     |\n|  2::::::222222:::::2     1:::::::1     |\n|  2222222     2:::::2     111:::::1     |\n|              2:::::2        1::::1     |\n|              2:::::2        1::::1     |\n|           2222::::2         1::::1     |\n|      22222::::::22          1::::l     |\n|    22::::::::222            1::::l     |\n|   2:::::22222               1::::l     |\n|  2:::::2                    1::::l     |\n|  2:::::2                    1::::l     |\n|  2:::::2       222222    111::::::111  |\n|  2::::::2222222:::::2    1::::::::::1  |\n|  2::::::::::::::::::2    1::::::::::1  |\n|  22222222222222222222    111111111111  |";
                    break;

                case 11:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222     222222222222222    |\n|2:::::::::::::::22  2:::::::::::::::22  |\n|2::::::222222:::::2 2::::::222222:::::2 |\n|2222222     2:::::2 2222222     2:::::2 |\n|            2:::::2             2:::::2 |\n|            2:::::2             2:::::2 |\n|         2222::::2           2222::::2  |\n|    22222::::::22       22222::::::22   |\n|  22::::::::222       22::::::::222     |\n| 2:::::22222         2:::::22222        |\n|2:::::2             2:::::2             |\n|2:::::2             2:::::2             |\n|2:::::2       2222222:::::2       222222|\n|2::::::2222222:::::22::::::2222222:::::2|\n|2::::::::::::::::::22::::::::::::::::::2|\n|2222222222222222222222222222222222222222|";
                    break;

                case 34:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 222222222222222      333333333333333   |\n|2:::::::::::::::22   3:::::::::::::::33 |\n|2::::::222222:::::2  3::::::33333::::::3|\n|2222222     2:::::2  3333333     3:::::3|\n|            2:::::2              3:::::3|\n|            2:::::2              3:::::3|\n|         2222::::2       33333333:::::3 |\n|    22222::::::22        3:::::::::::3  |\n|  22::::::::222          33333333:::::3 |\n| 2:::::22222                     3:::::3|\n|2:::::2                          3:::::3|\n|2:::::2                          3:::::3|\n|2:::::2       222222 3333333     3:::::3|\n|2::::::2222222:::::2 3::::::33333::::::3|\n|2::::::::::::::::::2 3:::::::::::::::33 |\n|22222222222222222222  333333333333333   |";
                    break;

                case 15:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222             444444444  |\n|2:::::::::::::::22          4::::::::4  |\n|2::::::222222:::::2        4:::::::::4  |\n|2222222     2:::::2       4::::44::::4  |\n|            2:::::2      4::::4 4::::4  |\n|            2:::::2    4::::4   4::::4  |\n|         2222::::2    4::::4    4::::4  |\n|    22222::::::22     4::::444444::::444|\n|  22::::::::222       4::::::::::::::::4|\n| 2:::::22222          4444444444:::::444|\n|2:::::2                         4::::4  |\n|2:::::2                         4::::4  |\n|2:::::2       222222            4::::4  |\n|2::::::2222222:::::2          44::::::44|\n|2::::::::::::::::::2          4::::::::4|\n|22222222222222222222          4444444444|";
                    break;

                case 22:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 222222222222222     555555555555555555 |\n|2:::::::::::::::22   5::::::::::::::::5 |\n|2::::::222222:::::2  5::::::::::::::::5 |\n|2222222     2:::::2  5:::::555555555555 |\n|            2:::::2  5:::::5            |\n|            2:::::2  5:::::5            |\n|         2222::::2   5:::::5555555555   |\n|    22222::::::22    5:::::::::::::::5  |\n|  22::::::::222      555555555555:::::5 |\n| 2:::::22222                     5:::::5|\n|2:::::2                          5:::::5|\n|2:::::2              5555555     5:::::5|\n|2:::::2       222222 5::::::55555::::::5|\n|2::::::2222222:::::2  55:::::::::::::55 |\n|2::::::::::::::::::2    55:::::::::55   |\n|22222222222222222222      555555555     |";
                    break;

                case 3:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222             66666666   |\n|2:::::::::::::::22          6::::::6    |\n|2::::::222222:::::2        6::::::6     |\n|2222222     2:::::2       6::::::6      |\n|            2:::::2      6::::::6       |\n|            2:::::2     6::::::6        |\n|         2222::::2     6::::::6         |\n|    22222::::::22     6::::::::66666    |\n|  22::::::::222      6::::::::::::::66  |\n| 2:::::22222         6::::::66666:::::6 |\n|2:::::2              6:::::6     6:::::6|\n|2:::::2              6:::::6     6:::::6|\n|2:::::2       222222 6::::::66666::::::6|\n|2::::::2222222:::::2  66:::::::::::::66 |\n|2::::::::::::::::::2    66:::::::::66   |\n|22222222222222222222      666666666     |";
                    break;

                case 20:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 222222222222222    77777777777777777777|\n|2:::::::::::::::22  7::::::::::::::::::7|\n|2::::::222222:::::2 7::::::::::::::::::7|\n|2222222     2:::::2 777777777777:::::::7|\n|            2:::::2            7::::::7 |\n|            2:::::2           7::::::7  |\n|         2222::::2           7::::::7   |\n|    22222::::::22           7::::::7    |\n|  22::::::::222            7::::::7     |\n| 2:::::22222              7::::::7      |\n|2:::::2                  7::::::7       |\n|2:::::2                 7::::::7        |\n|2:::::2       222222   7::::::7         |\n|2::::::2222222:::::2  7::::::7          |\n|2::::::::::::::::::2 7::::::7           |\n|2222222222222222222277777777            |";
                    break;

                case 1:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222          888888888     |\n|2:::::::::::::::22      88:::::::::88   |\n|2::::::222222:::::2   88:::::::::::::88 |\n|2222222     2:::::2  8::::::88888::::::8|\n|            2:::::2  8:::::8     8:::::8|\n|            2:::::2  8:::::8     8:::::8|\n|         2222::::2    8:::::88888:::::8 |\n|    22222::::::22      8:::::::::::::8  |\n|  22::::::::222       8:::::88888:::::8 |\n| 2:::::22222         8:::::8     8:::::8|\n|2:::::2              8:::::8     8:::::8|\n|2:::::2             8:::::8      8:::::8|\n|2:::::2       222222 8::::::88888::::::8|\n|2::::::2222222:::::2  88:::::::::::::88 |\n|2::::::::::::::::::2    88:::::::::88   |\n|22222222222222222222      888888888     |";
                    break;

                case 23:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 222222222222222          999999999     |\n|2:::::::::::::::22      99:::::::::99   |\n|2::::::222222:::::2   99:::::::::::::99 |\n|2222222     2:::::2  9::::::99999::::::9|\n|            2:::::2  9:::::9     9:::::9|\n|            2:::::2  9:::::9     9:::::9|\n|         2222::::2    9:::::99999::::::9|\n|    22222::::::22      99::::::::::::::9|\n|  22::::::::222          99999::::::::9 |\n| 2:::::22222                  9::::::9  |\n|2:::::2                      9::::::9   |\n|2:::::2                     9::::::9    |\n|2:::::2       222222       9::::::9     |\n|2::::::2222222:::::2      9::::::9      |\n|2::::::::::::::::::2     9::::::9       |\n|22222222222222222222    99999999        |";
                    break;

                case 4:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 333333333333333          000000000     |\n|3:::::::::::::::33      00:::::::::00   |\n|3::::::33333::::::3   00:::::::::::::00 |\n|3333333     3:::::3  0:::::::000:::::::0|\n|            3:::::3  0::::::0   0::::::0|\n|            3:::::3  0:::::0     0:::::0|\n|    33333333:::::3   0:::::0     0:::::0|\n|    3:::::::::::3    0:::::0 000 0:::::0|\n|    33333333:::::3   0:::::0 000 0:::::0|\n|            3:::::3  0:::::0     0:::::0|\n|            3:::::3  0:::::0     0:::::0|\n|            3:::::3  0::::::0   0::::::0|\n|3333333     3:::::3  0:::::::000:::::::0|\n|3::::::33333::::::3   00:::::::::::::00 |\n|3:::::::::::::::33      00:::::::::00   |\n| 333333333333333          000000000     |";
                    break;

                case 27:
                    this.background = ConsoleColor.Black;
                    this.representation = "|    333333333333333        1111111      |\n|   3:::::::::::::::33     1::::::1      |\n|   3::::::33333::::::3   1:::::::1      |\n|   3333333     3:::::3   111:::::1      |\n|               3:::::3      1::::1      |\n|               3:::::3      1::::1      |\n|       33333333:::::3       1::::1      |\n|       3:::::::::::3        1::::l      |\n|       33333333:::::3       1::::l      |\n|               3:::::3      1::::l      |\n|               3:::::3      1::::l      |\n|               3:::::3      1::::l      |\n|   3333333     3:::::3   111::::::111   |\n|   3::::::33333::::::3   1::::::::::1   |\n|   3:::::::::::::::33    1::::::::::1   |\n|    333333333333333      111111111111   |";
                    break;

                case 8:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 333333333333333     222222222222222    |\n|3:::::::::::::::33  2:::::::::::::::22  |\n|3::::::33333::::::3 2::::::222222:::::2 |\n|3333333     3:::::3 2222222     2:::::2 |\n|            3:::::3             2:::::2 |\n|            3:::::3             2:::::2 |\n|    33333333:::::3           2222::::2  |\n|    3:::::::::::3       22222::::::22   |\n|    33333333:::::3    22::::::::222     |\n|            3:::::3  2:::::22222        |\n|            3:::::3 2:::::2             |\n|            3:::::3 2:::::2             |\n|3333333     3:::::3 2:::::2       222222|\n|3::::::33333::::::3 2::::::2222222:::::2|\n|3:::::::::::::::33  2::::::::::::::::::2|\n| 333333333333333    22222222222222222222|";
                    break;

                case 31:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 333333333333333      333333333333333   |\n|3:::::::::::::::33   3:::::::::::::::33 |\n|3::::::33333::::::3  3::::::33333::::::3|\n|3333333     3:::::3  3333333     3:::::3|\n|            3:::::3              3:::::3|\n|            3:::::3              3:::::3|\n|    33333333:::::3       33333333:::::3 |\n|    3:::::::::::3        3:::::::::::3  |\n|    33333333:::::3       33333333:::::3 |\n|            3:::::3              3:::::3|\n|            3:::::3              3:::::3|\n|            3:::::3              3:::::3|\n|3333333     3:::::3  3333333     3:::::3|\n|3::::::33333::::::3  3::::::33333::::::3|\n|3:::::::::::::::33   3:::::::::::::::33 |\n| 333333333333333      333333333333333   |";
                    break;

                case 12:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 333333333333333            444444444   |\n|3:::::::::::::::33         4::::::::4   |\n|3::::::33333::::::3       4:::::::::4   |\n|3333333     3:::::3      4::::44::::4   |\n|            3:::::3     4::::4 4::::4   |\n|            3:::::3    4::::4  4::::4   |\n|    33333333:::::3    4::::4   4::::4   |\n|    3:::::::::::3    4::::444444::::444 |\n|    33333333:::::3   4::::::::::::::::4 |\n|            3:::::3  4444444444:::::444 |\n|            3:::::3            4::::4   |\n|            3:::::3            4::::4   |\n|3333333     3:::::3            4::::4   |\n|3::::::33333::::::3          44::::::44 |\n|3:::::::::::::::33           4::::::::4 |\n| 333333333333333             4444444444 |";
                    break;

                case 35:
                    this.background = ConsoleColor.Black;
                    this.representation = "| 333333333333333     555555555555555555 |\n|3:::::::::::::::33   5::::::::::::::::5 |\n|3::::::33333::::::3  5::::::::::::::::5 |\n|3333333     3:::::3  5:::::555555555555 |\n|            3:::::3  5:::::5            |\n|            3:::::3  5:::::5            |\n|    33333333:::::3   5:::::5555555555   |\n|    3:::::::::::3    5:::::::::::::::5  |\n|    33333333:::::3   555555555555:::::5 |\n|            3:::::3              5:::::5|\n|            3:::::3              5:::::5|\n|            3:::::3  5555555     5:::::5|\n|3333333     3:::::3  5::::::55555::::::5|\n|3::::::33333::::::3   55:::::::::::::55 |\n|3:::::::::::::::33      55:::::::::55   |\n| 333333333333333          555555555     |";
                    break;

                case 16:
                    this.background = ConsoleColor.DarkRed;
                    this.representation = "| 333333333333333             66666666   |\n|3:::::::::::::::33          6::::::6    |\n|3::::::33333::::::3        6::::::6     |\n|3333333     3:::::3       6::::::6      |\n|            3:::::3      6::::::6       |\n|            3:::::3     6::::::6        |\n|    33333333:::::3     6::::::6         |\n|    3:::::::::::3     6::::::::66666    |\n|    33333333:::::3   6::::::::::::::66  |\n|            3:::::3  6::::::66666:::::6 |\n|            3:::::3  6:::::6     6:::::6|\n|            3:::::3  6:::::6     6:::::6|\n|3333333     3:::::3  6::::::66666::::::6|\n|3::::::33333::::::3   66:::::::::::::66 |\n|3:::::::::::::::33      66:::::::::66   |\n| 333333333333333          666666666     |";
                    break;

                case 19:
                    this.background = ConsoleColor.DarkGreen;
                    this.representation = "|     000000000            000000000     |\n|   00:::::::::00        00:::::::::00   |\n| 00:::::::::::::00    00:::::::::::::00 |\n|0:::::::000:::::::0  0:::::::000:::::::0|\n|0::::::0   0::::::0  0::::::0   0::::::0|\n|0:::::0     0:::::0  0:::::0     0:::::0|\n|0:::::0     0:::::0  0:::::0     0:::::0|\n|0:::::0 000 0:::::0  0:::::0 000 0:::::0|\n|0:::::0 000 0:::::0  0:::::0 000 0:::::0|\n|0:::::0     0:::::0  0:::::0     0:::::0|\n|0:::::0     0:::::0  0:::::0     0:::::0|\n|0::::::0   0::::::0  0::::::0   0::::::0|\n|0:::::::000:::::::0  0:::::::000:::::::0|\n| 00:::::::::::::00    00:::::::::::::00 |\n|   00:::::::::00        00:::::::::00   |\n|     000000000            000000000     |";
                    break;
            }
        }
    }
}

```
