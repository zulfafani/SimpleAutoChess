using System;
//using AbstractFactoryDesignPattern.Before;
using AbstractFactoryDesignPattern.After;


namespace AbstractFactoryDesignPattern
{
    public class Program
    {
        public static void Main()
        {
            /*GameManager gameManager = new GameManager();
            gameManager.SpawnUnits("TuskChampion");  // Output: TuskChampion attacks!
            gameManager.SpawnUnits("TheSource");   // Output: TheSource attacks!
            gameManager.SpawnUnits("Dragon");*/  // Output: Invalid units name!

            TuskChampionFactory tuskChampionFactory = new TuskChampionFactory();
            TheSourceFactory theSourceFactory = new TheSourceFactory();

            GameManager gameManager1 = new GameManager(tuskChampionFactory);
            gameManager1.SpawnUnit();  // Output: TuskChampion attacks!

            GameManager gameManager2 = new GameManager(theSourceFactory);
            gameManager2.SpawnUnit();  // Output: Alien attacks!
        }
    }
}