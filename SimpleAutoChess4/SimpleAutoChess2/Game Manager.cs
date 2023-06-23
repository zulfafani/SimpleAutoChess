using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using SimpleAutoChess;

namespace SimpleAutoChess
{
	public class GameManager
	{
		private Dictionary<IPosition, List<UnitName>> _board;
		private Dictionary<string, List<UnitName>> _unitsName;
		private Dictionary<Tuple<int, int>, List<UnitName>> _unitPositions;
        //private Action<List<UnitName>> _onBattleComplete;

        public GameManager()
		{
			_board = new Dictionary<IPosition, List<UnitName>>();
			_unitsName = new Dictionary<string, List<UnitName>>();
            //_onBattleComplete = new Action<List<UnitName>>(_onBattleComplete);
        }

		public Dictionary<string, List<UnitName>> GetPlayerUnits()
		{
			return _unitsName;
		}

		public List<UnitName> GetAllUnitNames()
		{
			List<UnitName> unitNames = new List<UnitName>();
			foreach (UnitName unitName in Enum.GetValues(typeof(UnitName)))
			{
				unitNames.Add(unitName);
			}
			return unitNames;
		}

		public Dictionary<IPosition, List<UnitName>> GetAllUnitOnBoard()
		{
			return _board;
		}

		public string GenerateRandomId()
		{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			char[] idChars = new char[6];

			for (int i = 0; i < idChars.Length; i++)
			{
				idChars[i] = chars[random.Next(chars.Length)];
			}
			//_id = idChars.ToString(); will print out "System.Char[]" because calling ToString on a T array in .NET will always return "T[]".
			return new string(idChars);
		}

		public void AddPlayer(IPlayer player)
		{
			_unitsName.Add(player.GetName(), new List<UnitName>());
		}
		
		public bool PlayerExists(IPlayer player)
		{
			return _unitsName.ContainsKey(player.GetName());
		}

		public void AddUnitForPlayer(string playerName, UnitName unitName)
		{
			if (_unitsName.ContainsKey(playerName))
			{
				_unitsName[playerName].Add(unitName);
			}
		}

        public bool IsValidPosition(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }

        public bool IsEmptyPosition(int row, int column, string[,] board)
        {
            return board[row, column] == null;
        }

        public void AddUnitOnBoard(string playerName, UnitName unitName, IPosition position)
		{
			if (!_board.ContainsKey(position))
			{
				_board[position] = new List<UnitName>();

            }
            _board[position].Add(unitName);

        }
        public void RemoveUnit(string playerName, UnitName unitName, IPosition position)
		{
			if (_board.ContainsKey(position))
			{
                _board[position].Remove(unitName);
                //_unitsName[playerName].Remove(unitName);
            }
		}

		private bool IsBattleOngoing(List<UnitName> units)
		{
			int numberUnits = units.Count;
			return units.Count > 1;
		}

        public void StartBattle(List<UnitName> units, IAttack attack, IHealth health)
        {
            Console.WriteLine("Battle Start!");
            Console.WriteLine();

            //Display initial unit health
            //for (int i = 0; i < units.Count; i++)
            //{
            //Console.WriteLine($"Unit {i + 1} Health: {units[i].Health}");
            //}

            //Console.WriteLine();

            // Battle loop
            //while (IsBattleOngoing(units))
            while (IsBattleOngoing(units))
            {
                int numberUnits = units.Count;

                Console.WriteLine("UnitCount!");

                // Perform attacks for each unit
                for (int i = 0; i < units.Count; i++)
                {
                    UnitName attacker = units[i];
                    UnitName target = GetRandomTarget(units, attacker);

                    int damage = attack.GetAttack();
                    health.ModifyHealth(damage);

                    Console.WriteLine($"Unit {i + 1} attacks Unit {units.IndexOf(target) + 1} for {damage} damage.");
                }

                // Remove units with health less than or equal to 0 from the battle
                units.RemoveAll(unit => health.GetHealth() <= 0);

                // Display unit health after each round
                for (int i = 0; i < units.Count; i++)
                {
                    Console.WriteLine($"Unit {i + 1} Health: {units[i]}");
                }

                Console.WriteLine();
            }

            // Sort remaining units based on health
            //units.Sort((u1, u2) => u1.Health.CompareTo(u2.Health));

            // Invoke onBattleComplete with the remaining units
            //onBattleComplete?.Invoke(units);
        }

        public UnitName GetRandomTarget(List<UnitName> units, UnitName attacker)
        {
            Random random = new Random();
            List<UnitName> availableTargets = units.FindAll(u => u != attacker);
            int index = random.Next(availableTargets.Count);
            return availableTargets[index];
        }


        //public void Battle(IUnit unit1, IUnit unit2, Action<IUnit> onBattleComplete)
        //{
        //while (((IHealth)unit1).GetHealth() > 0 && (((IHealth)unit2).GetHealth() > 0))
        //{
        //Console.WriteLine("Battle");
        //((IHealth)unit2).ModifyHealth(-((IAttack)unit1).GetAttack());
        //((IHealth)unit1).ModifyHealth(-((IAttack)unit2).GetAttack());
        //}
        //onBattleComplete?.Invoke(((IHealth)unit1).GetHealth() <= 0 ? unit1 : unit2);
        //}

    }

}