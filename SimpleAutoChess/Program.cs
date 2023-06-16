using System;
using System.Numerics;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Program
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();
            Display display = new Display();

            //Invite Players
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();
            IPlayer player1 = new Player();
            player1.SetName(playerName);

            IPlayer player2 = new Player();
            player2.SetName("Player 2");

            gameManager.InvitePlayer(player1);
            gameManager.InvitePlayer(player2);

            //Add Unit player1
            Console.WriteLine("Available Race: Beast, Human, Goblin, Dragon, Dwarf");
            Console.WriteLine("Enter Race for Units:");
            string raceInput1 = Console.ReadLine();
            Enum.TryParse(raceInput1, out Race race1);
            IUnit unit1 = new Unit();
            unit1.SetRace(race1);

            //Add Unit player2
            IUnit unit2 = new Unit();
            Race race2 = (Race)new Random().Next(Enum.GetValues(typeof(Race)).Length);
            unit2.SetRace(race2);

            //Players with Units
            gameManager.AddUnitForPlayer(player1, unit1);
            gameManager.AddUnitForPlayer(player2, unit2);

            //Add location of Units on Board belum exeption handling
            Console.WriteLine($"Enter location of unit on the board: ");
            Console.Write("Enter row: ");
            string inputRow = Console.ReadLine();
            int numberRow = int.Parse(inputRow);
            Console.Write("Enter column: ");
            string inputCol = Console.ReadLine();
            int numberCol = int.Parse(inputCol);

            IPosition square1 = new Position();
            square1.row = numberRow;
            square1.col = numberCol;

            IPosition square2 = new Position();
            square2.row = 2;
            square2.col = 3;

            gameManager.AddUnitOnBoard(player1, unit1, square1);
            gameManager.AddUnitOnBoard(player2, unit2, square2);

            display.ShowInfoPlyers(player1);
            display.ShowInfoUnits(unit1);
            display.ShowInfoPlyers(player2);
            display.ShowInfoUnits(unit2);


            display.ShowBoard(square1, unit1);
            display.ShowBoard(square2, unit2);

            Action<IUnit> onBattleComplete = (unit) =>
            {
                Console.WriteLine("Battle complete!");
                Console.WriteLine($"Winner is Race {unit.Race}, Class {unit.Class}, Quality {unit.Quality}");
            };

            gameManager.Battle2(unit1, unit2, onBattleComplete);

        }

    }
}