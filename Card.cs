using System;
using System.Collections.Generic;

namespace JacksOrBetter
{
    class Card
    {
        readonly static string[] CardParts = { "┏━━━┓ ", "┃ {0} ┃ ", "┗━━━┛ " };

        public char Symbol { get; private set; }
        public char Number { get; private set; }

        public string Top
        {
            get { return CardParts[0]; }
        }

        public string MiddleTop
        {
            get { return String.Format(CardParts[1], Symbol); }
        }

        public string MiddleBottom
        {
            get { return String.Format(CardParts[1], Number); }
        }

        public string Bottom
        {
            get { return CardParts[2]; }
        }

        public Card(char symbol, char number)
        {
            Symbol = symbol;
            Number = number;
        }
    }
}
