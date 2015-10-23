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
            var deckShuffler = new DeckShuffler(_deck.GetDeck());
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
            for (var i = 0; i < 5; i++)
            {
                Assert.IsNotNull(_playerMaker.GetTeam()[i]);
            }
        }

        [TestMethod]
        public void HandOutCards()
        {
            var deckShuffler = new DeckShuffler(_deck.GetDeck());
            Assert.IsNotNull(_deck.GetDeck());
            foreach (var variable in deckShuffler.GetShuffledDeck())
            {
                Console.WriteLine("shuffled"+variable);
            }
            Console.WriteLine(deckShuffler.GetShuffledDeck().Count);
            var deckDealer = new DeckDealer(_playerMaker.GetTeam(),deckShuffler.GetShuffledDeck(),5);
            Assert.IsNotNull(deckDealer.GetPlayersCards());
            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(5,deckDealer.GetPlayersCards()[i].Count);
                Console.WriteLine("gracz {0} ma tyle kart "+deckDealer.GetPlayersCards()[i].Count,i);
                for (var j = 0; j <5; j++)
                {
                    Console.WriteLine("Karty gracza {0} to "+deckDealer.GetPlayersCards()[i].ElementAt(j),i);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfExceptionInPlayerMaker_MustPass()
        {
            
                var gracze = new PlayerMaker(53);
            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfExceptionInPlayerMaker2_MustPass()
        {

            var gracze = new PlayerMaker(1);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfNullExceptionInDeckDealer_MustPass()
        {
            
                var deckShuffler = new DeckShuffler(_deck.GetDeck());
                var deckDealerNullTest1 = new DeckDealer(null,deckShuffler.GetShuffledDeck(),5);
            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfNullExceptionInDeckDealer2_MustPass()
        {

            var deckShuffler = new DeckShuffler(_deck.GetDeck());
            var deckDealerNullTest2 = new DeckDealer(_playerMaker.GetTeam(), null, 5);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfHandOutExceptionInDeckDealer_MustPass()
        {

            var deckShuffler = new DeckShuffler(_deck.GetDeck());
            var deckDealerTest = new DeckDealer(_playerMaker.GetTeam(), deckShuffler.GetShuffledDeck(), 20);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOfHandOutExceptionInDeckDealer2_MustPass()
        {

            var deckShuffler = new DeckShuffler(_deck.GetDeck());
            var deckDealerTest = new DeckDealer(_playerMaker.GetTeam(), deckShuffler.GetShuffledDeck(), 0);

        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void TestOfNullExceptionInDeckShuffler_MustPass()
        {
            var deckShuffler = new DeckShuffler(null);
        }
    }
}
