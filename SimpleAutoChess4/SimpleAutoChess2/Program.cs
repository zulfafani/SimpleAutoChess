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
            int numbUnits = InputNumberOfUnits();
            int boardSize = InputBoardSize();

            Dictionary<string, List<UnitName>> players = InputPlayers(numPlayers, gameManager);
            
            /*string playerName = players.Keys.First();
            Player player = new Player(playerName);
            gameManager.GenerateInitialLevel(player);
            int numUnits = gameManager.GetValueLevel(player as ILevel);*/

            InputUnits(numbUnits, gameManager);
            
            Display.PlayerUnitInfo(gameManager.GetPlayerUnits(), gameManager);
            InputLocationUnits(boardSize, gameManager);
            //StartBattleForUnitsOnBoard(gameManager);

            gameManager.Play(numPlayers);

            /*gameManager.StartGame();

            Console.WriteLine();
            Console.WriteLine("Battle is over!");

            Console.WriteLine("Winning Order:");
            for (int i = 0; i < gameManager.WinningOrder.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gameManager.WinningOrder[i].Name}");
            }

            Console.ReadLine();*/


            //foreach (var unitNameOnBoard in gameManager.GetAllUnitOnBoard())
            //{
            //List<UnitName> unitName12 = unitNameOnBoard.Value;
            //foreach (UnitName unit12 in unitName12)
            //{
            //Console.WriteLine($"\nUnitName: {unit12}");

            //IAttack attack = null;
            //IHealth health = null;

            //switch (unit12)
            //{
            //case UnitName.TuskChampion:
            //attack = new TuskChampion();
            //health = new TuskChampion();
            //break;
            //case UnitName.TheSource:
            //attack = new TheSource();
            //health = new TheSource();
            //break;
            //case UnitName.FlameWizard:
            //attack = new FlameWizard();
            //health = new FlameWizard();
            //break;
            //case UnitName.SoulBreaker:
            //attack = new SoulBreaker();
            //health = new SoulBreaker();
            //break;
            //case UnitName.SkyBreaker:
            //attack = new SkyBreaker();
            //health = new SkyBreaker();
            //break;
            //case UnitName.HeavenBomber:
            //attack = new HeavenBomber();
            //health = new HeavenBomber();
            //break;
            //case UnitName.Venom:
            //attack = new Venom();
            //health = new Venom();
            //break;
            //case UnitName.DwarfSniper:
            //attack = new DwarfSniper();
            //health = new DwarfSniper();
            //break;
            //default:
            //Console.WriteLine("Invalid units.");
            //break;
            //}
            //if (attack != null && health != null)
            //{
            //int numberUnits = unitName12.Count;
            //units.Count > 1

            //Console.WriteLine($"Attack: {attack.GetAttack()}");
            //Console.WriteLine($"Health: {health.GetHealth()}");

            //Console.WriteLine($"unitName12.Count: {numberUnits.ToString()}");

            //gameManager.AddUnitToBattle(player, unitName12);

            //gameManager.StartBattle(unitName12, attack, health);
            //}
            //}
            //}

            //Action<IUnit> onBattleComplete = (unit) =>
            //{
            //Console.WriteLine("Battle complete!");
            //Console.WriteLine($"Winner is Race {unit.Race}, Class {unit.Class}, Quality {unit.Quality}");
            //};

            //gameManager.Battle2(unit1, unit2, onBattleComplete);


        }

        public static int InputNumberOfPlayers()
        {
            int numPlayers;
            bool validInput = false;

            do
            {
                Console.Write("Enter the number of players (2, 4, 6, 8): ");
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

        public static Dictionary<string, List<UnitName>> InputPlayers(int numPlayers, GameManager gameManager)
        {
            Dictionary<string, List<UnitName>> players = new Dictionary<string, List<UnitName>>();

            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Enter the name of player {i + 1}: ");
                string? playerName = Console.ReadLine();

                IPlayer player = new Player();
                player.SetName(playerName);

                if (gameManager.isPlayerExists(player))
                {
                    Display.InvalidPlayerNameInfo();
                    i--; // repeat the iteration for the same player index
                    continue;
                }
                gameManager.AddPlayer(player);
            }
            return players;
        }

        public static int InputNumberOfUnits()
        {
            int numUnits;
            bool validUnitInput = false;

            do
            {
                Console.Write("Enter the number of units: ");
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
            while (!validUnitInput);
            return numUnits;
        }

        public static void InputUnits(int numUnits, GameManager gameManager)
        {
            foreach (var player in gameManager.GetPlayerUnits())
            {
                string playerName = player.Key;

                Console.WriteLine($"\nPlayer: {playerName}");
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
                string currentPlayer = player.Key;
                List<UnitName> units = player.Value;

                foreach (UnitName unit in units)
                {
                    Console.Write($"Enter the location of {unit} for {currentPlayer} (row column): ");
                    string? locationInput = Console.ReadLine();
                    string[] locationValues = locationInput.Split(' ');

                    if (locationValues.Length == 2 && int.TryParse(locationValues[0], out int row) && int.TryParse(locationValues[1], out int column))
                    {
                        if (gameManager.IsValidPosition(row, column, boardSize))
                        {
                            IPosition position = new Position();
                            position.row = row;
                            position.col = column;

                            board[row, column] = $"[{unit}]";
                            Console.WriteLine($"Unit {unit} added at location: Row {row}, Column {column}");
                            gameManager.AddUnitOnBoard(currentPlayer, unit, position);
                        }
                        else
                        {
                            Display.InvalidLocationInfo();
                            // Method for random unit placement can be called here
                        }
                    }
                    else
                    {
                        Display.InvalidLocationInfo();
                        // Method for random unit placement can be called here
                    }
                }
            }
            Display.PrintBoard(boardSize, board);
        }
        public static void StartBattleForUnitsOnBoard(GameManager gameManager)
        {
            bool allUnitsDestroyed = false;

            

            while (!allUnitsDestroyed)
            {
                allUnitsDestroyed = true;

                foreach (var unitNameOnBoard in gameManager.GetAllUnitOnBoard())
                {
                    List<UnitName> unitNames = unitNameOnBoard.Value;

                    foreach (UnitName unitName in unitNames)
                    {
                        Console.WriteLine($"\nUnitName: {unitName}");

                        IAttack attack = CreateAttackInstance(unitName);
                        IHealth health = CreateHealthInstance(unitName);


                        if (attack != null && health != null)
                        {
                            int numberUnits = unitNames.Count;
                            gameManager.StartBattle(unitNames, attack, health);

                            if (health != null)
                            {
                            allUnitsDestroyed = false;
                            }
                        }
                    }
                }
            }

            // Determine the winner based on player name
            string player1Name = "Player1";
            string player2Name = "Player2";

            int player1RemainingUnits = gameManager.GetRemainingUnits(player1Name);
            int player2RemainingUnits = gameManager.GetRemainingUnits(player2Name);

            if (player1RemainingUnits > player2RemainingUnits)
            {
                Console.WriteLine($"Player {player1Name} is the winner with {player1RemainingUnits} units remaining.");
            }
            else if (player2RemainingUnits > player1RemainingUnits)
            {
                Console.WriteLine($"Player {player2Name} is the winner with {player2RemainingUnits} units remaining.");
            }
            else
            {
                Console.WriteLine("The battle ended in a draw. No winner!");
            }
        }
    

        public static IAttack CreateAttackInstance(UnitName unitName)
        {
            return unitName switch
            {
                UnitName.TuskChampion => new TuskChampion(),
                UnitName.TheSource => new TheSource(),
                UnitName.FlameWizard => new FlameWizard(),
                UnitName.SoulBreaker => new SoulBreaker(),
                UnitName.SkyBreaker => new SkyBreaker(),
                UnitName.HeavenBomber => new HeavenBomber(),
                UnitName.Venom => new Venom(),
                UnitName.DwarfSniper => new DwarfSniper(),
                _ => null
            };
        }

        public static IHealth CreateHealthInstance(UnitName unitName)
        {
            return unitName switch
            {
                UnitName.TuskChampion => new TuskChampion(),
                UnitName.TheSource => new TheSource(),
                UnitName.FlameWizard => new FlameWizard(),
                UnitName.SoulBreaker => new SoulBreaker(),
                UnitName.SkyBreaker => new SkyBreaker(),
                UnitName.HeavenBomber => new HeavenBomber(),
                UnitName.Venom => new Venom(),
                UnitName.DwarfSniper => new DwarfSniper(),
                _ => null
            };
        }

        static IUnit CreateUnit(GameManager gameManager)
        {
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
                }
            }
            return new Unit();

        }
    }
}