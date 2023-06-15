using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IAttack
    {
        int GetAttack();
        void ModifyAttack(int amount);
        Action<int> OnModifyAttack();
    }
}
