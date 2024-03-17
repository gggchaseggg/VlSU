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

namespace GrachevDaniilPRI120Lab15
{
    public partial class Form1 : Form
    {

        // отсчет времени
        float global_time = 0; // массив с параметрами установки камеры
        private float[,] camera_date = new float[5, 7];
        private bool isOgorod = false;

        // экземпляра класса Explosion
        private Explosion BOOOOM_1 = new Explosion(1, 10, 1, 500, 1000);

        public Form1()
        {

            InitializeComponent();
            AnT.InitializeContexts();
        }

        // генератор случайны чисел
        Random rnd = new Random();


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация OpenGL
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // инициализация библиотеки OpenIL
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            // установка начальных значений элементов comboBox
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;

            // позиция камеры 1:

            camera_date[0, 0] = -3;
            camera_date[0, 1] = 0;
            camera_date[0, 2] = -20;
            camera_date[0, 3] = 0;
            camera_date[0, 4] = 1;
            camera_date[0, 5] = 0;
            camera_date[0, 6] = 0;

            // позиция камеры 2:

            camera_date[1, 0] = -3;
            camera_date[2, 1] = 2;
            camera_date[1, 2] = -20;
            camera_date[1, 3] = 30;
            camera_date[1, 4] = 1;
            camera_date[1, 5] = 0;
            camera_date[1, 6] = 0;

            // позиция камеры 3:

            camera_date[2, 0] = -3;
            camera_date[2, 1] = 2;
            camera_date[2, 2] = -20;
            camera_date[2, 3] = 30;
            camera_date[2, 4] = 1;
            camera_date[2, 5] = 1;
            camera_date[2, 6] = 0;

            // позиция камеры 4:

            camera_date[3, 0] = -4;
            camera_date[3, 1] = -4;
            camera_date[3, 2] = -20;
            camera_date[3, 3] = 180;
            camera_date[3, 4] = 1;
            camera_date[3, 5] = 1;
            camera_date[3, 6] = 0;

            // позиция камеры 5:

            camera_date[4, 0] = -5;
            camera_date[4, 1] = 5;
            camera_date[4, 2] = -20;
            camera_date[4, 3] = 90;
            camera_date[4, 4] = 1;
            camera_date[4, 5] = 0;
            camera_date[4, 6] = 0;

            // активация таймера
            RenderTimer.Start();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // отсчитываем время
            global_time += (float)RenderTimer.Interval / 1000;
            // вызываем функцию отрисовки
            switch (isOgorod)
            {
                case false:
                    {
                        Draw();
                        break;
                    }
                case true:
                    {
                        Draw();
                        DrawOgorod();
                        break;
                    }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isOgorod = false;
            Model = null;
            Random rnd = new Random();
            // устанавливаем новые координаты взрыва
            BOOOOM_1.SetNewPosition(rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5));
            // случайную силу
            BOOOOM_1.SetNewPower(rnd.Next(20, 80));
            // и активируем сам взрыв
            BOOOOM_1.Boooom(global_time);
        }


        double a = 0, b = -0.575, c = -8.5, d = -61, zoom = 1; // выбранные оси
        int os_x = 1, os_y = 0, os_z = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isOgorod && Model == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) 
                { 
                    Model = new anModelLoader();
                    Model.LoadModel(openFileDialog1.FileName);
                    isOgorod = true;
                }
            } else
            {
                Model = null;
                //isOgorod = false;
            }
        }

        anModelLoader Model = null;

        private void DrawOgorod()
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

        // функция отрисовки сцены
        private void Draw()
        {
            // в зависимсоти от установленного режима отрисовываем сцену в черном или белом цвете
            if (comboBox2.SelectedIndex == 0)
            {
                // цвет очистки окна
                Gl.glClearColor(255, 255, 255, 1);
            }
            else
            {
                Gl.glClearColor(0, 0, 0, 1);
            }

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            // в зависимсоти от установленного режима отрисовываем сцену в черном или белом цвете
            if (comboBox2.SelectedIndex == 0)
            {
                // цвет рисования
                Gl.glColor3d(0, 0, 0);
            }
            else
            {
                Gl.glColor3d(255, 255, 255);
            }

            Gl.glPushMatrix();

            // определяем установленную камеру
            int camera = comboBox1.SelectedIndex;

            // используем параметры для установленной камеры
            Gl.glTranslated(camera_date[camera, 0], camera_date[camera, 1], camera_date[camera, 2]);
            Gl.glRotated(camera_date[camera, 3], camera_date[camera, 4], camera_date[camera, 5], camera_date[camera, 6]);

            Gl.glPushMatrix();

            // отрисовываем сеточную плоскость, которая нам будет напоминать где находится земля
            DrawMatrix(10);

            // выполняем просчет взрыва
            BOOOOM_1.Calculate(global_time);

            Gl.glPopMatrix();

            Gl.glPopMatrix();
            Gl.glFlush();

            // обновляем окно
            AnT.Invalidate();
        }

        // функция для отрисовки матрицы
        private void DrawMatrix(int x)
        {
            float quad_size = 1;

            // две последовательные линии после пересечения создадут "матрицу", чтобы мы могли понимать где находится земля
            Gl.glBegin(Gl.GL_LINES);

            for (int ax = 0; ax < x + 1; ax++)
            {
                Gl.glVertex3d(quad_size * ax, 0, 0);
                Gl.glVertex3d(quad_size * ax, 0, quad_size * x);
            }

            for (int bx = 0; bx < x + 1; bx++)
            {
                Gl.glVertex3d(0, 0, quad_size * bx);
                Gl.glVertex3d(quad_size * x, 0, quad_size * bx);
            }

            Gl.glEnd();
        }

    }
}
