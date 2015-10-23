using System;
using System.Collections.Generic;

namespace Lista2
{
    public class PlayerMaker
    {
        private readonly int _numberofplayers;
        public PlayerMaker(int players)
        {
            if (players < 2 || players > 52) throw new Exception("Wrong number of players");
            _numberofplayers = players;
        }

        public List<string>[] GetTeam()
        {
            var team = new List<string>[_numberofplayers];
            for (var i = 0; i < _numberofplayers; i++)
            {
                team[i]= new List<string>();
            }
            return team;
        }
    }
}