using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPlayer
    {
        string Name { get; set; }
        string Id { get; }
    }
}