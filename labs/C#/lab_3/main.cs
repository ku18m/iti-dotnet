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
            Console.WriteLine("Hello World!");
        }
    }
}