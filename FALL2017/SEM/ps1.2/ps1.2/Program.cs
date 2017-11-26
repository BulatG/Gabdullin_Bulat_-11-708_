using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, k;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a + (k - 1) * (b - a));

        }
    }
}
