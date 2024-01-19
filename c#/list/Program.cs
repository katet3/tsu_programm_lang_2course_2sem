using System;

namespace listSet
{
    class Node
    {
        int key; 
        Node next;

        //Метод доступа key
        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        //Метод доступа next
        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        //Конструктор default
        public Node()
        {
            key = 0; 
            next = null;
        }

        //Конструктор от Значения
        public Node(int value)
        {
            key = value;
            next = null;
        }

        //Вывод ключа
        public void PrintKey()
        {
            Console.Write(key);
        }

        //Вывод следующего
        public void PrintNext()
        {
            Console.WriteLine(next);
        }
    }


    class List
    {
        Node head;

        //Конструктор default
        public List() 
        { 
            head = null; 
        }

        // Конструктор по созданому узлу
        public List(Node n)
        {
            head = n;
        }

        //КОнструктор с заданым количеством начальных узлов
        public List(int n)
        {
            Random rnd = new Random();
            Node tmp = new Node(rnd.Next(0, 100));
            head = tmp; 
            n--;
            while (n > 0)
            {
                AddTail(rnd.Next(0, 100));
                n--;
            }
        }

        //Конструктор от массива
        public List(int[] a)
        {
            Node h = new Node(a[0]);
            head = h;
            for (int i = 1; i < a.Length; i++)
            {
                AddTail(a[i]);
            }
        }

        //Конструктор копирования
        public List(List list)
        {
            Node n = new Node(list.head.Key);
            head = n;
            for (Node i = list.head.Next, j = head; i != null; i = i.Next, j = j.Next)
            {
                Node node = new Node(i.Key);
                j.Next = node;
            }
        }

        //Метод доступа Head
        public Node Head
        {
            get
            {
                return head;
            }

            set
            {
                head = value;
            }

        }

        public Node Find(int value)
        {
            //Ищем позицию
            Node current;
            for (current = head; current != null && current.Key != value; current = current.Next);
            
            return current;
        }

        //вывод списка
        public void Print()
        {
            if (this.Empty()) 
            { 
                Console.WriteLine("Список пуст"); 
                return; 
            }

            Node i;
            for (i = head; i != null; i = i.Next)
            {
                i.PrintKey();
                Console.Write(" -> ");
            }
            Console.WriteLine(" null");
        }

        public void Input()
        {
            string[] values = Console.ReadLine().Split(new char[] {' '}); 
            Node h = new Node(Convert.ToInt32(values[0]));
            head = h;
            
            for (int i = 1; i < values.Length; i++)
            {
                AddTail(Convert.ToInt32(values[i]));
            }
        }

        public void Sort()
        {
            if (head == null || head.Next == null)
            {
                return;
            } 
            Node sorted = null;
            Node current = head; 
            while (current != null)
            {
                Node tmp = current.Next;
                if (sorted == null || sorted.Key > current.Key)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    Node prev = sorted;
                    while (prev.Next != null && prev.Next.Key < current.Key)
                    {
                        prev = prev.Next;
                    }
                    current.Next = prev.Next;
                    prev.Next = current;
                }
                current = tmp;
            }
            head = sorted;  
        }

        //вставка в голову
        public void AddHead(int value)
        {
            Node h = new Node(value);
            h.Next = head; 
            head = h;
        }


        public void AddTail(int value)
        {
            Node tail = new Node(value);
            if (head == null) 
            { 
                head = tail; 
                return; 
            }
            
            //Ищем позицию
            Node current;
            for (current = head; current.Next != null; current = current.Next);
            current.Next = tail;
        }

        //вставка по номеру
        public void AddPosition(int n, int value)
        {
            if (this.Empty()) 
            { 
                Console.WriteLine("Список пуст"); 
                return; 
            }
            
            if (n == 0) 
            { 
                AddHead(value); 
                return; 
            }
            
            //Ищем позицию
            Node current = head;
            for (int i = 0; i != n - 1 && current != null; i++, current = current.Next);
            
            if (current == null) 
            { 
                Console.WriteLine("Нет такой позиции"); 
                return; 
            }
            
            Node newNode = new Node(value);
            //если n последний
            if (current.Next == null) 
            { 
                current.Next = newNode; 
                return; 
            }
            //текущий на новый, новый на next текущего
            newNode.Next = current.Next; 
            current.Next = newNode;
        }

        //вставка по значению
        public void AddKey(int old_key, int new_key)
        {
            //Ищем позицию
            for (Node current = head; current != null; current = current.Next)
            {
                if (current.Key == old_key)
                {
                    Node elem = new Node(new_key);
                    elem.Next = current.Next;
                    current.Next = elem;
                }
            }
        }

        //Смена головы
        public void RemoveHead()
        {
            if (this.Empty())
            {
                Console.WriteLine("Список пуст");
                return;
            }
            head = head.Next;
        }

        public void Removetail()
        {
            if (this.Empty()) {
                Console.WriteLine("Список пуст"); 
                return; 
            }
            if (head.Next == null) { 
                head = null; 
                return; 
            }
            //Ищем позицию
            Node current;
            for (current = head; current.Next.Next != null; current = current.Next);

            current.Next = null;
        }

        public void RemovePosition(int n)
        {
            if (head == null) { 
                Console.WriteLine("Список пуст"); 
                return; 
            }
            if (n == 0) {
                RemoveHead(); 
                return; 
            }

            //Ищем позицию
            Node current = head;
            for (int i = 0; i != n - 1 && current != null; i++, current = current.Next);
            
            //2 условие?
            if (current == null && current.Next == null) { 
                Console.WriteLine("Нет такой позиции"); 
                return; 
            }
            if (current.Next.Next == null){
                current.Next = null; 
                return; 
            }
            current.Next = current.Next.Next;
        }

        public void RemoveKey(int key)
        {
            if (head != null && head.Key == key) 
            {
                head = head.Next;
                return;
            }

            for (Node current = head; current != null && current.Next != null; current = current.Next)
            {
                if (current.Next.Key == key)
                {
                    if (current.Next.Next == null) 
                    { 
                        current.Next = null;
                        return; 
                    }
                    current.Next = current.Next.Next;
                }
            }
        }

        public int Min()
        {
            int min = head.Key;
            for (Node i = head; i != null; i = i.Next)
            {
                if (i.Key < min)
                {
                    min = i.Key;
                }
            }
            return min;
        }

        public int Max()
        {
            int max = head.Key;
            for (Node i = head; i != null; i = i.Next)
            {
                if (i.Key > max)
                {
                    max = i.Key;
                }
            }
            return max;
        }

        public bool Empty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            /*
            while (head != null)
            {
                head = head.Next;
            }
            */
        }

        public void Assignment(List list)
        {
            Node newHead = new Node(list.head.Key);
            head = newHead;
            for (Node i = list.head.Next, j = head; i != null; i = i.Next, j = j.Next)
            {
                Node newNode = new Node(i.Key);
                j.Next = newNode;
            }
        }

        //Метод доступа []
        public int this[int k]
        {
            get
            {
                Node j = head;
                for (int i = 0; i < k && j != null; i++, j = j.Next);
                if (j == null) 
                { 
                    Console.WriteLine("Нет такого элемента"); 
                    return (0); 
                }
                return (j.Key);
            }
            set
            {
                Node j = head;
                for (int i = 0; i < k && j != null; i++, j = j.Next);
                if (j == null) 
                {
                    Console.WriteLine("Нет такого элемента");
                }
                j.Key = value;
            }
        }

        public static List operator + (List list1, List list2)
        {
            List newlist1 = new List();
            List newlist2 = new List();
            newlist1.Assignment(list2);
            newlist2.Assignment(list1);
            
            //идем по первому до конца
            Node current;
            for (current = newlist1.head; current.Next != null; current = current.Next);
            
            //ставим конец на начало второго
            current.Next = newlist2.head;
            return newlist1;
        }

        public static List operator - (List list1, List list2)
        {
            List newlist1 = new List();
            List newlist2 = new List();
            newlist1.Assignment(list1);
            newlist2.Assignment(list2);

            Node current;
            for (current = newlist1.head; current.Next != null; current = current.Next);
            
            current.Next = newlist2.head;
            return newlist1;
        }

        public static bool operator == (List list1, List list2)
        {
            for (Node i = list1.head, j = list2.head; i != null && j != null; i = i.Next, j = j.Next)
            {
                if (i.Key != j.Key)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator != (List list1, List list2)
        {
            return !(list1 == list2);
        }
    }

    class Set : List
    {
        int power;

        public Set() // конструктор по умолчанию
        {
            power = 0;
        }

        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }

        public Set(List list) // конструктор по списку
        {
            Node newHead = new Node(list.Head.Key);
            Node this_current = new Node();
            
            Head = newHead; 
            power = 1;
            
            for (Node current_from_list = list.Head.Next; current_from_list != null; current_from_list = current_from_list.Next)
            {
                for (this_current = Head; this_current.Next != null && this_current.Key != current_from_list.Key; this_current = this_current.Next);
                //сли такой ключ не добавили
                if (this_current.Next == null && this_current.Key != current_from_list.Key) 
                { 
                    Node node = new Node(current_from_list.Key); 
                    this_current.Next = node; 
                    power++;
                }
            }
        }

        public Set(int n) // конструктор
        {
            Random rnd = new Random();
            int value;
            for (power = 0; power != n;)
            {
                if (Find(value = rnd.Next(0, 100)) == null)
                {
                    AddElement(value);
                }
            }
        }

        public new void Input()
        {
            string[] values = Console.ReadLine().Split(new char[] {' '});
            Node h = new Node(Convert.ToInt32(values[0]));
            Head = h; 
            power = 1;
            for (int i = 1; i < values.Length; i++)
            {
                if (Find(Convert.ToInt32(values[i])) == null)
                {
                    AddTail(Convert.ToInt32(values[i]));
                    power++;
                }
            }
        } // ввод

        public void Assigment(Set set) // =
        {
            Assignment((List)set); 
            power = set.power;
        }

        public static bool operator == (Set set1, Set set2) // ==
        {
            if (set1.power != set2.power)
            {
                return false;
            }
            for (Node i = set1.Head; i != null; i = i.Next)
            {
                if (set2.Find(i.Key) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator != (Set set1, Set set2) // !=
        {
            return !(set1 == set2);
        }

        public static Set operator + (Set set1, Set set2) // объединение двух множеств с созданием нового set
        {
            Set set = new Set((List)set1 + (List)set2); 
            return set;
        }

        public static Set operator + (Set set, int value) // добавление элемента с созданием нового set
        {
            Set result = new Set(set);
            if (result.Find(value) == null)
            {
                Node newNode = new Node(value);
                Node current = new Node();
                for (current = result.Head; current.Next != null; current = current.Next) ;
                current.Next = newNode;
                result.power++;
            }
            return result;
        } 

        public static Set operator * (Set set1, Set set2) // пересечение двух множеств с созданием нового set
        {
            Set result = new Set();
            Node currentNodeSet1 = new Node();
            Node currentNodeSet2 = new Node();
            for (currentNodeSet1 = set1.Head; currentNodeSet1 != null; currentNodeSet1 = currentNodeSet1.Next)
            {
                for (currentNodeSet2 = set2.Head; currentNodeSet2 != null && currentNodeSet1.Key != currentNodeSet2.Key; currentNodeSet2 = currentNodeSet2.Next);
                if (currentNodeSet2 != null && currentNodeSet1.Key == currentNodeSet2.Key) 
                { 
                    result.AddTail(currentNodeSet1.Key); 
                    result.power++; 
                }
            }
            return result;
        } 

        public static Set operator / (Set set1, Set set2) // разность двух множеств с созданием нового set
        {
            Set result = new Set(set1);
            for (Node currentNodeResult = result.Head; currentNodeResult != null; currentNodeResult = currentNodeResult.Next)
            {
                if (set2.Find(currentNodeResult.Key) != null)
                {
                    result.RemoveKey(currentNodeResult.Key);
                }
            }
            return result;
        } 

        public void AddElement(int value) // добавление элемента к множеству без создания
        {
            if (Find(value) == null)
            {
                AddTail(value); 
                power++; 
            }
        } 

        public void Intersection(Set set) // пересечение двух множеств без создания
        {
            for (Node currentNodeThis = Head; currentNodeThis != null; currentNodeThis = currentNodeThis.Next)
            {
                if (set.Find(currentNodeThis.Key) == null)
                {
                    RemoveKey(currentNodeThis.Key);
                }
            }
        }  

        public void Complement(Set set) // разность двух множеств без создания 
        {
            for (Node currentNodeThis = Head; currentNodeThis != null; currentNodeThis = currentNodeThis.Next)
            {
                if (set.Find(currentNodeThis.Key) != null)
                {
                    RemoveKey(currentNodeThis.Key);
                }
            }
        } 

        public new void RemoveKey(int value) // удаление ключа из множества без создания 
        {
            if (Find(value) != null)
            {
                base.RemoveKey(value);
                power--;
            }
        } 

        public Set Removevalue(int value) // удаление ключа из множества с созданием нового set
        {
            Set set = new Set(this);
            if (set.Find(value) != null)
            {
                set.RemoveKey(value); 
                set.power--;
            }
            return set;
        } 

        public static Set operator ~ (Set set) // дополнение до идеального множества
        {
            Set newset = new Set();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                if (set.Find(i) == null)
                {
                    newset.AddElement(i);
                }
            }
            return newset;
        } 
    }

    class Program
    {
        static void СheckList()
        {
            int counter = 0;
            // 1
            Console.WriteLine("Проверка " + ++counter);
            List S1 = new List();
            S1.AddHead(1); 
            S1.AddTail(10);
            S1.Print();

            // 2
            Console.WriteLine("\nПроверка " + ++counter);
            List S2 = new List(6);
            S2.Print();
            int min = S2.Min();
            int max = S2.Max();
            Console.WriteLine("Минимум - " + min + " Максимум - " + max);
            S2.Sort(); 
            S2.Print();

            // 3
            Console.WriteLine("\nПроверка " + ++counter);
            int elem = S2[1];
            Console.WriteLine(elem);
            S2.RemovePosition(1);
            S2.Print();

            // 4
            Console.WriteLine("\nПроверка " + ++counter);
            elem = S2[6]; 
            S2.Removetail(); 
            S2.Print();

            // 5
            Console.WriteLine("\nПроверка " + ++counter);
            List S3 = new List(); 
            S3.Assignment(S1);
            S3.Print();
            if (S1 == S3)
            {
                Console.WriteLine("Списки равны");
            }
            Node a = new Node();
            a = S3.Find(15);

            // 6
            Console.WriteLine("\nПроверка " + ++counter);
            S3.RemoveHead(); 
            S3.RemoveKey(10); 
            S3.Print(); 
            if (S3.Empty()) Console.WriteLine("S3 пуст");

            // 7
            Console.WriteLine("\nПроверка " + ++counter);
            int[] b = new int[6]; 
            Random rnd = new Random();
            for (int i = 0; i < b.Length; i++) 
            { 
                b[i] = rnd.Next(0, 20); 
                Console.Write(b[i] + " "); 
            }
            Console.Write("\n");
            List S4 = new List(b); 
            S4.Print(); 
            a = S4.Find(25);
            S4.AddPosition(3, 25); 
            S4.Print();

            // 8
            Console.WriteLine("\nПроверка " + ++counter);
            List S5 = new List(S2); 
            S5.Print();
            if (S5.Find(4) != null)
            {
                S5.RemoveKey(4);
            }
            else
            {
                S5.AddTail(4);
            }
            S5.Print();

            // 9
            Console.WriteLine("\nПроверка " + ++counter);
            int val = 0;
            for (int i = 0; i < 4; i++)
            {
                val = Int32.Parse(Console.ReadLine());
                S5.AddTail(val);
            }
            S5.Print();
            if (S5 == S4)
            {
                Console.WriteLine("Равны");
            }
            else
            {
                Console.WriteLine("Не равны");
            }

            //10 
            Console.WriteLine("\nПроверка " + ++counter);
            S5 = S5 - S4 + S1;
            S5.Print();
        }

        static void CheckSet()
        {
            int counter = 0;

            //1
            Console.WriteLine("(создано 10)Проверка " + ++counter);
            Set S1 = new Set(10); 
            S1.Print();

            //2
            Console.WriteLine("\n(оператор=и==)Проверка " + ++counter);
            Set S2 = new Set(S1); 
            S2.Print();
            if (S1 == S2)
            {
                Console.WriteLine("Равны");
            }

            //3
            Console.WriteLine("\n(поиск элемента 5 и удаление)Проверка " + ++counter);
            Set S3 = new Set(S1);
            if (S1.Find(5) == null)
            {
                S3.AddElement(5);
            }
            else
            {
                S3.RemoveKey(5);
            }
            S3.Print();
            if (S1 != S3)
            {
                Console.WriteLine("Не равны");
            }

            //4
            Console.WriteLine("\nПроверка " + ++counter);
            Set S4 = new Set(); 
            S4.Empty();
            S4.AddElement(5); 
            S4.AddElement(10); 
            S4.AddElement(15); 
            S4.AddElement(5); 
            S4.Print();

            //5
            Console.WriteLine("\nПроверка " + ++counter);
            Set S5 = new Set();
            S5.Assigment(S4);
            if (S5.Find(15) != null)
            {
                S5.RemoveKey(15);
            }
            S5.Print();

            //6
            Console.WriteLine("\nПроверка " + ++counter);
            List T = new List(20);
            T.Print(); 
            Set s6 = new Set(T);
            s6.Print();
            Console.WriteLine("Мощность множества равна " + s6.Power);

            //7
            Console.WriteLine("\n(пересечение дополнение)Проверка " + ++counter);
            Set s7 = ~s6; 
            s7.Print();
            s6.Print();
            Set s8 = s7 * s6;
            s8.Print();

            //8
            Console.WriteLine("\n(операции+/*)Проверка " + ++counter);
            Set S9 = new Set(); 
            S9.Input(); 
            s7.Print(); 
            Set V1 = s7 * S9;
            Console.WriteLine("V1: ");
            V1.Print();
            Set V2 = s7 + S9;
            Console.WriteLine("V2: ");
            V2.Print(); 
            Set V3 = s7 / S9;
            Console.WriteLine("V3: ");
            V3.Print();

            //9
            Console.WriteLine("\n(+)Проверка " + ++counter);
            V1 = V1 + V3; 
            V1.Print();
            if (V1 == s7)
            {
                Console.WriteLine("Равны");
            }
            else
            {
                Console.WriteLine("Не равны");
            }

            //разность без создания
            //10
            Console.WriteLine("\nПроверка " + ++counter);
            V2.Print(); 
            V3.Print();
            V2.Complement(V3); 
            V2.Print();
            S9.Print();
            if (V2 == S9)
            {
                Console.WriteLine("Равны");
            }
            else Console.WriteLine("Не равны");
        }

        public static void Main()
        {
            //СheckList();
            Console.WriteLine("\n\n\n\n");
            CheckSet();
        }
    }
}