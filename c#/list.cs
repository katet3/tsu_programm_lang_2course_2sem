using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        /*        Console.WriteLine("Case 1");
                LinkedList S1 = new LinkedList();
                S1.AddHead(1);
                S1.AddLast(10);
                S1.print();

                Console.WriteLine("\n\nCase 2");
                LinkedList S2 = new LinkedList(2, 1, 10, 0);
                S2.print();

                Console.WriteLine("\nНаходим максимальный и минимальный элемент в списке");
                S2.max_node();
                S2.min_node();
                Console.Write("\n Отсортировали - ");
                S2.Sort();
                S2.print();

                Console.WriteLine("\nCase 3");
                Console.WriteLine("Находим второй элемент в списке и выводим его.");
                Console.WriteLine(S2._find(2));

                Console.WriteLine("\nУдаляем второй элемент из списка.");
                S2.remove_to_pos(2);
                S2.print();

                Console.WriteLine("\n\nCase 4");
                Console.WriteLine(S2._find(6));
                S2.remove_tail();
                S2.print();

                Console.WriteLine("\n\nCase 5");
                LinkedList S3 = new LinkedList(S1);
                Console.WriteLine("\n");
                S3.print();

                if(S3 == S1) { Console.WriteLine("Равны"); } else { Console.WriteLine("Не Равны"); }

                if (S3.find(15)) Console.WriteLine("\nДа, 15 есть в списке");
                else Console.WriteLine("\nНет, 15 нет в списке");

                Console.WriteLine("\n\nCase 6");
                S3.remove_head();
                S3.remove_to_key(10);
                if (S3.Is_empty()) 
                {
                    Console.WriteLine("Пуст");
                }
                else 
                {
                    Console.WriteLine("Не пуст");
                    S3.print();
                }


                Console.WriteLine("\n\nCase 7");
                LinkedList S4 = new LinkedList(2, 0, 20, 0);
                if (S4.find(25)) Console.WriteLine("\n Да, 25 есть в списке");
                else Console.WriteLine("\n Нет, 25 нет в списке");

                S4.add_to_pos(25, 4);
                S4.print();

                Console.WriteLine("\n\nCase 8");
                LinkedList S5 = S2;
                S5.print();

                if (S5.find(4))
                {
                    Console.WriteLine("\n Да, 4 есть в списке, значит удалим его");
                    S5.remove_to_key(4);
                }
                else
                {
                    Console.WriteLine("\n Нет, 4 есть в списке, значит добавим 4 в хвост");
                    S5.AddLast(4);
                }
                S5.print();

                Console.WriteLine("\n\nCase 9");
                S5 = new LinkedList(3, 0, 0, 0);
                S5.print();
                Console.WriteLine("\n");
                S4.print();

                if (S5 == S4) Console.WriteLine("\n S5 и S4 - равны");
                else Console.WriteLine("\n S5 и S4 - не равны");

                Console.WriteLine("\n\nCase 10");
                Console.WriteLine("Добавление в хвост S5 список S4 ");
                S5 = S5 + S4;
                S5.print();
                *//*Console.WriteLine("Добавление в хвост S5 список S4 "); нужно раскоментить оператор + другой*//*

                Console.WriteLine("\n\nCase 11");
                Console.WriteLine("Тест конструктора списка по массиву");
                int[] arr = { 1, 6, 5, 1 };
                LinkedList s_arr = new LinkedList(arr);
                s_arr.print();*/

        /*        Console.WriteLine("Case проверка функции Is_empty");
                LinkedList s1 = new LinkedList();
                s1.print();
                if (s1.Is_empty()) Console.WriteLine("Пуст");
                else Console.WriteLine("Не пуст");

                s1.AddHead(1);
                if (s1.Is_empty()) Console.WriteLine("Пуст");
                else { Console.Write("Не пуст, список: "); s1.print(); Console.WriteLine(" "); }

                s1.remove_head();
                if (s1.Is_empty()) Console.WriteLine("Пуст");
                else { Console.Write("Не пуст, список: "); s1.print(); Console.WriteLine(" "); }*/


/*        Console.WriteLine("Case 1");
        Mn s1= new Mn();
        s1.Input_random_mn(1,10);
        Console.Write("множество s1: ");
        s1.print();

        Console.WriteLine("Case 2");
        Mn s2 = new Mn(s1);
        Console.Write("множество s2: ");
        s2.print();

        if(s1 == s2) 
        {
            Console.WriteLine("Равны");
        }
        else 
        {
            Console.WriteLine("Не равны");
        }

        Console.WriteLine("Case 3");
        if (s1.Search_elem(5)) 
        {
            Mn s3 = new Mn(s1);
            s3.Remove(5);
            s3.print();
        }
        else 
        {
            Mn s3 = new Mn(s1);
            s3.Add(5);
            s3.print();
        }

        if(s1 != s2) 
        {
            Console.Write("Не равны");
        }
        else 
        {
            Console.WriteLine("Равны");    
        }

        Console.WriteLine("\nCase 4");
        Mn s4 = new Mn(0);
        if (s4.Is_empty()) 
        {
            Console.WriteLine("Пуст");
        }
        else 
        {
            Console.WriteLine("Не пуст");
        }
        s4.Input_mn();
        s4.print();

        Console.WriteLine("Case 5");
        Mn s5 = new Mn(s4);
        s5.print();
        if (s5.Search_elem(15)) 
        {
            Console.WriteLine("Нашел 15");
            s5.Remove(15);
        }
        s5.print();*/

        Console.WriteLine("Case 6");
        LinkedList T = new LinkedList(2,0,10,0);
        Mn s6 = new Mn(T);
        T.print();
        s6.print();
        Console.WriteLine("Размер множества s6 - " + s6.size_of_mn);

        Console.WriteLine("Case 7");

        Console.WriteLine("Case 8");

        int[] arrs9 = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29 }
        Mn s9 = new Mn(arrs9);

        Mn v1 = 
    }
}

//класс узла для класса лист и множество
class Node
{
    public int Data;  //поле для информации 
    public Node Next; //поле следюущего узла

    public Node(int data) //конструтор узла (на вход поступает инфа)
    {
        Data = data; //заполняем поле информации тем что поступило на вход
        Next = null; //next в null
    }

    public int print() //метод вывода узла
    {
        Console.WriteLine(Data);
        return Data;
    }
}


//класс одновсвязный список
class LinkedList
{
    public Node Head;  //поле "голова" списка

    //конструктор не пустого списка
    public LinkedList(int flag, int x = 0, int y = 0, int headData = 0)
    {
        if (flag == 1) //обычный конструктор одного элемента
        {
            Head = new Node(headData);
        }

        if (flag == 2) //конструктор для заполнения списка случайными числами
        {
            Console.Write("Enter a size of random list: ");
            int len_list = Convert.ToInt32(Console.ReadLine());

            Random a = new Random();  //первый элемент листа заполняем отдельно
            Head = new Node(a.Next(x, y));

            for (int i = 0; i < len_list - 1; i++)
            {
                AddLast(a.Next(x, y));
            }
        }

        if (flag == 3) //конструтор для заполенния списка с консоли
        {
            Console.Write("Enter a size of list: ");
            int len_list = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter an element 1: ");  //первый элемент листа заполняем отдельно
            int first_data = Convert.ToInt32(Console.ReadLine());

            Head = new Node(first_data); 

            for (int i = 0; i < len_list - 1; i++)
            {
                Console.Write("Enter an element " + (i+2) + ": ");
                int z = Convert.ToInt32(Console.ReadLine());
                AddLast(z);
            }
        }
    }


    //конструтор, чтобы создать список из массива
    public LinkedList(int[] arr)
    {
        Head = new Node(arr[0]);
        int size_of_list = arr.Length;
        Node current = Head;

        for (int i = 1; i < size_of_list; i++)
        {
            int a = arr[i]; 
            AddLast(a);
        }
    }

    //конструктор копирования
    public LinkedList(LinkedList A) 
    {
        Head = new Node(A.Head.Data);
        Node current = A.Head.Next;

        while (current != null) 
        {
            AddLast(current.Data);  
            current = current.Next; 
        }
    }


    //конструтор для создания пустого списка 
    public LinkedList() 
    {
           Head = null;
    }
    
    //метод проверки спика на путоту
    public bool Is_empty() 
    {
        if (Head == null) return true;
        else return false;
    }


    //возвращает элемент под инжексом n
    public int _find(int n) // n - индекс элемента
    {
        Node current = Head;
        //Console.WriteLine(current.Data);
        if (n >= size_list()+2) return -100; //если размер списка меньше чем n то -100
        for (int i = 1; i < size_list()+2; i++)
        {
            if (n == i) return current.Data;
            current = current.Next;
        }
        return -1; //-1 - если не найлен
    }

    //перегрузка квадратных скобок
    public new int this[int n] // n - индекс элемента в List
    {
        get { return _find(n); } //получаем найденный элемент в list при помощи метода find
        set {; }
    }

    //перегрузка ==
    public static bool operator ==(LinkedList A, LinkedList B)
    {
        if (A.size_list() != B.size_list()) return false;

        Node current_A = A.Head;
        Node current_B = B.Head;

        for (int i = 0; i < A.size_list(); i++)
        {
            if (current_A.Data != current_B.Data) return false;
            current_B = current_B.Next;
            current_A = current_A.Next;
        }
        return true;
    }


    // перегрузка !=
    public static bool operator !=(LinkedList A, LinkedList B)
    {
        if (A.size_list() != B.size_list())
        {
            return true;
        }
        Node current_A = A.Head;
        Node current_B = B.Head;

        for (int i = 0; i < A.size_list(); i++)
        {
            if (current_A.Data != current_B.Data)
            {
                return true;
            }
            current_A = current_A.Next;
            current_B = current_B.Next;
        }
        return false;

    }
    //в хвост
    public static LinkedList operator +(LinkedList A, LinkedList B)
    {

        Node current_A = A.Head;

        while (current_A.Next != null) current_A = current_A.Next;

        current_A.Next = B.Head;

        return A;
    }

    //в голову
    /*        public static LinkedList operator +(LinkedList A, LinkedList B)
            {

                Node current_B = B.Head;

                while (current_B.Next != null) current_B = current_B.Next;

                current_B.Next = A.Head;

                return B;
            }*/

    //добавление в голову
    public void AddHead(int data)
    {
        Node node = new Node(data);
        node.Next = Head; //новый в голову
        Head = node; //голову связываем с новым
    }

    //добавление в хвост
    public void AddLast(int data)
    {
        if (Is_empty()) 
        {
            AddHead(data);
            return;
        }
        Node current = Head;

        while (current.Next != null) 
            current = current.Next;
            
        current.Next = new Node(data);
    }

    //добавление на позицию
    public void add_to_pos(int data, int k)
    {
        Node node = new Node(data); //создаем новый узел
        Node current = Head; //текущий
        Node prev = null; //прощлый

        if (k > size_list())
        {
            return;
        }

        for (int i = 1; i < size_list()+2; i++)//В цикле встаем на позицию в которую надо добавить и запоминаем прошлую позицию
        {
            if (i == k)
            {

                prev.Next = node; //прошлый приравниваем к новому
                node.Next = current; //новый указываем на следующий
                break;
            }
            prev = current;
            current = current.Next;
        }
    }

    //после ключа
    public void add_after_key(int data, int key) //data - то что добавляем key - после чего добавляем
    {

        Node node = new Node(data); //создаем новый узел 
        Node current = Head; //запоминаем голову
        Node currentNext = current.Next; //указатель на следующий после current 

        for (int i = 0; i < size_list(); i++)
        {
            if (key == current.Data) 
            {
                current.Next = node;
                node.Next = currentNext;
                break;
            }
            current = current.Next;
            currentNext = current.Next;
        }
    }


    //удаление головы из списка
    public void remove_head()
    {
        Head = Head.Next;
    }

    //удаление хвоста из списка 
    public void remove_tail()
    {
        Node current = Head;
        while (current.Next.Next != null) current = current.Next; //в цикле встем на предпоследний элемент(элемент до хвоста)
        current.Next = null; // и говорим что у элемента до хвоста уже нет хвоста 
    }

    //удаление по позиции
    public void remove_to_pos(int k)
    {
        Node current = Head;
        Node prev = null;

        for (int i = 1; i < size_list()+2; i++) //в цикле встаем на позицию k и переопределяем указатели, пропуская позицию k
        {
            if (i == k)
            {

                prev.Next = current.Next;
                break;
            }

            prev = current;
            current = current.Next;

        }
    }


    //удаление по ключу
    public void remove_to_key(int key)
    {
        if (Is_empty()) return;
        Node current = Head;
        Node prev = null;

        if(current.Data == key) 
        {
            remove_head();
        }

        while (true) 
        {
            if(current.Data == key) 
            {
                remove_tail();
                return;
            }
            current = current.Next;
        }

        current = Head;
        while (current.Next != null) //в цикле встаем на нашу позицию и запоминаем прошлую позицию
        {
            if (current.Data == key) //на нужной позции переопределяем указатели, просто перепрыгивая элемент списка
            {
                prev.Next = current.Next;
                break;
            }
            prev = current;
            current = current.Next;
        }
    }

    //max
    public void max_node()
    {
        Node current = Head;
        int max = current.Data; //запоминаем максимальный элеменет

        while (current != null) //цикл по всему списку
        {
            if (current.Data > max) //если встетили новый максимум запоминаем его
            {
                max = current.Data;
            }
            current = current.Next; //переходим к следюущему элементу списка 
        }

        Console.WriteLine(max);
    }

    //min то же самое что и max только запоминаем минимальный элемнет
    public void min_node()
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

    //clean list
    public void Clear()
    {
        Head = null;
    }

    //find
    public bool find(int key)
    {
        Node current = Head;

        while (current != null)
        {
            if (current.Data == key)
            {
                //Console.WriteLine(current.Data);
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    //размер списка
    public int size_list()
    {
        Node current = Head;

        int i = 0;
        if (current == null) return 0;
        while (current.Next != null)
        {
            current = current.Next;
            i++;
        }

        return i;
    }

    public void print()
    {
        if (Head == null)
            Console.WriteLine("Список пуст");

        Node current = this.Head;

        while (current != null)
        {
            Console.Write(current.Data);
            Console.Write(" ");
            current = current.Next;
        }
        Console.WriteLine('\n');
    }


    public void Sort()
    {
        if (Head == null || Head.Next == null) // уже отсортирован или пустой список
            return;

        Node sorted = null;           // начало отсортированной части списка
        Node current = Head;          // текущий узел в исходном списке

        while (current != null)
        {
            Node next = current.Next; // сохраняем ссылку на следующий узел перед переносом узла в отсортированную часть

            if (sorted == null || sorted.Data > current.Data)
            {
                // переносим текущий узел в начало отсортированной части списка
                current.Next = sorted;
                sorted = current;
            }
            else
            {
                // ищем место для текущего узла в отсортированной части списка
                Node prev = sorted;
                while (prev.Next != null && prev.Next.Data < current.Data)
                {
                    prev = prev.Next;
                }
                // вставляем текущий узел после узла prev
                current.Next = prev.Next;
                prev.Next = current;
            }

            // переходим к следующему узлу в исходном списке
            current = next;
        }
        Head = sorted; // обновляем начало списка на начало отсортированной части
    }
}


class Mn : LinkedList
{
    public int size_of_mn;
    public LinkedList mnoj;
    public Mn() : base(1, 0, 0, 0) 
    {
        size_of_mn = 1;
    }
    
    //конструктор для пустого множества (используется в пересечении)
    public Mn(int flag = 0) : base(0, 0, 0, 0) 
    {
        mnoj = new LinkedList();
        size_of_mn = 0;    
    }

    public Mn(int[] arr): base(1,0,0,0) 
    {
        size_of_mn = arr.Length;
        this.Head.Data = arr[0];
        Node current = this.Head;

        for (int i = 1; i < size_of_mn; i++)
        {

            int a = arr[i];
            current = Head;
            for (int j = 0; j < size_of_mn - 1; j++)
            {

                if (current != null && current.Data == a)
                {
                    Console.WriteLine("В множестве не может быть повторяющихся элементов");
                }
                if (current.Next != null)
                    current = current.Next;
            }
            AddLast(a);
        }
    }

    //констрктор копирования 
    public Mn(Mn A) 
    {
        this.Head = new Node(A.Head.Data);
        Node current = A.Head.Next;
        
        while(current != null ) 
        {
            AddLast(current.Data); current = current.Next;
            size_of_mn++;
        }
        Sort();
    }
    
    //конструктор из списка 
    public Mn(LinkedList A) 
    {
        this.Head = new Node(A.Head.Data);
        Node current = A.Head.Next;
        size_of_mn = 1;

        while (current != null)
        {
            AddLast(current.Data);
            current = current.Next;
            size_of_mn++;
        }
        Sort();

    }

    public bool Input_mn() 
    {
        Console.Write("Введите размер множества: ");
        int len = Convert.ToInt32(Console.ReadLine());
        size_of_mn = len;

        Console.Write("Введите элемент множества: ");
        int first_data = Convert.ToInt32(Console.ReadLine());
        if(this.Head == null) 
        {
            this.Head = new Node(first_data);
        }
        this.Head.Data = first_data;

        Node current = this.Head;
        Node tmp = this.Head.Next;
        bool flag = true;

        for (int i = 0; i < len - 1; i++) 
        {
            Console.Write("Введите элемент множества: ");
            int a = Convert.ToInt32(Console.ReadLine());
            current = Head;
            flag = true;
            for (int j = 0; j < size_of_mn-1;j++) 
            {
                if (current!= null && current.Data == a) 
                {
                    //Console.WriteLine("В множестве не может быть повторяющихся элементов");
                    flag = false;
                }

                if (current.Next != null)
                    current = current.Next;
            }
            if (flag)
            {
                AddLast(a);
            }
        }
        return true;
    }

    public void Input_random_mn(int x = 0, int y = 10)
    {
        Console.Write("Введите размер рандомного множества: ");
        int len_list = Convert.ToInt32(Console.ReadLine());

        Random a = new Random();  //первый элемент листа заполняем отдельно
        Head = new Node(a.Next(x, y));

        for (int i = 0; i < len_list - 1; i++)
        {
            int c = Convert.ToInt32(a.Next(x, y));
            if (Search_elem(c))
            {
                i--;
                continue;
            }
            else 
            {
                AddLast(c); 
            }
            
        }
        Sort();
    }


    public bool Search_elem(int key) 
    {
        Node current = Head;

        while (current != null)
        {
            if (current.Data == key)
            { 
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void Max_node()
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


    public static bool operator ==(Mn A, Mn B)
    {

        if (A.size_of_mn != B.size_of_mn) return false;

        Node tmp_A = A.Head;
        Node tmp_B = B.Head;

        while (tmp_A != null)
        {
            if (tmp_A.Data != tmp_B.Data) return false;
            tmp_A = tmp_A.Next;
            tmp_B = tmp_B.Next;
        }
        return true;
    }

    public static bool operator !=(Mn A, Mn B)
    {

        if (A.size_of_mn != B.size_of_mn) return true;

        Node tmp_A = A.Head;
        Node tmp_B = B.Head;

        while (tmp_A != null)
        {
            if (tmp_A.Data != tmp_B.Data) return true;
            tmp_A = tmp_A.Next;
            tmp_B = tmp_B.Next;
        }

        return false;
    }

    public Mn Union(Mn A)
    {
        Mn result = new Mn();

            result = this;

            Node current = A.Head;

            for (int i = 0; i < A.size_of_mn; i++)
            {
                if (!this.Search_elem(current.Data))
                {
                    this.AddLast(current.Data);
                }
                current = current.Next;
            }
            result.Sort();  
            return result;
    }

    public Mn Intersection(Mn A) 
    {
        if(Is_empty() && A.Is_empty()) 
        {
            return null;
        }
        if (Is_empty()) 
        {
            return A;
        }
        if (A.Is_empty()) 
        {
            return this;
        }

        Mn result = new Mn(1);

        if(A.size_of_mn > size_of_mn) 
        {
            Node current = A.Head;
            for(int i = 0; i < A.size_of_mn; i++) 
            {
                if (Search_elem(current.Data)) 
                {
                    result.AddHead(current.Data);
                    result.size_of_mn++;
                }
                current = current.Next;
            }
            result.Sort();
            return result;
        }
        else 
        {
            Node current = Head;
            for (int i = 0; i < size_of_mn; i++)
            {
                if (A.Search_elem(current.Data))
                {
                    result.AddHead(current.Data);
                    result.size_of_mn++;
                }
                current = current.Next;
            }

            result.Sort();
            return result;
        }
    }

    public Mn Difference(Mn A) 
    {
        if (Is_empty() && A.Is_empty())
        {
            return null;
        }
        if (Is_empty())
        {
            return A;
        }
        if (A.Is_empty())
        {
            return this;
        }
        if(this == A) 
        {
            return this;
        }

        Mn result = new Mn(1);

        if (A.size_of_mn > size_of_mn)
        {
            Node current = A.Head;
            for (int i = 0; i < A.size_of_mn; i++)
            {
                if (!Search_elem(current.Data)) 
                {
                    result.AddLast(current.Data);
                    result.size_of_mn++;
                }
                current = current.Next;
            }

            result.Sort();
            return result;
        }
        else
        {
            Node current = Head;
            for (int i = 0; i < size_of_mn; i++)
            {
                if (!A.Search_elem(current.Data)) 
                {
                    result.AddLast(current.Data);
                    result.size_of_mn++;
                }
                current = current.Next;
            }

            result.Sort();
            return result;
        }
    }


    // как объединение 
/*    public void Perfect(Mn A)
    {
        Node current = A.Head;
        for (int i = 0; i < A.size_of_mn; i++)
        {
            if (!Search_elem(current.Data))
            {
                AddLast(current.Data);
            }
            current = current.Next;
        }
        Sort();
    }*/


    //как разность с множеством из элементов из 1 до 100 
    public Mn Perfect(Mn A) 
    {
        
        Mn perfct_mn = new Mn();
        for (int i = 1; i <= 100; i++)
            perfct_mn.AddLast(i);
        
        Node current  = A.Head;
        for(int i = 0; i < A.size_of_mn; i++) 
        {
            if (perfct_mn.Search_elem(current.Data)) 
            {
                perfct_mn.remove_to_key(current.Data);
            }
        }

        perfct_mn.Sort();
        return perfct_mn;
    }

    public void Perfect(Mn A) 
    {
        Node current = A.Head;
        for (int i = 0; i < A.size_of_mn; i++)
        {
            if (!Search_elem(current.Data))
            {
                AddLast(current.Data);
            }
            current = current.Next;
        }
        Sort();

    }


    public void Add(int x)
    {
        if (Search_elem(x)) Console.WriteLine($"Элемент {x} уже существует в мноестве.");
        else 
        {
            AddLast(x);
            size_of_mn += 1;
        }
        Sort();
    }

    public void Remove(int x)
    {
        this.remove_to_key(x);
        size_of_mn -= 1;
        Sort();
    }
}