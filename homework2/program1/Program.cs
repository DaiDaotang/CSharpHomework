using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个整数:");
            string s = " ";
            s = Console.ReadLine();
            int n = int.Parse(s);
            int a = n;
            int i = 2;
            string t=" ";
            do
            {
                if (a % i == 0)
                {
                    if(a == i)
                    {
                        t += i;
                        a = a / i;
                    }
                    else
                    {
                        t += i + "*";
                        a = a / i;
                    }
                }
                else
                {
                    i++;
                }
            } while (i <= n);
            Console.WriteLine(n + " =" + t);
            Console.ReadLine();
        }
    }
}
