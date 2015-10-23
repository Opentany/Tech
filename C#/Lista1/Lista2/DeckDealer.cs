using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista2
{
    public class DeckDealer
    {
        private readonly List<string>[] _tabLists;


        public DeckDealer(List<string>[] players, IList<string> deck, int handOut)
        {
            if (players == null || deck == null) throw new Exception("One of arguments is null");
            if (handOut<1 || handOut> deck.Count/ players.GetLength(0)) throw new Exception("Wrong number of cards to handout");
            foreach (var variable in players)
            {
                for (var i = 0; i < handOut; i++)
                {
                    var tmpCard = deck.ElementAt(0);
                    Console.WriteLine("Card taken form deck "+tmpCard);
                    deck.RemoveAt(0);
                    Console.WriteLine("Next card should be "+deck.ElementAt(0));
                    variable.Add(tmpCard);
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