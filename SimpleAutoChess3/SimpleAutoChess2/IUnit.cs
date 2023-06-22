using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnit
    {
        public UnitName unitName { get; set; }
        public Race Race { get; set; }
        public Class Class { get; }
        public Quality Quality { get; }

        UnitName GetUnitName();
        void SetUnitName(UnitName unitName);

        Race GetRace();
        void SetRace(Race race);
        Class GetClass();
        Quality GetQuality();
    }
}