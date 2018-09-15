using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] array = new int[6] { 1, 2, 3, 4, 5, 6 };
            int MaxNum = program.Max(array);
            int MinNum = program.Min(array);
            double AverNum = program.Average(array);
            int Sum = program.Sum(array);
            Console.WriteLine("数组中的最大值:" + MaxNum );
            Console.WriteLine("数组中的最小值:" + MinNum);
            Console.WriteLine("数组的平均值:" + AverNum );
            Console.WriteLine("数组的总和:" + Sum);
            Console.ReadLine();
        }
        public int Max(int[] array)
        {
            int Max = array[0];
            for(int i=0;i<6;i++)
            {
                if(Max<array[i])
                {
                    Max = array[i];
                }
            }
            return Max;
        }
        public int Min(int[] array)
        {
            int Min = array[0];
            for (int i = 0; i < 6; i++)
            {
                if (Min > array[i])
                {
                    Min = array[i];
                }
            }
            return Min;
        }
        public double  Average(int[] array)
        {
            int Sum = array[0];
            for (int i = 0; i < 6; i++)
            {
                Sum += array[i];
            }
            double Length = array.Length;
            double Average = Sum / Length;
            return Average;
        }
        public int Sum(int[] array)
        {
            int Sum = array[0];
            for(int i=0;i<6;i++)
            {
                Sum += array[i];
            }
            return Sum;
        }
    }
}
