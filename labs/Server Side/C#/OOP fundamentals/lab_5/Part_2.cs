namespace part_2
{

    public static class Math
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Divide(int a, int b)
        {
            return a / b;
        }
    }

    class Part2
    {
        public static void Run()
        {
            System.Console.WriteLine(Math.Add(1, 2));
            System.Console.WriteLine(Math.Subtract(1, 2));
            System.Console.WriteLine(Math.Multiply(1, 2));
            System.Console.WriteLine(Math.Divide(1, 2));
        }
    }
}
