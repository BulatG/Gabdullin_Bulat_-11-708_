using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, x, y;
            n = Convert.ToInt32(Console.ReadLine()) - 1;
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((int)((n / x) + (n / y) - (n / (x * y))));
        }
    }
}
