using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class HeavenBomberFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new HeavenBomber(
                45 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common), 600, (int)Quality.Common);
        }
    }
}
