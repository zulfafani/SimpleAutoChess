using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class HeavenBomber2 : IAttack, IHealth, IPrice //Goblin Mech Common $1
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

        public HeavenBomber2(int value)
        {
            _value = value;
        }
    }
}
