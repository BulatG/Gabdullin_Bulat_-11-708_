using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T c = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = c;
        }
        public static void Quicksort(List<int>Array,int left,int right)
        {
            if (left >= right)
                return;
            int Pivot = right - 1;
            int Wall =  left;
            int CurrentElement = Wall;
            for(;CurrentElement < right;CurrentElement++)
            {
                if(CurrentElement == Pivot)
                {
                        Swap(Array, Pivot, Wall);
                        Pivot = Wall;
                        Wall++;
                }
                if(Array[CurrentElement] <= Array[Pivot])
                {
                    if (Wall != right)
                        Swap(Array, CurrentElement, Wall);
                    Wall++;
                }
            }
            Quicksort(Array, left, Pivot);
            Quicksort(Array,Pivot+1,right);

        }
        
        static void Main(string[] args)
        {
            bool ans = true;
            Random rand = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 10000000; i++)
                list.Add(rand.Next(-1000000, 1000000));          
            Quicksort(list, 0, list.Count);

            for(int i = 0;i<list.Count - 1;i++)
            {
                if(list[i] > list[i+1])
                {
                    Console.WriteLine("false");
                    ans = false;
                }
            }
            if (ans)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
