using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Program
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();

            int numPlayers = InputNumberOfPlayers();
            int boardSize = InputBoardSize();

            Dictionary<Player, List<IUnit>> playerUnits = InputPlayers(numPlayers, gameManager);
            Display.PlayerInfo(gameManager);

            int numbUnits = gameManager.NumberOfUnits();
            InputUnits(numbUnits, gameManager);
            Display.PlayerUnitInfo(gameManager);

            InputLocationUnits(boardSize, gameManager);

            //gameManager.Battle(numPlayers);
            gameManager.StartGame();
        }

        public static int InputNumberOfPlayers()
        {
            int numPlayers = 0;
            bool validInput = false;

            do
            {
                Console.Write("Enter the number of players: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out numPlayers) && numPlayers > 1 && numPlayers <= 8 && numPlayers % 2 == 0)
                {
                    validInput = true;
                }
                else
                {
                    Display.InvalidNumberInfo();
                }
            }
            while (!validInput); //repeat the iteration for input number player

            return numPlayers;
        }
        public static Dictionary<Player, List<IUnit>> InputPlayers(int numPlayers, GameManager gameManager)
        {
            Dictionary<Player, List<IUnit>> playerUnits = new Dictionary<Player, List<IUnit>>();

            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Enter the name of player {i + 1}: ");
                string? playerName = Console.ReadLine();

                Player player = new Player(playerName, gameManager.GenerateRandomId(), 100, 2, 1);

                if (gameManager.IsPlayerNameExists(playerName))
                {
                    Display.InvalidPlayerNameInfo();
                    i--; // repeat the iteration for the same player index
                    continue;
                }
                gameManager.AddPlayer(player);
            }
            return playerUnits;
        }
        
        public static void InputUnits(int numUnits, GameManager gameManager)
        {
            foreach (var player in gameManager.GetPlayerUnits())
            {
                Player playerName = player.Key;

                Console.WriteLine($"\nPlayer: {playerName.Name}");
                //input units name -> AddUnitForPlayer method
                for (int i = 0; i < numUnits; i++)
                {
                    List<UnitName> unitNames = gameManager.GetAllUnitNames();
                    Console.WriteLine("Available units: ");
                    foreach (UnitName unitName in unitNames)
                    {
                        Console.WriteLine($"- {unitName}");
                    }

                    Console.Write($"Choose a unit name: {i + 1}: ");
                    string? unitInput = Console.ReadLine();
                    Enum.TryParse(unitInput, out UnitName selectedUnitName);

                    bool containsUnit = unitNames.Any(unit => unitInput.Contains(unit.ToString()));
                    if (!containsUnit)
                    {
                        Display.InvalidUnitInfo();
                        i--; // repeat the iteration for incorrect unit index
                        continue;
                    }
                    else
                    {
                        gameManager.SpawnUnit(playerName, gameManager.GetUnitFactory(selectedUnitName));
                    }
                }
            }
        }

        public static int InputBoardSize()
        {
            int boardSize;
            bool validSizeInput = false;

            do
            {
                Console.Write("Enter the size of the board (8 - 12): ");
                string? inputSize = Console.ReadLine();
                if (int.TryParse(inputSize, out boardSize) && boardSize >= 8 && boardSize <= 12)
                {
                    validSizeInput = true;
                }
                else
                {
                    Display.InvalidNumberInfo();
                }
            } while (!validSizeInput);
            return boardSize;
        }

        public static void InputLocationUnits(int boardSize, GameManager gameManager)
        {
            string[,] board = new string[boardSize, boardSize];
            Display.InitializeBoard(boardSize, board);

            foreach (var player in gameManager.GetPlayerUnits())
            {
                Player currentPlayer = player.Key;
                List<IUnit> units = player.Value;

                foreach (IUnit unit in units)
                {
                    Console.Write($"Enter the location of {unit.GetType().Name} for {currentPlayer.Name} (row column): ");
                    string? locationInput = Console.ReadLine();
                    string[] locationValues = locationInput.Split(' ');

                    IPosition position = new Position();

                    if (locationValues.Length == 2 && int.TryParse(locationValues[0], out int row) && int.TryParse(locationValues[1], out int column))
                    {
                        if (gameManager.IsValidPosition(row, column, boardSize))
                        {
                            position.Row = row;
                            position.Column = column;

                            board[row, column] = $"[{(unit.GetType().Name).Substring(0,5)}]";
                            Console.WriteLine($"Unit {unit.GetType().Name} added at location: Row {row}, Column {column}");
                            gameManager.AddUnitOnBoard(currentPlayer, unit, position);
                        }
                        else
                        {
                            Display.InvalidLocationInfo();
                            // Method for random unit placement can be called here
                            /*Random random = new Random();
                            int randomRow, randomColumn;
                            do
                            {
                                randomRow = random.Next(0, boardSize);
                                randomColumn = random.Next(0, boardSize);
                            }
                            while (gameManager.IsEmptyPosition(randomRow, randomColumn, board));
                            board[randomRow, randomColumn] = $"[{(unit.GetType().Name).Substring(0, 5)}]";
                            Console.WriteLine($"Unit {unit.GetType().Name} added at location: Row {randomRow}, Column {randomColumn}");
                            gameManager.AddUnitOnBoard(currentPlayer, unit, position);*/

                        }
                    }
                    else
                    {
                        Display.InvalidLocationInfo();
                        // Method for random unit placement can be called here
                        /*Random random = new Random();
                        int randomRow, randomColumn;
                        do
                        {
                            randomRow = random.Next(0, boardSize);
                            randomColumn = random.Next(0, boardSize);
                        }
                        while (gameManager.IsEmptyPosition(randomRow, randomColumn, board));
                        board[randomRow, randomColumn] = $"[{(unit.GetType().Name).Substring(0, 5)}]";
                        Console.WriteLine($"Unit {unit.GetType().Name} added at location: Row {randomRow}, Column {randomColumn}");
                        gameManager.AddUnitOnBoard(currentPlayer, unit, position);*/
                    }
                }
            }
            Display.PrintBoard(boardSize, board);
        }
    }
}