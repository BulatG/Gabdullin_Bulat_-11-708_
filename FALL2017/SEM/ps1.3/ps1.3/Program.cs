using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;

            a = Convert.ToInt32(Console.ReadLine());
            while (a != 0)
            {
                if (a % 2 == 0)
                    Console.Write(0);
                a /= 2;
            }


        }
              
    }
}
