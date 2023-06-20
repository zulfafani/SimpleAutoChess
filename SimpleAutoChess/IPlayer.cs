using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPlayer
    {
        public string name { get; set; }
        string GetName();
        void SetName(string name);
    }
}