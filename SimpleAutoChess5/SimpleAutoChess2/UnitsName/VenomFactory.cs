using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class VenomFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new Venom(
                55 + (((int)Race.Dragon + (int)Class.Assassin) * (int)Quality.Uncommon), 500, (int)Quality.Uncommon);
        }
    }
}
