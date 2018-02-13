using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryad_Foreya
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            RowFarei(n);
        }
        public static void RowFarei(int n)
        {
            Console.WriteLine("0 / 1");
            AddFarei(n, 0, 1, 1, 1);
            Console.WriteLine("1 / 1");
        }

        private static void AddFarei(int n, int a, int b, int c, int d)
        {
            int x = a + c, y = b + d;
            if (y <= n)
            {
                AddFarei(n, a, b, x, y);
                Console.WriteLine(x + " / " + y);
                AddFarei(n, x, y, c, d);
            }
        }
    }
}