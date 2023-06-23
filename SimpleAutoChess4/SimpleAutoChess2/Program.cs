using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public static class Program
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();

            //Input number of players
            int numPlayers;
            bool validInput = false;
            do
            {
                Console.Write("Enter the number of players: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out numPlayers) && numPlayers > 1 && numPlayers <= 8)
                {
                    validInput = true;
                }
                else
                {
                    Display.InvalidNumberInfo();
                }
            }
            while (!validInput); //repeat the iteration for input number player

            //Input name of players -> AddPlayer method
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Enter the name of player {i + 1}: ");
                string? playerName = Console.ReadLine();

                IPlayer player = new Player();
                player.SetName(playerName);

                if (gameManager.PlayerExists(player))
                {
                    Display.InvalidPlayerNameInfo();
                    i--; // repeat the iteration for the same player index
                    continue;
                }
                gameManager.AddPlayer(player);
            }

            //input number of units
            foreach (var player in gameManager.GetPlayerUnits())
            {
                string playerName = player.Key;

                Console.WriteLine($"\nPlayer: {playerName}");

                Console.Write("Enter the number of units: ");
                int numUnits;
                bool validUnitInput = false;

                do
                {
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out numUnits) && numUnits > 0)
                    {
                        validUnitInput = true;
                    }
                    else
                    {
                        Display.InvalidNumberInfo();
                    }
                }
                while (!validUnitInput); //repeat the iteration for input number unit

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
                    IUnit unit = new Unit();

                    bool containsUnit = unitNames.Any(unit => unitInput.Contains(unit.ToString()));
                    if (!containsUnit)
                    {
                        Display.InvalidUnitInfo();
                        i--; // repeat the iteration for incorrect unit index
                        continue;
                    }
                    else
                    {
                        gameManager.AddUnitForPlayer(playerName, selectedUnitName);
                    }
                }
            }
            Display.PlayerUnitInfo(gameManager.GetPlayerUnits(), gameManager);

            // Input size of Board
            int boardSize;
            bool validSizeInput = false;
            Console.WriteLine("\n--AutoChess Board--");
            do
            {
                Console.Write("Enter the size of Board (8 - 12):");
                string? inputSize = Console.ReadLine();
                if (int.TryParse(inputSize, out boardSize) & boardSize >= 8 && boardSize <= 12)
                {
                    validSizeInput = true;
                }
                else
                {
                    Display.InvalidNumberInfo();
                }
            }
            while (!validSizeInput); //repeat the iteration for input size board

            string[,] board = new string[boardSize, boardSize];
            Display.InitializeBoard(boardSize, board);

            // Place the units name on the board -> AddUnitOnBoard method
            foreach (var unitName in gameManager.GetPlayerUnits())
            {
                List<UnitName> units = unitName.Value;

                foreach (UnitName unit in units)
                {
                    Console.Write($"Enter the location of {unit} for {unitName.Key} (row column): ");
                    string? locationInput = Console.ReadLine();
                    string[] locationValues = locationInput.Split(' ');

                    if (locationValues.Length == 2 && int.TryParse(locationValues[0], out int row) && int.TryParse(locationValues[1], out int column))
                    {
                        if (gameManager.IsValidPosition(row, column, boardSize))
                        {
                            IPosition position = new Position { row = row, col = column };

                            board[row, column] = $"[{unit}]";
                            Console.WriteLine($"Unit {unit} added at location: Row {row}, Column {column}");
                            gameManager.AddUnitOnBoard(unitName.Key, unit, position);
                        }
                        else
                        {
                            Display.InvalidLocationInfo();
                            //method untuk random placement units
                        }
                    }
                    else
                    {
                        Display.InvalidLocationInfo();
                        //method untuk random placement units
                    }
                }
            }
            Display.PrintBoard(boardSize, board);


            foreach (var unitNameOnBoard in gameManager.GetAllUnitOnBoard())
            {
                List<UnitName> unitName12 = unitNameOnBoard.Value;
                foreach (UnitName unit12 in unitName12)
                {
                    Console.WriteLine($"\nUnitName: {unit12}");

                    IAttack attack = null;
                    IHealth health = null;

                    switch (unit12)
                    {
                        case UnitName.TuskChampion:
                            attack = new TuskChampion();
                            health = new TuskChampion();
                            break;
                        case UnitName.TheSource:
                            attack = new TheSource();
                            health = new TheSource();
                            break;
                        case UnitName.FlameWizard:
                            attack = new FlameWizard();
                            health = new FlameWizard();
                            break;
                        case UnitName.SoulBreaker:
                            attack = new SoulBreaker();
                            health = new SoulBreaker();
                            break;
                        case UnitName.SkyBreaker:
                            attack = new SkyBreaker();
                            health = new SkyBreaker();
                            break;
                        case UnitName.HeavenBomber:
                            attack = new HeavenBomber();
                            health = new HeavenBomber();
                            break;
                        case UnitName.Venom:
                            attack = new Venom();
                            health = new Venom();
                            break;
                        case UnitName.DwarfSniper:
                            attack = new DwarfSniper();
                            health = new DwarfSniper();
                            break;
                        default:
                            Console.WriteLine("Invalid units.");
                            break;
                    }
                    if (attack != null && health != null)
                    {
                        int numberUnits = unitName12.Count;
                        //units.Count > 1

                        Console.WriteLine($"Attack: {attack.GetAttack()}");
                        Console.WriteLine($"Health: {health.GetHealth()}");

                        Console.WriteLine($"unitName12.Count: {numberUnits.ToString()}");

                        gameManager.StartBattle(unitName12, attack, health);
                    }
                }
            }

            //Action<IUnit> onBattleComplete = (unit) =>
            //{
            //Console.WriteLine("Battle complete!");
            //Console.WriteLine($"Winner is Race {unit.Race}, Class {unit.Class}, Quality {unit.Quality}");
            //};

            //gameManager.Battle2(unit1, unit2, onBattleComplete);



        }
    }
}