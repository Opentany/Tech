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
            List<Card> tableCards=new List<Card>();
            Console.WriteLine("Podaj ilość graczy :");
            int playersCount = int.Parse(Console.ReadLine());
            //Console.WriteLine(playersCount);
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
                nazwa = nazwa + (i+1);
                graczeList.Add(new BasicPlayer());
                graczeList[i].Name = nazwa;
                Console.WriteLine(nazwa);
            }
            //foreach (var VARIABLE in graczeList)
            //{
            //    Console.WriteLine(VARIABLE.Name);
            //}
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Zaczynamy Texas Hold'Em");
            Console.WriteLine("Generowanie Tali Kart");
            Deck talia = new Deck(true);
            //foreach (var karta in talia.GetCards())
            //{
            //    Console.WriteLine(karta.ToString());
            //}
            Console.ReadKey();
            Console.Clear();
            foreach (var gracz in graczeList)
            {
                gracz.Tokens = 100;
            }
            int pula = 0;
            int zaklad = 0;
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
            var zakladgracza=0;
            //List<BasicPlayer> kolejkaPlayers = kolejnosPlayers(aktualniPlayers, dealerButton);
            //foreach (var players in kolejkaPlayers)
            //{
            //    Console.WriteLine(players.Name);
            //}
            var cioty = new List<BasicPlayer>();
            var zaklady = new int[aktualniPlayers.Count];
            do
            {
                tura++;
                // ReSharper disable once SwitchStatementMissingSomeCases
                bool wybor;
                switch (tura)
                {
                    case 1:
                    {
                        Console.WriteLine("Tura " + tura + " Pierwsza licytacja");
                        aktualniPlayers = kolejnosPlayers(aktualniPlayers, dealerButton);
                        foreach (var gracz in aktualniPlayers)
                        {
                            if (gracz.Name == aktualniPlayers[0].Name)
                            {
                                Console.Clear();
                                Console.WriteLine("Tura " + gracz.Name);
                                Console.ReadKey();
                                Console.WriteLine("Twoje tokeny: " + gracz.Tokens);
                                Console.WriteLine(gracz.Name + " wplaca mala ciemna");
                                gracz.Tokens -= smallBlind;
                                pula += smallBlind;
                                zaklady[aktualniPlayers.IndexOf(gracz)]=smallBlind;
                                zaklad = zaklady.Max();
                                Console.WriteLine("Twoja ręka");
                                foreach (var karty in gracz.Hand)
                                {
                                    Console.WriteLine(karty.ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (gracz.Name == aktualniPlayers[1].Name)
                            {
                                Console.Clear();
                                Console.WriteLine("Tura " + gracz.Name);
                                Console.ReadKey();
                                Console.WriteLine("Twoje tokeny: " + gracz.Tokens);
                                Console.WriteLine(gracz.Name + " wplaca duza ciemna");
                                gracz.Tokens -= bigBlind;
                                pula += bigBlind;
                                zaklady[aktualniPlayers.IndexOf(gracz)] = bigBlind;
                                zaklad = zaklady.Max();
                                Console.WriteLine("Twoja ręka");
                                foreach (var karty in gracz.Hand)
                                {
                                    Console.WriteLine(karty.ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                var i = 0;
                                Console.Clear();
                                Console.WriteLine("Tura " + gracz.Name);
                                Console.ReadKey();
                                Console.WriteLine("zakłady poprzednich graczy");
                                foreach (var zak in zaklady)
                                {
                                    Console.WriteLine(graczeList[i].Name);
                                    Console.WriteLine(zak);
                                    i++;
                                }
                                Console.WriteLine("najwyzszy zaklad to "+zaklad);
                                Console.WriteLine("Twoja ręka");
                                foreach (var karty in gracz.Hand)
                                {
                                    Console.WriteLine(karty.ToString());
                                }
                                Console.WriteLine("Twoje tokeny: "+gracz.Tokens);
                                Console.WriteLine("Co robisz? wpisz jedno z trzech (call/rise/fold)");
                                do
                                {
                                    switch (Console.ReadLine())
                                    {
                                        case "call":
                                            {
                                                zakladgracza = gracz.Call(zaklad);
                                                pula += zakladgracza;
                                                zaklady[aktualniPlayers.IndexOf(gracz)] = zakladgracza;
                                                Console.WriteLine("wpłacasz " + zakladgracza + " do puli");
                                                wybor = true;
                                                break;
                                            }
                                        case "rise":
                                            {
                                                Console.WriteLine("Ile wpłacasz ? ");
                                                zakladgracza = int.Parse(Console.ReadLine());
                                                zakladgracza = gracz.Raise(zakladgracza);
                                                pula += zakladgracza;
                                                zaklady[aktualniPlayers.IndexOf(gracz)] = zakladgracza;
                                                Console.WriteLine("wpłacasz " + zakladgracza + " do puli");
                                                wybor = true;
                                                break;
                                            }
                                        case "fold":
                                            {
                                                Console.WriteLine("wstrzymuje sie");
                                                cioty.Add(gracz);
                                                wybor = true;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Nie umiesz pisać frajerze !!");
                                                wybor = false;
                                                break;
                                            }
                                    }
                                } while (wybor!=true);
                                
                                zaklad = zaklady.Max();
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        foreach (var gracz in cioty)
                        {
                            gracz.Fold(aktualniPlayers);
                        }
                        Console.WriteLine("Gracze którzy pozostali w grze");
                        foreach (var gracz in aktualniPlayers)
                        {
                            Console.WriteLine(gracz.Name);
                        }
                        Console.ReadKey();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Tura "+tura+" Flop");
                        for (int i = 0; i < 3; i++)
                        {
                            tableCards.Add(talia.GetTopCard());
                        }
                        Console.WriteLine("Na stole pojawiają się karty");
                        Console.ReadKey();
                        foreach (var karta in tableCards)
                        {
                            Console.WriteLine(karta.ToString());
                        }
                        Console.ReadKey();
                        Console.WriteLine("Czas rozpocząć licytację");
                        Console.Clear();
                        zaklady=new int[aktualniPlayers.Count];
                        zaklad = zaklady.Max();
                        foreach (var gracz in aktualniPlayers)
                        {
                            int i = 0;
                            Console.Clear();
                            Console.WriteLine("Tura " + gracz.Name);
                            Console.ReadKey();
                            Console.WriteLine("zakłady poprzednich graczy");
                            foreach (var zak in zaklady)
                            {
                                Console.WriteLine(graczeList[i].Name);
                                Console.WriteLine(zak);
                                i++;
                            }
                            Console.WriteLine("najwyzszy zaklad to " + zaklad);
                            Console.WriteLine("Twoja ręka");
                            foreach (var karty in gracz.Hand)
                            {
                                Console.WriteLine(karty.ToString());
                            }
                            Console.WriteLine("Stol:");
                            foreach (var karta in tableCards)
                            {
                                Console.WriteLine(karta.ToString());
                            }
                            Console.WriteLine("Twoje tokeny: " + gracz.Tokens);
                            Console.WriteLine("Co robisz? wpisz jedno z pięciu (bet/check/call/rise/fold)");
                            do
                            {
                                switch (Console.ReadLine())
                                {
                                    case "call":
                                    {
                                        if (zaklad==0)
                                        {
                                            Console.WriteLine("nie masz do kogo wyrownac");
                                            wybor = false;
                                            Console.WriteLine("Wybierz inna opcje");
                                            break;
                                        }
                                        zakladgracza = gracz.Call(zaklad);
                                        pula += zakladgracza;
                                        zaklady[aktualniPlayers.IndexOf(gracz)] = zakladgracza;
                                        Console.WriteLine("wpłacasz " + zakladgracza + " do puli");
                                        wybor = true;
                                        break;
                                    }
                                    case "rise":
                                    {
                                        Console.WriteLine("Ile wpłacasz ? ");
                                        zakladgracza = int.Parse(Console.ReadLine());
                                        if (zakladgracza<=zaklad)
                                        {
                                            Console.WriteLine("Daj wiecej hajsu");
                                            wybor = false;
                                            Console.WriteLine("Wybierz opcje na nowo");
                                            break;
                                        }
                                        zakladgracza = gracz.Raise(zakladgracza);
                                        pula += zakladgracza;
                                        zaklady[aktualniPlayers.IndexOf(gracz)] = zakladgracza;
                                        Console.WriteLine("wpłacasz " + zakladgracza + " do puli");
                                        wybor = true;
                                        break;
                                    }
                                    case "fold":
                                    {
                                        Console.WriteLine("wstrzymuje sie");
                                        cioty.Add(gracz);
                                        wybor = true;
                                        break;
                                    }
                                    case "bet":
                                    {
                                        if (zaklad == 0)
                                        {
                                            Console.WriteLine("Ile wpłacasz ? ");
                                            zakladgracza = int.Parse(Console.ReadLine());
                                            zakladgracza = gracz.Bet(zakladgracza);
                                            pula += zakladgracza;
                                            zaklady[aktualniPlayers.IndexOf(gracz)] = zakladgracza;
                                            Console.WriteLine("wpłacasz " + zakladgracza + " do puli");
                                            wybor = true;
                                            break;
                                        }
                                        Console.WriteLine("Jest juz jakis zaklad wybierz inna opcje");
                                        wybor = false;
                                        break;
                                    }
                                    case "check":
                                    {
                                        if (zaklad == 0)
                                        {
                                            Console.WriteLine("czekam");
                                            wybor = true;
                                            break;
                                        }
                                        Console.WriteLine("Nie mozesz czekac, wybierz inna opcje");
                                        wybor = false;
                                        break;
                                    }

                                    default:
                                    {
                                        Console.WriteLine("Nie umiesz pisać frajerze !!");
                                        wybor = false;
                                        break;
                                    }
                                }
                            } while (wybor != true);
                            zaklad = zaklady.Max();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        foreach (var gracz in cioty)
                        {
                            gracz.Fold(aktualniPlayers);
                        }
                        Console.WriteLine("Gracze którzy pozostali w grze");
                        foreach (var gracz in aktualniPlayers)
                        {
                            Console.WriteLine(gracz.Name);
                        }
                        Console.ReadKey();
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

            } while (aktualniPlayers.Count>1 && tura<4);
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
