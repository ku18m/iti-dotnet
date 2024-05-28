using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace part_2
{
    public class Part_2
    {
        public static void run()
        {
            Console.WriteLine("Pick the task you want to run?");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");

            char task = Console.ReadKey().KeyChar;
            
            Console.WriteLine();

            switch (task)
            {
                case '1':
                    Task1();
                    break;
                case '2':
                    Task2();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }

        public static void Task1()
        {
            Console.WriteLine("Task 1>>");
            Console.WriteLine("How many students you have?");
            int studentsCounter = int.Parse(Console.ReadLine());
            int studentsGradesSum = 0;
            int[] studentsGrades = new int[studentsCounter];
            for (int i = 0; i < studentsCounter; i++)
            {
                Console.WriteLine($"Enter the grade of student {i + 1}:");
                studentsGrades[i] = int.Parse(Console.ReadLine());
                studentsGradesSum += studentsGrades[i];
            }

            for (int i = 0;i < studentsCounter;i++)
            {
                Console.WriteLine($"The student {i + 1} grade is {studentsGrades[i]}");
            }

            Console.WriteLine($"The average of grades is: { studentsGradesSum / studentsCounter }");
        }

        public static void Task2()
        {
            Console.WriteLine("Task 2>>");
            Console.WriteLine("Enter the length of the array:");
            int arrLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrLength];
            int distance = 0, longestDistance = 0, longestDistanceMember = 0;

            for (int i = 0; i < arrLength; i++)
            {
                Console.WriteLine($"Enter the grade of student {i + 1}:");
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arrLength; i++)
            {
                for (int j = 0; j < arrLength; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        distance = i - j;
                    }
                    if (distance < 0) { distance *= -1; }
                    if (distance > longestDistance) { 
                        longestDistance = distance - 1;
                        longestDistanceMember = arr[i];
                    }
                }
            }

            Console.WriteLine($"The longest distance between {longestDistanceMember} and the other {longestDistanceMember} is {longestDistance}");
        }
    }
}
