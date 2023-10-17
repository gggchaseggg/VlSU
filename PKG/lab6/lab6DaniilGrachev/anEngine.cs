using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace lab6DaniilGrachev
{
    // класс, реализующий "ядро" нашего растрового редактора
    public class anEngine
    {
        // размеры изображения
        private int picture_size_x, picture_size_y;

        // положение полос прокрутки будет использовано в будующем
        private int scroll_x, scroll_y;

        // размер оконной части (объекта AnT)
        private int screen_width, screen_height;

        // номер активного слоя
        private int ActiveLayerNom;

        // массив слоев
        private ArrayList Layers = new ArrayList();

        // стандартная кисть
        private anBrush standartBrush;

        // последний установленный цвет
        private Color LastColorInUse;

        // конструктор класса
        public anEngine(int size_x, int size_y, int screen_w, int screen_h)
        {
            // при инициализации экземпляра класса сохраним настройки
            // размеров элементов и изображения в локальных переменных

            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

            // полосы прокрутки у нас пока отсутствуют, поэтому просто обнулим значение переменных
            scroll_x = 0;
            scroll_y = 0;

            // добавим новый слой для работы, пока что он будет единственным
            Layers.Add(new anLayer(picture_size_x, picture_size_y));

            // номер активного слоя - 0
            ActiveLayerNom = 0;

            // и создадим стандартную кисть
            standartBrush = new anBrush(3, false);
        }

        // функция для установки номера активного слоя
        public void SetActiveLayerNom(int nom)
        {
            // установка номера активного слоя
            ActiveLayerNom = nom;

            // текущий слой больше не будет активным, следовательно надо создать новый дисплейный список для его быстрой визуализации
            ((anLayer)Layers[ActiveLayerNom]).CreateNewList(); // новый активный слой получает установленный активный цвет для предыдущего активного слоя
            ((anLayer)Layers[nom]).SetColor(((anLayer)Layers[ActiveLayerNom]).GetColor());
        }
        // установка видимости / невидимости слоя
        public void SetWisibilityLayerNom(int nom, bool visible)
        {
            // вернемся к этой функции позже
        }

        // рисование текущей кистью
        public void Drawing(int x, int y)
        {
            // транслируем координаты, в которых проходит рисование, стандартной кистью
            ((anLayer)Layers[ActiveLayerNom]).Draw(standartBrush, x, y);
        }

        // визуализация
        public void SwapImage()
        {
            // вызываем функцию визуализации в нашем слое
            for (int ax = 0; ax < Layers.Count; ax++)
            {
                // если этот слой является активным в данный момент
                if (ax == ActiveLayerNom)
                {
                    // вызываем визуализацию данного слоя напрямую
                    ((anLayer)Layers[ax]).RenderImage(false);
                }
                else
                {
                    // вызываем визуализацию слоя из дисплейного списка
                    ((anLayer)Layers[ax]).RenderImage(true);
                }
            }
        }

        // функция установки стандартной кисти, предается только размер
        public void SetStandartBrush(int SizeB)
        {
            standartBrush = new anBrush(SizeB, false);
        }

        // функция установки специальной кисти
        public void SetSpecialBrush(int Nom)
        {
            standartBrush = new anBrush(Nom, true);
        }

        // установка кисти из файла
        public void SetBrushFromFile(string FileName)
        {
            standartBrush = new anBrush(FileName);
        }

        // функция установки активного цвета
        public void SetColor(Color NewColor)
        {
            ((anLayer)Layers[ActiveLayerNom]).SetColor(NewColor);
            LastColorInUse = NewColor;
        }

        // функция добавления слоя
        public void AddLayer()
        {
            // добавляем слой в массив слоев ArrayList
            int AddingLayer = Layers.Add(new anLayer(picture_size_x, picture_size_y));
            // устанавливаем его активным
            SetActiveLayerNom(AddingLayer);
        }

        // функция удаления слоев
        public void RemoveLayer(int nom)
        {
            // если номер корректен (в диапазоне добавленных в ArrayList)
            if (nom < Layers.Count && nom >= 0)
            {
                // удаляем запись о слое
                Layers.RemoveAt(nom);
                // делаем активным слой 0
                SetActiveLayerNom(0);
            }
        }

        // получение финального изображения
        public Bitmap GetFinalImage()
        {
            // заготовка результирующего изображения
            Bitmap resaultBitmap = new Bitmap(picture_size_x, picture_size_y); // данное решение также не является оптимальным по быстродействию, но при этом является самым простым способом решения задачи

            for (int ax = 0; ax < Layers.Count; ax++)
            {
                // получаем массив пикселей данного слоя
                int[,,] tmp_layer_data = ((anLayer)Layers[ax]).GetDrawingPlace();

                // пройдем двумя циклами по информации о пикселях данного слоя
                for (int a = 0; a < picture_size_x; a++)
                {
                    for (int b = 0; b < picture_size_y; b++)
                    {
                        // если пиксель не помечен как "прозрачный"
                        if (tmp_layer_data[a, b, 3] != 1)
                        {
                            // устанавливаем данный пиксель на результирующее изображение
                            resaultBitmap.SetPixel(a, b, Color.FromArgb(tmp_layer_data[a, b, 0], tmp_layer_data[a, b, 1], tmp_layer_data[a, b, 2]));
                        }
                        else
                        {
                            if (ax == 0) // нулевой слой - необходимо закрасить белым остутствующие пиксели
                            {
                                // закрашиваем белым цветом
                                resaultBitmap.SetPixel(a, b, Color.FromArgb(255, 255, 255));
                            }
                        }
                    }
                }

            }

            // поворачиваем изображение для корректного отображения
            resaultBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            // возвращаем результат
            return resaultBitmap;
        }

        // получение изображения для главного слоя
        public void SetImageToMainLayer(Bitmap layer)
        {
            // поворачиваем изображение (чтобы оно корректно отображалось в области редактирования)
            layer.RotateFlip(RotateFlipType.Rotate180FlipX);

            // проходим двумя циклами по всем пикселям изображения, подгруженного в класс Bitmap
            // получая цвет пикселя, устанавливаем его в текущий слой с помощью функции Drawing
            // данный алгоритм является медленным, но простым
            // оптимальным решением здесь было бы написание собственного загрузчика файлов изображений,
            // что дало бы возможность без "посредников" получать массив значений пикселей изображений,
            // но данная задача является намного более сложной и выходит за рамки обучающей программы

            for (int ax = 0; ax < layer.Width; ax++)
            {
                for (int bx = 0; bx < layer.Height; bx++)
                {
                    // получения цвета пикселя изображения
                    SetColor(layer.GetPixel(ax, bx));
                    // отрисовка данного пикселя в слое
                    Drawing(ax, bx);
                }
            }
        }


        // фильтр для инвертирования цветов
        public void Filter_0()
        {
            // вызываем функцию инвертирования класса anLayer
            ((anLayer)Layers[ActiveLayerNom]).Invers();
        }

        public void Filter_1()
        {
            // собираем матрицу
            float[] mat = new float[9]; mat[0] = -0.1f;
            mat[1] = -0.1f;
            mat[2] = -0.1f;
            mat[3] = -0.1f;
            mat[4] = 1.8f;
            mat[5] = -0.1f;
            mat[6] = -0.1f;
            mat[7] = -0.1f;
            mat[8] = -0.1f;

            //вызываем функцию обработки, передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }


        public void Filter_2()
        {
            // собираем матрицу
            float[] mat = new float[9];

            mat[0] = 0.05f;
            mat[1] = 0.05f;
            mat[2] = 0.05f;
            mat[3] = 0.05f;
            mat[4] = 0.6f;
            mat[5] = 0.05f;
            mat[6] = 0.05f;
            mat[7] = 0.05f;
            mat[8] = 0.05f;

            //вызываем функцию обработки , передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }

        public void Filter_3()
        {
            // собираем матрицу
            float[] mat = new float[9];

            mat[0] = -1.0f;
            mat[1] = -1.0f;
            mat[2] = -1.0f;
            mat[3] = -1.0f;
            mat[4] = 8.0f;
            mat[5] = -1.0f;
            mat[6] = -1.0f;
            mat[7] = -1.0f;
            mat[8] = -1.0f;

            //вызываем функцию обработки, передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 2, true);
        }

        public void Filter_4()
        {
            // собираем матрицу
            // для данного фильтра нам необзодимо будет произвести два преобразования

            float[] mat = new float[9];

            mat[0] = 0.50f;
            mat[1] = 1.0f;
            mat[2] = 0.50f;
            mat[3] = 1.0f;
            mat[4] = 2.0f;
            mat[5] = 1.0f;
            mat[6] = 0.50f;
            mat[7] = 1.0f;
            mat[8] = 0.50f;

            //вызываем функцию обработки, передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 2, true);

            mat[0] = -0.5f;
            mat[1] = -0.5f;
            mat[2] = -0.5f;
            mat[3] = -0.5f;
            mat[4] = 6.0f;
            mat[5] = -0.5f;
            mat[6] = -0.5f;
            mat[7] = -0.5f;
            mat[8] = -0.5f;

            //вызываем функцию обработки, передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }
    }
}
