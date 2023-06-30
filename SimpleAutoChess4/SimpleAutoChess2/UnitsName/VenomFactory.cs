using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class VenomFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new Venom2(55 + (((int)Race.Dragon + (int)Class.Assassin) * (int)Quality.Uncommon));
        }

        public IHealth CreateHealth()
        {
            return new Venom2(500);
        }

        public IPrice CreatePrice()
        {
            return new Venom2((int)Quality.Uncommon);
        }
    }
}
