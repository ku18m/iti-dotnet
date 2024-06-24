using System.Diagnostics.CodeAnalysis;

namespace StudentServices
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public Student(int id = 1, string name = "Unknown", int age = 200)
        {
            Id = id;
            Name = name;
            Age = age;
        }


        public string GetString()
        {
            return "Id: " + Id + " Name: " + Name + " Age: " + Age;
        }

        public static void Operate(out int sum, out int mul, params int[] arr) {
            int i = 0;
            sum = 0;
            mul = 1;
            while (i < arr.Length)
            {
                sum += arr[i];
                mul *= arr[i];
                i++;
            }
        }

    }
}
