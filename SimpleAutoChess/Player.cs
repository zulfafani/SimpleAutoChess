using System;
using System.Collections.Generic;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Player : IPlayer
    {
        private string? _id;
        private string? _name;

        public string id
        {
            get { return _id; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        string IPlayer.GenerateRandomId()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] idChars = new char[6];

            for (int i = 0; i < idChars.Length; i++)
            {
                idChars[i] = chars[random.Next(chars.Length)];
            }
            //_id = idChars.ToString(); will print out "System.Char[]" because calling ToString on a T array in .NET will always return "T[]".
            _id = new string(idChars);
            return _id;
        }
        string IPlayer.GetName()
        {
            return _name;
        }
        void IPlayer.SetName(string name)
        {
            _name = name;
        }
    }
}