/*using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Unit : IUnit//, IAttack, IHealth, IPrice
    {
        //private UnitName _unitName;
        *//*private Race _race;
        private Class _class;
        private Quality _quality;*//*
        private int _health;
        private int _attack;
        private int _price;

        //public event Action<int> HealthModified;
        //public event Action<int> AttackModified;

        *//*public IPlayer Owner { get; }
        public UnitName UnitName { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int ModifyHealth { get; set; }
        public int Price { get; set; }*//*

        public Unit()
        {

        }
        *//*public Unit(IPlayer owner, int health, int attack)
        {
            Owner = owner;
            Health = health;
            Attack = attack;
        }*/

        /*public void TakeDamage2(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }*//*


        public void AttackTarget(IUnit target)
        {
            if (target is IHealth healthTarget)
            {
                healthTarget.TakeDamage(_attack);
                Console.WriteLine("TuskChampion attacked the target.");
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }

        public bool IsAlive()
        {
            return _health > 0;
        }

        public int GetPrice()
        {
            return _price;
        }


        //public bool IsAlive()
        //{
        //return health > 0;
        //}




        *//*public Race Race
        {
            get { return _race; }
            set { _race = value; }
        }
        public Class Class
        {
            get { return _class; }
        }
        public Quality Quality
        {
            get { return _quality; }
        }
        public UnitName UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
        public int Health2
        {
            get { return _health; }
        }
        public int Attack2
        {
            get { return _attack; }
        }

        UnitName IUnit.GetUnitName()
        {
            return _unitName;
        }
        void IUnit.SetUnitName(UnitName _unitName)
        {
            _unitName = UnitName;
        }

        Race IUnit.GetRace()
        {
            return _race;
        }
        void IUnit.SetRace(Race race)
        {
            _race = race;
        }
        Class IUnit.GetClass()
        {
            _class = (Class)new Random().Next(Enum.GetValues(typeof(Class)).Length);
            return _class;
        }
        Quality IUnit.GetQuality()
        {
            _quality = (Quality)new Random().Next(Enum.GetValues(typeof(Quality)).Length);
            return _quality;
        }*/

        /*int IHealth.GetHealth()
        {
            return _health;
        }
        void IHealth.ModifyHealth(int damage)
        {
            _health -= damage;
        }
        int IAttack.GetAttack()
        {
            return _health;
        }*//*


        //int IHealth.GetHealth()
        //{
        //_health = (int)new Random().Next(0,10);
        //return _health;
        //}
        //void IHealth.ModifyHealth(int amount)
        //{
        //_health -= amount;
        //HealthModified?.Invoke(amount);
        //}
        //Action<int> IHealth.OnModifyHealth()
        //{
        //return HealthModified;
        //}
        //int IAttack.GetAttack()
        //{
        //_attack = (int)new Random().Next(0,10);
        //return _attack;
        //}
        //void IAttack.ModifyAttack(int amount)
        //{
        //_attack += amount;
        //AttackModified?.Invoke(amount);
        //}
        //Action<int> IAttack.OnModifyAttack()
        //{
        //return AttackModified;
        //}
    }
}*/