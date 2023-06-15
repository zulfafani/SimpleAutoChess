using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnit
    {
        Race GetRace();
        void SetRace(Race race);
        Class GetClass();
        Quality GetQuality();
    }
}