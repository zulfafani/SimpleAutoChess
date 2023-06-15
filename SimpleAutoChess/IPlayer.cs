using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPlayer
    {
        string GenerateRandomId();
        string GetName();
        void SetName(string name);
    }
}