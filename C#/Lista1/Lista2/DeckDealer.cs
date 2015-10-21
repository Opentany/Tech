using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista2
{
    public class DeckDealer
    {
        private readonly List<string>[] _tabLists;


        public DeckDealer(List<string>[] players, List<string> deck, int handOut)
        {
            foreach (var VARIABLE in players)
            {
                for (int i = 0; i < handOut; i++)
                {
                    var tmpCard = deck.ElementAt(0);
                    Console.WriteLine("Karta zabrana z talii "+tmpCard);
                    deck.RemoveAt(0);
                    Console.WriteLine("kolejna karta powinna byc "+deck.ElementAt(0));
                    VARIABLE.Add(tmpCard);
                }
                
            }
            _tabLists = players;
        }

        public List<string>[] GetPlayersCards()
        {
            return _tabLists;
        }
    }
}