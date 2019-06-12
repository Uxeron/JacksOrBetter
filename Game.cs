using System;
using System.Collections.Generic;

namespace JacksOrBetter
{
    class Game
    {
        const int CardCount = 5;
        readonly static string[] CardParts = {"┏━━━┓ ", "┃ {0} ┃ ", "┗━━━┛ "};
        const string Symbols = "♠♥♦♣";
        const string Numbers = "A23456789TJQK";

        // Symbol, number/type.
        List< Tuple< int, int > > cards = new List< Tuple < int, int > > {};
        Random random = new Random();

        public void Run()
        {
            // Generate cards.
            for (int i = 0; i < CardCount; i++)
                cards.Add(new Tuple< int, int > (random.Next(Symbols.Length), random.Next(Numbers.Length)));
            
            DrawCards();
        }

        void DrawCards() 
        {
            // Clear the screen.
            Console.Clear();

            // Draw top parts of all cards.
            for (int i = 0; i < CardCount; i++)
                Console.Write(CardParts[0]);
            Console.WriteLine();

            // Draw middle top parts of all cards.
            for (int i = 0; i < CardCount; i++)
                Console.Write(CardParts[1], Symbols[cards[i].Item1]);
            Console.WriteLine();

            // Draw middle bottom parts of all cards.
            for (int i = 0; i < CardCount; i++)
                Console.Write(CardParts[1], Numbers[cards[i].Item2]);
            Console.WriteLine();

            // Draw bottom parts of all cards.
            for (int i = 0; i < CardCount; i++)
                Console.Write(CardParts[2]);
            Console.WriteLine();
        }
    }
}
