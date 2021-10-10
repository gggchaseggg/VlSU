using System;

namespace Port
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    abstract class Sudno
    {
        public string name;
        public int vodoizmesh;
        public int ves;

        public abstract void GetInfo();
    }

    class Passag : Sudno
    {
        public int vmestimost;
        public string marshrut;

        public override void GetInfo()
        {
            Console.WriteLine("Название судна : " + name);
            Console.WriteLine("Водоизмещение : " + vodoizmesh);
            Console.WriteLine("Вес судна : " + ves);
        }
    }
}
