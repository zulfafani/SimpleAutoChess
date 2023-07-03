using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TheSourceFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new TheSource2(50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Common));
        }

        public IHealth CreateHealth()
        {
            return new TheSource2(500);
        }

        public IPrice CreatePrice()
        {
            return new TheSource2((int)Quality.Common);
        }
    }
}
