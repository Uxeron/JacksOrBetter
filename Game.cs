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
        }

        void DrawCards() 
        {
            // Clear the screen.
            Console.Clear();

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
        }
    }
}
