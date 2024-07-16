using Part1;
using Part2;

namespace Day3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Pick the part you want to run?");
            Console.WriteLine("1. Part 1");
            Console.WriteLine("2. Part 2");

            char task = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (task)
            {
                case '1':
                    Part_1.run();
                    break;
                case '2':
                    Part_2.run();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }
    }
}
