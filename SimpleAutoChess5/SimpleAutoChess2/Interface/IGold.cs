using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IGold
    {
        int Gold { get; set; }
        void ModifyGold(int amount); //IncreaseGold
        void ModifyGoldWithPrice(int price); //DecreaseGold
    }
}
