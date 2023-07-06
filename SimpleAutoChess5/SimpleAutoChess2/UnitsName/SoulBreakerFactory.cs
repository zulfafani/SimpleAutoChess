using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SoulBreakerFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new SoulBreaker(
                60 + (((int)Race.Goblin + (int)Class.Assassin) * (int)Quality.Common), 550, (int)Quality.Common);
        }
    }
}
