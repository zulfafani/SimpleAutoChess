using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
	public static class Display
	{
		public static void InvalidNumberInfo()
		{
			Console.WriteLine("Invalid input. Please enter a valid number.");
		}

		public static void InvalidPlayerNameInfo()
		{
			Console.WriteLine("Name already exists. Please enter a different name.");
		}

		public static void InvalidUnitInfo()
		{
			Console.WriteLine("Invalid unit name. Please enter the correct name.");
		}

        public static void InvalidLocationInfo()
        {
            Console.WriteLine("Invalid location input. Skipping unit placement.");
        }

        public static void PlayerUnitInfo(Dictionary<string, List<UnitName>> playerUnits, GameManager gameManager)
        {
            Console.WriteLine("\n--Player List--");
            int playerIndex = 1;
            foreach (var player in playerUnits)
            {
                string playerName = player.Key;
                List<UnitName> units = player.Value;

                Console.WriteLine($"Player {playerIndex}: {playerName}");
                Console.WriteLine($"Player ID: {gameManager.GenerateRandomId()}");

                Console.WriteLine("Units:");
                foreach (UnitName unit in units)
                {
                    Console.WriteLine($"Unit name: {unit}, ");
                }
                playerIndex++;
            }
        }

        public static void InitializeBoard(int boardSize, string[,] board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = "[        ]";
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintBoard(int boardSize, string[,] board)
        {
            // Print the board
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void UnitOnBoardInput(GameManager gameManager)
        {
            foreach (var unitNameOnBoard in gameManager.GetAllUnitOnBoard())
            {
                List<UnitName> unitNames = unitNameOnBoard.Value;
                foreach (UnitName unit in unitNames)
                {
                    Console.WriteLine($"UnitName: {unit}");
                }
            }
        }
    }
}