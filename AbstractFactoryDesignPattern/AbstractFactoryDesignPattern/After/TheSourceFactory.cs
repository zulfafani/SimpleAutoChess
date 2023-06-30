using System;

namespace AbstractFactoryDesignPattern.After
{
    public class TheSourceFactory : IUnitsFactory
    {
        public IUnits CreateUnits()
        {
            return new TheSource();
        }

        /*public IUnits IUnitsFactory.CreateUnits()
        {
            return new TheSource();
        }*/
    }
}
