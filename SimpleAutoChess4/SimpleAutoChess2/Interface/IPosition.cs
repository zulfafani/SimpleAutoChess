using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IPosition
    {
        public int row { get; set; }
        public int col { get; set; }
    }
}
