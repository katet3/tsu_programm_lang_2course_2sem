using System;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // Node x = new Node(12);
            // x.print();

            // LinkedList list = new LinkedList(1);

            // for(int i = -1; i < 12; i++){
            //     list.AddLast(i);
            // }

            // LinkedList l = new LinkedList(1120);

            // for(int i = 12; i < 20; i++){
            //     l.AddLast(i);
            // }

            //     LinkedList a = new LinkedList(1);
            //     a.input();
            // //     a.print();

            // //     LinkedList b = new LinkedList(1);
            // //     b.input();
            // //     b.print();

            // //   Console.WriteLine(a != b);

            //   Console.WriteLine(a[0]);

            // Console.WriteLine(" ");

            // a.Sort();

            // a.print();

            // list.print();

            // list.AddHead(123);

            // list.print();

            // list.add_to_pos(-10213,8);
            // list.print();
            // Console.WriteLine(list.size_list());

            // list.add_after_key(-2222 ,-10213);
            // list.print();
            // list.remove_head();
            // list.remove_tail();
            // list.remove_to_pos(6);

            // list.remove_to_key(-10213);

            // list.add_to_pos(-12345, 8);

            // list.print();

            // list.min_node();

            // list.Clear();

            // Console.WriteLine(list.find(-103213));

            // list.sort_list();

            // list.print();

            // Console.WriteLine(list + l);

            // Console.WriteLine(help(list));

            // Console.WriteLine(list == list);

            // if(list == l) Console.WriteLine("True");
            // else Console.WriteLine("False");

            // Console.WriteLine(list[1]);

            // Console.WriteLine(list == l);

            // l = list + l;

            // Console.WriteLine(list._find(1314));
            //  int x = list[13243];
            //  Console.WriteLine(x);

            // l.print();

            Mnoj a = new Mnoj(12);
            a.Add();
            a.remove_el_set(55);
            Console.WriteLine(" ");
            a.print();

            // Mnoj d = new Mnoj(13);

            // d.Add();

            // // a.unite(d);

            // //a.Intersection_Of_Set(d);
            // //a.Set_Difference(d);
            // a.Complement(d);

            // a.Add_Element_To_Set();
            // a.print();
        }
    }

    class Node
    {
    public
        int Data;
    public
        Node Next;
    public
        Node(int data)
        {
            Data = data;
            Next = null;
        }
        // public Node(int data){
        //     Data = data;
        // }

        // public int Data;
        // public Node Next{int data}{
        //     Data = data;
        //     Next = null;
        // }//private

    public
        int print()
        {
            // Console.WriteLine(Data);
            return Data;
        }
    }

    class Mnoj : LinkedList
    {
    public
        int P = 0;
    public
        LinkedList llist = new LinkedList(-11);
    public
        Mnoj(int headData) : base(headData) {}

    public
        void _input()
        {
            Node current = Head;
            Console.Write("Enter a size list: ");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter a number: ");
                int x = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < size - i; i++)
                {
                    if (current.Data == x)
                    {
                        i--;
                        Console.WriteLine("Данный элемент уже присутствует!");
                        break;
                    }
                }

                AddLast(x);
                current = current.Next;
            }
        }

    public
        void Add()
        {
            Console.Write("Enter a size list: ");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter a number: ");
                int x = Convert.ToInt32(Console.ReadLine());
                if (Find(x) != null)
                {
                    Console.WriteLine($"Элемент {x} уже существует в списке. Введите другое значение:");
                    i--;
                    continue;
                    // AddLast(x);
                    //  Node newNode = new Node(x);
                    //  newNode.Next = Head;
                    //  Head = newNode;
                }
                else
                {
                    AddLast(x);
                    // Node newNode = new Node(x);
                    // newNode.Next = Head;
                    // Head = newNode;
                }
            }
        }

    public
        Node Find(int data)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        // 7)	объединение

    public
        void Union(LinkedList A)
        {
            Node currentA = A.Head;
            Node current = Head;

            LinkedList result = new LinkedList(A.Head.Data);

            // while(currentA.Next != null){
            //     result.AddLast(currentA.Data);
            // }

            // result.AddLast(15);
            // result.print();

            // Console.WriteLine(A.size_list());
            for (int i = 0; i < size_list() + 1; i++)
            {
                result.AddLast(current.Data);
                current = current.Next;
            }

            result.print();

            Console.WriteLine(" | ");

            for (int i = 0; i < A.size_list() + 1; i++)
            {
                if (Find(currentA.Data) != null)
                {
                }
                else
                {
                    result.AddLast(currentA.Data);
                }
                currentA = currentA.Next;
            }

            // Console.WriteLine(size_list());

            result.print();
            // Console.WriteLine(currentA.Data);

            // Console.WriteLine(current.Data);
        }

        // 8)	добавление элемента к множеству (создается новое множество, изменяется исходное множество)

    public
        void Add_Element_To_Set()
        {
            // Node current = Head;
            // LinkedList tmp = new LinkedList(current.Data);

            Console.Write("Сколько элементов добавить:  ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter a number: ");
                int x = Convert.ToInt32(Console.ReadLine());

                if (Find(x) != null)
                {
                    Console.WriteLine($"Элемент {x} уже существует в списке. Введите другое значение:");
                    i--;
                    continue;
                }
                else
                {
                    AddLast(x);
                }
            }
        }

        // 9)	пересечение двух множеств (создается новое множество, изменяется исходное множество)

    public
        void Intersection_Of_Set(LinkedList A)
        {
            Node currentA = A.Head;
            // Node current = Head;

            LinkedList tmp = new LinkedList(-1);

            for (int i = 0; i < size_list() + 1; i++)
            {
                int temp = currentA.Data;
                if (Find(temp) != null)
                {
                    tmp.AddLast(temp);
                }
                currentA = currentA.Next;
            }

            print();
            Console.WriteLine(" ");
            A.print();
            Console.WriteLine(" ");
            tmp.remove_head();
            tmp.print();
        }

        // 10)	разность двух множеств (создается новое множество, изменяется исходное множество)

    public
        void Set_Difference(LinkedList l2)
        {

            Node current1 = Head;
            Node current2 = l2.Head;

            LinkedList result = new LinkedList(-1);

            while (current1 != null)
            {
                bool contains = false;
                while (current2 != null)
                {
                    if (current1.Data == current2.Data)
                    {
                        contains = true;
                        break;
                    }
                    current2 = current2.Next;
                }
                if (!contains)
                {
                    result.AddLast(current1.Data);
                }
                current1 = current1.Next;
                current2 = l2.Head;
            }

            result.remove_head();
            result.print();
        }

        // 11)	дополнение до идеального множества

    public
        void Complement(LinkedList idealSet)
        {
            LinkedList complementSet = new LinkedList(0); // создаем новый список, который будет содержать дополнение
            // Node current = Head;
            Node currentA = idealSet.Head;

            for (int i = 0; i < size_list(); i++)
            {
                int temp = currentA.Data;
                if (Find(temp) == null)
                {
                    complementSet.AddLast(temp);
                }

                currentA = currentA.Next;
            }

            complementSet.remove_head();
            complementSet.print();
        }

        // сделай дополнение до иделаьного множетсва

    public
        void remove_el_set(int data)
        {

            remove_to_key(data);
        }

        // public Mnoj(int headData){
        //     Head = new Node(headData);
        //     Node current = Head;
        //     Console.Write("Enter a size list: ");
        //     int size = Convert.ToInt32(Console.ReadLine());

        //     for(int i = 0; i < size; i++){
        //         Console.Write("Enter a number: ");
        //         int x = Convert.ToInt32(Console.ReadLine());
        //         AddLast(x);
        //         current = current.Next;
        //     }
        // }
    }

    class LinkedList
    {

        // public int _find(int n){
        //     Node current = Head;
        //     //Console.WriteLine(current.Data);
        //     if(n >= size_list()) return -100;
        //     for(int i = 0; i < size_list(); i++){
        //         if(n == i) return current.Data;
        //         current = current.Next;
        //     }
        //     return 1;
        // }

        // public new int this[int n]{
        //     get{return _find(n);}
        //     set{;}
        // }

    public
        int this [int index]
        {
            get
            {
                Node current = Head;
                for (int i = 0; i < index && current != null; i++)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                return current.Data;
            }
        }


        public static bool
        operator==(LinkedList l1, LinkedList l2)
        {

            Node current1 = l1.Head;
            Node current2 = l2.Head;
            while (current1?.Next != null && current2?.Next != null)
            {
                current1 = current1.Next;
                current2 = current2.Next;

                if (current1.Data != current2.Data)
                {

                    return false;
                }
            }
            return true;
        }

    public
        static bool operator!=(LinkedList l1, LinkedList l2)
        {
            return !(l1 == l2);
        }

    public
        override bool Equals(object o)
        {
            if (o == null || !(o is LinkedList))
            {
                return false;
            }
            return this == (LinkedList)o;
        }

    public
        override int GetHashCode()
        {
            return base.GetHashCode();
        }

    public
        static LinkedList operator+(LinkedList A, LinkedList B)
        {
            // Node current_A = A.Head;
            Node current_B = B.Head;

            while (current_B.Next != null)
                current_B = current_B.Next;

            // Console.WriteLine(current_A.Data);
            // Console.WriteLine(current_B.Data);

            current_B.Next = A.Head;

            return B;
        }

        // в хвост
        //  public static LinkedList operator +(LinkedList A, LinkedList B){

        //     Node current_A = A.Head;
        //     Node current_B = B.Head;

        //     while(current_A.Next != null) current_A = current_A.Next;

        //     //Console.WriteLine(current_A.Data);
        //     //Console.WriteLine(current_B.Data);

        //     current_A.Next = B.Head;

        //     return A;
        // }

        // public static int operator + (LinkedList A, int key){

        //     Node node = new Node(key);
        //     node.Next = A.Head;
        //     A.Head = node;

        //     return 1;
        // }
        /*public static int operator + (LinkedList A, LinkedList B){
            //A.print();
            //B.print();

            //Node current = A.Head;
            Node currentt = B.Head;

            //Console.WriteLine(current.Data);
            //Console.WriteLine(currentt.Data);


            A.Clear();
            A.AddHead(currentt.Data);
            for(int i = 0; i < B.size_list(); i++){
                currentt = currentt.Next;
                A.AddLast(currentt.Data);
            }


            //A.print();
            return 0;
        }*/

    public
        Node Head;
        // Node tail;
        // int count;

    public
        LinkedList(int headData)
        {
            Head = new Node(headData);
        }
    public LinkedList() 
    {
        Head = null;
    }
        // добавление в голову

    public
        void AddHead(int data)
        {
            Node node = new Node(data);
            node.Next = Head;
            Head = node;
        }

        // добавление в хвост
    public
        void AddLast(int data)
        {
            Node current = Head;

            while (current.Next != null)
                current = current.Next;
            current.Next = new Node(data);
        }

        // добавление на позицию

    public
        void add_to_pos(int data, int k)
        {
            Node node = new Node(data);
            Node current = Head;
            Node prev = null;

            for (int i = 0; i < size_list(); i++)
            {
                if (i == k)
                {

                    prev.Next = node;
                    node.Next = current;

                    // Console.WriteLine(prev.Data);
                    // Console.WriteLine(current.Data);
                    break;
                }
                prev = current;
                current = current.Next;
                // Console.WriteLine(prev.Data);
                // Console.WriteLine(current.Data);
            }
        }

        // после ключа

    public
        void add_after_key(int data, int key)
        {
            Node node = new Node(data);
            Node current = Head;
            Node currentNext = null;

            for (int i = 0; i < size_list(); i++)
            {
                if (key == current.Data)
                {

                    // current = node;
                    // node = current.Next;

                    current.Next = node;
                    node.Next = currentNext;

                    // Console.WriteLine(current.Data);
                    // Console.WriteLine(currentNext.Data);
                    // Console.WriteLine(node.Data);
                    break;
                }
                current = current.Next;
                currentNext = current.Next;
            }
        }

        // сортировка списка

        // public void sort_list(){

        // }

        // удаление элемента из головы

    public
        void remove_head()
        {
            Head = Head.Next;
        }

        // удаление хвоста

    public
        void remove_tail()
        {
            Node current = Head;

            while (current.Next.Next != null)
                current = current.Next;

            current.Next = null;
            // Console.WriteLine(current.Data);
        }

        // удаление по позиции

    public
        void remove_to_pos(int k)
        {
            Node current = Head;
            Node prev = null;

            for (int i = 0; i < size_list(); i++)
            {
                if (i == k)
                {

                    prev.Next = current.Next;

                    // Console.WriteLine(prev.Data);
                    // Console.WriteLine(current.Next.Data);
                    break;
                }

                prev = current;
                current = current.Next;
            }
        }

        // удаление по ключу

    public
        void remove_to_key(int key)
        {
            Node current = Head;
            Node prev = null;

            while (current.Next != null)
            {
                if (current.Data == key)
                {
                    prev.Next = current.Next;
                    break;
                }

                prev = current;
                current = current.Next;
            }

            // Console.WriteLine(current.Data);
        }

        // max

    public
        void max_node()
        {
            Node current = Head;
            int max = current.Data;

            while (current != null)
            {
                if (current.Data > max)
                {
                    max = current.Data;
                }
                current = current.Next;
            }

            Console.WriteLine(max);
        }

        // min

    public
        void min_node()
        {
            Node current = Head;
            int max = current.Data;

            while (current != null)
            {
                if (current.Data < max)
                {
                    max = current.Data;
                }
                current = current.Next;
            }

            Console.WriteLine(max);
        }

        // clean list

    public
        void Clear()
        {
            Head = null;
        }

        // Проверка пустоты списка
        // не понятно что нужно сделать
        //  public void check(){
        //      Node current = Head;

        // }

        // find

    public
        Node find(int key)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Data == key)
                {
                    Console.WriteLine(current.Data);
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        // размер списка

    public
        int size_list()
        {
            Node current = Head;

            int i = 0;
            while (current.Next != null)
            {
                current = current.Next;
                i++;
            }

            return i + 1;
        }

    public
        void print()
        {
            Node current = Head;

            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write(" ");
                current = current.Next;
            }
        }

    public
        void input()
        {
            Node current = Head;
            Console.Write("Enter a size list: ");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter a number: ");
                int x = Convert.ToInt32(Console.ReadLine());
                AddLast(x);
                current = current.Next;
            }
        }

        // public void sort(){
        //     Node current = Head;

        //     for(int i = 0; i < size_list; i++){

        //     }

        // }

        // перегрузка операторов:  присвоение

        // public static bool operator == (LinkedList A, LinkedList B){

        //     if(A.size_list() != B.size_list() ) return false;

        //     Node current = Head;

        //     Console.WriteLine(current.Data);

        //     // for(int i = 0; i < A.size_list(); i++){
        //     //     if(A.Data != B.Data) return false;

        //     // }

        //     return true;
        // }

        // public static bool operator != (LinkedList A, LinkedList B){
        //     return false;
        // }

    public
        void Sort()
        {
            if (Head == null || Head.Next == null) // уже отсортирован или пустой список
            {
                return;
            }

            Node currentNode = Head;
            Node nextNode = Head.Next;
            Node tempNode = new Node(0);
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                while (nextNode != null)
                {
                    if (currentNode.Data > nextNode.Data)
                    {
                        tempNode.Data = currentNode.Data;
                        currentNode.Data = nextNode.Data;
                        nextNode.Data = tempNode.Data;
                        swapped = true;
                    }
                    currentNode = currentNode.Next;
                    nextNode = nextNode.Next;
                }
                currentNode = Head;
                nextNode = Head.Next;
            }
        }
    }
}