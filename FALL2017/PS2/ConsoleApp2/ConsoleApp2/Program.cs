using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static double Fact(double number)
        {
            if (number > 0)
            {
                return Fact(number - 1) * number;
            }
            else return 1;
        }
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double epsilon = double.Parse(Console.ReadLine());
            double k = 0;
            double preSum = 0;
            double sum = 0;
            while (true)
            {
                preSum = sum;
                sum += (Math.Pow(-1, k) * Math.Pow(x, 2 * k)) / (Fact(2 * k));
                k++;
                if (Math.Abs(sum - preSum) <= epsilon) break;

            }
            Console.WriteLine(k);
            Console.WriteLine(sum);
        }
    }
}
