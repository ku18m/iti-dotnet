using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace bonus_1
{
    public class Bonus1
    {
        public static void run()
        {
            Console.WriteLine("Bonus 1>>");
            Console.WriteLine("Enter the length of the array:");
            int arrLength = int.Parse(Console.ReadLine());
            int[] array = new int[arrLength];
            bool inputLoopFlag = true;
            for (int i = 0; i < arrLength; i++)
            {
                Console.WriteLine($"Enter the grade of student {i + 1}:");
                array[i] = int.Parse(Console.ReadLine());
            }
            while (inputLoopFlag)
            {
                Console.WriteLine("Pick the operation you want to run?");
                Console.WriteLine("1. Operation 1");
                Console.WriteLine("2. Operation 2");
                Console.WriteLine("3. Operation 3");
                Console.WriteLine("4. Operation 4");
                Console.WriteLine("5. Operation 5");
                Console.WriteLine("6. Operation 6");
                Console.WriteLine("7. Operation 7");

                char task = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (task)
                {
                    case '1':
                        Operation1(array);
                        break;
                    case '2':
                        Operation2(array);
                        break;
                    case '3':
                        Operation3(array);
                        break;
                    case '4':
                        Operation4(array);
                        break;
                    case '5':
                        Operation5(array);
                        break;
                    case '6':
                        Operation6(array);
                        break;
                    case '7':
                        Operation7(array);
                        break;
                    default:
                        Console.WriteLine("Invalid task number");
                        inputLoopFlag = false;
                        break;
                }
            }
            
        }

        public static void Operation1(int[] array)
        {
            Console.WriteLine("Operation 1>>");
            int sum = 0;
            for(int i = 0; i < array.Length;i++)
            {
                sum += array[i];
            }
            Console.WriteLine($"The sum of the array is: {sum}");
            
        }

        public static void Operation2(int[] array)
        {
            Console.WriteLine("Operation 2>>");
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine($"The maximum member of the array is: {max}");
        }

        public static void Operation3(int[] array)
        {
            Console.WriteLine("Operation 3>>");
            int max = array.Length;
            int[] reversed = new int[max];
            for (int i = 0; i < array.Length; i++)
            {
                reversed[i] = array[max - 1];
                max--;
            }
            array = reversed;
            Console.WriteLine($"Array reversed");
            for (int i = 0;i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void Operation4(int[] array)
        {
            Console.WriteLine("Operation 4>>");
            Console.WriteLine("Enter the number to check:");
            int number = int.Parse(Console.ReadLine()), occurnices = 0;
            
            for(int i = 0; i<array.Length; i++)
            {
                if (array[i] > number) { occurnices++; }
            }

            Console.WriteLine($"Number of occurnices is: {occurnices}");
        }

        public static void Operation5(int[] array)
        {
            Console.WriteLine("Operation 5>>");
            int[] modifiedArr = new int[array.Length];
            int arrSize = array.Length;
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if(Helpers.isItIn(modifiedArr, array[i]))
                {
                    arrSize--;
                }
                else
                {
                    modifiedArr[j] = array[i];
                    j++;
                }
            }
            
            Console.WriteLine($"Duplications removed.");
            for (int i = 0;i < arrSize; i++) 
            { 
                Console.WriteLine(modifiedArr[i]);
            }
        }

        public static void Operation6(int[] array)
        {
            Console.WriteLine("Operation 6>>");

            int max = 0, secondMax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    secondMax = max;
                    max = array[i];
                }
                else if (array[i] > secondMax && array[i] != max)
                {
                    secondMax = array[i];
                }
            }
            Console.WriteLine($"The second maximum member of the array is: {secondMax}");
        }

        public static void Operation7(int[] array)
        {
            Console.WriteLine("Operation 7>>");

            int minIdx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[minIdx])
                {
                    minIdx = i;
                }
            }
            Console.WriteLine($"The minimum element index in the array is: {minIdx}");
        }
    }

    public class Helpers
    {
        public static bool isItIn(int[] array, int number)
        {
            for(int i=0; i<array.Length; i++)
            {
                if (array[i] == number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

namespace bonus_2
{
    public class Bonus2
    {
        public static void run()
        {
            Console.WriteLine("Bonus 2>>");
            Console.WriteLine("Enter the max number:");
            string maxNumber = Console.ReadLine();
            double occurrences = 0;

            occurrences = Math.Pow(10, (maxNumber.Length - 1)) * maxNumber.Length;



            #region commented solutions
            //int lastIdx = maxNumber.Length - 1;

            //for(int i = 0; i < maxNumber.Length; i++)
            //{
            //    Console.WriteLine(Math.Pow(10, (lastIdx - i)));
            //    occurrences += Math.Pow(10, (lastIdx - i));
            //}

            //int occurrences = Helpers.CountOnes(int.Parse(maxNumber));


            //int lastIdx = maxNumber.Length - 1;
            //double occurnices = 1;
            ////Console.WriteLine(lastIdx);
            ////for (int i = 0; i < maxNumber.Length;i++)
            ////{
            ////    if ((char)maxNumber[lastIdx] > '0')
            ////    {
            ////        Console.WriteLine($"param1 is {(int)maxNumber[lastIdx] - '0'}, param2 is: {Math.Pow(9, 0)}");
            ////        occurnices += Math.Pow(9, (int)maxNumber[lastIdx] - '0');
            ////    }
            ////    else { occurnices += Math.Pow(9, 0 + i); }
            ////    Console.WriteLine($"Max: {(int)maxNumber[lastIdx] - '0'}");
            ////    lastIdx--;
            ////}
            //for (int i = 0; i < maxNumber.Length; i++)
            //{
            //    if ((char)maxNumber[lastIdx] > '0')
            //    {
            //        occurnices *= 1 + (maxNumber.Length - lastIdx);
            //    }
            //    else { occurnices += Math.Pow(9, 0 + i); }
            //    Console.WriteLine($"Max: {(int)maxNumber[lastIdx] - '0'}");
            //    lastIdx--;
            //}
            #endregion
            Console.WriteLine($"Number of occurnices is: {occurrences}");
        }
    }

    public class Helpers
    {
        public static int CountOnes(int n)
        {
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                count += CountOnesInNumber(i);
            }
            return count;
        }

        static int CountOnesInNumber(int num)
        {
            int count = 0;
            while (num > 0)
            {
                if (num % 10 == 1)
                {
                    count++;
                }
                num /= 10;
            }
            return count;
        }
    }
}