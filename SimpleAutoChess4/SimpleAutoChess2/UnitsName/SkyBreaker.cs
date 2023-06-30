using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SkyBreaker2 : IAttack, IHealth, IPrice //Goblin Mech Common $1
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

        public SkyBreaker2(int value)
        {
            _value = value;
        }
    }
}
