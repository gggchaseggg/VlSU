using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DaniilGrachev_PRI120
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = -5;
            int b = 5;
            double n = 20;
            double interval = (b - a) / n;
            Thread th1 = new Thread(() => calc(a, a + interval * 5, interval));
            Thread th2 = new Thread(() => calc(a + interval * 5, a + interval * 10, interval));
            Thread th3 = new Thread(() => calc(a + interval * 10, a + interval * 15, interval));
            Thread th4 = new Thread(() => calc(a + interval * 15, a + interval * 20, interval));

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();

            Console.WriteLine("Все потоки запущены");

            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();

            Console.ReadKey();

            
        }
        static void calc(double from, double to, double interval)
        {
            for (double x = from; x < to; x += interval)
            {
                double result = (Math.Pow(x, 3) * Math.Exp(-Math.Abs(x + 1))) - (Math.Log(5 * Math.Tan(x))) - Math.Exp(7 * Math.Sqrt(x)) + 0.3 * (Math.Pow(x, 3) + Math.Pow(x, 2) - 1);
                Console.WriteLine($"{x}:\t {result}");
            }
        }
    }
}
