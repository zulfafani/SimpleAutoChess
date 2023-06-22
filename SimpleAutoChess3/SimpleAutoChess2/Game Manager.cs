using System;
using System.Collections.Generic;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<IPosition, List<IUnit>> _board;
        private Dictionary<string, List<IUnit>> _units;
        private Dictionary<string, List<UnitName>> _unitsName;

        public GameManager()
        {
            _board = new Dictionary<IPosition, List<IUnit>>();
            _units = new Dictionary<string, List<IUnit>>();
            _unitsName = new Dictionary<string, List<UnitName>>();
    }

        public Dictionary<string, List<IUnit>> GetPlayerUnits()
        {
            return _units;
        }

        public Dictionary<string, List<UnitName>> GetPlayerUnits2()
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

        public void AddUnitForPlayer2(string playerName, UnitName unitName)
        {
            if (_unitsName.ContainsKey(playerName))
            {
                _unitsName[playerName].Add(unitName);
            }
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
            _units.Add(player.GetName(), new List<IUnit>());
        }

        public void AddPlayer2(IPlayer player)
        {
            _unitsName.Add(player.GetName(), new List<UnitName>());
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

        public void AddUnitOnBoard(IPlayer player, IUnit unit, IPosition square)
        {
            if (!_board.ContainsKey(square))
                _board[square] = new List<IUnit>();

            //_units[player].Add(unit);
            _board[square].Add(unit);
        }
        public void RemoveUnit(IPlayer player, IUnit unit, IPosition square)
        {
            if (_board.ContainsKey(square))
            {
                _board[square].Remove(unit);
                // _units[player].Remove(unit);
            }
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