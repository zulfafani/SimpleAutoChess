using System;

namespace AbstractFactoryDesignPattern.After
{
    public class TuskChampionFactory : IUnitsFactory
    {
        public IUnits CreateUnits()
        {
            return new TuskChampion();
        }

        /*public IUnits IUnitsFactory.CreateUnits()
        {
            return new TuskChampion();
        }*/
    }
}
