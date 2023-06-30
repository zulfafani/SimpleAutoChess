using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private IUnitFactory _unitFactory;
        private List<List<IAttack>> players;
        //private List<IPlayer> _players = new List<IPlayer>();
        private Dictionary<string, List<UnitName>> _unitsName;
        private Dictionary<IPosition, List<UnitName>> _board;
        private Dictionary<IPlayer, List<IUnit>> _playersBattle;
        private Action<IPlayer> _onBattleComplete;
        private List<IPlayer> _winningOrder = new List<IPlayer>();
        public List<IPlayer> WinningOrder => _winningOrder;


        public GameManager()
        {
            players = new List<List<IAttack>>();
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

        public string GenerateRandomId(Player player)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] idChars = new char[6];

            for (int i = 0; i < idChars.Length; i++)
            {
                idChars[i] = chars[random.Next(chars.Length)];
            }
            //_id = idChars.ToString(); will print out "System.Char[]" because calling ToString on a T array in .NET will always return "T[]".
            ((IPlayer)player).SetId(new string(idChars));
            return new string(idChars);
        }


        /*public ILevel GetPlayerLevel(string playerName)
        {
            IPlayer player = _unitsName.FirstOrDefault(player.GetName());
            if (player != null)
            {
                return (ILevel)player;
            }
            return null;
        }*/
        public void GenerateInitialLevel(Player player)
        {
            ((ILevel)player).ModifyLevel(1);
        }
        public int GetValueLevel(ILevel level)
        {
            int modifiedLevel = level.GetLevel();
            return modifiedLevel;
        }

        public void GenerateInitialPoint(Player player)
        {
            ((IPoint)player).ModifyPoint(100);
        }
        public int GetValuePoint(IPoint point)
        {
            int modifiedPoint = point.GetPoint();
            return modifiedPoint;
        }

        public void GenerateInitialGold(Player player)
        {
            ((IGold)player).ModifyGold(1);
        }
        public int GetValueGold(IGold gold)
        {
            int modifiedGold = gold.GetGold();
            return modifiedGold;
        }




        public void AddPlayer(IPlayer player)
        {
            //_players.Add(player);
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
            Console.WriteLine("Let the battle begin!");
            Console.WriteLine();

            _onBattleComplete = AddToWinningOrder;
            Battle2();
            //Battle3();
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


        private void Battle2()
        {
            var players = _unitsName.Keys.ToList();
            int numberOfBattles = players.Count - 1;

            for (int battle = 0; battle < numberOfBattles; battle++)
            {
                int attackerIndex = battle;
                int targetIndex = (battle + 1) % players.Count;

                string attackingPlayerName = players[attackerIndex];
                string targetPlayerName = players[targetIndex];

                Console.WriteLine($"--- Battle {battle + 1} ---");
                Console.WriteLine($"{attackingPlayerName} vs. {targetPlayerName}");

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

                    Console.WriteLine($"{attackingPlayerName}'s {unitName} attacks {targetPlayerName}'s {targetUnitName} for {damage} damage.");

                    while (target.Health > 0)
                    {
                        target.TakeDamage(damage);

                        if (target.Health <= 0)
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

                Console.WriteLine();
            }

            _onBattleComplete?.Invoke(null);
        }

        private void Battle3()
        {
            var players = _unitsName.Keys.ToList();
            int currentPlayerIndex = 0;

            while (players.Count > 1)
            {
                var defeatedUnits = new List<(string playerName, UnitName unitName)>();
                int targetPlayerIndex = (currentPlayerIndex + 1) % players.Count;

                string attackingPlayerName = players[currentPlayerIndex];
                string targetPlayerName = players[targetPlayerIndex];

                foreach (UnitName unitName in _unitsName[attackingPlayerName])
                {
                    foreach (UnitName targetUnitName in _unitsName[targetPlayerName])
                    {
                        IPlayer attackingPlayer = new Player(attackingPlayerName);
                        IPlayer targetPlayer = new Player(targetPlayerName);

                        Unit attacker = CreateUnit(attackingPlayer, unitName);
                        Unit target = CreateUnit(targetPlayer, targetUnitName);

                        while (target.Health > 0)
                        {
                            int damage = attacker.Attack;
                            target.TakeDamage(damage);

                            Console.WriteLine($"{attackingPlayerName}'s {unitName} attacks {targetPlayerName}'s {targetUnitName} for {damage} damage.");

                            if (target.Health <= 0)
                            {
                                Console.WriteLine($"{targetPlayerName}'s {targetUnitName} has been defeated.");
                                defeatedUnits.Add((targetPlayerName, targetUnitName));
                                _onBattleComplete?.Invoke(targetPlayer);
                            }
                            else
                            {
                                Console.WriteLine($"{targetPlayerName}'s {targetUnitName} health: {target.Health}");
                            }
                        }
                    }
                }

                // Remove defeated units
                foreach (var defeatedUnit in defeatedUnits)
                {
                    _unitsName[defeatedUnit.playerName].Remove(defeatedUnit.unitName);
                }

                players.RemoveAll(player => _unitsName[player].Count == 0);

                // Update the current player index
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
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


        public void Play(int numPlayers)
        {
            Console.WriteLine("\nGame started!");

            while (true)
            {
                CreateArmy(numPlayers);
                PerformRound(numPlayers);

                if (CheckEndGame())
                {
                    int winner = FindWinner();
                    Console.WriteLine($"\nPlayer {winner} has emerged victorious!");
                    break;
                }

                Console.WriteLine("\nPress Enter to continue to the next round...");
                Console.ReadLine();
            }
        }
        private void CreateArmy(int player)
        {
            List<IAttack> playerUnits = new List<IAttack>();

            foreach (var unitNameOnBoard in GetAllUnitOnBoard())
            {
                List<UnitName> unitName = unitNameOnBoard.Value;
                foreach (UnitName unit in unitName)
                {
                    Console.WriteLine($"\nUnitName: {unit}");

                    IUnitFactory unitFactory = GetUnitFactory(unit);

                    IAttack attack = unitFactory.CreateAttack();
                    IHealth health = unitFactory.CreateHealth();
                    IPrice price = unitFactory.CreatePrice();

                    playerUnits.Add(attack);
                }

                players.Add(playerUnits);
            }
        }

        private void PerformRound(int numPlayers)
        {
            Console.WriteLine("\n=== Next Round ===");

            for (int i = 0; i < numPlayers; i++)
            {
                List<IAttack> currentUnits = players[i];
                List<IAttack> opposingUnits = GetOpposingUnits(i);

                for (int j = 0; j < currentUnits.Count; j++)
                {
                    IAttack attacker = currentUnits[j];
                    IAttack defender = opposingUnits[j % opposingUnits.Count];

                    Console.Write($"\nPlayer {i + 1} - Attacker (Unit {j + 1}) attacks Player {GetOpponentPlayerIndex(i) + 1} - Defender (Unit {(j % opposingUnits.Count) + 1}), deals {attacker.Attack} damage");

                    defender.ModifyHealth = 500;
                    defender.ModifyHealth -= attacker.Attack;

                    if (defender.ModifyHealth <= 0)
                    {
                        Console.WriteLine($"\nPlayer {GetOpponentPlayerIndex(i) + 1} - Defender (Unit {(j % opposingUnits.Count) + 1}) has been defeated!");
                        opposingUnits.RemoveAt(j % opposingUnits.Count);
                    }
                }
            }

            Console.WriteLine();
            DisplayUnitHealth();
        }

        private List<IAttack> GetOpposingUnits(int currentPlayerIndex)
        {
            int opponentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            return players[opponentPlayerIndex];
        }

        private int GetOpponentPlayerIndex(int currentPlayerIndex)
        {
            return (currentPlayerIndex + 1) % players.Count;
        }

        private bool CheckEndGame()
        {
            int remainingPlayers = 0;

            foreach (var playerUnits in players)
            {
                if (playerUnits.Count > 0)
                    remainingPlayers++;
            }

            return remainingPlayers <= 1;
        }

        private int FindWinner()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Count > 0)
                    return i + 1;
            }

            return -1; // No winner found
        }

        private void DisplayUnits(List<IAttack> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                Console.WriteLine($"Unit {i + 1} - Attack: {units[i].Attack}");
            }
        }

        private void DisplayUnitHealth()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"\nPlayer {i + 1}'s units:");

                for (int j = 0; j < players[i].Count; j++)
                {
                    Console.WriteLine($"Unit {j + 1} - Health: {GetUnitHealth(i, j)}");
                }
            }
        }

        private int GetUnitHealth(int playerIndex, int unitIndex)
        {
            return ((IHealth)players[playerIndex][unitIndex]).Health;
        }
    }
}