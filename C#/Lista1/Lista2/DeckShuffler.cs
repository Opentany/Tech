using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista2
{
    public class DeckShuffler
    {
        private readonly Random _random = new Random();
        private readonly List<string> _tmpList = new List<string>();
        public DeckShuffler(IList<string> scards)
        {
            for (var i = 0; i < 52; i++)
            {
                if (scards == null) throw new Exception("Shuffled deck is null");
                var index = _random.Next(0, scards.Count - 1);
                var tmpCard = scards.ElementAt(index);
                _tmpList.Add(tmpCard);
                scards.RemoveAt(index);
            }
        }

        public List<string> GetShuffledDeck()
        {
            return _tmpList;
        }

    }
}