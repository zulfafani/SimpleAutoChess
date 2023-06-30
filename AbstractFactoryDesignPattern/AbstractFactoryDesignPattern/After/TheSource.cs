using System;

namespace AbstractFactoryDesignPattern.After
{
    //unit name class
    public class TheSource : IUnits
    {
        /*public void Attack()
        {
            Console.WriteLine("TheSource attacks!");
        }*/

        void IUnits.Attack()
        {
            Console.WriteLine("TheSource attacks!");
        }
    }
}
