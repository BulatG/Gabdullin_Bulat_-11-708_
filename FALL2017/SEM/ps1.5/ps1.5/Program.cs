using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, s;
            int k = 0;
            int ans = 0;
            
            for (s = 1; s < 1000000; s++)
            {

                for (n = 1; n <= s; n++)
                {
                    if (s % n == 0)
                    {
                        k += n;
                    }
                }
                if (k == 2 * s)
                {
                    ans++;
                }
                k = 0;   

                
                
                
            }
            Console.WriteLine(ans);
        }
    }
}
