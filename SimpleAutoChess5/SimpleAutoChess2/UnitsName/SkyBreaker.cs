using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class SkyBreaker : IUnit //Goblin Mech Common $1
    {
        private int _attack;
        private int _health;
        private int _price;

        public SkyBreaker(int attack, int health, int price)
        {
            _attack = attack;
            _health = health;
            _price = price;
        }

        void IUnit.AttackTarget(IUnit target)
        {
            target.TakeDamage(_attack);
        }

        void IUnit.TakeDamage(int damage)
        {
            _health -= damage;
        }

        bool IUnit.IsAlive()
        {
            return _health > 0;
        }

        int IUnit.GetPrice()
        {
            return _price;
        }

        int IUnit.GetHealth()
        {
            return _health;
        }

        int IUnit.GetAttack()
        {
            return _attack;
        }
    }
}
