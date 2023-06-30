using System;

namespace AbstractFactoryDesignPattern.After
{
    //unit name class
    public class TuskChampion : IUnits
    {
        /*public void Attack()
        {
            Console.WriteLine("TuskChampion attacks!");
        }*/

        void IUnits.Attack()
        {
            Console.WriteLine("TuskChampion attacks!");
        }
    }
}
