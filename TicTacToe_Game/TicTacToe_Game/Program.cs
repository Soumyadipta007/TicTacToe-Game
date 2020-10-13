using System;
using System.Diagnostics.SymbolStore;

namespace TicTacToe_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
            char symbolForPlayer = chooseXor0("Player");
            Player player = new Player("Player", symbolForPlayer);
            char symbolForComputer;
            if (symbolForPlayer == 'X')
                symbolForComputer = 'O';
            else
                symbolForComputer = 'X';
            Player computer = new Player("Computer", symbolForComputer);
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
        private static char chooseXor0(string name)
        {
            char symbol;
            while (true)
            {
                Console.WriteLine("Enter Symbol X or O for "+name);
                symbol = Console.ReadLine()[0];
                symbol = char.ToUpper(symbol);
                if (symbol == 'X' || symbol == 'O')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
            return symbol;
        }
    }
}
