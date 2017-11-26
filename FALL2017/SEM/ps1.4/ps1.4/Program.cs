using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps1._4
{
    class Program
    {
        public static int IsDegree(int a)
        {
            int k = 1;
            while (a > 2)
            {
                if (a % 2 == 0)
                    k = k + 1;
                else return 0;
                a /= 2;
                
            }
            return k;
        }
        static void Main(string[] args)
        {
            int summa = 0;
            while (true)
            {
                int b;
                b = Convert.ToInt32(Console.ReadLine());
                if(b == 0)
                {
                    Console.WriteLine(summa);
                    return;
                }
                summa = summa + IsDegree(b);
                


            }   
        }
    }
    
}
