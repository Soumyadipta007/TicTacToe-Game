using System;
using System.Diagnostics.SymbolStore;

namespace TicTacToe_Game
{
    class Program
    {
        private static char symbolForPlayer;
        private static char symbolForComputer;
        const int HEADS = 0;
        const int TAILS = 1;
        static void Main(string[] args)
        {
            char[] board = createBoard();
            chooseXor0ForPlayer();
            Player player = new Player("Player", symbolForPlayer);
            Player computer = new Player("Computer", symbolForComputer);
            showBoard(board);
            board = checkBoard(board,symbolForPlayer);
            showBoard(board);
            string whoStarts=checkWhoStarts();
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
                Console.WriteLine("..Enter Symbol X or O for Player..");
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
            Console.WriteLine("|"+board[1]+"|"+ board[2] + "|"+ board[3] + "|");
            Console.WriteLine("-------");
            Console.WriteLine("|" + board[4] + "|" + board[5] + "|" + board[6] + "|");
            Console.WriteLine("-------");
            Console.WriteLine("|" + board[7] + "|" + board[8] + "|" + board[9] + "|");            
        }
        private static char[] checkBoard(char[] board,char symbol)
        {

            while (true)
            {
                Console.WriteLine("Enter index");
                int index = Convert.ToInt32(Console.ReadLine());
                if (board[index] == ' ' && index>=1 && index<=9)
                {
                    board[index] = symbol;
                    break;
                }
                else
                {
                    Console.WriteLine("Index is not free");
                }
            }
            return board;
        }
        private static string checkWhoStarts()
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            if (toss == HEADS)
                return "Player";
            else
                return "Computer";
        }
    }
}
