using System;

namespace AbstractFactoryDesignPattern.Before
{
    public class GameManager
    {
        private TuskChampion _tuskChampion;
        private TheSource _theSource;

        public GameManager() //GameManager directly creates instances
        {
            _tuskChampion = new TuskChampion();
            _theSource = new TheSource();
        }

        public void SpawnUnits(string unitsName)
        {
            if (unitsName == "TuskChampion")
            {
                _tuskChampion.Attack();
            }
            else if (unitsName == "TheSource")
            {
                _theSource.Attack();
            }
            else
            {
                Console.WriteLine("Invalid units name!");
            }
        }
    }
}
