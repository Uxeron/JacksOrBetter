using System;
using System.Collections.Generic;
using System.Linq;

namespace JacksOrBetter
{
    class HandEvaluator
    {
        const string Symbols = "♠♥♦♣";
        const string Numbers = "A23456789TJQK";
        List< Card > hand;
        public HandEvaluator(List< Card > cards)
        {
            hand = cards;
        }

        public (string, string) Evaluate() 
        {
            if (IsRoyalFlush())
                return ("a Royal Flush", "800");
            
            if (IsStraightFlush())
                return ("a Straight Flush", "50");
            
            if (IsFourOfAKind())
                return ("a Four of a Kind", "25");
            
            if (IsFullHouse())
                return ("a Full House", "9");
            
            if (IsFlush())
                return ("a Flush", "6");
            
            if (IsStraight())
                return ("a Straight", "4");
            
            if (IsThreeOfAKind())
                return ("a Three of a Kind", "3");
            
            if (IsTwoPair()) 
                return ("a Two Pair", "2");
            
            if (IsJacksOrBetter())
                return ("a Jacks or Better", "1");

            return ("Nothing", "0");
        }

        bool IsFlush()
        {
            char symbol = hand[0].Symbol;

            // Check if each card has the same symbol.
            foreach (var card in hand)
                if (card.Symbol != symbol)
                    return false;
            
            return true;
        }

        bool IsStraight()
        {
            List< int > numbers = new List< int > ();

            // Convert the cards' "Numbers" into actual int's.
            foreach (var card in hand)
                numbers.Add(Numbers.IndexOf(card.Number));

            numbers.Sort();

            // Entire hand is already sequential.
            if (IsSequential(numbers))
                return true;
            // 4/5 cards are sequential, and the 5th one is an Ace.
            else if (numbers[0] == 0 && IsSequential(numbers.GetRange(1, numbers.Count - 1))) 
                return true;
            
            return false;
        }

        bool IsSequential(List<int> numbers)
        {
            for(int i = 0; i < numbers.Count - 1; i++)
                if (numbers[i] != numbers[i + 1] - 1)
                    return false;
            
            return true;
        }

        bool AreBestCards()
        {
            foreach (var card in hand)
            {
                int number = Numbers.IndexOf(card.Number);
                // If card is a 10 or better
                if (number < 8 && number != 0)
                    return false;
            }

            return true;
        }

        List< int > GetCountsOfNumbers()
        {
            var counts = new List<int>();
            for (int i = 0; i < Numbers.Length; i++)
                counts.Add(0);

            foreach (var card in hand)
                counts[Numbers.IndexOf(card.Number)]++;
            
            return counts;
        }

        int MaxAmountOfSameNumbers()
        {
            return GetCountsOfNumbers().Max();
        }

        int CountPairs()
        {
            int pairs = 0;

            foreach (var count in GetCountsOfNumbers())
                if (count == 2)
                    pairs++;

            return pairs;
        }

        bool IsRoyalFlush()
        {
            return (IsFlush() && IsStraight() && AreBestCards());
        }

        bool IsStraightFlush()
        {
            return (IsFlush() && IsStraight());
        }

        bool IsFourOfAKind()
        {
            return (MaxAmountOfSameNumbers() == 4);
        }

        bool IsFullHouse()
        {
            return (MaxAmountOfSameNumbers() == 1 && CountPairs() == 1);
        }

        bool IsThreeOfAKind()
        {
            return (MaxAmountOfSameNumbers() == 3);
        }

        bool IsTwoPair()
        {
            return (CountPairs() == 2);
        }

        bool IsJacksOrBetter()
        {
            if (CountPairs() == 0)
                return false;

            var pairs = GetCountsOfNumbers();
            
            for (int i = 9; i < Numbers.Length; i++)
                if (pairs[i] == 2)
                    return true;

            if (pairs[0] == 2)
                return true;
            
            return false;
        }
    }
}
