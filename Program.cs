using System.Linq;

namespace Tic_Tac_Toe_Game
{
    internal class Program
    {
        static string[,] gameBoard = new string[3, 3];
        static string p1 = "1", p2 = "2", p3 = "3", p4 = "4", p5 = "5", p6 = "6", p7 = "7", p8 = "8", p9 = "9";
        static string token = "error";
        static bool endgame = false;
        static int turn = 0;
        static List<int> places = new List<int>();
        static int pos;
        static bool valueVerification;
        static int player = 0;
        static bool playExecuted = false;
        static void Main(string[] args)
        {
            LetsPlay();
        }

        static void LetsPlay()
        {
            WriteTheGameBoard();
            while (endgame == false && turn < 9)
            {
                while (playExecuted == false)
                {
                    player = (turn % 2) + 1;
                    Console.WriteLine($"\nPlayer {player} : Choose your field");
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid. Please choose a number between 1 and 9");
                        playExecuted = false;
                    }
                    else
                    {
                        CallPlayer(input);
                    }
                }
                playExecuted = false;
                turn++;
                endgame = Checker(gameBoard);
            }
            GameEnding();
        }
        static void GameEnding()
        {
            Console.WriteLine("");
            if (endgame)
            {
                Console.WriteLine($"Player {player} Winner");
            }
            else
            {
                Console.WriteLine("No winner, game tied");
            }
            Console.WriteLine("\nPress any key to restart the game");
            Console.ReadKey();
            ResetFunction();
        }

        static void CallPlayer(string input) {
                valueVerification = int.TryParse(input, out pos);
                if (valueVerification && pos > 0 && pos < 10)
                {
                    if (places.Contains(pos)) { Console.WriteLine("Place already taken, choose another one"); playExecuted = false; }
                    else
                    {
                        places.Add(pos);
                        Console.Clear();
                        token = turn % 2 == 0 ? "X" : "O";
                        PlayTheGame(input, token);
                        playExecuted = true;
                }
                }
                else { Console.WriteLine("Invalid. Please choose a number between 1 and 9"); playExecuted = false; }
        }
        static void WriteTheGameBoard()
        {
            Console.WriteLine("     |     |");
            Console.WriteLine($"  {gameBoard[0, 0] = p1}  |  {gameBoard[0, 1] = p2}  |  {gameBoard[0, 2] = p3}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine($"  {gameBoard[1, 0] = p4}  |  {gameBoard[1, 1] = p5}  |  {gameBoard[1, 2] = p6}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine($"  {gameBoard[2, 0] = p7}  |  {gameBoard[2, 1] = p8}  |  {gameBoard[2, 2] = p9}");
            Console.WriteLine("     |     |   ");
        }

        
        static void PlayTheGame(string input, string token)
        {
            switch (input)
            {
                case "1":
                    p1 = token;
                    WriteTheGameBoard();
                    break;
                case "2":
                    p2 = token;
                    WriteTheGameBoard();
                    break;
                case "3":
                    p3 = token;
                    WriteTheGameBoard();
                    break;
                case "4":
                    p4 = token;
                    WriteTheGameBoard();
                    break;
                case "5":
                    p5 = token;
                    WriteTheGameBoard();
                    break;
                case "6":
                    p6 = token;
                    WriteTheGameBoard();
                    break;
                case "7":
                    p7 = token;
                    WriteTheGameBoard();
                    break;
                case "8":
                    p8 = token;
                    WriteTheGameBoard();
                    break;
                case "9":
                    p9 = token;
                    WriteTheGameBoard();
                    break;
                default:
                    Console.WriteLine("endgame");
                    break;
            }
        }
        public static bool Checker(string[,] board)
        {

            int cont = 0;
            int positionsX = 0;
            int positionsY = 0;
            // HORIZONTAL CHECK
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[cont, j] == "X")
                    {
                        positionsX++;
                        if (positionsX == 3) { return true; }
                    }
                    else if (board[cont, j] == "O")
                    {
                        positionsY++;
                        if (positionsY == 3) { return true; }
                    }
                }
                cont++; positionsX = 0; positionsY = 0;
            }
            cont = 0;
            // VERTICAL CHECK
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, cont] == "X")
                    {
                        positionsX++;
                        if (positionsX == 3) { return true; }
                    }
                    else if (board[j, cont] == "O")
                    {
                        positionsY++;
                        if (positionsY == 3) { return true; }
                    }
                }
                cont++; positionsX = 0; positionsY = 0;
            }
            cont = 0;
            // DIAGONAL CHECK RIGHT TO LEFT
            for (int i = 0, j = 2; i < 3; i++, j--)
            {
                if (board[i, j] == "X")
                {
                    positionsX++;
                    if (positionsX == 3) { return true; }
                }
                else if (board[i, j] == "O")
                {
                    positionsY++;
                    if (positionsY == 3) { return true; }
                }
            }
            positionsX = 0; positionsY = 0;
            // DIAGONAL CHECK LEFT TO RIGHT
            for (int i = 0; i < 3; i++)
            {
                if (board[i, i] == "X")
                {
                    positionsX++;
                    if (positionsX == 3) { return true; }
                }
                else if (board[i, i] == "O")
                {
                    positionsY++;
                    if (positionsY == 3) { return true; }
                }
            }
            return false;
        }
        public static void ResetFunction()
        {
            Console.Clear();
            p1 = "1"; p2 = "2"; p3 = "3"; p4 = "4"; p5 = "5"; p6 = "6"; p7 = "7"; p8 = "8"; p9 = "9";
            turn = 0;
            endgame = false;
            places.Clear();
            LetsPlay();
        }
    }
}
