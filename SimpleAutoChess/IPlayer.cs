using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPlayer
    {
        public string id { get; }
        public string name { get; set; }
        string GenerateRandomId();
        string GetName();
        void SetName(string name);
    }
}