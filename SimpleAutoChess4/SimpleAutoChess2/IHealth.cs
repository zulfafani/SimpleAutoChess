using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IHealth
    {
        public int Health { get; }
        int GetHealth();
        void ModifyHealth(int amount);
        
        //Action<int> OnModifyHealth();
    }
}
