using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IAttack
    {
        public int Attack { get; }
        public int ModifyHealth { get; set; }
        //int GetAttack();
        //void ModifyAttack(int amount);
        //Action<int> OnModifyAttack();
    }
}
