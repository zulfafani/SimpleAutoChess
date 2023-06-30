using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TuskChampion2 : IAttack, IHealth, IPrice //Beast Warior Common $1
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

        public TuskChampion2(int value)
        {
            _value = value;
        }
    }
}
