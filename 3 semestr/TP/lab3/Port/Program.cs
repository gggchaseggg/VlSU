using System;

namespace Port
{
    class Program
    {
        static void Main(string[] args)
        {
            Passag korabl = new Passag();
            korabl.InputInfo();
            korabl.PrintInfo();
        }
    }

    abstract class Sudno
    {
        public string name;
        public int vodoizmesh;
        public int ves;

        public abstract void PrintInfo();
        public abstract void InputInfo();
    }

    class Passag : Sudno
    {
        public int vmestimost;
        public string marshrut;
        private string sityfrom, sityto;

        private void dlinamarshruta ()
        {
        //do something
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Название судна : " + name);
            Console.WriteLine("Водоизмещение : " + vodoizmesh);
            Console.WriteLine("Вес судна : " + ves);
            Console.WriteLine("Вместимость людей : " + vmestimost);
            Console.WriteLine("Маршрут : " + marshrut);
        }

        public override void InputInfo()
        {
            Console.Write("\nВведите название судна: ");
            name = Console.ReadLine();
            Console.Write("Введите водоизмещение судна: ");
            vodoizmesh = Int32.Parse(Console.ReadLine());
            Console.Write("Введите вес судна: ");
            ves = Int32.Parse(Console.ReadLine());
            Console.Write("Введите вместимость судна: ");
            vmestimost = Int32.Parse(Console.ReadLine());
            Console.Write("Введите маршрут судна: ");
            marshrut = Console.ReadLine();
        }

    }
}
