using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = b - a;
            a = c / 4;
            a = a - (c / 100);
            a = a + (c / 400);
            Console.WriteLine(a.ToString());
        }
    }
}
