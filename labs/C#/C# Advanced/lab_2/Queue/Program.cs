namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Queue<int> q = new Queue<int>(5);
                q.push(1);
                q.push(2);
                q.push(3);
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                q.push(4);
                q.push(4);
                Console.WriteLine(q.pop());
                q.push(4);
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                q.push(70);
                q.push(4);
                q.push(4);
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
                Console.WriteLine(q.pop());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
