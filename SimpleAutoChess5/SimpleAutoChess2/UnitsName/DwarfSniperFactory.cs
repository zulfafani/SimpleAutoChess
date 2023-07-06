using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class DwarfSniperFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new DwarfSniper(
                70 + (((int)Race.Dwarf + (int)Class.Hunter) * (int)Quality.Uncommon), 450, (int)Quality.Uncommon);
        }
    }
}
