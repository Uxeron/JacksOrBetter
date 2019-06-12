using System;
using System.Collections.Generic;

namespace JacksOrBetter
{
    class Game
    {
        private const int CardCount = 5;
        private const string Symbols = "♠♥♦♣";
        private const string Numbers = "A23456789TJQK";

        private List< Card > deck = new List< Card > ();
        private List< Card > hand = new List< Card > ();
        private Random random = new Random();

        public void Run()
        {
            hand.Clear();
            MakeNewDeck();

            // Generate hand.
            for (int i = 0; i < CardCount; i++)
            {
                var card = deck[random.Next(deck.Count)];
                deck.Remove(card);
                hand.Add(card);
            }
            
            DrawCards();

            var parsedNumbers = new List< int >();

            // Read input until correct input is received.
            while (true)
            {
                Console.WriteLine("Enter numbers of hand to discard (space separated): ");

                if (GetInput(parsedNumbers))
                    break;

                Console.WriteLine("Error, invalid input");
            }
            
            // Shuffle the selected cards.
            foreach (var number in parsedNumbers)
            {
                var card = hand[number];
                hand.Remove(card);
                deck.Add(card);

                card = deck[random.Next(deck.Count)];
                deck.Remove(card);
                hand.Insert(number, card);
            }

            DrawCards();

            var evaluator = new HandEvaluator(hand);
            var values = evaluator.Evaluate();

            Console.WriteLine("You drew {0} and won {1} coins", values.Item1, values.Item2);
        }


        private void MakeNewDeck() 
        {
            deck.Clear();

            foreach (var symbol in Symbols)
                foreach (var number in Numbers)
                    deck.Add(new Card(symbol, number));
        }


        private bool GetInput(List< int > parsedNumbers) {
            parsedNumbers.Clear();
            var input = Console.ReadLine().Trim().Split(" ");
            int parsedNumber;

            // No number was entered
            if (input.Length == 0)
                return false;

            foreach (var number in input)
            {
                // Empty string, most likely an accidental spacebar press.
                if (number.Length == 0)
                    continue;
                
                // Check if input is a number.
                if (!Int32.TryParse(number, out parsedNumber))
                    return false;

                // Make sure number is within bounds.
                if (1 > parsedNumber || parsedNumber > CardCount)
                    return false;

                parsedNumbers.Add(parsedNumber - 1);
            }

            return true;
        }

        private void DrawCards() 
        {
            // Clear the screen.
            Console.Clear();

            Console.WriteLine("Your current hand: ");

            // Draw top parts of all cards.
            foreach (var card in hand)
                Console.Write(card.Top);
            Console.WriteLine();

            // Draw middle top parts of all cards.
            foreach (var card in hand)
                Console.Write(card.MiddleTop);
            Console.WriteLine();

            // Draw middle bottom parts of all cards.
            foreach (var card in hand)
                Console.Write(card.MiddleBottom);
            Console.WriteLine();

            // Draw bottom parts of all cards.
            foreach (var card in hand)
                Console.Write(card.Bottom);
            Console.WriteLine();

            // Draw card indexes.
            for (int i = 0; i < CardCount; i++)
                Console.Write($"  {i + 1}   ");
            Console.WriteLine();

            Console.WriteLine();
        }
    }
}
