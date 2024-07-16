using StudentServices;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Instance of Student With Default Constructor
            Student student = new Student(name: "Omar");
            Console.WriteLine(student.GetString());
            #endregion

            #region Static Params Method
            int sum, mul;
            Student.Operate(out sum, out mul, 10, 20, 30, 40, 1, 2, 3, 4, 5);
            Console.WriteLine($"Sum = {sum}\nMul = {mul}");
            #endregion

            Console.ReadKey();
        }
    }
}
