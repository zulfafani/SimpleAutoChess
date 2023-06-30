using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class FlameWizard2 : IAttack, IHealth, IPrice //Human Mage Uncommon $2
    {
        private int _value;

        public int ModifyHealth { get; set; }
        public int Health
        {
            get { return _value; }
        }
        public int Attack
        {
            get { return _value; }
        }
        public int Price
        {
            get { return _value; }
        }

        public FlameWizard2(int value)
        {
            _value = value;
        }
    }
}
