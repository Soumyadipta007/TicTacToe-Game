using System;
using System.Diagnostics.SymbolStore;


namespace TicTacToe_Game
{
    class Program
    {
        private static char symbolForPlayer;
        private static char symbolForComputer;
        const int HEADS = 0;
        static void Main(string[] args)
        {
            char[] board = createBoard();
            chooseXor0ForPlayer();
            Player player = new Player("Player", symbolForPlayer);
            Player computer = new Player("Computer", symbolForComputer);
            showBoard(board);
            board = checkBoard(board,symbolForPlayer);
            showBoard(board);
            string whoStarts=checkWhoStarts(player.name,computer.name);
            Console.WriteLine(whoStarts + " starts the game");
            Console.WriteLine("Check if won " + isWinner(board, symbolForPlayer));
            int computerMove = getComputerMove(board, symbolForComputer,symbolForPlayer);
        
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
        private static string checkWhoStarts(string player,string computer)
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            if (toss == HEADS)
                return player;
            else
                return computer;
        }
        private static bool isWinner(char[] b,char ch)
        {
            return ((b[1] == ch && b[2] == ch && b[3] == ch) ||
                (b[4] == ch && b[5] == ch && b[6] == ch) ||
                (b[7] == ch && b[8] == ch && b[9] == ch) ||
                (b[1] == ch && b[4] == ch && b[7] == ch) ||
                (b[2] == ch && b[5] == ch && b[8] == ch) ||
                (b[3] == ch && b[6] == ch && b[9] == ch) ||
                (b[1] == ch && b[5] == ch && b[9] == ch) ||
                (b[7] == ch && b[5] == ch && b[3] == ch));
        }
        private static int getComputerMove(char[] board,char compLetter,char playerletter)
        {
            int compwinMove = getWinningMove(board, compLetter);
            if (compwinMove != 0)
                return compwinMove;
            int playerwinMove = getWinningMove(board, playerletter);
            if (playerwinMove != 0)
                return playerwinMove;
            return 0;
        }
        private static int getWinningMove(char[] board, char letter)
        {
            for(int index = 1; index < board.Length; index++)
            {
                char[] copyBoard = getCopyBoard(board);
                if(isSpaceFree(copyBoard,index))
                {
                    copyBoard[index] = letter;
                    if (isWinner(copyBoard, letter))
                        return index;
                }
            }
            return 0;
        }
        private static char[] getCopyBoard(char[] board)
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, 0, boardCopy, 0, board.Length);
            return boardCopy;
        }
        private static bool isSpaceFree(char[] board,int index)
        {
            return board[index] == ' ';
        }
    }
}
