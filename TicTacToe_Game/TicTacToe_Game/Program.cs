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
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
    }
}
