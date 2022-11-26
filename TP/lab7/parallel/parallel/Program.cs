namespace parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var array = Enumerable.Range(0,100000).Select(i => rand.Next(100000)).ToArray();
            var arr1 = array.ToArray();
            var arr2 = array.ToArray();
            var arr3 = array.ToArray();
            var arr4 = array.ToArray();


            DateTime startTime1 = DateTime.Now;
            Console.WriteLine(startTime1);


            Parallel.Invoke(
                () => Bubble_Sort(arr1),
                () => Insert_Sort(arr2)
                );
            
  
            Console.WriteLine(DateTime.Now - startTime1);

            DateTime startTime2 = DateTime.Now;
            Console.WriteLine(startTime1);


            Bubble_Sort(arr3);
            Insert_Sort(arr4);


            Console.WriteLine(DateTime.Now - startTime2);

        }

        private static void Bubble_Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }

            }
        }

        private static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            int tmpParam = aFirstArg;

            aFirstArg = aSecondArg;

            aSecondArg = tmpParam;
        }

        private static void Insert_Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int k = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = k;
            }
        }

        private static void PrintArray(int[] anArray)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                Console.Write(anArray[i] + " ");
            }

            Console.WriteLine("\n");
        }
    }
}