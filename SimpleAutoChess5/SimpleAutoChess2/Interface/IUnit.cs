using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnit
    {
        void AttackTarget(IUnit target);
        void TakeDamage(int damage);
        bool IsAlive();
        int GetPrice();
        int GetHealth();
        int GetAttack();
    }
}