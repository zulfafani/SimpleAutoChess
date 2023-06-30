using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TuskChampionFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new TuskChampion2(52 + (((int)Race.Beast + (int)Class.Warior) * (int)Quality.Common));
        }

        public IHealth CreateHealth()
        {
            return new TuskChampion2(650);
        }

        public IPrice CreatePrice()
        {
            return new TuskChampion2((int)Quality.Common);
        }
    }
}
