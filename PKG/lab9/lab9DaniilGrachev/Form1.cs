using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace lab9DaniilGrachev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private float[,] GeomObject = new float[32, 3];
        private int count_elements = 0;

        private float[,] GeomObject2 = new float[32, 3];
        private int count_elements2 = 0;

        private float[,] GeomObject3 = new float[32, 3];
        private int count_elements3 = 0;

        private void createDot(float x, float y, int index)
        {
            if (index == 1) {
                GeomObject[count_elements, 0] = x / 5f;
                GeomObject[count_elements, 1] = y / 5f;
                count_elements++;
                return;
            }

            if (index == 2)
            {
                GeomObject2[count_elements2, 0] = x / 5f;
                GeomObject2[count_elements2, 1] = y / 5f;
                count_elements2++;
                return;
            }

            if (index == 3)
            {
                GeomObject3[count_elements3, 0] = x / 5f;
                GeomObject3[count_elements3, 1] = y / 5f;
                count_elements3++;
                return;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            createDot(-7, -9, 1);
            createDot(7, -9, 1);
            createDot(7, -6, 1);
            createDot(4, -6, 1);
            createDot(4, -3, 1);
            createDot(7, -3, 1);
            createDot(7, 4, 1);
            createDot(3, 4, 1);
            createDot(3, 6, 1);
            createDot(7, 6, 1);
            createDot(7, 10, 1);
            createDot(-3, 10, 1);
            createDot(-3.7f, 9.8f, 1);
            createDot(-4.35f, 9.35f, 1);
            createDot(-4.8f, 8.7f, 1);
            createDot(-5, 8, 1);
            createDot(-5, 0, 1);
            createDot(-7, 0, 1);
            createDot(-7, -3, 1);
            createDot(-4, -3, 1);
            createDot(-4, -6, 1);
            createDot(-7, -6, 1);

            createDot(-1, -6, 2);
            createDot(1, -6, 2);
            createDot(1, 2, 2);
            createDot(-1, 2, 2);

            createDot(-4, 7, 3);
            createDot(-3.5f, 8.5f, 3);
            createDot(-2, 9, 3);
            createDot(-0.5f, 8.5f, 3);
            createDot(0, 7, 3);
            createDot(-0.5f, 5.5f, 3);
            createDot(-2, 5, 3);
            createDot(-3.5f, 5.5f, 3);

            comboBox1.SelectedIndex = 0;
            RenderTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // функция масштабирования
        private void CreateZoom(float coef, int os)
        {
            // создаем матрицу
            float[,] Zoom2D = new float[3, 3];
            Zoom2D[0, 0] = 1;
            Zoom2D[1, 0] = 0;
            Zoom2D[2, 0] = 0;

            Zoom2D[0, 1] = 0;
            Zoom2D[1, 1] = 1;
            Zoom2D[2, 1] = 0;

            Zoom2D[0, 2] = 0;
            Zoom2D[1, 2] = 0;
            Zoom2D[2, 2] = 1;

            // устанавливаем коэфицент масштабирования для необходимой (выбранной и переданной в качестве параметра) оси
            Zoom2D[os, os] = coef;

            // вызываем функцию для выполнения умножения матрицы
            // координт вершин геометрического объекта
            // на созданную в данной функции матрицу
            multiply2(GeomObject, Zoom2D);
            multiply2(GeomObject2, Zoom2D);
            multiply2(GeomObject3, Zoom2D);
        }

        // функция переноса
        private void CreateTranslate(float translate, int os)
        {
            // создаем матрицу
            float[,] Tran2D = new float[4, 4];
            Tran2D[0, 0] = 1;
            Tran2D[1, 0] = 0;
            Tran2D[2, 0] = 0;
            Tran2D[3, 0] = 0;

            Tran2D[0, 1] = 0;
            Tran2D[1, 1] = 1;
            Tran2D[2, 1] = 0;
            Tran2D[3, 1] = 0;

            Tran2D[0, 2] = 0;
            Tran2D[1, 2] = 0;
            Tran2D[2, 2] = 1;
            Tran2D[3, 3] = 0;

            Tran2D[0, 3] = 0;
            Tran2D[1, 3] = 0;
            Tran2D[2, 3] = 0;
            Tran2D[3, 3] = 1;

            Tran2D[os, 3] = translate;

            multiply(GeomObject, Tran2D);
            multiply(GeomObject2, Tran2D);
            multiply(GeomObject3, Tran2D);
        }

        // реализация поворота
        private void CreateRotate(float angle)
        {

            int os = comboBox1.SelectedIndex;
            float[,] Rotate2D = new float[3, 3];


            switch (os)
            {
                case 0:
                    Rotate2D[0, 0] = 1;
                    Rotate2D[1, 0] = 0;
                    Rotate2D[2, 0] = 0;

                    Rotate2D[0, 1] = 0;
                    Rotate2D[1, 1] = (float)Math.Cos(angle);
                    Rotate2D[2, 1] = (float)Math.Sin(angle);

                    Rotate2D[0, 2] = 0;
                    Rotate2D[1, 2] = (float)-Math.Sin(angle);
                    Rotate2D[2, 2] = (float)Math.Cos(angle);
                    break;
                case 1:
                    Rotate2D[0, 0] = (float)Math.Cos(angle);
                    Rotate2D[1, 0] = 0;
                    Rotate2D[2, 0] = (float)-Math.Sin(angle);

                    Rotate2D[0, 1] = 0;
                    Rotate2D[1, 1] = 1;
                    Rotate2D[2, 1] = 0;

                    Rotate2D[0, 2] = (float)Math.Sin(angle);
                    Rotate2D[1, 2] = 0;
                    Rotate2D[2, 2] = (float)Math.Cos(angle);
                    break;
                case 2:
                    Rotate2D[0, 0] = (float)Math.Cos(angle);
                    Rotate2D[1, 0] = (float)-Math.Sin(angle);
                    Rotate2D[2, 0] = 0;

                    Rotate2D[0, 1] = (float)Math.Sin(angle);
                    Rotate2D[1, 1] = (float)Math.Cos(angle);
                    Rotate2D[2, 1] = 0;

                    Rotate2D[0, 2] = 0;
                    Rotate2D[1, 2] = 0;
                    Rotate2D[2, 2] = 1;
                    break;
            }

            // вызываем функцию для выполнения умножения матрицы
            // координт вершин геометрического объекта
            // на созданную в данной функции матрицу
            multiply2(GeomObject, Rotate2D);
            multiply2(GeomObject2, Rotate2D);
            multiply2(GeomObject3, Rotate2D);
        }

        private void multiply(float[,] obj, float[,] matrix)
        {
            float res_1, res_2, res_3;

            for (int ax = 0; ax < count_elements; ax++)
            {
                res_1 = (obj[ax, 0] * matrix[0, 0] + obj[ax, 1] * matrix[0, 1] + obj[ax, 2] * matrix[0, 2] + matrix[0, 3]);
                res_2 = (obj[ax, 0] * matrix[1, 0] + obj[ax, 1] * matrix[1, 1] + obj[ax, 2] * matrix[1, 2] + matrix[1, 3]);
                res_3 = (obj[ax, 0] * matrix[2, 0] + obj[ax, 1] * matrix[2, 1] + obj[ax, 2] * matrix[2, 2] + matrix[2, 3]);

                obj[ax, 0] = res_1;
                obj[ax, 1] = res_2;
                obj[ax, 2] = res_3;
            }

        }

        private void multiply2(float[,] obj, float[,] matrix)
        {
            float res_1, res_2, res_3;

            for (int ax = 0; ax < count_elements; ax++)
            {
                res_1 = (obj[ax, 0] * matrix[0, 0] + obj[ax, 1] * matrix[0, 1] + obj[ax, 2] * matrix[0, 2]);
                res_2 = (obj[ax, 0] * matrix[1, 0] + obj[ax, 1] * matrix[1, 1] + obj[ax, 2] * matrix[1, 2]);
                res_3 = (obj[ax, 0] * matrix[2, 0] + obj[ax, 1] * matrix[2, 1] + obj[ax, 2] * matrix[2, 2]);

                obj[ax, 0] = res_1;
                obj[ax, 1] = res_2;
                obj[ax, 2] = res_3;
            }

        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // обработка "тика" таймера - вызов функции отрисовки
            Draw();
        }

        // функция отрисовки
        private void Draw()
        {
            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы
            Gl.glLoadIdentity();

            // установка черного цвета
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц
            Gl.glPushMatrix();

            // перемещаем камеру для лучшего обзора объекта
            Gl.glTranslated(0, 0, -7);

            // помещаем состояние матрицы в стек матриц
            Gl.glPushMatrix();

            // начинаем отрисовку объекта
            Gl.glBegin(Gl.GL_LINE_LOOP);

            // геометрические данные ме берем из массива GeomObject
            // рисуем объект с помощью замкнутой линии (координата z=0)

            for (int i = 0; i < count_elements; i++)
            {
                Gl.glVertex3d(GeomObject[i, 0], GeomObject[i, 1], GeomObject[i, 2]);
            }

            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);

            for (int i = 0; i < count_elements2; i++)
            {
                Gl.glVertex3d(GeomObject2[i, 0], GeomObject2[i, 1], GeomObject2[i, 2]);
            }

            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);

            for (int i = 0; i < count_elements3; i++)
            {
                Gl.glVertex3d(GeomObject3[i, 0], GeomObject3[i, 1], GeomObject3[i, 2]);
            }

            // завершаем отрисовку примитивов
            Gl.glEnd();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // отрисовываем геометрию
            Gl.glFlush();

            // обновляем состояние элемента
            AnT.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // устанавливаем фокус в AnT
            AnT.Focus();
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            // Z и X отвечают за зум
            if (e.KeyCode == Keys.Z)
            {
                CreateZoom(0.5f, comboBox1.SelectedIndex);
            }
            else if (e.KeyCode == Keys.X)
            {
                CreateZoom(2, comboBox1.SelectedIndex);
            }

            // W и S отвечают за перенос
            else if (e.KeyCode == Keys.W)
            {
                CreateTranslate(0.15f, comboBox1.SelectedIndex);
            }
            else if (e.KeyCode == Keys.S)
            {
                CreateTranslate(-0.15f, comboBox1.SelectedIndex);
            } 

            // A и D отвечают за поворот
            else if (e.KeyCode == Keys.A)
            {
                CreateRotate((float)Math.PI / 32);
            }
            else if (e.KeyCode == Keys.D)
            {
                CreateRotate((float)-Math.PI / 32);
            }
        }
    }
}
