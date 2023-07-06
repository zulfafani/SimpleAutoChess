using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Player : IPlayer, IPoint, IGold, ILevel
    {
        private string? _name;
        private string? _id;
        private int _point;
        private int _gold;
        private int _level;

        public Player()
        {

        }

        public Player(string? name, string id, int point, int gold, int level)
        {
            _name = name;
            _id = id;
            _point = point;
            _gold = gold;
            _level = level;
        }

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Id
        {
            get { return _id; }
        }
        
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        void IPoint.ModifyPoint(int amount)
        {
            _point -= amount;
        }

        void IGold.ModifyGold(int amount)
        {
            _gold += amount;
        }
        
        void IGold.ModifyGoldWithPrice(int price)
        {
            _gold -= price;
        }

        void ILevel.ModifyLevel()
        {
            _level++;
        }
    }
}