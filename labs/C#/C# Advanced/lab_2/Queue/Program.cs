namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int> q = new Queue<int>(5);
            q.push(1);
            q.print();
            q.push(2);
            q.print();
            q.push(3);
            q.print();

            q.push(4);
            q.print();

            q.push(5);
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.push(6);
            q.print();

            q.push(7);
            q.print();

            q.push(8);
            q.print();

            q.push(9);
            q.print();

            //q.push(10);
            //q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();

            q.pop();
            q.print();
        }
    }
}
