using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IHealth
    {
        int GetHealth();
        void ModifyHealth(int amount);
        Action<int> OnModifyHealth();
    }
}
