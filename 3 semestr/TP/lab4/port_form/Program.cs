using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace port_form
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Passenger[] Spisok = new Passenger[7];

            Spisok[0] = new Passenger("Бригантина", 520, 1540000, 330);
            Spisok[1] = new Passenger("Победа", 100, 120000, 100);
            Spisok[2] = new Passenger("Беда", 10, 15400, 0);


            byte LastInd = 3;

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
            if (PasAmount > Vmest)
            {
                Console.WriteLine("{0} - Уже заполнено ", Name);
            }
            else
            {
                Console.WriteLine("{0} - Еще не заполнено ", Name);
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