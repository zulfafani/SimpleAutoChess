using System;
using System.Numerics;
using SimpleAutoChess;

namespace SimpleAutoChess
{
	public static class Display
	{
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void InvalidNumberInfo()
		{
            ShowMessage("Invalid input. Please enter a valid number.");
		}

		public static void InvalidPlayerNameInfo()
		{
            ShowMessage("Name already exists. Please enter a different name.");
		}

		public static void InvalidUnitInfo()
		{
            ShowMessage("Invalid unit name. Please enter the correct name.");
		}

        public static void InvalidLocationInfo()
        {
            ShowMessage("Invalid location input. Skipping unit placement.");
        }

        public static void PlayerInfo(GameManager gameManager)
        {
            Console.Clear();
            ShowMessage($"Players Information:");
            foreach (Player player in gameManager.GetPlayerUnits().Keys)
            {
                ShowMessage("------------------------------");
                ShowMessage($"Player Name: {player.Name}");
                ShowMessage($"Player ID: {player.Id}");
                ShowMessage($"Player Point: {player.Point}");
                ShowMessage($"Player Gold: ${player.Gold}");
                ShowMessage($"Player Level: {player.Level}");
            }
        }

        public static void PlayerUnitInfo(GameManager gameManager)
        {
            Console.Clear();
            int playerIndex = 1;
            ShowMessage($"Players Information:");
            foreach (var player in gameManager.GetPlayerUnits())
            {
                Player players = player.Key;
                List<IUnit> units = player.Value;
                ShowMessage("------------------------------");
                ShowMessage($"Player Name: {players.Name}");
                ShowMessage($"Player ID: {players.Id}");
                ShowMessage($"Player Point: {players.Point}");
                ShowMessage($"Player Gold: ${players.Gold}");
                ShowMessage($"Player Level: {players.Level}");
                
                ShowMessage("Units:");
                foreach (IUnit unit in units)
                {
                    ShowMessage($"Unit name: {unit.GetType().Name}");
                    ShowMessage($"Unit price: ${unit.GetPrice()}");
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
                    board[i, j] = "[     ]";
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
    }
}