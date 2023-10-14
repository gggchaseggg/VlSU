using System;
using System.Windows.Forms;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;
using System.Reflection.Emit;

namespace lab5DaniilGrachev
{
    public partial class Form1 : Form
    {

        double ScreenW, ScreenH;
        private float devX;
        private float devY;
        private float[,] GrapValuesArray;
        private int elements_count = 0;
        private bool not_calculate = true;
        private int pointPosition = 0;
        float lineX, lineY;
        float Mcoord_X = 0, Mcoord_Y = 0;

        bool isFunctionsDisplay = false;
        bool isTriDisplay = false;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {
            if (isFunctionsDisplay) { 
                if (pointPosition == elements_count - 1) pointPosition = 0;

                Draw();

                pointPosition++;
            }
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;

            lineX = devX * e.X;
            lineY = (float)(ScreenH - devY * e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 30.0;
                ScreenH = 30.0 * (float)AnT.Height / (float)AnT.Width;
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Height / (float)AnT.Width, 0.0, 30.0);
            } else {
                ScreenW = 30.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 30.0;
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // настройка параметров OpenGL для визуализации
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            PointInGrap.Start();
            RenderTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isFunctionsDisplay = false;
            isTriDisplay = false;
            // очищаем буфер цвета и глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // очищаем текущую матрицу
            Gl.glLoadIdentity();
            // устанавливаем текущий цвет - красный
            Gl.glColor3d(0.16, 0.67, 0.53);
            Gl.glLineWidth((float)1.3);

            // Г
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(1, 29);
            Gl.glVertex2d(1, 23);
            Gl.glVertex2d(2, 23);
            Gl.glVertex2d(2, 28);
            Gl.glVertex2d(5, 28);
            Gl.glVertex2d(5, 29);
            Gl.glEnd();

            // Р
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(6, 29);
            Gl.glVertex2d(6, 23);
            Gl.glVertex2d(7, 23);
            Gl.glVertex2d(7, 26);
            Gl.glVertex2d(9, 26);
            Gl.glVertex2d(9, 29);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(7, 28);
            Gl.glVertex2d(7, 27);
            Gl.glVertex2d(8, 27);
            Gl.glVertex2d(8, 28);
            Gl.glEnd();

            // А
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(10, 23);
            Gl.glVertex2d(11, 29);
            Gl.glVertex2d(13, 29);
            Gl.glVertex2d(14, 23);
            Gl.glVertex2d(13, 23);
            Gl.glVertex2d(12.5, 25);
            Gl.glVertex2d(11.5, 25);
            Gl.glVertex2d(11, 23);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(11.5, 26);
            Gl.glVertex2d(12.5, 26);
            Gl.glVertex2d(12, 28);
            Gl.glEnd();

            // Ч
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(15, 29);
            Gl.glVertex2d(15, 26);
            Gl.glVertex2d(17, 26);
            Gl.glVertex2d(17, 23);
            Gl.glVertex2d(18, 23);
            Gl.glVertex2d(18, 29);
            Gl.glVertex2d(17, 29);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(16, 27);
            Gl.glVertex2d(16, 29);
            Gl.glEnd();

            // Е
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(19, 29);
            Gl.glVertex2d(19, 23);
            Gl.glVertex2d(22, 23);
            Gl.glVertex2d(22, 24);
            Gl.glVertex2d(20, 24);
            Gl.glVertex2d(20, 26);
            Gl.glVertex2d(22, 26);
            Gl.glVertex2d(22, 27);
            Gl.glVertex2d(20, 27);
            Gl.glVertex2d(20, 28);
            Gl.glVertex2d(22, 28);
            Gl.glVertex2d(22, 29);
            Gl.glEnd();

            // В
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(23, 29);
            Gl.glVertex2d(23, 23);
            Gl.glVertex2d(26, 23);
            Gl.glVertex2d(26, 26);
            Gl.glVertex2d(24, 26);
            Gl.glVertex2d(24, 24);
            Gl.glVertex2d(25, 24);
            Gl.glVertex2d(25, 28);
            Gl.glVertex2d(24, 28);
            Gl.glVertex2d(24, 26);
            Gl.glVertex2d(25.5, 26);
            Gl.glVertex2d(25.5, 29);
            Gl.glEnd();

            // Д.
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(28, 23);
            Gl.glVertex2d(27, 24);
            Gl.glVertex2d(27, 25);
            Gl.glVertex2d(28.3, 25);
            Gl.glVertex2d(29, 29);
            Gl.glVertex2d(31, 29);
            Gl.glVertex2d(31.7, 25);
            Gl.glVertex2d(33, 25);
            Gl.glVertex2d(33, 24);
            Gl.glVertex2d(32, 23);
            Gl.glVertex2d(31, 23);
            Gl.glVertex2d(31.5, 24);
            Gl.glVertex2d(28.5, 24);
            Gl.glVertex2d(29, 23);
            Gl.glEnd();
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(29.5, 25);
            Gl.glVertex2d(30.5, 25);
            Gl.glVertex2d(30, 28);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(33.5, 23);
            Gl.glVertex2d(34.5, 23);
            Gl.glVertex2d(34.5, 24);
            Gl.glVertex2d(33.5, 24);
            Gl.glEnd();

            // А.
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(36, 23);
            Gl.glVertex2d(37, 29);
            Gl.glVertex2d(39, 29);
            Gl.glVertex2d(40, 23);
            Gl.glVertex2d(39, 23);
            Gl.glVertex2d(38.5, 25);
            Gl.glVertex2d(37.5, 25);
            Gl.glVertex2d(37, 23);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(37.5, 26);
            Gl.glVertex2d(38.5, 26);
            Gl.glVertex2d(38, 28);
            Gl.glEnd();
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(40.5, 23);
            Gl.glVertex2d(41.5, 23);
            Gl.glVertex2d(41.5, 24);
            Gl.glVertex2d(40.5, 24);
            Gl.glEnd();

            // дожидаемся конца визуализации кадра
            Gl.glFlush();

            // посылаем сигнал перерисовки элемента AnT.
            AnT.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isTriDisplay = false;
            isFunctionsDisplay = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isFunctionsDisplay = false;
            isTriDisplay = true;
        }

        private void PrintText2D(float x, float y, string text)
        {
            Gl.glRasterPos2f(x, y);

            foreach (char char_for_draw in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }
        }

        double a = 1, b = 0, c = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar1.Value / 1000.0;
            label2.Text = a.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar2.Value / 1000.0;
            label3.Text = b.ToString();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            if (isTriDisplay)
            {
                DrawTri();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar3.Value / 1000.0;
            label4.Text = c.ToString();
        }

        private void DrawTri()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3d(0.0 + a, 0.0 + b, 0.0 + c);
            Gl.glVertex2d(5.0, 5.0);
            Gl.glColor3d(0.0 + c, 0.0 + a, 0.0 + b);
            Gl.glVertex2d(25.0, 5.0);
            Gl.glColor3d(0.0 + b, 0.0 + c, 0.0 + a);
            Gl.glVertex2d(5.0, 25.0);
            Gl.glEnd();

            Gl.glFlush();

            AnT.Invalidate();
        }

        private void functionCalculation()
        {
            float x = 0, y = 0;

            GrapValuesArray = new float[300, 2];

            elements_count = 0;

            for (x = -5; x < 5; x += 0.5f)
            {
                y = (float) (Math.Pow(x,3)*Math.Exp(-Math.Abs(x+1)));

                GrapValuesArray[elements_count, 0] = x;
                GrapValuesArray[elements_count, 1] = y;
                elements_count++;
            }

            not_calculate = false;
        }

        private void DrawDiagram()
        {
            if (not_calculate)
            {
                functionCalculation();
            }

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);

            for (int ax = 1; ax < elements_count; ax += 2)
            {
                Gl.glVertex2d(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }

            Gl.glEnd();

            Gl.glPointSize(5);
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2d(GrapValuesArray[pointPosition, 0], GrapValuesArray[pointPosition, 1]);
            Gl.glEnd();
            Gl.glPointSize(1);
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Gl.glColor3f(0, 0, 0);

            Gl.glPushMatrix();

            Gl.glTranslated(15, 15, 0);

            Gl.glBegin(Gl.GL_POINTS);

            for (int ax = -15; ax < 15; ax++)
            {
                for (int bx = -15; bx < 15; bx++)
                {
                    Gl.glVertex2d(ax, bx);
                }
            }

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(0, -15);
            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(-15, 0);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(0.1, 14.5);
            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(-0.1, 14.5);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, 0.1);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, -0.1);
            Gl.glEnd();

            PrintText2D(15.5f, 0, "x");
            PrintText2D(0.5f, 14.5f, "y");

            DrawDiagram();

            Gl.glPopMatrix();

            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X - 15).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y - 15).ToString() + "]");

            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(lineX, 15);
            Gl.glVertex2d(lineX, lineY);
            Gl.glVertex2d(15, lineY);
            Gl.glVertex2d(lineX, lineY);
            Gl.glEnd();

            Gl.glFlush();

            AnT.Invalidate();
        }
    }
}
