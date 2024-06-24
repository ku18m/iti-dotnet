using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Part_2
    {
        public static void run()
        {
            Console.WriteLine("Pick the task you want to run?");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Bonus");

            char task = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (task)
            {
                case '1':
                    CreateArrayOfTimespan();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }

        }

        struct Rectangle
        {
            int width;
            int height;

            public int Width
            {
                get { return width; }
                set
                {
                    if (value >= 0)
                        width = value;
                    else
                        width = 0;
                }
            }

            public int Height
            {
                get { return height; }
                set
                {
                    if (value >= 0)
                        height = value;
                    else
                        height = 0;
                }
            }

            public int Area()
            {
                return width * height;
            }

            public int Perimeter()
            {
                return (width + height) * 2;
            }

            public string GetString()
            {
                return $"Rectangle dimensions is: width = {width}, height = {height}";
            }
        }

        struct TimeSpan
        {
            int hours;
            int minutes;
            int seconds;

            public int Hours
            {
                get { return hours; }
                set
                {
                    if (value < 0 || value > 23)
                    {
                        hours = 0;
                    }
                    else { hours = value; }
                }
            }

            public int Minutes
            {
                get { return minutes; }
                set
                {
                    if (value < 0 || value > 60)
                    {
                        minutes = 0;
                    }
                    else { minutes = value; }
                }
            }

            public int Seconds
            {
                get { return seconds; }
                set
                {
                    if (value < 0 || value > 60)
                    {
                        seconds = 0;
                    }
                    else { seconds = value; }
                }
            }

            public int TotalSeconds() 
            {
                int totalSec = 0;

                totalSec += seconds;
                totalSec += minutes * 60;
                totalSec += hours * 60 * 60;

                return totalSec;
            }

            public string Getstring()
            {
                return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }
        }

        public static void CreateArrayOfTimespan()
        {
            Console.WriteLine("Create array of time span>>");
            Console.WriteLine("Enter the number of timesapns:");
            int size = int.Parse(Console.ReadLine());
            TimeSpan[] arr = new TimeSpan[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = new TimeSpan();
                Console.WriteLine("Enter the hours:");
                arr[i].Hours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the minutes:");
                arr[i].Minutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the seconds:");
                arr[i].Seconds = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(arr[i].Getstring());
            }

            // Bonus, sorting the array

            int arraySize = arr.Length;
            int minimum = 0;
            TimeSpan tmp;


            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i + 1; j < arraySize; j++)
                {
                    if (arr[j].TotalSeconds() < arr[i].TotalSeconds() || (arr[j].TotalSeconds() < arr[minimum].TotalSeconds()))
                    {
                        minimum = j;
                    }
                }
                if (arr[minimum].TotalSeconds() < arr[i].TotalSeconds())
                {
                    tmp = arr[i];
                    arr[i] = arr[minimum];
                    arr[minimum] = tmp;
                }
            }
            Console.WriteLine("Sorted array");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(arr[i].Getstring());
            }
        }
    }
}
