using System;

namespace SimpleAutoChess
{
    public interface ILevel
    {
        public int Level { get; }
        int GetLevel();
        void ModifyLevel(int amount);
    }
}
