using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IAttack
    {
        public int Attack { get; }
        //int GetAttack();
        //void ModifyAttack(int amount);
        //Action<int> OnModifyAttack();
    }
}
