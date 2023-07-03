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
            Dictionary<string, List<Unit>> playerUnits = InputPlayers(numPlayers, gameManager);
            InputUnits(numbUnits, gameManager);
            Display.PlayerUnitInfo(gameManager.GetPlayerUnits(), gameManager);
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
        public static Dictionary<string, List<Unit>> InputPlayers(int numPlayers, GameManager gameManager)
        {
            Dictionary<string, List<Unit>> playerUnits = new Dictionary<string, List<Unit>>();

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
            return playerUnits;
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

                    gameManager.GetUnitFactory(selectedUnitName);

                    Unit unit = new Unit();

                    bool containsUnit = unitNames.Any(unit => unitInput.Contains(unit.ToString()));
                    if (!containsUnit)
                    {
                        Display.InvalidUnitInfo();
                        i--; // repeat the iteration for incorrect unit index
                        continue;
                    }
                    else
                    {
                        gameManager.AddUnitForPlayer(playerName, unit);
                    }
                }
            }
        }
    }
}