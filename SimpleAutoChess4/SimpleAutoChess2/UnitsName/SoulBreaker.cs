using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SoulBreaker2 : IAttack, IHealth, IPrice //Goblin Assassin Common $1
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

        public SoulBreaker2(int value)
        {
            _value = value;
        }
    }
}
