using System;

namespace SimpleAutoChess
{
    public interface IPoint
    {
        int Point { get; set; }
        //int GetPoint();
        void ModifyPoint(int amount); //DecreasePoint
    }
}
