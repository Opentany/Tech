using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Cards;
using Poker.Players;

namespace ConsoleApplication1
{
    class Game
    {
        static List<BasicPlayer> KolejnosPlayers(List<BasicPlayer> listagraczy, int ktodealer)
        {
            int j;
            var tmp = new List<BasicPlayer>();
            for (var i = 0; i < listagraczy.Count; i++)
            {
                j = MaMalaCiemna(ktodealer + i, listagraczy.Count);
                tmp.Add(listagraczy[j]);
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
        static void Main()
        {
            var random = new Random();
            var tableCards=new List<Card>();
            Console.WriteLine("Podaj ilość graczy :");
            // ReSharper disable once AssignNullToNotNullAttribute
            var playersCount = int.Parse(Console.ReadLine());
            //Console.WriteLine(playersCount);
            if (playersCount>10)
            {
                Console.Clear();
                Console.WriteLine("Za duzo graczy");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Podaj małą ciemną");
            // ReSharper disable once AssignNullToNotNullAttribute
            var smallBlind = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj dużą ciemną");
            // ReSharper disable once AssignNullToNotNullAttribute
            var bigBlind = int.Parse(Console.ReadLine());
            var graczeList = new List<BasicPlayer>(playersCount);
            for (var i = 0; i < playersCount; i++)

            {
                var nazwa = "gracz";
                nazwa = nazwa + (i+1);
                graczeList.Add(new BasicPlayer());
                graczeList[i].Name = nazwa;
                Console.WriteLine(nazwa);
            }
            //foreach (var VARIABLE in graczeList)
            //{
            //    Console.WriteLine(VARIABLE.Name);
            //}
            foreach (var gracz in graczeList)
            {
                gracz.Tokens = 100;
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Zaczynamy Texas Hold'Em");
            Console.WriteLine("Generowanie Tali Kart");
            var talia = new Deck(true);
            //foreach (var karta in talia.GetCards())
            //{
            //    Console.WriteLine(karta.ToString());
            //}
            Console.ReadKey();
            Console.Clear();
            var dealerButton = random.Next(graczeList.Count);
            var mamalaciemna = MaMalaCiemna(dealerButton, playersCount);
            var maduzaciemna = MaDuzaCiemna(dealerButton, playersCount);
            var pula = 0;
            var zaklad = 0;
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
            var aktualniPlayers = graczeList;
            var tura=0;
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
                int zakladgracza;
                switch (tura)
                {
                    case 1:
                    {
                        Console.WriteLine("Tura " + tura + " Pierwsza licytacja");
                        aktualniPlayers = KolejnosPlayers(aktualniPlayers, dealerButton);
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
                                                // ReSharper disable once AssignNullToNotNullAttribute
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
                        for (var i = 0; i < 3; i++)
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
                                        // ReSharper disable once AssignNullToNotNullAttribute
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
                                            // ReSharper disable once AssignNullToNotNullAttribute
                                            zakladgracza = int.Parse(Console.ReadLine());
                                            if (zakladgracza < 1)
                                            {
                                                Console.WriteLine("Daj wiecej hajsu");
                                                wybor = false;
                                                Console.WriteLine("Wybierz opcje na nowo");
                                                break;
                                            }
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
                        Console.WriteLine("Tura " + tura + " Turn");
                        tableCards.Add(talia.GetTopCard());
                        Console.WriteLine("Na stole pojawia się nowa karta");
                        Console.ReadKey();
                        foreach (var karta in tableCards)
                        {
                            Console.WriteLine(karta.ToString());
                        }
                        Console.ReadKey();
                        Console.WriteLine("Czas rozpocząć licytację");
                        Console.Clear();
                        zaklady = new int[aktualniPlayers.Count];
                        zaklad = zaklady.Max();
                        foreach (var gracz in aktualniPlayers)
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
                                            if (zaklad == 0)
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
                                            // ReSharper disable once AssignNullToNotNullAttribute
                                            zakladgracza = int.Parse(Console.ReadLine());
                                            if (zakladgracza <= zaklad)
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
                                                // ReSharper disable once AssignNullToNotNullAttribute
                                                zakladgracza = int.Parse(Console.ReadLine());
                                                if (zakladgracza < 1)
                                                {
                                                    Console.WriteLine("Daj wiecej hajsu");
                                                    wybor = false;
                                                    Console.WriteLine("Wybierz opcje na nowo");
                                                    break;
                                                }
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
                    case 4:
                    {
                        Console.WriteLine("Tura " + tura + " River");
                        tableCards.Add(talia.GetTopCard());
                        Console.WriteLine("Na stole pojawia się nowa karta");
                        Console.ReadKey();
                        foreach (var karta in tableCards)
                        {
                            Console.WriteLine(karta.ToString());
                        }
                        Console.ReadKey();
                        Console.WriteLine("Czas rozpocząć licytację");
                        Console.Clear();
                        zaklady = new int[aktualniPlayers.Count];
                        zaklad = zaklady.Max();
                        foreach (var gracz in aktualniPlayers)
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
                                            if (zaklad == 0)
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
                                            // ReSharper disable once AssignNullToNotNullAttribute
                                            zakladgracza = int.Parse(Console.ReadLine());
                                            if (zakladgracza <= zaklad)
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
                                                // ReSharper disable once AssignNullToNotNullAttribute
                                                zakladgracza = int.Parse(Console.ReadLine());
                                                if (zakladgracza < 1)
                                                {
                                                    Console.WriteLine("Daj wiecej hajsu");
                                                    wybor = false;
                                                    Console.WriteLine("Wybierz opcje na nowo");
                                                    break;
                                                }
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
                }

            } while (aktualniPlayers.Count>1 && tura<4);

            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
