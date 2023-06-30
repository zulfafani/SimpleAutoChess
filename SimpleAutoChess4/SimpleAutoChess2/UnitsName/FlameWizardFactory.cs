using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class FlameWizardFactory : IUnitFactory
    {
        public IAttack CreateAttack()
        {
            return new FlameWizard2(50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Uncommon));
        }

        public IHealth CreateHealth()
        {
            return new FlameWizard2(500);
        }

        public IPrice CreatePrice()
        {
            return new FlameWizard2((int)Quality.Uncommon);
        }
    }
}
