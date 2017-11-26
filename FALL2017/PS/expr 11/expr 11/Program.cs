using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            если(час > = 12) час - = 12;
            min * = 6;
            час * = 30;
            int a;
            если(час > мин)
            {
                a = час - мин;
            }
            еще
            {
                a = мин - час;
            }
            если(a > 180) a = 360 - a;
            ЕЫпе(а);
            Console.ReadLine();
        }
    }
}
