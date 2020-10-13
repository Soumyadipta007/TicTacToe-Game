using System;

namespace TicTacToe_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
        }
        private static char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < 10; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
    }
}
