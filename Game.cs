using System;
using System.Collections.Generic;

namespace JacksOrBetter
{
    class Game
    {
        const int CardCount = 5;
        const string Symbols = "♠♥♦♣";
        const string Numbers = "A23456789TJQK";

        // Symbol, number/type.
        List< Card > cards = new List< Card > {};
        Random random = new Random();

        public void Run()
        {
            cards.Clear();
            // Generate cards.
            for (int i = 0; i < CardCount; i++)
                cards.Add(new Card(Symbols[random.Next(Symbols.Length)], Numbers[random.Next(Numbers.Length)]));
            
            DrawCards();

            List<int> parsedNumbers;

            // Read input until correct input is received.
            while (true)
            {
                Console.WriteLine("Enter numbers of cards to discard (space separated): ");

                if (GetInput(out parsedNumbers))
                    break;

                Console.WriteLine("Error, invalid input");
            }
            

            // Shuffle the selected cards.
            foreach (var number in parsedNumbers)
                cards[number] = new Card(Symbols[random.Next(Symbols.Length)], Numbers[random.Next(Numbers.Length)]);
            

            DrawCards();

            var evaluator = new HandEvaluator(cards);
            var values = evaluator.Evaluate();

            Console.WriteLine("You drew {0} and won {1} coins", values.Item1, values.Item2);
        }


        bool GetInput(out List< int > parsedNumbers) {
            parsedNumbers = new List< int > ();
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
                else
                    // Make sure number is within bounds.
                    if (1 > parsedNumber || parsedNumber > CardCount)
                        return false;
                    else
                        parsedNumbers.Add(parsedNumber - 1);
            }

            return true;
        }

        void DrawCards() 
        {
            // Clear the screen.
            Console.Clear();

            Console.WriteLine("Your current hand: ");

            // Draw top parts of all cards.
            foreach (var card in cards)
                Console.Write(card.Top);
            Console.WriteLine();

            // Draw middle top parts of all cards.
            foreach (var card in cards)
                Console.Write(card.MiddleTop);
            Console.WriteLine();

            // Draw middle bottom parts of all cards.
            foreach (var card in cards)
                Console.Write(card.MiddleBottom);
            Console.WriteLine();

            // Draw bottom parts of all cards.
            foreach (var card in cards)
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
