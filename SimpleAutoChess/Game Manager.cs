using System;
using System.Collections.Generic;
using System.Numerics;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<IPosition, List<IUnit>> _board;
        private Dictionary<string, List<IUnit>> _units;

        public GameManager()
        {
            _board = new Dictionary<IPosition, List<IUnit>>();
            _units = new Dictionary<string, List<IUnit>>();
        }

        public Dictionary<string, List<IUnit>> GetPlayerUnits()
        {
            return _units;
        }

        public void AddPlayer(IPlayer player)
        {
            _units.Add(player.GetName(), new List<IUnit>());
        }

        public bool PlayerExists(IPlayer player)
        {
            return _units.ContainsKey(player.GetName());
        }
        

        public void AddUnitForPlayer(string playerName, IUnit unit)
        {
            if (_units.ContainsKey(playerName))
            {
                _units[playerName].Add(unit);
            }
        }

        public void AddUnitOnBoard(string playerName, IUnit unit, IPosition square)
        {
            if (!_board.ContainsKey(square))
                _board[square] = new List<IUnit>();

            _units[playerName].Add(unit);
            _board[square].Add(unit);
        }
        public void Battle()
        {
            Unit unit = new Unit();

            unit.HealthModified += OnModifyHealthHandler;
            unit.AttackModified += OnModifyAttackHandler;

            int initialHealth = ((IHealth)unit).GetHealth();
            int initialAttack = ((IAttack)unit).GetAttack();

            Console.WriteLine("Initial Health: " + initialHealth);
            Console.WriteLine("Initial Attack: " + initialAttack);

            // Simulate battle and modify health and attack
            ((IHealth)unit).ModifyHealth(20);
            ((IAttack)unit).ModifyAttack(10);

        }

        public void Battle2(IUnit unit1, IUnit unit2, Action<IUnit> onBattleComplete)
        {
            while (((IHealth)unit1).GetHealth() > 0 && (((IHealth)unit2).GetHealth() > 0))
            {
                    Console.WriteLine("Battle");
                    ((IHealth)unit2).ModifyHealth(-((IAttack)unit1).GetAttack());
                    ((IHealth)unit1).ModifyHealth(-((IAttack)unit2).GetAttack());

                    //int attack1 = (((IHealth)unit2).GetHealth() - ((IAttack)unit1).GetAttack());
                    //int attack2 = (((IHealth)unit1).GetHealth() - ((IAttack)unit2).GetAttack());
            }
            onBattleComplete?.Invoke(((IHealth)unit1).GetHealth() <= 0 ? unit1 : unit2);
        }

        public void OnModifyHealthHandler(int amount)
        {
            //amount = (int)new Random().Next(10, 100);
            Console.WriteLine("Attack modified by: " + amount);
        }
        public void OnModifyAttackHandler(int amount)
        {
            //amount = (int)new Random().Next(10, 100);
            Console.WriteLine("Attack modified by: " + amount);
        }
    }
}