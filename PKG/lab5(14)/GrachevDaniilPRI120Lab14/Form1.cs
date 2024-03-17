using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.DevIl;

namespace GrachevDaniilPRI120Lab14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        double a = 0, b = -0.575, c = -8.5, d = -61, zoom = 1; // выбранные оси
        int os_x = 1, os_y = 0, os_z = 0;
        bool Wire = false; // режим сеточной визуализации
        anModelLoader Model = null;

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar, в необходимый нам формат
            b = (double)trackBar2.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label9.Text = b.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar, в необходимый нам формат
            c = (double)trackBar3.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label10.Text = c.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar, в необходимый нам формат
            d = (double)trackBar4.Value;
            // подписываем это значение в label элементе под данным ползунком
            label11.Text = d.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar, в необходимый нам формат
            zoom = (double)trackBar5.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label12.Text = zoom.ToString();
        }

        private void выбратьФайлДляЗагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Model = new anModelLoader();
                Model.LoadModel(openFileDialog1.FileName);
                RenderTimer.Start();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Wire = checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в зависимости от выбранного режима
            switch (comboBox1.SelectedIndex)
            {
                // устанавливаем необходимую ось (будет испльзовано в функции glRotate**)
                case 0:
                    {
                        os_x = 1;
                        os_y = 0;
                        os_z = 0;
                        break;
                    }
                case 1:
                    {
                        os_x = 0;
                        os_y = 1;
                        os_z = 0;
                        break;
                    }
                case 2:
                    {
                        os_x = 0;
                        os_y = 0;
                        os_z = 1;
                        break;
                    }

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar, в необходимый нам формат
            a = (double)trackBar1.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label8.Text = a.ToString();
        }

        

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {

            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы
            Gl.glLoadIdentity();

            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта
            Gl.glPushMatrix();
            // производим перемещение в зависимости от значений, полученных при перемещении ползунков
            Gl.glTranslated(a, b, c);
            // поворот по установленной оси
            Gl.glRotated(d, os_x, os_y, os_z);
            // и масштабирование объекта
            Gl.glScaled(zoom, zoom, zoom);

            if (Model != null) Model.DrawModel();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // завершаем рисование
            Gl.glFlush();

            // обновлем элемент AnT
            AnT.Invalidate();

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация бибилиотеки glut
            Glut.glutInit();
            // инициализация режима экрана
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // инициализация библиотеки OpenIL
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // установка цвета очистки экрана (RGBA)
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы
            Gl.glLoadIdentity();

            // установка перспективы
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // начальная настройка параметров openGL (тест глубины, освещение и первый источник света)
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            openFileDialog1.Filter = "ase files (*.ase)|*.ase|All files (*.*)|*.*";

            // установка первых элементов в списках combobox
            comboBox1.SelectedIndex = 0;
            trackBar1.Value = (int)a * 1000;
            trackBar2.Value = (int)b * 1000;
            trackBar3.Value = (int)c * 1000;
            trackBar4.Value = (int)d;
            trackBar5.Value = (int)zoom * 1000;

            label8.Text = a.ToString();
            label9.Text = b.ToString();
            label10.Text = c.ToString();
            label11.Text = d.ToString();
            label12.Text = zoom.ToString();

        }
    }
}
