using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
	public class Display
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
			Console.WriteLine("Race of unit not exists. Please enter the correct Race.");
		}
		public static void PlayerUnitInfo(Dictionary<string, List<IUnit>> playerUnits, GameManager gameManager)
		{
			Console.WriteLine("\n--Player List--");
			int playerIndex = 1;
			foreach (var entry in playerUnits)
			{
				string playerName = entry.Key;
				List<IUnit> units = entry.Value;

				Console.WriteLine($"Player {playerIndex}: {playerName}");
				Console.WriteLine($"Player ID: {gameManager.GenerateRandomId()}");
				//Console.WriteLine($"Player Gold: ");

				Console.WriteLine("Units:");
				foreach (IUnit unit in units)
				{
                    //Console.WriteLine($"Unit name: {unit.GetUnitName()}, ");
                    Console.WriteLine($"Unit name: {unit.GetRace()}, ");
					//Console.WriteLine($"Unit name: {unit.GetUnitName()}, ");
					//Console.Write($"Class: {unit.GetClass()}, ");
					//Console.WriteLine($"Quality: {unit.GetQuality()}");
				}
				playerIndex++;
			}
		}
        public static void PlayerUnitInfo2(Dictionary<string, List<UnitName>> playerUnits2, GameManager gameManager)
        {
            Console.WriteLine("\n--Player List--");
            int playerIndex = 1;
            foreach (var entry in playerUnits2)
            {
                string playerName = entry.Key;
                List<UnitName> units = entry.Value;

                Console.WriteLine($"Player {playerIndex}: {playerName}");
                Console.WriteLine($"Player ID: {gameManager.GenerateRandomId()}");
                //Console.WriteLine($"Player Gold: ");

                Console.WriteLine("Units:");
                foreach (UnitName unit in units)
                {
                    Console.WriteLine($"Unit name: {unit}, ");
                    //Console.WriteLine($"Unit name: {unit.GetRace()}, ");
                    //Console.WriteLine($"Unit name: {unit.GetUnitName()}, ");
                    //Console.Write($"Class: {unit.GetClass()}, ");
                    //Console.WriteLine($"Quality: {unit.GetQuality()}");
                }
                playerIndex++;
            }
        }
    }
}