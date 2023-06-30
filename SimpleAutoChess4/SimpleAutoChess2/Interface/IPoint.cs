using System;

namespace SimpleAutoChess
{
    public interface IPoint
    {
        public int Point { get; }
        int GetPoint();
        void ModifyPoint(int amount);
    }
}
