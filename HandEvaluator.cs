using System;
using System.Collections.Generic;
using System.Linq;

namespace JacksOrBetter
{
    class HandEvaluator
    {
        private const string Symbols = "♠♥♦♣";
        private const string Numbers = "A23456789TJQK";
        private List< Card > hand;
        public HandEvaluator(List< Card > cards)
        {
            hand = cards;
        }

        public Hand Evaluate() 
        {
            if (IsRoyalFlush())
                return new RoyalFlush();
            
            if (IsStraightFlush())
                return new StraightFlush();
            
            if (IsFourOfAKind())
                return new FourOfAKind();
            
            if (IsFullHouse())
                return new FullHouse();
            
            if (IsFlush())
                return new Flush();
            
            if (IsStraight())
                return new Straight();
            
            if (IsThreeOfAKind())
                return new ThreeOfAKind();
            
            if (IsTwoPair()) 
                return new TwoPair();
            
            if (IsJacksOrBetter())
                return new JacksOrBetter();

            return new Nothing();
        }

        private bool IsFlush()
        {
            char symbol = hand[0].Symbol;

            // Check if each card has the same symbol.
            foreach (var card in hand)
                if (card.Symbol != symbol)
                    return false;
            
            return true;
        }

        private bool IsStraight()
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
            if (numbers[0] == 0 && IsSequential(numbers.GetRange(1, numbers.Count - 1))) 
                return true;
            
            return false;
        }

        private bool IsSequential(List<int> numbers)
        {
            for(int i = 0; i < numbers.Count - 1; i++)
                if (numbers[i] != numbers[i + 1] - 1)
                    return false;
            
            return true;
        }

        private bool AreBestCards()
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

        private List< int > GetCountsOfNumbers()
        {
            var counts = new List<int>();
            for (int i = 0; i < Numbers.Length; i++)
                counts.Add(0);

            foreach (var card in hand)
                counts[Numbers.IndexOf(card.Number)]++;
            
            return counts;
        }

        private int MaxAmountOfSameNumbers()
        {
            return GetCountsOfNumbers().Max();
        }

        private int CountPairs()
        {
            int pairs = 0;

            foreach (var count in GetCountsOfNumbers())
                if (count == 2)
                    pairs++;

            return pairs;
        }

        private bool IsRoyalFlush()
        {
            return (IsFlush() && IsStraight() && AreBestCards());
        }

        private bool IsStraightFlush()
        {
            return (IsFlush() && IsStraight());
        }

        private bool IsFourOfAKind()
        {
            return (MaxAmountOfSameNumbers() == 4);
        }

        private bool IsFullHouse()
        {
            return (MaxAmountOfSameNumbers() == 1 && CountPairs() == 1);
        }

        private bool IsThreeOfAKind()
        {
            return (MaxAmountOfSameNumbers() == 3);
        }

        private bool IsTwoPair()
        {
            return (CountPairs() == 2);
        }

        private bool IsJacksOrBetter()
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
