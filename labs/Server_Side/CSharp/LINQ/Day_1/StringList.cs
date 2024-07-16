namespace Day_1
{
    internal class StringList
    {
        // Declare a list of strings
        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

        public void Run()
        {
            // Query 1 Result
            IEnumerable<string> result = names.Where(name => name.Length == 3);

            // Show the result of query one.
            Console.WriteLine("Query One Result:");
            foreach (string name in result)
            {
                Console.WriteLine(name);
            }

            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Query 2 Result
            Console.WriteLine("Query Two Result:");
            result = names.Where(name => name.ToLower().Contains("a")).OrderBy(name => name.Length);

            // Show the result of query two.
            foreach (string name in result)
            {
                Console.WriteLine(name);
            }

            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Query 3 Result
            result = names.Take(2);

            // Show the result of query three.
            Console.WriteLine("Query Three Result:");
            foreach (string name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
