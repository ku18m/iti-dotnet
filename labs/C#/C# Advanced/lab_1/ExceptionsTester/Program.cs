namespace ExcpetionsTester
{
    public class Student
    {
        string _name;
        int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 3)
                    throw new NameExceptions.NameTooShortException();
                if (value.Length > 10)
                    throw new NameExceptions.NameTooLongException();
                if (char.IsLower(value[0]))
                    throw new NameExceptions.NameNotCapitalizedException();
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18)
                    throw new AgeExceptions.AgeTooYoungException();
                if (value > 28)
                    throw new AgeExceptions.AgeTooOldException();
                _age = value;
            }
        }

        public Student(string name = "Unknown", int age = 18)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student s = new Student("Ahmed", 100);
            }
            catch (Exceptions.BaseException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
