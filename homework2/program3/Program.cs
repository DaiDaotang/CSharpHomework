using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace program3 
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            ArrayList prime = new ArrayList();
            bool[] isPrime = new bool[99];
            for(int i=2;i<100;i++)
            {
                isPrime[i-2]= true;
                array[i - 2] = i;
            }
            for(int i=2;i<100;i++)
            {
                for (int j = i; j * i < 100; j++)
                {
                    isPrime[j * i - 2] = false;
                }
            }
            for (int i = 2; i < 100; i++)
            {
                if(isPrime [i-2])
                {
                    prime.Add(array[i - 2]);
                }
            }
            Console.Write("2到100之间的素数有:");
            foreach (int n in prime) Console.Write(" " + n);
            Console.ReadLine();
        }
    }
}
