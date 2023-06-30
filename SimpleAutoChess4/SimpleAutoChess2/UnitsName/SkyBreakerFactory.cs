using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SkyBreakerFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new SkyBreaker2(50 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common));
        }

        public IHealth CreateHealth()
        {
            return new SkyBreaker2(700);
        }

        public IPrice CreatePrice()
        {
            return new SkyBreaker2((int)Quality.Common);
        }
    }
}
