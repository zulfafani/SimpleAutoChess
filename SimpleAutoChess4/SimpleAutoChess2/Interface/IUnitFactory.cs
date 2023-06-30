using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public interface IUnitFactory
    {
        IAttack CreateAttack();
        IHealth CreateHealth();
        IPrice CreatePrice();
    }
}
