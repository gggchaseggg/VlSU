using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrachevDaniil_PRI120
{
    class Man
    {

        public Man(string name)
        {
            this.Name = name;
            this.isLife = true;
            this.Age = (uint)this.rnd.Next(15, 50);
            this.Health = (uint)this.rnd.Next(10, 100);
        }

        private string Name;
        private uint Age;
        private uint Health;
        private bool isLife;
        Random rnd = new Random();

        public void Talk()
        {
            int random_talk = rnd.Next(1, 3);
            string tmp_str = "";

            switch (random_talk)
            {

                case 1:
                    {
                        tmp_str = "Привет, меня зовут " + Name + ", рад познакомиться";

                        break;
                    }

                case 2:
                    {
                        tmp_str = "Мне " + Age + ". А тебе?";
                        break;
                    }

                case 3:
                    {
                        if (Health > 50)
                        {
                            tmp_str = "Да я зводоров как бык!";
                        }
                        else
                        {
                            tmp_str = "Со здоровьем у меня неважно, дожить бы до " + (Age + 10).ToString();
                        }
                        break;
                    }
            }
            Console.WriteLine(tmp_str);
        }

        public void Go()
        {
            if (isLife == true)
            {
                if (Health > 40)
                {
                    string outString = Name + " мирно прогуливается по городу";
                    Console.WriteLine(outString);
                }
                else
                {
                    string outString = Name + " болен и не может гулять по городу";
                    Console.WriteLine(outString);
                }
            }
            else
            {
                string outString = Name + " не может идти, он умер";
                Console.WriteLine(outString);
            }
        }

        public void Healing()
        {
            if (isLife == true)
            {
                if (Health < 80)
                {
                    this.Health += 20;
                    Console.WriteLine($"{this.Name} подлечился, его здоровье было {this.Health - 20}, а стало {this.Health}");
                }
                else
                {
                    Console.WriteLine($"{this.Name} здоров, лечение не требуется");
                }
            }
        }

        public void ChangeName(string newName)
        {
            Console.WriteLine($"{this.Name} сменил имя на {newName}");
            this.Name = newName;
        }

        public void Kill()
        {
            isLife = false;
        }

        public bool IsAlive()
        {
            return isLife;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string user_command = "";
            bool Infinity = true;
            Man SomeMan = null;

            while (Infinity)
            {
                Console.WriteLine("Пожалуйста, введите команду");

                user_command = Console.ReadLine();

                switch (user_command)
                {

                    case "exit":
                        {
                            Infinity = false;
                            break;
                        }
                    case "help":
                        {

                            Console.WriteLine("Список команд:");
                            Console.WriteLine("---");

                            Console.WriteLine("create_man : команда создает человечка, (экземпляр класса Man)");
                            Console.WriteLine("kill_man : команда убивает человечка");
                            Console.WriteLine("talk : команда заставляет человечка говорить (если создан экземпляр класса)");
                            Console.WriteLine("go : команда заставляет человечка идти (если создан экземпляр класса)");
                            Console.WriteLine("healing : команда заставляет человечка лечиться (если создан экземпляр класса)");
                            Console.WriteLine("change_name : команда заставляет человечка сменить имя на указанное (если создан экземпляр класса)");
                            Console.WriteLine("---");
                            Console.WriteLine("---");

                            break;

                        }
                    case "create_man":
                        {
                            if (SomeMan != null)
                            {
                                SomeMan.Kill();
                            }
                            Console.WriteLine("Пожалуйста, введите имя создаваемого человечка \n");
                            user_command = Console.ReadLine();
                            SomeMan = new Man(user_command);
                            Console.WriteLine("Человечек успешно создан \n");

                            break;

                        }
                    case "kill_man":
                        {
                            if (SomeMan != null)
                            {
                                SomeMan.Kill();
                            }
                            break;
                        }
                    case "talk":
                        {
                            if (SomeMan != null)
                            {
                                SomeMan.Talk();
                            }
                            else
                            {
                                Console.WriteLine("Человечек не создан. Команда не может быть выполнена");
                            }
                            break;

                        }
                    case "go":
                        {
                            if (SomeMan != null)
                            {
                                SomeMan.Go();
                            }
                            else
                            {
                                Console.WriteLine("Человечек не создан. Команда не может быть выполнена");
                            }
                            break;

                        }
                    case "healing":
                        {
                            Console.WriteLine("---Грачев Даниил Алексеевич ПРИ-120---");
                            if (SomeMan != null)
                            {
                                SomeMan.Healing();
                            }
                            else
                            {
                                Console.WriteLine("Человек мертв, он не может лечиться");
                            }
                            break;

                        }
                    case "change_name":
                        {
                            Console.WriteLine("---Грачев Даниил Алексеевич ПРИ-120---");
                            if (SomeMan != null)
                            {
                                SomeMan.Kill();
                                Console.WriteLine("Пожалуйста, введите новое имя");
                                string newName = Console.ReadLine();
                                SomeMan.ChangeName(newName);
                                Console.WriteLine("Имя человека успешно изменено");
                            }


                            break;

                        }
                    default:
                        {

                            System.Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова");
                            System.Console.WriteLine("Для вывода списка команд введите команду help");
                            System.Console.WriteLine("Для завершения программы введите команду exit");
                            break;
                        }
                }
            }
        }
    }
}
