using System;
using System.Collections.Generic;
using System.Diagnostics;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Unit : IUnit, IHealth, IAttack
    {
        private Race _race;
        private Class _class;
        private Quality _quality;
        private int _health;
        private int _attack;

        public event Action<int> HealthModified;
        public event Action<int> AttackModified;

        public Race Race
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
        }
        int IHealth.GetHealth()
        {
            _health = (int)new Random().Next(0,10);
            return _health;
        }
        void IHealth.ModifyHealth(int amount)
        {
            _health -= amount;
            HealthModified?.Invoke(amount);
        }
        Action<int> IHealth.OnModifyHealth()
        {
            return HealthModified;
        }
        int IAttack.GetAttack()
        {
            _attack = (int)new Random().Next(0,10);
            return _attack;
        }
        void IAttack.ModifyAttack(int amount)
        {
            _attack += amount;
            AttackModified?.Invoke(amount);
        }
        Action<int> IAttack.OnModifyAttack()
        {
            return AttackModified;
        }
    }
}