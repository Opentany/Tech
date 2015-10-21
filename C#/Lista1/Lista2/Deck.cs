
using System.Collections.Generic;

namespace Lista2
{
    public class Deck
    {
        private readonly List<string> _cards = new List<string>();

        public Deck()
        {
            if (_cards != null)
            {
                _cards.Add("2 Kier");
                _cards.Add("2 Karo");
                _cards.Add("2 Trefl");
                _cards.Add("2 Pik");
                _cards.Add("3 Kier");
                _cards.Add("3 Karo");
                _cards.Add("3 Trefl");
                _cards.Add("3 Pik");
                _cards.Add("4 Kier");
                _cards.Add("4 Karo");
                _cards.Add("4 Trefl");
                _cards.Add("4 Pik");
                _cards.Add("5 Kier");
                _cards.Add("5 Karo");
                _cards.Add("5 Trefl");
                _cards.Add("5 Pik");
                _cards.Add("6 Kier");
                _cards.Add("6 Karo");
                _cards.Add("6 Trefl");
                _cards.Add("6 Pik");
                _cards.Add("7 Kier");
                _cards.Add("7 Karo");
                _cards.Add("7 Trefl");
                _cards.Add("7 Pik");
                _cards.Add("8 Kier");
                _cards.Add("8 Karo");
                _cards.Add("8 Trefl");
                _cards.Add("8 Pik");
                _cards.Add("9 Kier");
                _cards.Add("9 Karo");
                _cards.Add("9 Trefl");
                _cards.Add("9 Pik");
                _cards.Add("10 Kier");
                _cards.Add("10 Karo");
                _cards.Add("10 Trefl");
                _cards.Add("10 Pik");
                _cards.Add("Walet Kier");
                _cards.Add("Walet Karo");
                _cards.Add("Walet Trefl");
                _cards.Add("Walet Pik");
                _cards.Add("Dama Kier");
                _cards.Add("Dama Karo");
                _cards.Add("Dama Trefl");
                _cards.Add("Dama Pik");
                _cards.Add("Król Kier");
                _cards.Add("Król Karo");
                _cards.Add("Król Trefl");
                _cards.Add("Król Pik");
                _cards.Add("As Kier");
                _cards.Add("As Karo");
                _cards.Add("As Trefl");
                _cards.Add("As Pik");
            }
        }

        public List<string> GetDeck()
        {
            return _cards;
        }

    }
}
