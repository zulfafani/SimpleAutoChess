using System;
using System.Collections.Generic;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Player : IPlayer
    {
        private string? _name;

        public string? name
        {
            get { return _name; }
            set { _name = value; }
        }
        string? IPlayer.GetName()
        {
            return _name;
        }
        void IPlayer.SetName(string name)
        {
            _name = name;
        }
    }
}