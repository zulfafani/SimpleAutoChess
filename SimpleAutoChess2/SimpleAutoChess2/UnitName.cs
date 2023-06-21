using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class TuskChampion : IAttack, IHealth, IGold //Beast Warior Common $1
    {
        public int Attack { get; } = 52 + (((int)Race.Beast + (int)Class.Warior)*(int) Quality.Common);
        public int Health { get; } = 650;
        public int Gold { get; } = (int)Quality.Common;
    }
    public class TheSource : IAttack, IHealth, IGold //Human Mage Common $1
    {
        public int Attack { get; } = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Common);
        public int Health { get; } = 500;
        public int Gold { get; } = (int)Quality.Common;
    }
    public class FlameWizard : IAttack, IHealth, IGold //Human Mage Uncommon $2
    {
        public int Attack { get; } = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Uncommon);
        public int Health { get; } = 500;
        public int Gold { get; } = (int)Quality.Uncommon;
    }
    public class SoulBreaker : IAttack, IHealth, IGold //Goblin Assassin Common $1
    {
        public int Attack { get; } = 60 + (((int)Race.Goblin + (int)Class.Assassin) * (int)Quality.Common);
        public int Health { get; } = 550;
        public int Gold { get; } = (int)Quality.Common;
    }
    public class SkyBreaker : IAttack, IHealth, IGold //Goblin Mech Common $1
    {
        public int Attack { get; } = 50 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
        public int Health { get; } = 700;
        public int Gold { get; } = (int)Quality.Common;
    }
    public class HeavenBomber : IAttack, IHealth, IGold //Goblin Mech Common $1
    {
        public int Attack { get; } = 45 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
        public int Health { get; } = 600;
        public int Gold { get; } = (int)Quality.Common;
    }
    public class Venom : IAttack, IHealth, IGold //Dragon Assassin uncommon $2
    {
        public int Attack { get; } = 55 + (((int)Race.Dragon + (int)Class.Assassin) * (int)Quality.Uncommon);
        public int Health { get; } = 500;
        public int Gold { get; } = (int)Quality.Uncommon;
    }
    public class DwarfSniper : IAttack, IHealth, IGold //Dwarf Hunter uncommon $2
    {
        public int Attack { get; } = 70 + (((int)Race.Dwarf + (int)Class.Hunter) * (int)Quality.Uncommon);
        public int Health { get; } = 450;
        public int Gold { get; } = (int)Quality.Uncommon;
    }
}
