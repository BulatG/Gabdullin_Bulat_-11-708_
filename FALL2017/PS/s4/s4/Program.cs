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
                int k = Convert.ToInt32(Console.ReadLine());
                int ans = 0;
                while (k != 0)
                {
                    ans = ans + getPow(k, 2);
                    k = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine(ans);
            }
            static int getPow(int d, int osn)
            {
                int answer = 0;
                while (d > 1)
                {

                    if (d % osn == 0)
                    {
                        answer++;
                        d = d / 2;
                        continue;
                    }
                    return 0;

                }
                return answer;
            }
        }
    }


