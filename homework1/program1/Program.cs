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
            string s = " ";
            string t = " ";
            double a, b;
            Console.Write("Please input the first double:");
            s = Console.ReadLine();
            Console.Write("Please input the second double:");
            t = Console.ReadLine();
            a = Double.Parse(s);
            b = Double.Parse(t);
            Console.WriteLine("乘积是"+ a * b);
            Console.ReadLine();
        }
    }
}
