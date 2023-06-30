using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class DwarfSniperFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new DwarfSniper2(70 + (((int)Race.Dwarf + (int)Class.Hunter) * (int)Quality.Uncommon));
        }

        public IHealth CreateHealth()
        {
            return new DwarfSniper2(450);
        }

        public IPrice CreatePrice()
        {
            return new DwarfSniper2((int)Quality.Uncommon);
        }
    }
}
