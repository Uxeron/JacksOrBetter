using System;
using System.Collections.Generic;

namespace JacksOrBetter
{
    class HandEvaluator
    {
        const string Symbols = "♠♥♦♣";
        const string Numbers = "A23456789TJQK";
        readonly static string[] Hands = {"nothing", "Jacks or Better", "Two Pair", "Three of a Kind", "Straight", "Flush", "Full House", "Four of a Kind", "Straight Flush", "Royal Flush"};
        readonly static int[] Prizes = {0, 1, 2, 3, 4, 5, 6, 9, 25, 50, 800};
        List< Card > hand;
        public HandEvaluator(List< Card > cards)
        {
            hand = cards;
        }
        public void evaluate(out string win, out int prize) 
        {
            win = "";
            prize = 0;
        }

        bool isFlush()
        {
            char symbol = hand[0].Symbol;

            // Check if each card has the same symbol.
            foreach (var card in hand)
                if (card.Symbol != symbol)
                    return false;
            
            return true;
        }

        bool isStraight()
        {
            List< int > numbers = new List< int > ();

            // Convert the cards' "Numbers" into actual int's.
            foreach (var card in hand)
                numbers.Add(Numbers.IndexOf(card.Number));

            numbers.Sort();

            // Entire hand is already sequential.
            if (isSequential(numbers))
                return true;
            // 4/5 cards are sequential, and the 5th one is an Ace.
            else if (numbers[0] == 0 && isSequential(numbers.GetRange(1, numbers.Count - 1))) 
                return true;
            
            return false;
        }

        bool isSequential(List<int> numbers)
        {
            for(int i = 0; i < numbers.Count - 1; i++)
                if (numbers[i] != numbers[i + 1] - 1)
                    return false;
            
            return true;
        }
    }
}
