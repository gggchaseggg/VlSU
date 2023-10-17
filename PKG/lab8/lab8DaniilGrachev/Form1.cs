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

namespace lab8DaniilGrachev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        // массив, в который будут заносится управляющие точки
        private float[,] DrawingArray = new float[64, 2]; // количество точек
        private float[,] DrawingArray1 = new float[9, 2]; // круг
        private float[,] DrawingArray2 = new float[16, 2]; // прямоугольник
        private int count_points = 0;
        private int count_points1 = 0;
        private int count_points2 = 0;
        bool isHidden = false;

        // размеры окна
        double ScreenW, ScreenH;

        // отношения сторон окна визуализации
        // для корректного перевода координат мыши в координаты,
        // принятые в программе

        private float devX;
        private float devY;

        // вспомогательные переменные для построения линий от курсора мыши к координатным осям
        float lineX, lineY;

        // текущение координаты курсора мыши
        float Mcoord_X = 0, Mcoord_Y = 0;

        /*
        * Состояние захвата вершины мышью (при редактированиее)
        */

        // -1 означает, что нет захваченой вершины,
        // иначе номер указывает на элемент массива, хранящий захваченную вершину
        int captured = -1;


        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация бибилиотеки glut
            Glut.glutInit();
            // инициализация режима экрана
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA)
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы
            Gl.glLoadIdentity();

            // определение параметров настройки проекции, в зависимости от размеров сторон элемента AnT.
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 500.0;
                ScreenH = 500.0 * (float)AnT.Height / (float)AnT.Width;

                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 500.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 500.0;

                Glu.gluOrtho2D(0.0, 500.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 500.0);
            }

            // сохранение коэфицентов, которые нам необходимы для перевода
            // координат указателя в оконной системе, в координаты,
            // принятые в нашей OpenGL сцене
            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            // установка объектно-видовой матрицы
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            RenderTimer.Start();

            comboBox1.SelectedIndex = 0;
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            // если мы находимся в режиме создания сплайна
            if (comboBox1.SelectedIndex == 0)
            {
                // забираем координаты мыши
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                // приводим к нужному нам формату в соотвествии с настройками проекции
                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                // создаем новую контрольную точку
                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;

                // и увеличиваем значение счетчика контрольных точек
                count_points++;
            }
        }

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            // если режим редактирования сплайна
            if (comboBox1.SelectedIndex == 1)
            {
                // получаем и преобразовываем координаты нажатия
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                // проходим циклом по всем установленным контрольным точкам
                for (int ax = 0; ax < count_points; ax++)
                {
                    // если точка попадает под курсор
                    if (lineX < DrawingArray[ax, 0] + 5 && lineX > DrawingArray[ax, 0] - 5 && lineY < DrawingArray[ax, 1] + 5 && lineY > DrawingArray[ax, 1] - 5)
                    {
                        // отмечаем ее как захваченную (записываем ее индекс в массив captured)
                        captured = ax;
                        // останавливаем цикл, мы нашли нужную точку
                        break;
                    }
                }
            }
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            // отмечаем, что нет захваченной точки
            captured = -1;
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            // если установлен режим создания сплайна
            if (comboBox1.SelectedIndex == 0)
            {
                // сохраняем координаты мыши
                Mcoord_X = e.X;
                Mcoord_Y = e.Y; // вычисляем параметры для будующей дорисовки линий от указателя мыши к координатным осям.
                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                // текущая (интерактивная) точка, добавляемая к уже установленным - непрерывно изменяется от движения
                // мыши и создает эффект интерактивности и наглядности приложения
                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;
            }
            else
            {
                // обычное протоколирование координат для подсвечивания вершины в случае наведения
                // сохраняем координаты мыши
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                // вычисляем параметры для будующей дорисовки линий от указателя мыши к координатным осям

                float _lastX = lineX;
                float _lastY = lineY;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                // если точка захвачена (т.е. пользователь удерживает кнопку мыши)
                if (captured != -1)
                {
                    // то мы вносим разницу с последними координатами курсора
                    // другими словами перемещаем захваченную точку
                    DrawingArray[captured, 0] -= _lastX - lineX;
                    DrawingArray[captured, 1] -= _lastY - lineY;
                }
            }
        }

        private void addSingleDot(float x, float y)
        {
            float scale = 23;

            DrawingArray[count_points, 0] = x * scale;
            DrawingArray[count_points, 1] = y * scale;
            count_points++;
        }

        private void addSingleDot1(float x, float y)
        {
            float scale = 23;

            DrawingArray1[count_points1, 0] = x * scale;
            DrawingArray1[count_points1, 1] = y * scale;
            count_points1++;
        }

        private void addSingleDot2(float x, float y)
        {
            float scale = 23;

            DrawingArray2[count_points2, 0] = x * scale;
            DrawingArray2[count_points2, 1] = y * scale;
            count_points2++;
        }

        private void addDot(float x, float y, string variant)
        {
            switch(variant)
            {
                case "left-top":
                    {
                        addSingleDot(x - 0.24f, y);
                        addSingleDot(x, y);
                        addSingleDot(x, y + 0.24f);
                        break;
                    }
                case "down-left":
                    {
                        addSingleDot(x, y - 0.24f);
                        addSingleDot(x, y);
                        addSingleDot(x - 0.24f, y);
                        break;
                    }
                case "right-top":
                    {
                        addSingleDot(x + 0.24f, y);
                        addSingleDot(x, y);
                        addSingleDot(x, y + 0.24f);
                        break;
                    }
                case "down-right":
                    {
                        addSingleDot(x, y - 0.24f);
                        addSingleDot(x, y);
                        addSingleDot(x + 0.24f, y);
                        break;
                    }
                case "right-down":
                    {
                        addSingleDot(x + 0.24f, y);
                        addSingleDot(x, y);
                        addSingleDot(x, y - 0.24f);
                        break;
                    }
                case "top-left":
                    {
                        addSingleDot(x, y + 0.24f);
                        addSingleDot(x, y);
                        addSingleDot(x - 0.24f, y );
                        break;
                    }
                case "top-right":
                    {
                        addSingleDot(x, y + 0.24f);
                        addSingleDot(x, y);
                        addSingleDot(x + 0.24f, y);
                        break;
                    }
                case "left-down":
                    {
                        addSingleDot(x - 0.24f, y);
                        addSingleDot(x, y);
                        addSingleDot(x, y - 0.24f);
                        break;
                    }
            }
            
        }

        private void addDot2(float x, float y, string variant)
        {
            switch (variant)
            {
                case "left-top":
                    {
                        addSingleDot2(x - 0.24f, y);
                        addSingleDot2(x, y);
                        addSingleDot2(x, y + 0.24f);
                        break;
                    }
                case "down-left":
                    {
                        addSingleDot2(x, y - 0.24f);
                        addSingleDot2(x, y);
                        addSingleDot2(x - 0.24f, y);
                        break;
                    }
                case "right-top":
                    {
                        addSingleDot2(x + 0.24f, y);
                        addSingleDot2(x, y);
                        addSingleDot2(x, y + 0.24f);
                        break;
                    }
                case "down-right":
                    {
                        addSingleDot2(x, y - 0.24f);
                        addSingleDot2(x, y);
                        addSingleDot2(x + 0.24f, y);
                        break;
                    }
                case "right-down":
                    {
                        addSingleDot2(x + 0.24f, y);
                        addSingleDot2(x, y);
                        addSingleDot2(x, y - 0.24f);
                        break;
                    }
                case "top-left":
                    {
                        addSingleDot2(x, y + 0.24f);
                        addSingleDot2(x, y);
                        addSingleDot2(x - 0.24f, y);
                        break;
                    }
                case "top-right":
                    {
                        addSingleDot2(x, y + 0.24f);
                        addSingleDot2(x, y);
                        addSingleDot2(x + 0.24f, y);
                        break;
                    }
                case "left-down":
                    {
                        addSingleDot2(x - 0.24f, y);
                        addSingleDot2(x, y);
                        addSingleDot2(x, y - 0.24f);
                        break;
                    }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSingleDot(1, 1);
            addSingleDot(0.76f, 1);
            addSingleDot(1.24f, 1);

            addDot(15, 1, "left-top");
            addDot(15, 4, "down-left");
            addDot(12, 4, "right-top");
            addDot(12, 7, "down-right");
            addDot(15, 7, "left-top");
            addDot(15, 14, "down-left");
            addDot(11, 14, "right-top");
            addDot(11, 16, "down-right");
            addDot(15, 16, "left-top");
            addDot(15, 20, "down-left");

            addSingleDot(6.5f, 20);
            addSingleDot(3, 20);
            addSingleDot(3, 16.5f);

            addDot(3, 10, "top-left");
            addDot(1, 10, "right-down");
            addDot(1, 7, "top-right");
            addDot(4, 7, "left-down");
            addDot(4, 4, "top-left");
            addDot(1, 4, "right-down");
            addDot(1, 1, "top-right");


            addSingleDot1(6, 17.5f);
            addSingleDot1(6, 15);
            addSingleDot1(4, 17);
            addSingleDot1(6, 19);
            addSingleDot1(8, 17);
            addSingleDot1(6,15);
            addSingleDot1(4, 17);
            addSingleDot1(6, 19);

            addSingleDot2(8, 4);
            addSingleDot2(6.5f, 4);
            addSingleDot2(8.24f, 4);

            addDot2(9, 4, "left-top");
            addDot2(9, 12, "down-left");
            addDot2(7, 12, "right-down");
            addDot2(7, 4, "top-right");

        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {

            // обработка "тика" таймера - вызов функции отрисовки
            Draw();
            Draw1();
            Draw2();
            AnT.Invalidate();

        }

        // функция визуализации текста
        private void PrintText2D(float x, float y, string text)
        {
            // устанавливаем позицию вывода растровых символов
            // в переданных координатах x и y.
            Gl.glRasterPos2f(x, y);

            // в цикле foreach перебираем значения из массива text,
            // который содержит значение строки для визуализации
            foreach (char char_for_draw in text)
            {
                // визуализируем символ с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15.
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, char_for_draw);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isHidden = !isHidden;
        }

        // функция отрисовки, вызываемая событием таймера
        private void Draw()
        {
            // количество сегментов при расчете сплайна
            int N = 30; // вспомогательные переменные для расчета сплайна
            double X, Y;

            // n = count_points+1 означает что мы берем все созданные контрольные
            // точки + ту, которая следует за мышью, для создания интерактивности приложения
            int eps = 4, i, j, n = count_points + 1, first;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;

            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы
            Gl.glLoadIdentity();

            // установка черного цвета
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц
            Gl.glPushMatrix();

            Gl.glPointSize(5.0f);
            Gl.glBegin(Gl.GL_POINTS);

            Gl.glVertex2d(0, 0);

            Gl.glEnd();
            Gl.glPointSize(1.0f);

            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y).ToString() + "]");


            // выполняем перемещение в прострастве по осям X и Y

            // выполняем цикл по контрольным точкам
            for (i = 0; i < n; i++)
            {
                // сохраняем координаты точки (более легкое представления кода)
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];

                // если точка выделена (перетаскивается мышью)
                if (i == captured)
                {
                    // для ее отрисовки будут использоватся более толстые линии
                    Gl.glLineWidth(3.0f);
                }

                if (!isHidden)
                {
                    // начинаем отрисовку точки (квадрат)
                    Gl.glBegin(Gl.GL_LINE_LOOP);

                    Gl.glVertex2d(X - eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y + eps);
                    Gl.glVertex2d(X - eps, Y + eps);

                    Gl.glEnd();
                }

                

                // если была захваченная точка - необходимо вернуть толщину линий
                if (i == captured)
                {
                    // возвращаем прежнее значение
                    Gl.glLineWidth(1.0f);
                }
            }


            // дополнительный цикл по всем контрольным точкам -
            // подписываем их координаты и номер
            for (i = 0; i < n; i++)
            {
                // координаты точки
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];
                // выводим подпись рядом с точкой
                if (!isHidden)
                {
                    PrintText2D((float)(X - 20), (float)(Y - 20), "P " + i.ToString() + ": " + X.ToString() + ", " + Y.ToString());
                }
                
            }

            // начинает отрисовку кривой
            Gl.glBegin(Gl.GL_LINE_STRIP);

            // используем все точки -1 (т,к. алгоритм "зацепит" i+1 точку)
            for (i = 1; i < n - 1; i++)
            {
                // реализация представленного в теоретическом описании алгоритма для калькуляции сплайна
                first = 1;
                xA = DrawingArray[i - 1, 0];
                xB = DrawingArray[i, 0];
                xC = DrawingArray[i + 1, 0];
                xD = DrawingArray[i + 2, 0];

                yA = DrawingArray[i - 1, 1];
                yB = DrawingArray[i, 1];
                yC = DrawingArray[i + 1, 1];
                yD = DrawingArray[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;

                a2 = (xA - 2 * xB + xC) / 2.0;

                a1 = (xC - xA) / 2.0;

                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;

                b2 = (yA - 2 * yB + yC) / 2.0;

                b1 = (yC - yA) / 2.0;

                b0 = (yA + 4 * yB + yC) / 6.0;

                // отрисовка сегментов

                for (j = 0; j <= N; j++)
                {
                    // параметр t на отрезке от 0 до 1
                    t = (double)j / (double)N;

                    // генерация координат
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    // и установка вершин
                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex2d(X, Y);
                    }
                    else
                        Gl.glVertex2d(X, Y);
                }
            }
            Gl.glEnd();


            // завершаем рисование
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию
            //AnT.Invalidate();

        }

        private void Draw1()
        {
            // количество сегментов при расчете сплайна
            int N = 30; // вспомогательные переменные для расчета сплайна
            double X, Y;

            // n = count_points+1 означает что мы берем все созданные контрольные
            // точки + ту, которая следует за мышью, для создания интерактивности приложения
            int eps = 4, i, j, n = count_points1, first;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;


            // выполняем цикл по контрольным точкам
            for (i = 0; i < n; i++)
            {
                // сохраняем координаты точки (более легкое представления кода)
                X = DrawingArray1[i, 0];
                Y = DrawingArray1[i, 1];

                if (!isHidden) { 

                    // начинаем отрисовку точки (квадрат)
                    Gl.glBegin(Gl.GL_LINE_LOOP);

                    Gl.glVertex2d(X - eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y + eps);
                    Gl.glVertex2d(X - eps, Y + eps);

                    Gl.glEnd();
                }
            }


            // дополнительный цикл по всем контрольным точкам -
            // подписываем их координаты и номер
            for (i = 0; i < n; i++)
            {
                // координаты точки
                X = DrawingArray1[i, 0];
                Y = DrawingArray1[i, 1];
                // выводим подпись рядом с точкой
                if(!isHidden) PrintText2D((float)(X - 20), (float)(Y - 20), "P1 " + i.ToString() + ": " + X.ToString() + ", " + Y.ToString());
            }

            // начинает отрисовку кривой
            Gl.glBegin(Gl.GL_LINE_STRIP);

            // используем все точки -1 (т,к. алгоритм "зацепит" i+1 точку)
            for (i = 1; i < n - 2; i++)
            {
                // реализация представленного в теоретическом описании алгоритма для калькуляции сплайна
                first = 1;
                xA = DrawingArray1[i - 1, 0];
                xB = DrawingArray1[i, 0];
                xC = DrawingArray1[i + 1, 0];
                xD = DrawingArray1[i + 2, 0];

                yA = DrawingArray1[i - 1, 1];
                yB = DrawingArray1[i, 1];
                yC = DrawingArray1[i + 1, 1];
                yD = DrawingArray1[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;

                a2 = (xA - 2 * xB + xC) / 2.0;

                a1 = (xC - xA) / 2.0;

                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;

                b2 = (yA - 2 * yB + yC) / 2.0;

                b1 = (yC - yA) / 2.0;

                b0 = (yA + 4 * yB + yC) / 6.0;

                // отрисовка сегментов

                for (j = 0; j <= N; j++)
                {
                    // параметр t на отрезке от 0 до 1
                    t = (double)j / (double)N;

                    // генерация координат
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    // и установка вершин
                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex2d(X, Y);
                    }
                    else
                        Gl.glVertex2d(X, Y);
                }
            }
            Gl.glEnd();


            // завершаем рисование
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию
            //AnT.Invalidate();

        }

        private void Draw2()
        {
            // количество сегментов при расчете сплайна
            int N = 30; // вспомогательные переменные для расчета сплайна
            double X, Y;

            // n = count_points+1 означает что мы берем все созданные контрольные
            // точки + ту, которая следует за мышью, для создания интерактивности приложения
            int eps = 4, i, j, n = count_points2, first;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;

            // выполняем перемещение в прострастве по осям X и Y

            // выполняем цикл по контрольным точкам
            for (i = 0; i < n; i++)
            {
                // сохраняем координаты точки (более легкое представления кода)
                X = DrawingArray2[i, 0];
                Y = DrawingArray2[i, 1];

                // если точка выделена (перетаскивается мышью)
                if (i == captured)
                {
                    // для ее отрисовки будут использоватся более толстые линии
                    Gl.glLineWidth(3.0f);
                }

                if (!isHidden) { 
                    // начинаем отрисовку точки (квадрат)
                    Gl.glBegin(Gl.GL_LINE_LOOP);

                    Gl.glVertex2d(X - eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y - eps);
                    Gl.glVertex2d(X + eps, Y + eps);
                    Gl.glVertex2d(X - eps, Y + eps);

                    Gl.glEnd();
                }

                // если была захваченная точка - необходимо вернуть толщину линий
                if (i == captured)
                {
                    // возвращаем прежнее значение
                    Gl.glLineWidth(1.0f);
                }
            }


            // дополнительный цикл по всем контрольным точкам -
            // подписываем их координаты и номер
            for (i = 0; i < n; i++)
            {
                // координаты точки
                X = DrawingArray2[i, 0];
                Y = DrawingArray2[i, 1];
                // выводим подпись рядом с точкой
                if (!isHidden) PrintText2D((float)(X - 20), (float)(Y - 20), "P2 " + i.ToString() + ": " + X.ToString() + ", " + Y.ToString());
            }

            // начинает отрисовку кривой
            Gl.glBegin(Gl.GL_LINE_STRIP);

            // используем все точки -1 (т,к. алгоритм "зацепит" i+1 точку)
            for (i = 1; i < n - 2; i++)
            {
                // реализация представленного в теоретическом описании алгоритма для калькуляции сплайна
                first = 1;
                xA = DrawingArray2[i - 1, 0];
                xB = DrawingArray2[i, 0];
                xC = DrawingArray2[i + 1, 0];
                xD = DrawingArray2[i + 2, 0];

                yA = DrawingArray2[i - 1, 1];
                yB = DrawingArray2[i, 1];
                yC = DrawingArray2[i + 1, 1];
                yD = DrawingArray2[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;

                a2 = (xA - 2 * xB + xC) / 2.0;

                a1 = (xC - xA) / 2.0;

                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;

                b2 = (yA - 2 * yB + yC) / 2.0;

                b1 = (yC - yA) / 2.0;

                b0 = (yA + 4 * yB + yC) / 6.0;

                // отрисовка сегментов

                for (j = 0; j <= N; j++)
                {
                    // параметр t на отрезке от 0 до 1
                    t = (double)j / (double)N;

                    // генерация координат
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    // и установка вершин
                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex2d(X, Y);
                    }
                    else
                        Gl.glVertex2d(X, Y);
                }
            }
            Gl.glEnd();


            // завершаем рисование
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию
            //AnT.Invalidate();

        }
    }
}
