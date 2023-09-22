using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaniilGrachev_PRI120
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // переводит координату X в строку и записывает в поля ввода
            textBox1.Text = e.X.ToString();
            // переводит координату Y в строку и записывает в поля ввода
            textBox2.Text = e.Y.ToString();

            Point tmp_location;
            int _w = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            int _h = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;

            // если координата по оси X и по оси Y лежит в очерчиваемом вокруг кнопки "да, конечно" квадрате
            if (e.X > 115 && e.X < 205 && e.Y > 243 && e.Y < 273)
            {

                // запоминаем текущее положение окна
                tmp_location = this.Location;
                // генерируем перемещения по осям X и Y и прибавляем их к хранимому значению текущего положения окна
                // числа генерируются в диапазоне от -100 до 100.
                tmp_location.X += rnd.Next(-100, 100);
                tmp_location.Y += rnd.Next(-100, 100);

                // если окно вышло за пределы экрана по одной из осей
                if (tmp_location.X < 0 || tmp_location.X > (_w - this.Width / 2) || tmp_location.Y < 0 || tmp_location.Y > (_h - this.Height / 2))
                {
                    // новыми координатами станет центр окна
                    tmp_location.X = _w / 2;
                    tmp_location.Y = _h / 2;
                }

                // обновляем положение окна на новое сгенерированное
                this.Location = tmp_location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Вывести сообщение с текстом "Вы усердны"
            MessageBox.Show("Вы усердны!!");
            // Завершить приложение
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Вывести сообщение, с текстом "Мы не сомневались в вешем безразличии"
            // второй параметр - заголовок окна сообщения "Внимание"
            // MessageBoxButtons.OK - тип размещаемой кнопки на форме сообщения
            // MessageBoxIcon.Information - тип сообщения - будет иметь иконку "информация" и соотвествующее звуковой сигнал
            MessageBox.Show("Мы не сомневались в вешем безразличии", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
