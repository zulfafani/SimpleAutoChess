using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<string, List<UnitName>> _unitsName;
        private Dictionary<IPosition, List<UnitName>> _board;
        private Dictionary<IPlayer, List<IUnit>> _playersBattle;
        private Action<IPlayer> _onBattleComplete;
        private List<IPlayer> _winningOrder = new List<IPlayer>();
        public List<IPlayer> WinningOrder => _winningOrder;


        public GameManager()
        {
            _unitsName = new Dictionary<string, List<UnitName>>();
            _board = new Dictionary<IPosition, List<UnitName>>();
            _playersBattle = new Dictionary<IPlayer, List<IUnit>>();
            _winningOrder = new List<IPlayer>();
        }

        public Dictionary<string, List<UnitName>> GetPlayerUnits()
        {
            return _unitsName;
        }
        public Dictionary<IPosition, List<UnitName>> GetAllUnitOnBoard()
        {
            return _board;
        }
        public Dictionary<IPlayer, List<IUnit>> GetPlayerBattle()
        {
            if (_playersBattle != null)
            {
                return _playersBattle;
            }
            return null;
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
            _playersBattle.Add(player, new List<IUnit>());
        }

        public bool isPlayerExists(IPlayer player)
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
            //_unitsName[playerName].Add(unitName);
        }

        public void AddUnitToBattle(IPlayer player, IUnit unit)
        {
            _playersBattle[player].Add(unit);
        }


        public void RemoveUnit(string playerName, UnitName unitName, IPosition position)
        {
            if (_board.ContainsKey(position))
            {
                _board[position].Remove(unitName);
                //_unitsName[playerName].Remove(unitName);
            }
        }

        private bool IsBattleOngoing(IPlayer player)
        {
            int numberPlayer = player.GetName().Count();
            return numberPlayer > 1;
        }

        public void StartBattle(List<UnitName> unitNames, IAttack attack, IHealth health)
        {
            foreach (UnitName unitName in unitNames)
            {
                //attack.Attack();
                //health.TakeDamage(10); // Example damage value, you can customize it
            }
        }

        public int GetRemainingUnits(string playerName)
        {
            if (_unitsName.ContainsKey(playerName))
            {
                return _unitsName[playerName].Count;
            }

            return 0;
        }


        public void StartGame()
        {
            //Console.WriteLine("Enter the number of players:");
            //int playerCount = int.Parse(Console.ReadLine());

            //for (int i = 0; i < playerCount; i++)
            //{
                //Console.WriteLine($"Enter the name for player {i + 1}:");
                //string playerName = Console.ReadLine();

                //IPlayer player = new Player(playerName);
                //_unitsName.Add(playerName, new List<UnitName>());

                //Console.WriteLine($"Enter the number of units for player {playerName}:");
                //int unitCount = int.Parse(Console.ReadLine());

                //for (int j = 0; j < unitCount; j++)
                //{
                    //Console.WriteLine($"Enter the unit name for unit {j + 1} of player {playerName}:");
                    //string unitNameInput = Console.ReadLine();

                    //if (!Enum.TryParse(unitNameInput, true, out UnitName unitName))
                    //{
                        //Console.WriteLine($"Invalid unit name for unit {j + 1} of player {playerName}. Skipping...");
                        //continue;
                    //}

                    //_unitsName[playerName].Add(unitName);
                //}
            //}

            Console.WriteLine("Let the battle begin!");
            Console.WriteLine();

            _onBattleComplete = AddToWinningOrder;
            Battle();
        }

        private Unit CreateUnit(IPlayer owner, UnitName unitName)
        {
            int health = 0;
            int attack = 0;

            switch (unitName)
            {
                case UnitName.TuskChampion:
                    health = 100;
                    attack = 10;
                    break;
                case UnitName.TheSource:
                    health = 120;
                    attack = 15;
                    break;
                case UnitName.FlameWizard:
                    health = 80;
                    attack = 12;
                    break;
                case UnitName.SoulBreaker:
                    health = 150;
                    attack = 18;
                    break;
                case UnitName.SkyBreaker:
                    health = 90;
                    attack = 11;
                    break;
                case UnitName.HeavenBomber:
                    health = 110;
                    attack = 13;
                    break;
                case UnitName.Venom:
                    health = 70;
                    attack = 9;
                    break;
                case UnitName.DwarfSniper:
                    health = 130;
                    attack = 16;
                    break;
                default:
                    break;
            }

            return new Unit(owner, health, attack);
        }

        private void Battle()
        {
            var players = _unitsName.Keys.ToList();

            while (players.Count > 1)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    string attackingPlayerName = players[i];
                    string targetPlayerName = players[(i + 1) % players.Count];

                    foreach (UnitName unitName in _unitsName[attackingPlayerName])
                    {
                        IPlayer attackingPlayer = new Player(attackingPlayerName);
                        IPlayer targetPlayer = new Player(targetPlayerName);

                        Unit attacker = CreateUnit(attackingPlayer, unitName);
                        List<UnitName> targetUnits = _unitsName[targetPlayerName];

                        Random random = new Random();
                        UnitName targetUnitName = GetRandomTarget(targetUnits, random);

                        Unit target = CreateUnit(targetPlayer, targetUnitName);

                        int damage = attacker.Attack;
                        target.TakeDamage(damage);

                        Console.WriteLine($"{attackingPlayerName}'s {unitName} attacks {targetPlayerName}'s {targetUnitName} for {damage} damage.");

                        if (target.Health == 0)
                        {
                            Console.WriteLine($"{targetPlayerName}'s {targetUnitName} has been defeated.");
                            targetUnits.Remove(targetUnitName);
                            _onBattleComplete?.Invoke(targetPlayer);
                        }
                        else
                        {
                            Console.WriteLine($"{targetPlayerName}'s {targetUnitName} health: {target.Health}");
                        }
                    }
                }

                players.RemoveAll(player => _unitsName[player].Count == 0);
            }

            _onBattleComplete?.Invoke(null);
        }

        private UnitName GetRandomTarget(List<UnitName> units, Random random)
        {
            int index = random.Next(units.Count);
            return units[index];
        }

        private void AddToWinningOrder(IPlayer player)
        {
            if (player != null && !_winningOrder.Contains(player))
                _winningOrder.Add(player);

            // Check if all players have been added to the winning order
            if (_winningOrder.Count == _playersBattle.Count)
                _onBattleComplete?.Invoke(null);
        }
    }
}