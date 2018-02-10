using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            while (k>1)
            {
                if (k % 2 == 0)
                    Console.WriteLine("0");
                k = k / 2;
            }
        }
    }
}

