namespace lab3
{
    struct HiringDate
    {
        int day;
        int month;
        int year;

        public HiringDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public void SetDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public string GetString()
        {
            return $"{day}/{month}/{year}";
        }

        public int Day {
            get { return day; }
            set {
                if (value > 0 && value <= 31)
                    day = value;
                else
                    day = 1;
            }
        }

        public int Month {
            get { return month; }
            set {
                if (value > 0 && value <= 12)
                    month = value;
                else
                    month = 1;
            }
        }

        public int Year {
            get { return year; }
            set {
                if (value > 0 && value <= 2024)
                    year = value;
                else
                    year = 2024;
            }
        }

        public int GetDays()
        {
            return day + month * 30 + year * 365;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public udouble Salary { get; set; }
        public HiringDate HireDate { get; set; }

        public Employee(int _id, udouble _salary, HiringDate _hireDate)
        {
            Id = _id;
            Salary = _salary;
            HireDate = _hireDate;
        }

        public string GetString()
        {
            return $"Id: {Id}\n" + $"Salary: {Salary:D2}\n" + $"Hiring date: {HireDate.GetString()}\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creation of array of employees based on user input
            Console.WriteLine("How many employees do you want to add?");
            int numberOfEmployees = int.Parse(Console.ReadLine());
            Employee[] employeesArray = new Employee[numberOfEmployees];

            // Get employees data from the user
            for(int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"Enter the id of the employee {i + 1}:");
                int employeeId = int.Parse(Console.ReadLine());
                Console.WriteLine($"Enter the salary of the employee {i + 1}:");
                udouble employeeSalary = udouble.Parse(Console.ReadLine());
                Console.WriteLine($"Enter the hiring date of the employee {i + 1}:");
                Console.WriteLine("Day:");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("Month:");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Year:");
                int year = int.Parse(Console.ReadLine());
                HiringDate employeeHireDate = new HiringDate(day, month, year);
                employeesArray[i] = new Employee(employeeId, employeeSalary, employeeHireDate);
            }

            // Sort employees by hiring date
            int minimum = 0;
            Employee tmp;
            for (int i = 0; i < numberOfEmployees; i++)
            {
                for (int j = i + 1; j < numberOfEmployees; j++)
                {
                    if (employeesArray[j].HireDate.GetDays() < employeesArray[i].HireDate.GetDays() || (employeesArray[j].HireDate.GetDays() < employeesArray[minimum].HireDate.GetDays()))
                    {
                        minimum = j;
                    }
                }
                if (employeesArray[minimum].HireDate.GetDays() < employeesArray[i].HireDate.GetDays())
                {
                    tmp = employeesArray[i];
                    employeesArray[i] = employeesArray[minimum];
                    employeesArray[minimum] = tmp;
                }
            }

            Console.WriteLine("Array Sorted");

            // Print the sorted array
            Console.WriteLine("Employees=>");
            for (int i = 0; i < numberOfEmployees; i++)
            {
                System.Console.WriteLine($"Employee {i + 1}");
                System.Console.WriteLine(employeesArray[i].GetString());
            }
        }
    }
}