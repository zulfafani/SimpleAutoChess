using System;

namespace AbstractFactoryDesignPattern.After
{
    public class GameManager
    {
        private IUnitsFactory _unitsFactory;

        public GameManager(IUnitsFactory factory)
        {
            _unitsFactory = factory;
        }

        public void SpawnUnit()
        {
            IUnits unit = _unitsFactory.CreateUnits();
            unit.Attack();
        }
    }
}
