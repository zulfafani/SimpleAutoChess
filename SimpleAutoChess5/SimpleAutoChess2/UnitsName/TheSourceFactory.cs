using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TheSourceFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new TheSource(
                50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Common), 500, (int)Quality.Common);
        }
    }
}
