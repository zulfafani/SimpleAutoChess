using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SoulBreakerFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new SoulBreaker2(60 + (((int)Race.Goblin + (int)Class.Assassin) * (int)Quality.Common));
        }

        public IHealth CreateHealth()
        {
            return new SoulBreaker2(550);
        }

        public IPrice CreatePrice()
        {
            return new SoulBreaker2((int)Quality.Common);
        }
    }
}
