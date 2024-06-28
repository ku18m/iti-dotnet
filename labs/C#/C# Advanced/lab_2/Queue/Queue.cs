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

        // int size = 0;

        public Queue(int size = 10)
        {
            arr = new Type[size];
        }

        // New version using endless increment of first and last
        // instead of resetting the counters based on arr.Length
        // to avoid equality while looping
        // and handle it using modulo operator.

        public void push(Type item)
        {
            if ((first == last && last != -1) || (first > arr.Length - 2 && last == -1)) // arr.Length - 2 => (1 for the max array length) + (1 for the increment).
            {
                Console.WriteLine($"ErrPUSH: {item} , F: {first}, L: {last}");
                throw new Exception("Queue is full");
            }
            first++;
            Console.WriteLine($"Push: {item}, F: {first}, L: {last}");
            arr[first % arr.Length] = item;
        }

        public Type pop()
        {
            if ( last == first )
            {
                Console.WriteLine($"ErrPOP: {arr[last % arr.Length]} , F: {first}, L: {last}");
                throw new Exception("Queue is empty");
            }
            last++;
            Console.WriteLine($"POP: {arr[last % arr.Length]} , F: {first}, L: {last}");
            return arr[last % arr.Length];
        }

        public void print()
        {
            Console.WriteLine("#################################");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("#################################");

        }




        //Old version, handling using size indicator variable.

        //public void push(Type item)
        //{
        //    if (size == arr.Length)
        //        throw new Exception("Queue is full");
        //    if (first == arr.Length - 1 && last > -1)
        //        first = -1;
        //    arr[++first] = item;
        //    size++;
        //    Console.WriteLine($"Push: {item}, First: {first}, Last: {last}, Size: {size}");
        //}

        //public Type pop()
        //{
        //    if (size == 0)
        //        throw new Exception("Queue is empty");
        //    if (last == arr.Length - 1 && first > -1)
        //        last = -1;
        //    size--;
        //    Console.WriteLine($"Pop: {arr[last + 1]}, First: {first}, Last: {last}, Size: {size}");
        //    return arr[++last];
        //}

    }
}
