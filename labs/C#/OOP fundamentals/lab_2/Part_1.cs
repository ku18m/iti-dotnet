using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1
{
    internal class Part_1
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
                    GenerateMultiDimArray();
                    break;
                case '2':
                    DynamicMultiDimArray();
                    break;
                case '3':
                    JuggedArr();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }

        public static void GenerateMultiDimArray()
        {
            Console.WriteLine("Task 1>>");
            int[,] arr = new int[10, 10];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++) { arr[i, j] = (i + 1) * (j + 1); }
            }

            for (int i = 0; i < arr.GetLength(0); i++) 
            {
                for(int j = 0;j < arr.GetLength(1); j++) { Console.WriteLine(arr[i,j]); }
            }
        }

        public static void DynamicMultiDimArray()
        {
            Console.WriteLine("Task 2>>");

            Console.WriteLine("Enter the number of tracks:");
            int numOfTracks = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of students:");
            int numOfStudents = int.Parse(Console.ReadLine());

            int[,] arr = new int[numOfTracks, numOfStudents];
            int[] agesArr = new int[numOfTracks];

            for (int i = 0;i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"Track {i + 1} students->");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter the age of student {j + 1}:");
                    arr[i, j] = int.Parse(Console.ReadLine());
                    agesArr[i] += arr[i, j];
                }
            }

            for(int i = 0; i < agesArr.Length; i++)
            {
                Console.WriteLine($"The average age for track {i + 1} is {agesArr[i] / arr.GetLength(1)}");
            }

        }

        public static void JuggedArr()
        {
            Console.WriteLine("Task 3>>");
            Console.WriteLine("Enter the number of tracks:");
            int numOfTracks = int.Parse(Console.ReadLine());
            int[][] tracksArr = new int[numOfTracks][];
            int[] agesArr = new int[numOfTracks];

            //Create inner arrays
            for (int i = 0; i < numOfTracks; i++)
            {
                Console.WriteLine($"How many students in track {i + 1}");
                int numOfStudents = int.Parse(Console.ReadLine());
                tracksArr[i] = new int[numOfStudents];
                for (int j = 0; j < tracksArr[i].Length; j++)
                {
                    Console.WriteLine($"Enter the age of the student {j + 1}");
                    tracksArr[i][j] = int.Parse(Console.ReadLine());
                    agesArr[i] += tracksArr[i][j];
                }
            }

            //print the array
            for (int i = 0; i < tracksArr.Length; i++)
            {
                Console.WriteLine($"Track {i + 1} ages is:");
                for (int j = 0; j < tracksArr[i].Length; j++)
                {
                    Console.WriteLine(tracksArr[i][j]);
                }
                Console.WriteLine("==========================");
            }

            //print the age average of each track
            for (int i = 0; i < agesArr.Length; i++)
            {
                Console.WriteLine($"The average age for track {i + 1} is {agesArr[i] / tracksArr[i].Length}");
            }
        }
    }
}
