using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace lab6
{
    public class Library
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Library));
        public static double multiplyByTwo(double arg)
        {
            log.Info("Запущен метод умножения на 2...");
            return arg * 2;
        }

        public static double multiplyByThree(double arg)
        {
            log.Info("Запущен метод умножения на 3...");
            return arg * 3;
        }
        public static double multiply(double arg1, double arg2)
        {
            log.Info("Запущен метод перемножения 2 чисел...");
            return arg1 * arg2;
        }

    }
}
