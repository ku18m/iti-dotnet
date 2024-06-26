using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Queue<Type>
    {
        Type[] arr;
        int first = -1;
        int last = -1;
        int size = 0;

        public Queue(int size = 10)
        {
            arr = new Type[size];
        }

        public void push(Type item)
        {
            Console.WriteLine("Push");
            if (first == last && last != -1)
                throw new Exception("Queue is full");
            if (first == arr.Length - 1 && last > -1)
                first = -1;
            arr[++first] = item;
            size++;
            print();
        }

        public Type pop()
        {
            Console.WriteLine("POP");
            if (size == 0)
                throw new Exception("Queue is empty");
            if (last == arr.Length - 1 && first > -1)
                last = -1;
            print();
            size--;
            return arr[++last];
        }

        public void print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
