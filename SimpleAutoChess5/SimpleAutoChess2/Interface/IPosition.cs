using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPosition
    {
        int Row { get; set; }
        int Column { get; set; }
    }
}
