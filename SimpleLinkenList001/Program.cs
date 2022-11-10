using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimpleLinkenList001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new NodeList("0");
            myList.AddLast("2");
            myList.AddLast("5");
            myList.AddLast("9");
            myList.AddLast("16");
            myList.AddLast("19");
            myList.AddLast("22");
            myList.AddLast("31");
            myList.AddLast("44");
            myList.AddLast("55");
            myList.AddLast("63");
            myList.AddLast("78");
            myList.AddLast("85");
            Console.WriteLine("Вывод всего списка. Работает метод \"PrintLoop\":");
            myList.PrintLoop();
            Console.WriteLine("\nВывод чётных чисел:");
            myList.Loop(x =>
            {
                try
                {
                    if (int.Parse(x.ToString()) % 2 == 0)
                    {
                        Console.WriteLine(x + " - чётное число");
                    }
                }
                catch
                {
                }
            });
            Console.WriteLine("\nВывод всего списка. Работает метод \"Loop\":");
            myList.Loop(x => Console.Write(x + " "));
            Console.WriteLine("\n" + myList + " " + myList.Count);
            Console.WriteLine("\nВывод всего списка. После метода \"DelLast\":");
            myList.DelLast();
            myList.DelLast();
            myList.DelLast();
            myList.DelLast();

            Console.WriteLine("Работает foreach:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"В нашем списке {myList.ToString()}" +
                $" содержится {myList.Count} записей\n");
        }
    }
    class Node // Звено односвязной цепочки
    {
        public string Data { get; set; }
        public Node(string data)
        {
            Data = data;
        }
        public Node Next { get; set; }
    }
    class NodeList : IEnumerable, IEnumerator // Односвязная цепочка
    {
        private int count;
        public int Count
        {
            get
            {
                count = 0;
                Node current = Head;
                while (current.Next != null)
                {
                    count++;
                    current = current.Next;
                }
                return count + 1;
            }
            set
            {                
                count = value;
            }
        }
        public int position;
        public bool MoveNext()
        {
            Node current = Head;
            while (current != null)
            {
                current = current.Next;
                return true;
            }
            return false;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= Count)
                {
                    throw new Exception("Некорректный индекс элемента");
                }
                else
                {
                    return position;
                }
            }

        }
        public void Reset()
        {
            position = 0;
        }
        public IEnumerator GetEnumerator()
        {
            Node current = Head;
            while (current.Next != null)
            {
                yield return current.Data;
                current = current.Next;
            }
            yield return current.Data;
        }
        public int Length
        {
            get
            {
                int length = 0;
                Node current = Head;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }
                return length;
            }
        }
        public Node Head { get; } // Ссылочной тип, Head - ссылк
        public NodeList(string headData)
        {
            Head = new Node(headData);
        }
        public void AddLast(string data)
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
        }
        public void DelLast()
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
                position++;
                if (position == Count - 2)
                    current.Next = null;    
            }
        }
        public void PrintLoop()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void Loop(Action<object> action)
        {
            Node current = Head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

}
