namespace JacksOrBetter
{
    interface Hand
    {
        string Name { get; }
        string Value { get; }
    }

    class RoyalFlush : Hand
    {
        public string Name { get { return "a Royal Flush"; } }
        public string Value { get { return "800"; } }
    }


    class StraightFlush : Hand
    {
        public string Name { get { return "a Straight Flush"; } }
        public string Value { get { return "50"; } }
    }

    class FourOfAKind : Hand
    {
        public string Name { get { return "a Four of a Kind"; } }
        public string Value { get { return "25"; } }
    }

    class FullHouse : Hand
    {
        public string Name { get { return "a Full House"; } }
        public string Value { get { return "9"; } }
    }

    class Flush : Hand
    {
        public string Name { get { return "a Flush"; } }
        public string Value { get { return "6"; } }
    }

    class Straight : Hand
    {
        public string Name { get { return "a Straight"; } }
        public string Value { get { return "4"; } }
    }

    class ThreeOfAKind : Hand
    {
        public string Name { get { return "a Three of a Kind"; } }
        public string Value { get { return "3"; } }
    }

    class TwoPair : Hand
    {
        public string Name { get { return "a Two Pair"; } }
        public string Value { get { return "2"; } }
    }

    class JacksOrBetter : Hand
    {
        public string Name { get { return "a Jacks or Better"; } }
        public string Value { get { return "1"; } }
    }

    class Nothing : Hand
    {
        public string Name { get { return "Nothing"; } }
        public string Value { get { return "0"; } }
    }
}
