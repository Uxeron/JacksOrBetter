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
            

            // Shuffle the selected cards
            foreach (var number in parsedNumbers)
                cards[number] = new Card(Symbols[random.Next(Symbols.Length)], Numbers[random.Next(Numbers.Length)]);
            

            DrawCards();

        }


        bool GetInput(out List< int > parsedNumbers) {
            parsedNumbers = new List< int > ();
            var input = Console.ReadLine().Split(" ");
            int parsedNumber;

            foreach (var number in input)
            {
                // Check if input is a number.
                if (Int32.TryParse(number, out parsedNumber))
                {
                    // Input is 1-based, change it to 0-based.
                    parsedNumber--;

                    // Make sure number is within bounds.
                    if (0 <= parsedNumber && parsedNumber < CardCount)
                    {
                        parsedNumbers.Add(parsedNumber);
                    }
                    else
                    {
                        parsedNumbers.Clear();
                        return false;
                    }
                }
                else
                {
                    parsedNumbers.Clear();
                    return false;
                }
            }

            return true;
        }

        void DrawCards() 
        {
            // Clear the screen.
            Console.Clear();

            Console.WriteLine("Your current hand: ");

            // Draw card indexes.
            for (int i = 0; i < CardCount; i++)
                Console.Write($"  {i+1}   ");
            Console.WriteLine();

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

            Console.WriteLine();
        }
    }
}
