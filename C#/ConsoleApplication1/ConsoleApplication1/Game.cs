using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Poker.Cards;
using Poker.Players;

namespace ConsoleApplication1
{
    class Game
    {
        static List<BasicPlayer> kolejnosPlayers(List<BasicPlayer> Listagraczy, int ktodealer)
        {
            int j;
            List<BasicPlayer> tmp = new List<BasicPlayer>();
            for (int i = 0; i < Listagraczy.Count; i++)
            {
                j = MaMalaCiemna(ktodealer + i, Listagraczy.Count);
                tmp.Add(Listagraczy[j]);
            }
            return tmp;
        }
        static int MaMalaCiemna(int ktodealer, int liczbagraczy)//aka nastepny gracz
        {
            if (ktodealer + 1 > liczbagraczy - 1)
            {
                return ktodealer + 1 - liczbagraczy;
            }
            else
            {
                return ktodealer + 1;
            }
        }
        static int MaDuzaCiemna(int ktodealer, int liczbagraczy)
        {
            if (ktodealer + 2 > liczbagraczy - 1)
            {
                return ktodealer + 2 - liczbagraczy;
            }
            else
            {
                return ktodealer + 2;
            }
        }
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
                gracz.Tokens = 100;
            }
            int dealerButton = random.Next(graczeList.Count);
            int mamalaciemna = MaMalaCiemna(dealerButton, playersCount);
            int maduzaciemna = MaDuzaCiemna(dealerButton, playersCount);
            Console.WriteLine(graczeList[dealerButton].Name+" Ma dealer button");
            Console.WriteLine(graczeList[mamalaciemna].Name + " Ma mala ciemna");
            Console.WriteLine(graczeList[maduzaciemna].Name + " Ma duza ciemna");
            Console.WriteLine("Rozdanie wstępne");
            foreach (var gracz in graczeList)
            {
               // Console.WriteLine(gracz.Name);
                gracz.Hand.Add(talia.GetTopCard());
                gracz.Hand.Add(talia.GetTopCard());
            }
            //foreach (var gracz in graczeList)
            //{
            //    Console.WriteLine(gracz.Name);
            //    foreach (var karty in gracz.Hand)
            //    {
            //        Console.WriteLine(karty.ToString());
            //    }
            //}
            Console.ReadKey();
            List<BasicPlayer> aktualniPlayers = graczeList;
            var tura=0;
            //List<BasicPlayer> kolejkaPlayers = kolejnosPlayers(aktualniPlayers, dealerButton);
            //foreach (var players in kolejkaPlayers)
            //{
            //    Console.WriteLine(players.Name);
            //}
            do
            {
                tura++;
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (tura)
                {
                    case 1:
                    {
                        aktualniPlayers = kolejnosPlayers(aktualniPlayers, dealerButton);
                        foreach (var gracz in aktualniPlayers)
                        {
                            if (gracz.Name == aktualniPlayers[0].Name)
                            {
                                Console.WriteLine(gracz.Name + " wplaca mala ciemna");
                                gracz.Tokens -= smallBlind;
                            }
                            else if (gracz.Name == aktualniPlayers[1].Name)
                            {
                                Console.WriteLine(gracz.Name + " wplaca duza ciemna");
                                gracz.Tokens -= bigBlind;
                            }
                            else
                            {
                                Console.WriteLine("Tura "+gracz.Name);
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine(tura);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine(tura);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine(tura);
                        break;
                    }
                }
                Console.WriteLine(tura);

            } while (aktualniPlayers.Count>1 && tura<4);
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
