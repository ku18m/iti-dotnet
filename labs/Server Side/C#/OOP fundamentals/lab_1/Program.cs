using part_1;
using part_2;
using bonus_1;
using bonus_2;
namespace lab_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Pick the part you want to run?");
            Console.WriteLine("1. Part 1");
            Console.WriteLine("2. Part 2");
            Console.WriteLine("3. Bonus 1");
            Console.WriteLine("4. Bonus 2");

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
                case '3':
                    Bonus1.run();
                    break;
                case '4':
                    Bonus2.run();
                    break;
                default:
                    Console.WriteLine("Invalid task number");
                    break;
            }
        }
    }
}
