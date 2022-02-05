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

    }

    class Passenger : Sudno
    {
        private int PasAmount;
        public delegate void DelegForEvent(string message);
        public event DelegForEvent sessionevent;


        public Passenger(string name, int vmest, int ves, int pasamount) : base(name, vmest, ves)
        {
            PasAmount = pasamount;
        }

        public void PlusPassenger(int plus_size)
        {
            PasAmount += plus_size;
        }

        public void Info()
        {
            MessageBox.Show($"{Name}-{Vmest}-{Ves}-{PasAmount}");
        }

        public void SudnoNotify()
        {
            sessionevent?.Invoke(String.Format("Кораблю сообщили о возможности отбытия"));
        }
    }

}