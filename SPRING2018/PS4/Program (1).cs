using System;

namespace PS4Bulat
{
    public class Node<T>
    {
        private Node<T> next;
        private T value;
        public void SetNextNode(Node<T> next_)
        {
            next = next_;
        }
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        public Node<T> Next => next;
    }
    public class List<T>
    {
        public List()
        {
            headNode = null;
            tailNode = headNode;
            Count = 0;
        }
        public void Add(T _element)
        {
            if (headNode == null)// Выполнение при создании списка 
            {
                // создать узел, сделать его головным 
                headNode = new Node<T>();
                headNode.Value = _element;
                // этот же узел и является хвостовым 
                tailNode = headNode;
                // следующего узла нет 
                headNode.SetNextNode(null);
            }
            else
            {
                Node<T> newNode = new Node<T>();
                tailNode.SetNextNode(newNode);
                tailNode = newNode;
                tailNode.Value = _element;
                tailNode.SetNextNode(null);
            }

            ++Count;
        }
        public T this[int index]
        {
            get
            {
                Node<T> tempNode = this.headNode;
                for (int i = 0; i < index; ++i)
                    tempNode = tempNode.Next;
                return tempNode.Value;
            }
            set {
                Node<T> tempNode = this.headNode;
                for (int i = 0; i < index; ++i)
                    tempNode = tempNode.Next;
                tempNode.Value = value;
            }
        }
        public void Erase(int index)
        {
            if (index == 0)
                headNode = headNode.Next;
            else if (index == Count - 1)
            {
                Node<T> tempNode = headNode;
                for (int i = 0; i < index - 1; ++i)
                    tailNode = tempNode;
            }
            else
            {
                Node<T> tempNode = headNode;
                for (int i = 0; i < index - 1; ++i)
                    tempNode = tempNode.Next;
                tempNode.SetNextNode(tempNode.Next.Next);
            }
            Count--;
        }
        public void Insert(T item, int index)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = item;
            if (index == 0)
            {
                newNode.SetNextNode(headNode);
                headNode = newNode;
            }
            else if (index > 0 && index < Count)
            {
                Node<T> current = headNode;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                newNode.SetNextNode(current.Next);
                current.SetNextNode(newNode);
            }

            Count++;
        }
        public int Count { get; private set; }
        private Node<T> headNode;
        private Node<T> tailNode;
    }
    public class Literal
    {
        private bool negation;
        public Literal(bool negation_, int index_)
        {
            negation = negation_;
            Index = index_;
        }
        public bool Equal => negation;
        public int Index { get; set; }
    }
    public class Pair<T1,T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }
        public Pair(T1 first,T2 second)
        {
            First = first;
            Second = second;
        }
    }
    public class DNF
    {
        private List<Literal> IsBonding(List<Literal>a,List<Literal>b)
        {
            if (a.Count != b.Count)
                return null;
            List<Literal> ans = new List<Literal>();
            int index = -1;
            int size = a.Count;
            int coincidence = 0;
            int non_coincidence = 0;
            for (int i = 0;i<a.Count;i++)
            {
                for(int j = 0;j<b.Count;j++)
                {
                    if(a[i].Index == b[j].Index && a[i].Equal != b[j].Equal)
                    {
                        index = a[i].Index;
                        non_coincidence++;
                    }
                    if(a[i].Index == b[j].Index && a[i].Equal == b[j].Equal)
                    {
                        coincidence++;
                    }
                }
            }
            if (!(coincidence == size - 1 && non_coincidence == 1))
                return null;
            for(int i = 0;i<a.Count;i++)
            {
                if (i == index)
                    continue;
                ans.Add(a[i]);
            }
            return ans;
        }
        private int Pow(int val,int degree)
        {
            int ans = 1;
            for (int i = 0; i < degree; i++)
                ans *= val;
            return ans;
        }
        private List<List<Literal>> body;
        public void Erase(int index)
        {
            body.Erase(index);
        }//–удаления элемента из списка: удаления элемента, находящегося в некоторой позиции (позиция определяется в интерактивном режиме);
        public void Insert(List<Literal> item, int index)
        {
            body.Insert(item, index);
        }//–вставки элемента в список:  вставки конъюнкции в некоторую позицию списка (позиция определяется в интерактивном режиме; при вставке учесть существует ли подобный элемент в списке); 
        public DNF()
        {
            body = new List<List<Literal>>();
        }
        public DNF(int VariablesCount)
        {
            body = new List<List<Literal>>();
            for(int i = 0;i<Pow(2, VariablesCount);i++)
            {
                int j = 0;
                List<Literal> h_StepLiteral = new List<Literal>();
                String input = Console.ReadLine();
                for(;j < input.Length - 1;j+=2)
                {
                    if(input[j] == '0')
                        h_StepLiteral.Add(new Literal(true,j/2));
                    else if(input[j] == '1')
                        h_StepLiteral.Add(new Literal(false,j/2));
                }
                if (input[j] == '1')
                    body.Add(h_StepLiteral);
            }
            MakeDNFFromSDNF();
        }
        public static DNF Merge(DNF d1,DNF d2)
        {
            DNF ans = new DNF();
            for (int i = 0; i < d1.body.Count; i++)
                ans.body.Add(d1.body[i]);
            for (int i = 0; i < d2.body.Count; i++)
                ans.body.Add(d2.body[i]);
            return ans;
        }//–Используя списки, построить дизъюнкцию двух ДНФ
        public void Write()
        {
            for(int i = 0;i<body.Count;i++)
            {
                for(int j = 0;j<body[i].Count;j++)
                {
                    if (body[i][j].Equal)
                        Console.Write("¬");
                    Console.Write("x");
                    Console.Write(body[i][j].Index);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }//–декодирования:  восстановления формулы ДНФ с выводом результата в текстовый файл, с освобождением выделенной динамической памяти;
        public void Sort()
        {
            for(int i = 0;i<body.Count;i++)
            {
                List<Literal> current = body[i];
                for(int j = i+1;j<body.Count;j++)
                {
                    if(current.Count>=body[j].Count)
                    {
                        List<Literal> hstep = new List<Literal>();
                        hstep = body[i];
                        body[i] = current;
                        current = hstep;
                    }
                }
            }
        }
        public bool Calculate(List<Literal>Variables)
        {           
            bool ans = false;
            for(int i = 0;i<body.Count;i++)
            {
                ans = false;
                for (int j = 0;j<body[i].Count;j++)
                {
                    for(int q = 0;q<Variables.Count;q++)
                    {
                        if(Variables[q].Index == body[i][j].Index)
                        {
                            if(!(body[i][j].Equal && Variables[q].Equal))
                            {
                                ans = true;
                            }
                        }
                    }
                }
                if (ans)
                    return true;
            }
            return false;
        }//–Вычислить значение ДНФ в некоторой вершине 5-мерного куба
        private bool IsAbsorpition(List<Literal> who_,List<Literal> in_)
        {
            List<bool> a = new List<bool>();
            for (int i = 0; i < who_.Count; i++)
                a.Add(false);
            for(int i = 0;i<in_.Count;i++)
            {
                for(int j = 0;j<who_.Count;j++)
                {
                    if(who_[j].Index == in_[i].Index && who_[j].Equal == in_[i].Equal)
                    {
                        a[j] = true;
                    }
                }
            }
            for(int i = 0;i<a.Count;i++)
            {
                if (!a[i])
                    return false;
            }
            return true;
        }
        private void MakeDNFFromSDNF()//Метод Квайна
        {
            List<Pair<bool, List<Literal>>> hbody = new List<Pair<bool, List <Literal>>>();
            for(int i = 0;i<body.Count;i++)
            {
                hbody.Add(new Pair<bool, List<Literal>>(false, body[i]));
            }
            List<Pair<bool, List<Literal>>> hstep = new List<Pair<bool, List<Literal>>>();
            List<Literal> step;
            while (true)
            {
                for (int i = 0; i < hbody.Count; i++)
                {
                    for (int j = i + 1; j < hbody.Count; j++)
                    {
                        step = IsBonding(hbody[i].Second, hbody[j].Second);
                        if (step != null)
                        {
                            hstep.Add(new Pair<bool, List<Literal>>(false, step));
                            hbody[i].First = true;
                            hbody[j].First = true;
                            step = null;
                        }
                    }
                }
                if (hstep.Count == 0)
                    break;
                for (int i = 0; i < hbody.Count; i++)
                {
                    if (!hbody[i].First)
                    {
                        hbody[i].First = true;
                        hstep.Add(hbody[i]);
                    }
                }
                hbody = hstep;
                hstep = new List<Pair<bool, List<Literal>>>();
            }

            List<bool> htable = new List<bool>();
            List<List<bool>> table = new List<List<bool>>();
            for(int i = 0;i<hbody.Count;i++)
            {
                for(int j = 0;j<body.Count;j++)
                {
                    htable.Add(IsAbsorpition(hbody[i].Second, body[j]));
                }
                table.Add(htable);
                for(int j = 0;j<table[i].Count;j++)
                {
                    if (table[i][j]) Console.Write("+");
                    else Console.Write(" ");
                }
                Console.WriteLine("");
                htable = new List<bool>();
            }

            List<bool> hlist = new List<bool>();
            List<bool> list = new List<bool>();
            List<List<Literal>> ans = new List<List<Literal>>();
            for (int i = 0; i < table[0].Count; i++)
                list.Add(false);
            for (int i = 0; i < table.Count; i++)
                hlist.Add(false);
            bool once = false;
            bool break_ = false;
            int index = -1;
            for(int i = 0;i<table[0].Count;i++)
            {
                once = false;
                break_ = false;
                index = -1;
                int j = 0;
                for (;j<table.Count;j++)
                {
                    if(table[j][i] && !once)
                    {
                        hlist[j] = true;
                        once = true;
                        index = j;
                    }
                    else if(table[j][i] && once)
                    {
                        once = false;
                        break_ = true;
                    }
                    if (break_)
                        break;
                }
                if(once)
                {
                    for(int q = 0;q<list.Count;q++)
                    {
                        if(!list[q])
                            list[q] = table[index][q];
                    }
                    ans.Add(hbody[index].Second);
                }
            }
            for(int i = 0;i<list.Count;i++)
            {
                if(!list[i])
                {
                    body = new List<List<Literal>>();
                    for(int j = 0;j<hbody.Count;j++)
                        body.Add(hbody[i].Second);                   
                    return;
                }
            }
            body = ans;
        }
        public DNF MakeNewDNFFromIndex(int index)
        {
            DNF ans = new DNF();
            for(int i = 0;i<body.Count;i++)
            {
                for(int j = 0;j<body[i].Count;j++)
                {
                    if(body[i][j].Index == index)
                    {
                        ans.body.Add(body[i]);
                        break;
                    }
                }
            }
            if (ans.body.Count == 0)
                return null;
            return ans;
        }//–Построить новый список из конъюнкций, содержащих переменную x (переменная определяется в интерактивном режиме).
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Literal> list = new List<Literal>();
            list.Add(new Literal(true, 0));
            list.Add(new Literal(false, 2));
            list.Add(new Literal(true, 1));
            DNF a = new DNF(3);        
            DNF dnf = new DNF(3);
            dnf.Sort(); //демонстрация сорта
            dnf.Write(); // вывод
            Console.WriteLine("");
            dnf.Insert(new List<Literal>(), 2);//вставка
            dnf.Erase(2);//удаление того же елемента
            Console.WriteLine("");
            DNF q = dnf.MakeNewDNFFromIndex(1);//постороение новой днф в которой присутствуют только конъюнкции содержащие икс с какаимто индексом в этом случае икс1
            q.Write();// вывод
            Console.WriteLine("");
            a.Sort(); //демонстрация сорта
            a.Write();// вывод
            Console.WriteLine("");
            Console.WriteLine(a.Calculate(list).ToString());//вывод значения в какой -то вершине , так же будет работать для n вершин
            Console.WriteLine("");
            DNF sum = DNF.Merge(a,dnf);//дизъюнкция
            sum.Write();// вывод
            Console.WriteLine("");



        }
    }
}
/*0 0 0 0
0 0 1 1
0 1 0 1
0 1 1 0
1 0 0 1
1 0 1 0
1 1 0 0
1 1 1 1
0 0 0 1
0 0 1 0
0 1 0 0
0 1 1 0
1 0 0 0
1 0 1 1
1 1 0 1
1 1 1 1
*/

/*для проверки метода квайна
0 0 0 0 0
0 0 0 1 1
0 0 1 0 0
0 0 1 1 1
0 1 0 0 0
0 1 0 1 1
0 1 1 0 0
0 1 1 1 1
1 0 0 0 0
1 0 0 1 0
1 0 1 0 0
1 0 1 1 0
1 1 0 0 0
1 1 0 1 0
1 1 1 0 1
1 1 1 1 1
*/
