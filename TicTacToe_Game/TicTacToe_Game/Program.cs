using System;
using System.Diagnostics.SymbolStore;


namespace TicTacToe_Game
{
    class Program
    {
        private static char symbolForPlayer;
        private static char symbolForComputer;
        const int HEADS = 0;
        public enum GameStatus { WON, FULL_BOARD, CONTINUE};
        static void Main(string[] args)
        {
            char[] board = createBoard();
            chooseXor0ForPlayer();
            Player player = new Player("Player", symbolForPlayer);
            Player computer = new Player("Computer", symbolForComputer);
            showBoard(board);
            int index = checkBoard(board);
            board[index] = symbolForPlayer;
            showBoard(board);
            string whoStarts=checkWhoStarts(player.name,computer.name);
            Console.WriteLine(whoStarts + " starts the game");
            Console.WriteLine("Check if won " + isWinner(board, symbolForPlayer));
            int computerMove = getComputerMove(board, symbolForComputer,symbolForPlayer);
            bool gamePlay = true;
            string currentPlayer = whoStarts;
            GameStatus gameStatus;
            while (gamePlay)
            {
                if (currentPlayer.Equals(player.name))
                {
                    showBoard(board);
                    int playerMove = checkBoard(board);
                    string winMessage = "You Won!";
                    gameStatus = getGameStatus(board, playerMove, symbolForPlayer, winMessage);
                    currentPlayer = computer.name;
                }
                else
                {
                    string winMessage = "Computer Won!";
                    int compMove = getComputerMove(board, symbolForComputer, symbolForPlayer);
                    gameStatus = getGameStatus(board, compMove, symbolForComputer, winMessage);
                    currentPlayer = player.name;
                }
                if (gameStatus.Equals(GameStatus.CONTINUE))
                    continue;
                gamePlay = playAgain();
                if (gamePlay)
                {
                    board = createBoard();
                }
            }        
        }
        private static GameStatus getGameStatus(char[] board,int move,char letter,string winMessage)
        {
            bool free = isSpaceFree(board, move);
            if (free)
                board[move] = letter;
            if (isWinner(board, letter))
            {
                showBoard(board);
                Console.WriteLine(winMessage);
                return GameStatus.WON;
            }
            if(isBoardFull(board))
            {
                showBoard(board);
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }
            return GameStatus.CONTINUE;
        }
        private static bool isBoardFull(char[] board)
        {
            for(int index = 1; index < board.Length; index++)
            {
                if (isSpaceFree(board, index))
                    return false;
            }
            return true;
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
        private static int checkBoard(char[] board)
        {
            int index;
            while (true)
            {
                Console.WriteLine("Enter index");
                index = Convert.ToInt32(Console.ReadLine());
                if (board[index] == ' ' && index>=1 && index<=9)
                {               
                    break;
                }
                else
                {
                    Console.WriteLine("Index is not free");
                }
            }
            return index;
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
            int winMove = getWinningMove(board, compLetter);
            if (winMove != 0)
                return winMove;
            int playerwinMove = getWinningMove(board, playerletter);
            if (playerwinMove != 0)
                return playerwinMove;
            int[] cornorMoves = { 1, 3, 7, 9 };
            int computerMove = getRandomMoveFromList(board, cornorMoves);
            if (computerMove != 0)
                return computerMove;
            if (isSpaceFree(board, 5))
                return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            computerMove = getRandomMoveFromList(board, sideMoves);
            if (computerMove != 0)
                return computerMove;
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
        private static int getRandomMoveFromList(char[] board,int[] moves)
        {
            for(int index = 0; index < moves.Length; index++)
            {
                if (isSpaceFree(board, moves[index]))
                    return moves[index];
            }
            return 0;
        }
        private static bool playAgain()
        {
            Console.WriteLine("Enter y to play again else n");
            string option = Console.ReadLine().ToLower();
            if (option.Equals("y"))
                return true;
            else
                return false;
        }
    }    
}
