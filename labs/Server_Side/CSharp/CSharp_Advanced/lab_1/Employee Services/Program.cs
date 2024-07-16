namespace Employee_Services
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArr = new Employee[3];


            for (int i = 0; i < empArr.Length; i++)
            {
                try
                {
                    int id = i + 1;
                    Console.WriteLine($"Enter Employee {i + 1} name:");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Enter Employee {i + 1} salary:");
                    double salary = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter Employee {i + 1} security level:");
                    Privileges security = (Privileges)int.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter Employee {i + 1} Gender:");
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
                    Console.WriteLine($"Enter Employee {i + 1} Hiring Date:");
                    Console.WriteLine("Year:");
                    int year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Month:");
                    int month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Day:");
                    int day = int.Parse(Console.ReadLine());
                    HiringDate hiringDate = new HiringDate(year, month, day);
                    empArr[i] = new Employee(id, name, salary, security, gender, hiringDate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            // Using Selection Sort
            //int min_idx = 0;
            //for (int i = 0; i < empArr.Length; i++)
            //{
            //    for (int j = i + 1; j < empArr.Length; j++)
            //    {
            //        if (empArr[j] < empArr[min_idx])
            //        {
            //            min_idx = j;
            //        }
            //    }

            //    if (min_idx != i)
            //    {
            //        Employee temp = empArr[i];
            //        empArr[i] = empArr[min_idx];
            //        empArr[min_idx] = temp;
            //    }
            //}

            // Using Array.Sort, with IComparable implementation
            Array.Sort(empArr);

            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine(empArr[i]);
            }
        }
    }
}
