using System;

namespace IndZad
{
    class Program
    {
        static void Main(string[] args)
        {
            int ArraySize;
            int[] Array;

            Console.Write("Введите количество элементов массива: ");
            ArraySize = Int32.Parse(Console.ReadLine());
            Array = new int[ArraySize];
            for (int i=0; i<ArraySize;i++)
            {
                Console.Write("Введите " + i.ToString() + " элемент: ");
                Array[i] = Int32.Parse(Console.ReadLine());
            }

            int ArraySize2 = Array.Length / 2;
            int[] ArrayEnd;
            ArrayEnd = new int[ArraySize2];

            for (int i=0; i<ArraySize;i=i+2)
            {
                ArrayEnd[i / 2] = Array[i] + Array[i + 1];
            }

            foreach (int i in ArrayEnd)
            {
                Console.WriteLine(i);
            }
        }
    }
}
