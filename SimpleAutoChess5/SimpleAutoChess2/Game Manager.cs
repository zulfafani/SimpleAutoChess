using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<Player, List<IUnit>> _playerUnitsName;
        private Dictionary<IPosition, List<IUnit>> _board;

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

        public bool? AddPlayer(Player player)
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

        public bool? SpawnUnit(Player player, IUnitFactory factory)
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



        public void Battle(int numPlayer)
        {
            var players = _playerUnitsName.Keys.ToList();

            int numPlayers = numPlayer;

            Console.WriteLine("---------- BATTLE START ----------");

            bool continueBattle = true;
            int round = 1;

            while (continueBattle)
            {
                Console.WriteLine("Round " + round);
                Console.WriteLine();

                for (int i = 0; i < numPlayers; i++)
                {
                    Player attackingPlayer = players[i];
                    Player defendingPlayer = players[(i + 1) % numPlayers];

                    Console.WriteLine(attackingPlayer.Name + " vs " + defendingPlayer.Name);
                    Console.WriteLine();

                    List<IUnit> attackingPlayerUnits = _playerUnitsName[attackingPlayer];
                    List<IUnit> defendingPlayerUnits = _playerUnitsName[defendingPlayer];

                    while (attackingPlayerUnits.Count > 0 && defendingPlayerUnits.Count > 0)
                    {
                        // Attacker's turn
                        IUnit attackingUnit = attackingPlayerUnits[0];
                        IUnit defendingUnit = defendingPlayerUnits[0];

                        Console.WriteLine(attackingUnit.GetType().Name + " from " + attackingPlayer.Name + " attacks " + defendingUnit.GetType().Name + " from " + defendingPlayer.Name);
                        attackingUnit.AttackTarget(defendingUnit);

                        if (!defendingUnit.IsAlive())
                        {
                            Console.WriteLine(defendingUnit.GetType().Name + " from " + defendingPlayer.Name + " is defeated!");
                            defendingPlayerUnits.RemoveAt(0);
                        }

                        Console.WriteLine();

                        // Swap players
                        Player temp = attackingPlayer;
                        attackingPlayer = defendingPlayer;
                        defendingPlayer = temp;

                        List<IUnit> tempUnits = attackingPlayerUnits;
                        attackingPlayerUnits = defendingPlayerUnits;
                        defendingPlayerUnits = tempUnits;
                    }

                    Console.WriteLine("---------- BATTLE END ----------");
                    Console.WriteLine();
                }

                // Check if any player has lost all units
                continueBattle = false;

                foreach (var playerUnits in _playerUnitsName)
                {
                    if (playerUnits.Value.Count == 0)
                    {
                        continueBattle = true;
                        break;
                    }
                }

                round++;
            }

            Console.WriteLine("---------- BATTLE OVER ----------");
            Console.WriteLine();

            // Menampilkan pemenang atau hasil seri
            List<Player> winners = new List<Player>();

            foreach (var playerUnits in _playerUnitsName)
            {
                if (playerUnits.Value.Count > 0)
                {
                    winners.Add(playerUnits.Key);
                }
            }

            if (winners.Count == 0)
            {
                Console.WriteLine("The battle ends in a draw!");
            }
            else
            {
                Console.WriteLine("The winners are:");

                foreach (var winner in winners)
                {
                    Console.WriteLine(winner.Name);
                }
            }
        }


        public void StartGame()
        {
            bool isBattleFinished = false;
            Player winner = null;

            while (!isBattleFinished)
            {
                foreach (var playerUnitsPair in _playerUnitsName)
                {
                    Player attacker = playerUnitsPair.Key;
                    List<IUnit> attackerUnits = playerUnitsPair.Value;

                    Console.WriteLine($"Player: {attacker.Name}");

                    foreach (var attackerUnit in attackerUnits)
                    {
                        Console.WriteLine($"HP {attackerUnit.GetType().Name}:  {attackerUnit.GetHealth()}, is alive: {attackerUnit.IsAlive()}");
                        if (attackerUnit.IsAlive() == false)
                        {
                            //continue;
                            winner = DetermineWinner();
                            Console.WriteLine("The winner is: " + winner.Name);
                            if(winner != null)
                            {
                                isBattleFinished = true;
                            }
                        }

                        //serangan
                        foreach (var targetPlayerUnitsPair in _playerUnitsName)
                        {
                            Player targetPlayer = targetPlayerUnitsPair.Key;
                            List<IUnit> targetUnits = targetPlayerUnitsPair.Value;

                            if (attacker != targetPlayer)
                            {
                                foreach (var targetUnit in targetUnits)
                                {
                                    Console.WriteLine($"HP target {targetUnit.GetType().Name}: {targetUnit.GetHealth()}, is alive: {targetUnit.IsAlive()}");
                                    //damage
                                    if (targetUnit.IsAlive())
                                    {
                                        targetUnit.TakeDamage(attackerUnit.GetAttack());
                                        Console.WriteLine($"{attackerUnit.GetType().Name} attack {targetUnit.GetType().Name}, take damage {attackerUnit.GetAttack()}, new HP {targetUnit.GetHealth()}");
                                    }

                                }
                            }
                        }
                    }

                    Console.WriteLine();
                }

                isBattleFinished = CheckBattleFinished();
            }

            winner = DetermineWinner();
            Console.WriteLine("The winner is: " + winner.Name);
        }

        private bool CheckBattleFinished()
        {
            foreach (var playerUnitsPair in _playerUnitsName)
            {
                List<IUnit> units = playerUnitsPair.Value;

                foreach (var unit in units)
                {
                    if (unit.IsAlive())
                        return false;
                }
            }

            return true;
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