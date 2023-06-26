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

        IPlayer Owner { get; }
        int Health { get; set; }
        int Attack { get; }
        void TakeDamage(int damage);
        //bool IsAlive();
    }
}