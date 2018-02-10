using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{ 
class IsTicketHappines
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число x и e: ");


            var x = double.Parse(Console.ReadLine());
            var e = double.Parse(Console.ReadLine());

            var result = GetSum(x, e);


            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);

        }

        public static Tuple<double, int> GetSum(double x, double e)
        {
            double preview = 0, 
            current = 0, 
            sum = 1, 
            factorial = 3; 
            int count = 1; 


            current = -x * x;
            sum += current;
            while (Math.Abs(current - preview) > e)
            {
                preview = current;
                current *= -1 * 4 * x * x / factorial * (factorial + 1);
                factorial += 2;
                sum += current;
                count++;
            }
            return Tuple.Create(sum, count);
        }


    }
}







    

