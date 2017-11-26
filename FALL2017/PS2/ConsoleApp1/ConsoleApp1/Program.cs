using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int fact (int k)
        {
            int Ans = 1;
            for (int f = 1; f <= k; k++)
            {
                Ans = Ans * f;
                
            }
            return Ans;
        }
         public static int ConstantaCatalanta(decimal G)
        {
            decimal L = (decimal)(Math.PI / 8 * Math.Log(Math.Sqrt(3) + 2, Math.E));
            decimal Ans = 0;
           
           for (int i = 0; ;i++)
            {
                Ans += fact(i)*fact(i)/fact(2*i)*(2*i+1)*(2*i+1);
               
                Math.Round(decimal.Parse(Console.ReadLine()));
            }
             
        }


        static void Main(string[] args)
        {
            decimal G = (decimal)0.915965594177219015054603514932384110774;
           
        }
        
         
        
    }
    
}
