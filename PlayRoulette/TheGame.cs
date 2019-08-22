using System;
using System.Collections.Generic;
using System.Text;
using Wheel;
using Roulette;
using System.Threading;
using System.Diagnostics;

namespace TheGame
{
    class Play
    {
        public static void Game()
        {
            bool stopBetting = false;
            double betAmount;
            Random r = new Random();
            int count = 1;
            Stopwatch s = new Stopwatch();

            //Create the board
            Board board = new Board();
            Bin[] binArr = board.CreateWheel();
            List<Bets> bets = new List<Bets>();
            List<string> betsChoice = new List<string>();
            List<double> betsMade = new List<double>();

            //Prints out the board and rules
            DrawBoard();

            //sets up the user for the game:
            Console.Write("How much money do you bring to the table?: $");
            double wallet = getDollars();
            double walletStart = wallet;
            Console.WriteLine();

            //collecting the bets
            Console.WriteLine("The wheel has been spun - PLACE YOUR BETS!");
            Console.WriteLine("The wheel will spin for around 1 minute. Good luck!");
            int actual = r.Next(0, 37);
            int time = 75;
            s.Start();
            var process = new Process();
            Process.Start(@"Spinner.exe", actual.ToString());
            while (stopBetting == false && wallet > 0 && s.Elapsed < TimeSpan.FromSeconds(time))
            {

                int guess = new int();
                Console.WriteLine($" ({count})\tnumbers|evens|odds|reds|blacks|lows|highs|dozens|columns|street|six|split|corner|stop");
                Console.Write($"\tHow much money are you putting down? (current total ${wallet.ToString("#,##0.00")}): $");
                betAmount = getDollars();
                if (betAmount == 0)
                {
                    stopBetting = true;
                    break;
                }
                if (betAmount >= wallet)
                {
                    betAmount = wallet;
                }
                Console.Write($"\tType your choice: ");
                string choice = getStr();
                if (choice == "stop")
                {
                    stopBetting = true;
                    break;
                }
                else if (choice == "numbers")
                {
                    Console.Write("\tPick a bin 0-37(37 is 00): ");
                    guess = getChoice();
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "dozens")
                {
                    Console.Write("\tPick a range: low, middle, or high: ");
                    choice = getDozen();
                    if (choice == "low") guess = 1;
                    if (choice == "middle") guess = 13;
                    if (choice == "high") guess = 25;

                    choice = "dozens";
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "lows")
                {
                    guess = 1;
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "highs")
                {
                    guess = 36;
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "columns")
                {
                    Console.Write("\tPick a column: first, second, or third: ");
                    choice = getDozen();
                    if (choice == "first") guess = 1;
                    if (choice == "second") guess = 2;
                    if (choice == "third") guess = 3;

                    choice = "columns";
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "reds" || choice == "odds")
                {
                    guess = 1;
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "blacks" || choice == "evens")
                {
                    guess = 1;
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "split") //checking rows, very unclean, but it probably works
                {
                    bool flag = true;
                    int secondGuess = new int();
                    Console.Write("\tPick a bin 0-37(37 is 00): ");
                    guess = getChoice();
                    if (guess == 0) secondGuess = 37;
                    if (guess != 0 && guess != 37)
                    {
                        while (flag)
                        {
                            Console.Write("\tPick an adjacent bin 1-36: ");
                            secondGuess = getChoice();
                            if (
                                   ((binArr[guess].Column == 1) && (secondGuess == guess + 1 || secondGuess == guess + 3 || secondGuess == guess - 3))
                                || ((binArr[guess].Column == 2) && (secondGuess == guess + 1 || secondGuess == guess - 1 || secondGuess == guess + 3 || secondGuess == guess - 3))
                                || ((binArr[guess].Column == 3) && (secondGuess == guess - 1 || secondGuess == guess + 3 || secondGuess == guess - 3))
                               )
                            {
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("This number is not adjacent, please refer to the board");
                            }
                        }
                    }
                    bets.Add(SetBet(binArr, choice, actual, guess, secondGuess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                else if (choice == "corner")
                {
                    bool flag = true;
                    while (flag)   //checks to see if numbes are in first 2 colums, and not in last row
                    {
                        Console.Write("\tPick the top left corner of the square 1-32: ");
                        guess = getChoice();
                        if (guess % 3 != 0 && guess < 33)
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid corner location.");
                        }
                    }
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);

                }
                else
                {
                    Console.Write("\tPick a bin 1-36: ");
                    guess = getChoice();
                    bets.Add(SetBet(binArr, choice, actual, guess, betAmount));
                    betsChoice.Add(choice);
                    betsMade.Add(betAmount);
                }
                wallet -= betAmount;
                count++;
            }
            s.Stop();

            Console.WriteLine("\n\tCALCULATING RESULTS");
            Thread.Sleep(1250);
            Console.Write("\t.");
            Thread.Sleep(1250);
            Console.Write(".");
            Thread.Sleep(1250);
            Console.Write(".\n");

            Thread.Sleep(1250);
            Console.Write("\t.");
            Thread.Sleep(1250);
            Console.Write(".");
            Thread.Sleep(1250);
            Console.Write(".\n");

            Thread.Sleep(1250);
            Console.Write("\t.");
            Thread.Sleep(1250);
            Console.Write(".");
            Thread.Sleep(1250);
            Console.Write(".\n");


            Console.WriteLine("\tDONE\n");

            Console.WriteLine($"The ball landed on {actual}.");
            //TODO: bet results and calculations

            for (int i = 0; i < bets.Count; i++)
            {
                Console.WriteLine($"Bet {i + 1} ({betsChoice[i]}): You bet ${betsMade[i].ToString("#,##0.00")} and won ${bets[i].Winnings().ToString("#,##0.00")}");
                wallet += bets[i].Winnings();
            }
            if (wallet == walletStart)
            {
                Console.WriteLine("You didn't win anything, but you also didn't lose anything.");
            }
            else if (wallet > walletStart)
            {
                Console.WriteLine($"You made ${(wallet - walletStart).ToString("#,##0.00")}. You are a winner!");
            }
            else
            {
                Console.WriteLine($"You lost ${(walletStart - wallet).ToString("#,##0.00")}. Better luck next time!");
            }

            Console.WriteLine($"Amont left in Wallet: ${wallet.ToString("#,##0.00")}");
        }
        static int getChoice() //function to get the choice of the user, with error checking
        {
            int value = 0;
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();
                bool check = int.TryParse(userInput, out _);

                if (check == true)
                {
                    value = int.Parse(userInput);
                    if (value >= 0 && value < 38)
                    {
                        exit = true;
                    }
                    else
                        Console.WriteLine("Not a valid choice, try again: ");
                }
                else
                {
                    Console.Write("Not a number, try again: ");
                }
            } while (exit == false);
            return value;
        }
        static double getDollars()  //gets the amount of money that they want to bet, with error checking
        {
            double value = 0;
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();
                bool check = double.TryParse(userInput, out _);

                if (check == true)
                {
                    value = double.Parse(userInput);
                    if (value >= 0)
                    {
                        exit = true;
                    }
                    else
                        Console.WriteLine("Not enough money: try again ");
                }
                else
                {
                    Console.Write("Not a number, try again: ");
                }
            } while (exit == false);
            return value;
        }
        static string getStr()  //gets the bet, not really clean
        {
            string value = "";
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();

                if (userInput == "stop" || userInput == "numbers" || userInput == "evens" || userInput == "odds" || userInput == "reds" || userInput == "blacks" || userInput == "lows" || userInput == "highs" || userInput == "dozens" || userInput == "columns" || userInput == "street" || userInput == "six" || userInput == "split" || userInput == "corner")
                {
                    value = userInput;
                    exit = true;
                }
                else
                {
                    Console.Write("Not a valid choice, try again: ");
                }
            } while (exit == false);
            return value;
        }
        static string getDozen()  //gets the range for dozens and columns, not really clean
        {
            string value = "";
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();

                if (userInput == "low" || userInput == "middle" || userInput == "high" || userInput == "first" || userInput == "second" || userInput == "third")
                {
                    value = userInput;
                    exit = true;
                }
                else
                {
                    Console.Write("Not a valid choice, try again: ");
                }
            } while (exit == false);
            return value;
        }
        static Bets SetBet(Bin[] binArr, string choice, int actual, int guess, double betAmount)
        {
            Bets bet = new Bets(binArr[actual], binArr[guess], betAmount);
            //numbers|evens|odds|reds|blacks|lows|highs|dozens|columns|street|six|corner|stop
            switch (choice)
            {
                case "numbers":
                    bet.Numbers();
                    break;
                case "evens":
                    bet.Evens();
                    break;
                case "odds":
                    bet.Odds();
                    break;
                case "reds":
                    bet.Reds();
                    break;
                case "blacks":
                    bet.Blacks();
                    break;
                case "lows":
                    bet.Lows();
                    break;
                case "highs":
                    bet.Highs();
                    break;
                case "columns":
                    bet.Columns();
                    break;
                case "street":
                    bet.Street();
                    break;
                case "six":
                    bet.SixNumbers();
                    break;
                case "dozens":
                    bet.Dozens();
                    break;
                case "corner":
                    bet.Corner();
                    break;
                default:
                    break;

            }
            return bet;
        }
        static Bets SetBet(Bin[] binArr, string choice, int actual, int guess, int secondGuess, double betAmount)
        {
            Bets bet = new Bets(binArr[actual], binArr[guess], binArr[secondGuess], betAmount);
            bet.Split();
            return bet;
        }
        static void DrawBoard() //drawns a board with the different bets to the size. purely AESTHETICS
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("    +-----+-----+-----+-----+-----+-----+    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\tTYPES OF BETS:");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("    | 1-18| EVEN| RED |BLACK| ODD |19-36|    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t1. Numbers: Number of the bin");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("+---+--+--+--+--+--+--+--+--+--+--+--+--+---+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t2. Evens/Odds: Number is even or odd");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("| 0 |");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" 3");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" 6");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" 9");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("12");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("15");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("18");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("21");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("24");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("27");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("30");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("33");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("36");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|3rd|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t3. Reds/Blacks: Number is red or black");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("| 0 +--+--+--+--+--+--+--+--+--+--+--+--+---+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t4. Lows/Highs: Number is 1-18 or 19-36");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|---|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" 2");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" 5");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" 8");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("11");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("14");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("17");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("20");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("23");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("26");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("29");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("32");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("35");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|2nd|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t5. Dozens: Number is 1-12, 13-24, 25-36");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|   +--+--+--+--+--+--+--+--+--+--+--+--+---+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t6. Colums: Number is in 1st, 2nd or 3rd");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("| 0 |");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" 1");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" 4");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" 7");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("10");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("13");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("16");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("19");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("22");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("25");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("28");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("31");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("34");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("|1st|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t7. Street: Number is in the same row");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("+---+--+--+--+--+--+--+--+--+--+--+--+--+---+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t8. Six Numbers: Number is on one of the adjacent rows");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("    |    1-12   |   13-24   |   25-36   |    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t9. Split: Number is one of the adjacent numbers");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("    +-----------+-----------+-----------+    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t10. Corner: Number is one of the corner pieces");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
