using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using System.Threading.Tasks;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<Player, List<IUnit>> _playerUnitsName;
        private Dictionary<IPosition, List<IUnit>> _board;
		private static readonly ILog _logger = LogManager.GetLogger(typeof(GameManager));

		public GameManager()
        {
            _playerUnitsName = new Dictionary<Player, List<IUnit>>();
            _board = new Dictionary<IPosition, List<IUnit>>();
        }
		
        public Dictionary<Player, List<IUnit>> GetPlayerUnits()
        {
            return _playerUnitsName;
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

        public bool AddPlayer(Player player)
        {
            if (_playerUnitsName != null)
            {
                if (!_playerUnitsName.ContainsKey(player))
                {
                    List<IUnit> unitName = new List<IUnit>();
                    _playerUnitsName.Add(player, unitName);
                    return true;
                }
            }
            return false;
        }

        public bool IsPlayerNameExists(string? playerName)
        {
            foreach (Player player in _playerUnitsName.Keys)
            {
                if (player.Name == playerName)
                {
                    return true;
                }
            }
            return false;
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

        public int NumberOfUnits()
        {
            int numUnits = 0;
            foreach (Player player in GetPlayerUnits().Keys)
            {
                numUnits = player.Level;
            }
            return numUnits;
        }

        public IUnitFactory GetUnitFactory(UnitName unitName)
        {
            switch (unitName)
            {
                case UnitName.TuskChampion:
                    return new TuskChampionFactory();
                case UnitName.TheSource:
                    return new TheSourceFactory();
                case UnitName.FlameWizard:
                    return new FlameWizardFactory();
                case UnitName.SoulBreaker:
                    return new SoulBreakerFactory();
                case UnitName.SkyBreaker:
                    return new SkyBreakerFactory();
                case UnitName.HeavenBomber:
                    return new HeavenBomberFactory();
                case UnitName.Venom:
                    return new VenomFactory();
                case UnitName.DwarfSniper:
                    return new DwarfSniperFactory();
                default:
                    throw new ArgumentException($"Invalid unit name: {unitName}");
            }
        }

        public bool SpawnUnit(Player player, IUnitFactory factory)
        {
            if (!_playerUnitsName.ContainsKey(player))
            {
                _playerUnitsName[player] = new List<IUnit>();
                return false;
            }

            IUnit unit = factory.CreateUnit();
            AddUnitForPlayer(player, unit);
            ((IGold)player).ModifyGoldWithPrice(unit.GetPrice());
            return true;
        }

        public bool? AddUnitForPlayer(Player playerName, IUnit unitName)
        {
            if (_playerUnitsName.ContainsKey(playerName))
            {
                _playerUnitsName[playerName].Add(unitName);
                return true;
            }
            return false;
        }

        public bool IsValidPosition(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }

        public bool IsEmptyPosition(int row, int column, string[,] board)
        {
            return board[row, column] == "[     ]";
        }

        public void AddUnitOnBoard(Player playerName, IUnit unitName, IPosition position)
        {
            if (!_board.ContainsKey(position))
            {
                _board[position] = new List<IUnit>();
            }
            _board[position].Add(unitName);
        }

		public async Task Battle()
		{
			bool isBattleFinished = false;
			Player winner = null;

			while (!isBattleFinished)
			{
				foreach (var playerUnitsPair in _playerUnitsName)
				{
					Player attacker = playerUnitsPair.Key;
					List<IUnit> attackerUnits = playerUnitsPair.Value;

					_logger.Info($"Player: {attacker.Name}");

					foreach (var attackerUnit in attackerUnits)
					{
						_logger.Info($"HP {attackerUnit.GetType().Name}:  {attackerUnit.GetHealth()}, is alive: {attackerUnit.IsAlive()}");
						if (attackerUnit.IsAlive() == false)
						{
							winner = DetermineWinner();
							_logger.Info("The winner is: " + winner.Name);
							if (winner != null)
							{
								isBattleFinished = true;
							}
						}
						// Serangan
						foreach (var targetPlayerUnitsPair in _playerUnitsName)
						{
							Player targetPlayer = targetPlayerUnitsPair.Key;
							List<IUnit> targetUnits = targetPlayerUnitsPair.Value;

							if (attacker != targetPlayer)
							{
								foreach (var targetUnit in targetUnits)
								{
									_logger.Info($"HP target {targetUnit.GetType().Name}: {targetUnit.GetHealth()}, is alive: {targetUnit.IsAlive()}");
									// Damage
									if (targetUnit.IsAlive())
									{
										targetUnit.TakeDamage(attackerUnit.GetAttack());
										_logger.Info($"{attackerUnit.GetType().Name} attack {targetUnit.GetType().Name}, take damage {attackerUnit.GetAttack()}, new HP {targetUnit.GetHealth()}\n");
									}
								}
							}
						}
						await Task.Delay(500);
					}
				}
				isBattleFinished = CheckBattleFinished();
			}
			winner = DetermineWinner();
			_logger.Info("The winner is: " + winner.Name);
		}

        private bool CheckBattleFinished()
        {
            foreach (var playerUnitsPair in _playerUnitsName)
            {
                List<IUnit> units = playerUnitsPair.Value;

                bool allUnitsDead = true;

                foreach (var unit in units)
                {
                    if (unit.IsAlive())
                    {
                        allUnitsDead = false;
                        break;
                    }
                }
                if (allUnitsDead)
                    return true;
            }
            return false;
        }

        private Player DetermineWinner()
        {
            Dictionary<Player, int> playerUnitCounts = new Dictionary<Player, int>();

            foreach (var playerUnitsPair in _playerUnitsName)
            {
                Player player = playerUnitsPair.Key;
                List<IUnit> units = playerUnitsPair.Value;

                int aliveUnitCount = 0;
                foreach (var unit in units)
                {
                    if (unit.IsAlive())
                        aliveUnitCount++;
                }

                playerUnitCounts[player] = aliveUnitCount;
            }

            Player winner = null;
            int maxAliveUnitCount = 0;

            foreach (var playerUnitCountPair in playerUnitCounts)
            {
                Player player = playerUnitCountPair.Key;
                int aliveUnitCount = playerUnitCountPair.Value;

                if (aliveUnitCount > maxAliveUnitCount)
                {
                    maxAliveUnitCount = aliveUnitCount;
                    winner = player;
                }
            }
            return winner;
        }
    }
}