using System;

namespace Port
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Passenger[] Spisok = new Passenger[7];

            Spisok[0] = new Passenger("Бригантина",520,1540000,330);
            Spisok[1] = new Passenger("Победа", 100, 120000, 100);
            Spisok[2] = new Passenger("Беда", 10, 15400, 0);

            byte LastInd = 3;

            Console.WriteLine("Здравствуйте!");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Какое действие вы хотите выполнить?");
                Console.WriteLine("1 - Добавить судно и информацию о нем");
                Console.WriteLine("2 - Получить информацию о судне");
                Console.WriteLine("3 - Добавить пассажиров на судно");
                Console.WriteLine("4 - закрыть программу");
                Console.Write("Выберите пункт: ");

                byte key = Convert.ToByte(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        if (LastInd == 6)
                        {
                            Console.WriteLine("НЕ ОСТАЛОСЬ МЕСТА В ПОРТУ");
                            break;
                        }

                        Console.WriteLine("--------------------------------------------------");
                        Console.Write("Введите название судна: ");
                        string name = Console.ReadLine();
                        
                        Console.Write("Введите вместимость судна: ");
                        int vmest = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Введите вес судна: ");
                        int ves = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Введите кол-во людей на судне: ");
                        int pasamount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("--------------------------------------------------");
                        
                        Spisok[LastInd] = new Passenger(name, vmest, ves, pasamount);
                        Console.WriteLine("Было создано судно с индексом - " + LastInd);
                        LastInd++;

                        break;

                    case 2:
                        Console.Write("Введите индекс судна: ");
                        byte ind = Convert.ToByte(Console.ReadLine());
                        Spisok[ind].PrintInfo();
                        break;

                    case 3:
                        Console.Write("Введите индекс судна: ");
                        byte ind1 = Convert.ToByte(Console.ReadLine());
                        Console.Write("Введите количество севших пассажиров: ");
                        int plssize = Convert.ToInt32(Console.ReadLine());
                        Spisok[ind1].PlusPassenger(plssize);
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            
            
        }
    }

    abstract class Sudno
    {
        protected string Name;
        protected int Vmest;
        protected int Ves;

        protected Sudno(string name, int vmest, int ves)
        {
            Name = name;
            Vmest = vmest;
            Ves = ves;
        }

        public abstract void PrintInfo();
    }

    class Passenger : Sudno
    {
        private int PasAmount;

        public Passenger(string name, int vmest, int ves, int pasamount) : base(name, vmest, ves)
        {
            PasAmount = pasamount;
        }

        private void Zagruzhen()
        {
            if (PasAmount == Vmest)
            {
                Console.WriteLine("{0} - Уже заполнено ", Name);
            }
            else
            {
                Console.WriteLine("{0} - Не заполнено или переполнено ", Name);
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Название судна : " + Name);
            Console.WriteLine("Вместимость людей : " + Vmest);
            Console.WriteLine("Вес судна : " + Ves);
            Console.WriteLine("Находящиеся на борту люди : " + PasAmount);
            Zagruzhen();
            Console.WriteLine("--------------------------------------------------");
        }

        public void PlusPassenger(int plus_size)
        {
            PasAmount += plus_size;
        }

    }
}