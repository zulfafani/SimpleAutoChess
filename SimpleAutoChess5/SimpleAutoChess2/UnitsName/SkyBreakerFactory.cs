using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SkyBreakerFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new SkyBreaker(
                50 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common), 700, (int)Quality.Common);
        }
    }
}
