using System;

namespace SimpleAutoChess
{
    public interface ILevel
    {
        int Level { get; set; }
        void ModifyLevel(); //IncreaseLevel
    }
}
