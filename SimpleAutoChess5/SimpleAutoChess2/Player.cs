using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Player : IPlayer, IPoint, IGold, ILevel
    {
        private string? _name;
        private string _id;
        private int _point;
        private int _gold;
        private int _level;

        public Player()
        {

        }
        public Player(string playerName)
        {
            _name = playerName;
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
        }
        public int Gold
        {
            get { return _gold; }
        }
        public int Level
        {
            get { return _level; }
        }

        void IPlayer.SetId(string generateId)
        {
            _id = generateId;
        }
        string? IPlayer.GetName()
        {
            return _name;
        }
        void IPlayer.SetName(string name)
        {
            _name = name;
        }

        int IPoint.GetPoint()
        {
            return _point;
        }
        void IPoint.ModifyPoint(int amount)
        {
            _point += amount;
        }

        int IGold.GetGold()
        {
            return _gold;
        }
        void IGold.ModifyGold(int amount)
        {
            _gold += amount;
        }
        void IGold.ModifyGoldWithPrice(int price)
        {
            _gold -= price;
        }

        int ILevel.GetLevel()
        {
            return _gold;
        }
        void ILevel.ModifyLevel(int amount)
        {
            _level += amount;
        }
    }
}