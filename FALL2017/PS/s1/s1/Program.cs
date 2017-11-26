using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            b = b - a;
            a = a + b;
            b = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
