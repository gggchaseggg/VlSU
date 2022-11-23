using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace lab4
{
    
    
    public class ForTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ForTest));

        public static bool isTrue(string arg)
        {
            log.Info("Запущен метод со строковым аргументом...");
            if (arg == "Exception") {
                log.Warn("Возникла ошибка");
                throw new ArgumentException();
            }
            return arg == "true" ? true : false;
        }

        public static bool isTrue(int arg)
        {
            log.Info("Запущен метод с целочисленным аргументом...");
            return arg == 1 ? true : false;
        }

        public static bool isTrue(bool arg)
        {
            log.Info("Запущен метод с логическим аргументом...");
            return arg;
        }
    }
}
