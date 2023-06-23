using System;
using System.Collections.Generic;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public enum UnitName
    {
        TuskChampion,
        TheSource,
        FlameWizard,
        SoulBreaker,
        SkyBreaker,
        HeavenBomber,
        Venom,
        DwarfSniper
    }
    public enum Race
    {
        Beast = 21,
        Human = 22,
        Goblin = 23,
        Dragon = 24,
        Dwarf = 25
    }
    public enum Class //efek sinergi (Rase+Class) menambah nilai attack
    {
        Warior = 5,
        Hunter = 6,
        Mage = 7,
        Assassin = 8,
        Mech = 9
    }
    public enum Quality
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
    }
}