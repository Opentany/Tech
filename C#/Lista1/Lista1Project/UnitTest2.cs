using System;
using System.Linq;
using Lista2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class UnitTest2
    {
        private readonly Deck _deck = new Deck();
        private readonly PlayerMaker _playerMaker = new PlayerMaker(5);

        [TestMethod]
        public void DeckIsNotEmpty()
        {
            Assert.IsNotNull(_deck.GetDeck());
            foreach (var variable in _deck.GetDeck())
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine(_deck.GetDeck().Count);
        }

        [TestMethod]
        public void ShufflingDeck()
        {
            DeckShuffler deckShuffler = new DeckShuffler(_deck.GetDeck());
            Assert.IsNotNull(deckShuffler.GetShuffledDeck());
            foreach (var variable in deckShuffler.GetShuffledDeck())
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine(deckShuffler.GetShuffledDeck().Count);
        }

        [TestMethod]
        public void IsTeamReal()
        {
            Assert.IsNotNull(_playerMaker.GetTeam());
        }

        [TestMethod]
        public void CheckingTeammates()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.IsNotNull(_playerMaker.GetTeam()[i]);
            }
        }

        [TestMethod]
        public void HandOutCards()
        {
            DeckShuffler deckShuffler = new DeckShuffler(_deck.GetDeck());
            Assert.IsNotNull(_deck.GetDeck());
            foreach (var variable in deckShuffler.GetShuffledDeck())
            {
                Console.WriteLine("shuffled"+variable);
            }
            Console.WriteLine(deckShuffler.GetShuffledDeck().Count);
            DeckDealer deckDealer = new DeckDealer(_playerMaker.GetTeam(),deckShuffler.GetShuffledDeck(),5);
            Assert.IsNotNull(deckDealer.GetPlayersCards());
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(5,deckDealer.GetPlayersCards()[i].Count);
                Console.WriteLine("gracz {0} ma tyle kart "+deckDealer.GetPlayersCards()[i].Count,i);
                for (int j = 0; j <5; j++)
                {
                    Console.WriteLine("Karty gracza {0} to "+deckDealer.GetPlayersCards()[i].ElementAt(j),i);
                }
            }
        }
    }
}
