using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BrickGameShooter
{
    class Bullet
    {
        private int left, top;
        public Bullet(int left_,int[][] map)
        {
            top = 17;
            left = left_;
            map[top][left] = 2;
        }
        public bool update(int[][] map)
        {
            if(top == 0)
            {
                map[top][left] = 0;
                return true;
            }
            if (map[top - 1][left] == 3)
            {
                map[top - 1][left] = 0;
                map[top][left] = 0;
                return true;
            }
            map[top][left] = 0;
            top--;
            map[top][left] = 1;
            return false;
        }

    }
    class Shooter
    {   
        private int left;
        private void MakeShooter(int[][] map, int value)
        {
            if (left == 10)
                left--;
            if (left == -1)
                left++;
            map[19][left] = value;
            map[18][left] = value;
            if(left > 0)
                map[19][left - 1] = value;
            if(left < 9)
                map[19][left + 1] = value;
        }
        private void DrawShooter(int[][] map,ConsoleKey key)
        {
            MakeShooter(map, 0);
            left += GetDx(key);
            MakeShooter(map, 1);
        }
        private int GetDx(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                return -1;
            if (key == ConsoleKey.RightArrow)
                return 1;
            return 0;
        }
        public Shooter(int left_)
        {
            left = left_;
        }
        public bool update(int[][] map, ConsoleKey key,List<Bullet>Bullets)
        {
            if (map[18][left] == 3)
                return true;
            DrawShooter(map,key);
            return false;
        }
        public void Fire(int[][] map,List<Bullet> Bullets)
        {
            Bullets.Add(new Bullet(left,map));
        }
    }
    class Stones
    {
        private int[] buffer;
        private Random random;
        public Stones()
        {
            random = new Random();
            buffer = new int[9];
            RefreshBuff();
        }
        private void RefreshBuff()
        {
            int value = random.Next() % 1000000000, a = 0;
            while(value > 0)
            {
                buffer[a] = value % 10;
                value /= 10;
                a++;
            }
        }
        private int GetLastBuffVal()
        {
            if (buffer[0] == -1)
                RefreshBuff();
            int ans = buffer[0], a = 0;
            while(buffer[a]!=-1 && a < 8)
            {
                buffer[a] = buffer[a + 1];
                a++;
            }
            buffer[a - 1] = -1;
            return ans;
        }
        private bool Down(int[][]map,int n)
        {
            int a = 0;
            while(map[a][n] == 3)
            {
                a++;
            }
            map[a][n] = 3;
            if (a == 19)
                return true;
            return false;
        }
        public bool update(int[][] map)
        {
            if (Down(map, GetLastBuffVal()))
                return true;
            return false;
        }
    }
    class MainGameClass
    {
        private static void Print(int[][] array,int n,int m,int score)
        {
            Console.SetCursorPosition(0, 0);
            for(int a = 0;a<n;a+=1)
            {
                for(int b = 0;b<m;b+=1)
                {
                    if(array[a][b] == 0)
                        Console.Write("  ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine("");
            }
            Console.SetCursorPosition(25, 5);
            Console.Write("Score : ");
            Console.WriteLine(score);
        }
        private static ConsoleKey GetConsoleKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                while (Console.KeyAvailable) { Console.ReadKey(true); }
                return key;
            }
            return ConsoleKey.NoName;
        }
        private static void Lose(int Lifes)
        {
            Lifes++;
            Console.Clear();
            Console.WriteLine("Loser");
            if(Lifes == 5)
                Console.WriteLine("Secret : you can`t win, I didn`t code it,stop trying");
            Console.ReadKey(true);
            Console.Clear();
            Main(new string[Lifes]);
        }
        static void Main(string[] args)
        {
            int Lifes = args.Length;
            int score = 0, hard = 25,dhard = 0;
            int[][] map = new int[20][];
            for(int a = 0;a<20;a+=1)
                map[a] = new int[10];
            List<Bullet> Bullets = new List<Bullet>();
            Shooter player = new Shooter(5);
            Stones stone = new Stones();
            ConsoleKey key;
            while(1==1)
            {
                key = GetConsoleKey();
                if (key == ConsoleKey.Spacebar)
                    player.Fire(map, Bullets);
                if (dhard >= hard - score / 1000)
                {
                    if (stone.update(map))
                        Lose(Lifes);
                    dhard = 0;
                }
                if (player.update(map, key,Bullets))
                    Lose(Lifes);
                for(int a = 0;a<Bullets.Count;a++)
                {
                    if (Bullets[a].update(map))
                    {
                        Bullets.RemoveAt(a);
                        score += 10;
                    }
                }
                Print(map, 20, 10,score);
                dhard++;
            }

        }
    }
}
