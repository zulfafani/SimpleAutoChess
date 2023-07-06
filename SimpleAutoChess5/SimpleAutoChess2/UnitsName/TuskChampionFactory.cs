using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TuskChampionFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new TuskChampion(
                52 + (((int)Race.Beast + (int)Class.Warior) * (int)Quality.Common), 650, (int)Quality.Common);
        }
    }
}
