using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class FlameWizardFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new FlameWizard(
                50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Uncommon), 500, (int)Quality.Uncommon);
        }
    }
}
