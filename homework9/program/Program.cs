using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler c = new Crawler("http://www.4399.com/");
            c.Crawl();
        }
    }
}
