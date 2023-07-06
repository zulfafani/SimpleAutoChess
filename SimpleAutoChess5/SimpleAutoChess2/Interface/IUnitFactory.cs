using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnitFactory
    {
        IUnit CreateUnit();
    }
}
