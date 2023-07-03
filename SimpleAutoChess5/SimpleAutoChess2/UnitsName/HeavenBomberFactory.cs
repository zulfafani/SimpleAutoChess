using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class HeavenBomberFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new HeavenBomber2(45 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common));
        }

        public IHealth CreateHealth()
        {
            return new HeavenBomber2(600);
        }

        public IPrice CreatePrice()
        {
            return new HeavenBomber2((int)Quality.Common);
        }
    }
}
