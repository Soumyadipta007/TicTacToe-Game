using System;
using System.Diagnostics.SymbolStore;

namespace TicTacToe_Game
{
    class Program
    {
        private static char symbolForPlayer;
        private static char symbolForComputer;
        static void Main(string[] args)
        {
            char[] board = createBoard();
            chooseXor0ForPlayer();
            Player player = new Player("Player", symbolForPlayer);
            Player computer = new Player("Computer", symbolForComputer);
            showBoard(board);
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
        private static void chooseXor0ForPlayer()
        {
            while (true)
            {
                Console.WriteLine("Enter Symbol X or O for Player");
                symbolForPlayer = Console.ReadLine()[0];
                symbolForPlayer = char.ToUpper(symbolForPlayer);
                if (symbolForPlayer == 'X' || symbolForPlayer == 'O')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
            if (symbolForPlayer == 'X')
                symbolForComputer = 'O';
            else
                symbolForComputer = 'X';
        }
        private static void showBoard(char[] board)
        {
            int columnSize = 3;
            for(int i = 1; i < board.Length; i+=3)
            {
                for(int j = 1; j <= columnSize; j++)
                {
                    Console.Write("| " + board[i] + "| ");
                }

                Console.WriteLine();
            }
        }
    }
}
