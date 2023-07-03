using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Venom2 : IAttack, IHealth, IPrice //Dragon Assassin uncommon $2
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

        public Venom2(int value)
        {
            _value = value;
        }
    }
}
