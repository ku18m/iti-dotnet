namespace Day_1
{
    internal class NumbersList
    {
        // Declare a list of integers
        List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

        public void Run()
        {
            // Filter the list based on query one.
            var QueryOneResult = numbers.Distinct().OrderBy(num => num);

            // Show the result of query one.
            Console.WriteLine("Query One Result:");
            foreach (var item in QueryOneResult)
            {
                Console.WriteLine(item);
            }

            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Use query one result to filter the list based on query two.
            var QueryTwoResult = QueryOneResult.Select(num => new
            {
                Number = num,
                Multiply = num * num
            });

            // Show the result of query two.
            Console.WriteLine("Query Two Result:");
            foreach (var item in QueryTwoResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
