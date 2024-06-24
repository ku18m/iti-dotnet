using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    public class Part_1
    {
        public static void run()
        {
            Console.WriteLine("Pick the task you want to run?");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Task 5");
            Console.WriteLine("6. Task 6");

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
                case '3':
                    Task3();
                    break;
                case '4':
                    Task4();
                    break;
                case '5':
                    Task5();
                    break;
                case '6':
                    Task6();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }

        public static void Task1()
        {
            Console.WriteLine("Task 1>>");
            Console.WriteLine("Enter a character:");
            Console.WriteLine((int)Console.ReadLine()[0]);
        }

        public static void Task2()
        {
            Console.WriteLine("Task 1>>");
            Console.WriteLine("Enter a number:");
            Console.WriteLine((char)int.Parse(Console.ReadLine()));
        }

        public static void Task3()
        {
            Console.WriteLine("Task 3>>");
            Console.WriteLine("Enter a number:");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("The number is Odd");
            }
            else { Console.WriteLine("The number is Even"); };

        }

        public static void Task4()
        {
            Console.WriteLine("Task 4>>");
            Console.WriteLine("Enter the first number:");
            int firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine(
                $"The Sum is: {firstNum + secondNum}\n" +
                $"The Sub is: {firstNum - secondNum}\n" +
                $"The Multiplication is: {firstNum * secondNum}"
                );
        }

        public static void Task5()
        {
            Console.WriteLine("Task 5>>");
            Console.WriteLine("Enter the your degree:");
            int degree = int.Parse(Console.ReadLine());
            if (degree > 90)
            {
                Console.WriteLine("A");
            }
            else if (degree > 65) { Console.WriteLine("B"); }
            else if (degree > 50) { Console.WriteLine("C"); }
            else { Console.WriteLine("D"); }
        }

        public static void Task6()
        {
            Console.WriteLine("Task 6>>");
            for (int firstNum = 1; firstNum <= 12; firstNum++)
            {
                for (int secondNum = 1; secondNum <= 12; secondNum++)
                {
                    Console.WriteLine($"{firstNum} x {secondNum} = {firstNum * secondNum}");
                }
            }
        }
    }
}
