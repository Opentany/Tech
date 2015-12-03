﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Cards;
using Poker.Players;

namespace ConsoleApplication1
{
    class Game
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int smallBlind;
            int bigBlind;
            Console.WriteLine("Podaj ilość graczy :");
            int playersCount = int.Parse(Console.ReadLine());
            Console.WriteLine(playersCount);
            if (playersCount>10)
            {
                Console.Clear();
                Console.WriteLine("Za duzo graczy");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Podaj małą ciemną");
            smallBlind = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj dużą ciemną");
            bigBlind = int.Parse(Console.ReadLine());
            List<BasicPlayer> graczeList = new List<BasicPlayer>(playersCount);
            for (int i = 0; i < playersCount; i++)

            {
                string nazwa = "gracz";
                nazwa = nazwa + i;
                graczeList.Add(new BasicPlayer());
                graczeList[i].Name = nazwa;
                Console.WriteLine(nazwa);
            }
            foreach (var VARIABLE in graczeList)
            {
                Console.WriteLine(VARIABLE.Name);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Zaczynamy Texas Hold'Em");
            Console.WriteLine("Generowanie Tali Kart");
            Deck talia = new Deck(true);
            foreach (var karta in talia.GetCards())
            {
                Console.WriteLine(karta.ToString());
            }
            Console.ReadKey();
            Console.Clear();
            foreach (var gracz in graczeList)
            {
                gracz.Tokens = 500;
            }
            int dealerButton = random.Next(graczeList.Count);
            Console.WriteLine("Rozdanie wstępne");
            foreach (var gracz in graczeList)
            {
                Console.WriteLine(gracz.Name);
                gracz.Hand.Add(talia.GetTopCard());
                gracz.Hand.Add(talia.GetTopCard());
            }
            foreach (var gracz in graczeList)
            {
                Console.WriteLine(gracz.Name);
                foreach (var karty in gracz.Hand)
                {
                    Console.WriteLine(karty.ToString());
                }
            }
            Console.ReadKey();
            Console.WriteLine("1 tura licytacji");
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
