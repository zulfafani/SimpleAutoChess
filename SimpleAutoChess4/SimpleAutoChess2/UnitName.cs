using System;
using SimpleAutoChess;
namespace SimpleAutoChess
{
	public class TuskChampion : Unit//IAttack, IHealth, IGold //Beast Warior Common $1
	{
		private int _health;
		private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        //int IHealth.GetHealth()
        //{
			//_health = 650;
            //return _health;
        //}
        //void IHealth.ModifyHealth(int damage)
		//{
            //_health -= damage;
        //}
		//int IAttack.GetAttack()
		//{
            //_attack = 52 + (((int)Race.Beast + (int)Class.Warior) * (int)Quality.Common);
            //return _attack;
		//
        ///}
        //


        public int Attack { get; } = 52 + (((int)Race.Beast + (int)Class.Warior)*(int) Quality.Common);
		public int Health { get; } = 650;
		public int Gold { get; } = (int)Quality.Common;

	}

	public class TheSource : Unit //IAttack, IHealth, IGold //Human Mage Common $1
	{
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        //int IHealth.GetHealth()
        //{
            //_health = 500;
            //return _health;
        //}
        //void IHealth.ModifyHealth(int damage)
        //{
           // _health -= damage;
        //}
        //int IAttack.GetAttack()
        //{
           // _attack = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Common);
            //return _attack;
        //}
        
		public int Attack { get; } = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Common);
		public int Health { get; } = 500;
		public int Gold { get; } = (int)Quality.Common;
	}

	public class FlameWizard : Unit //IAttack, IHealth, IGold //Human Mage Uncommon $2
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            _health = 500;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
           _attack = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Uncommon);
            return _attack;
        }*/
        
        public int Attack { get; } = 50 + (((int)Race.Human + (int)Class.Mage) * (int)Quality.Uncommon);
		public int Health { get; } = 500;
		public int Gold { get; } = (int)Quality.Uncommon;
	}

	public class SoulBreaker : Unit //IAttack, IHealth, IGold //Goblin Assassin Common $1
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            //_health = 550;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            _attack = 60 + (((int)Race.Goblin + (int)Class.Assassin) * (int)Quality.Common);
            return _attack;
        }*/

        public int Attack { get; } = 60 + (((int)Race.Goblin + (int)Class.Assassin) * (int)Quality.Common);
		public int Health { get; } = 550;
		public int Gold { get; } = (int)Quality.Common;
	}

	public class SkyBreaker : Unit // IAttack, IHealth, IGold //Goblin Mech Common $1
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            _health = 700;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            _attack = 50 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
            return _attack;
        }*/
        
        public int Attack { get; } = 50 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
		public int Health { get; } = 700;
		public int Gold { get; } = (int)Quality.Common;
	}

	public class HeavenBomber : Unit //IAttack, IHealth, IGold //Goblin Mech Common $1
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            _health = 600;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            _attack = 45 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
            return _health;
        }*/
        
        public int Attack { get; } = 45 + (((int)Race.Goblin + (int)Class.Mech) * (int)Quality.Common);
		public int Health { get; } = 600;
		public int Gold { get; } = (int)Quality.Common;
	}

	public class Venom : Unit //IAttack, IHealth, IGold //Dragon Assassin uncommon $2
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            _health = 550;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            _attack = 55 + (((int)Race.Dragon + (int)Class.Assassin) * (int)Quality.Uncommon);
            return _attack;
        }*/
        
        public int Attack { get; } = 55 + (((int)Race.Dragon + (int)Class.Assassin) * (int)Quality.Uncommon);
		public int Health { get; } = 500;
		public int Gold { get; } = (int)Quality.Uncommon;
	}

	public class DwarfSniper : Unit //IAttack, IHealth, IGold //Dwarf Hunter uncommon $2
    {
        private int _health;
        private int _attack;

        public int health
        {
            get { return _health; }
        }
        public int attack
        {
            get { return _attack; }
        }

        /*int IHealth.GetHealth()
        {
            _health = 450;
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            _attack = 70 + (((int)Race.Dwarf + (int)Class.Hunter) * (int)Quality.Uncommon);
            return _attack;
        }*/

        public int Attack { get; } = 70 + (((int)Race.Dwarf + (int)Class.Hunter) * (int)Quality.Uncommon);
		public int Health { get; } = 450;
		public int Gold { get; } = (int)Quality.Uncommon;
	}
}
