using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class GameManager
    {
        private Dictionary<string, List<Unit>> _playerUnitsName;

        public GameManager()
        {
            _playerUnitsName = new Dictionary<string, List<Unit>>();
        }

        public void AddPlayer(IPlayer player)
        {
            _playerUnitsName.Add(player.GetName(), new List<Unit>());
        }

        public bool isPlayerExists(IPlayer player)
        {
            return _playerUnitsName.ContainsKey(player.GetName());
        }

        public Dictionary<string, List<Unit>> GetPlayerUnits()
        {
            return _playerUnitsName;
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

        public void AddUnitForPlayer(string playerName, Unit unitName)
        {
            if (_playerUnitsName.ContainsKey(playerName))
            {
                _playerUnitsName[playerName].Add(unitName);
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
    }
}