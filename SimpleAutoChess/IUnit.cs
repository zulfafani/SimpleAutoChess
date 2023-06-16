using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnit
    {
        public Race Race { get; set; }
        public Class Class { get; }
        public Quality Quality { get; }
        Race GetRace();
        void SetRace(Race race);
        Class GetClass();
        Quality GetQuality();
    }
}