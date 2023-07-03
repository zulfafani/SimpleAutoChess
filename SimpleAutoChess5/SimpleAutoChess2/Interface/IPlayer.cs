using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public string Id { get; }
        void SetId(string generateId);
        string? GetName();
        void SetName(string name);
    }
}