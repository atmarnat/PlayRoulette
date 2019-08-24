using System;
using System.Collections.Generic;
using System.Text;
using Wheel;

namespace Roulette
{
    public class Bets
    {
        Bin actual;
        Bin guess;
        Bin secondGuess;
        int multiplier;
        double amount;

        public Bets(Bin s, Bin a, double bet)
        {
            actual = s;
            guess = a;
            amount = bet;
        }
        public Bets(Bin s, Bin a, Bin b, double bet)
        {
            actual = s;
            guess = a;
            secondGuess = b;
            amount = bet;
        }
        public void Numbers()
        {
            multiplier = 35 + 1;
            if (guess.Number == actual.Number)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Evens()
        {
            multiplier = 1 + 1;
            if (actual.Number % 2 == 0 && actual.Number != 0)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Odds()
        {
            multiplier = 1 + 1;
            if (actual.Number % 2 == 1 && actual.Number != 37)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Reds()
        {
            multiplier = 1 + 1;
            if (actual.Color == (int)Colors.Red && guess.Color == (int)Colors.Red)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Blacks()
        {
            multiplier = 1 + 1;
            if (actual.Color == (int)Colors.Black && guess.Color == (int)Colors.Black)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Lows()
        {
            multiplier = 1 + 1;
            if ((actual.Number < 19 && actual.Number >= 1) && (guess.Number < 19 && guess.Number >= 1))
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Highs()
        {
            multiplier = 1 + 1;
            if (actual.Number > 18 && guess.Number > 18)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Dozens()
        {
            multiplier = 2 + 1;
            if (actual.Number >= 25 && guess.Number >= 25)
                amount = multiplier * amount;
            else if ((actual.Number >= 13 && actual.Number < 25) && (guess.Number >= 13 && guess.Number < 25))
                amount = multiplier * amount;
            else if ((actual.Number >= 1 && actual.Number < 13) && (guess.Number >= 1 && guess.Number < 13))
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Columns()
        {
            multiplier = 2 + 1;
            if (guess.Column == actual.Column)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Street()
        {
            multiplier = 11 + 1;
            if (guess.Row == actual.Row)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void SixNumbers()
        {
            multiplier = 5 + 1;
            if (guess.Row == actual.Row - 1 || guess.Row == actual.Row + 1)
                amount = multiplier * amount;
            amount = 0;
        }
        public void Split()
        {
            multiplier = 17 + 1;
            if (guess.Number == actual.Number || secondGuess.Number == actual.Number)
                amount = multiplier * amount;
            else amount = 0;
        }
        public void Corner()
        {
            multiplier = 8 + 1;
            if (guess.Number == actual.Number || guess.Number == actual.Number + 1 || guess.Number == actual.Number + 3 || guess.Number == actual.Number + 4)
                amount = multiplier * amount;
            amount = 0;
        }
        public double Winnings()
        {
            return amount;
        }
    }
}
