using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Game
{
    class Player
    {
        public string name;
        public char symbol;
        public Player(string name,char symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }
    }
}
