
namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1 - NumbersList
            Console.WriteLine("Task 1 - Numbers List");
            NumbersList numbersList = new();
            numbersList.Run();
            #endregion
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();
            #region Task 2 - StringList
            Console.WriteLine("Task 2 - String List");
            StringList stringList = new();
            stringList.Run();
            #endregion
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();
            #region Task 3 - StudentsList
            Console.WriteLine("Task 3 - Students List");
            StudentsList studentsList = new();
            studentsList.Run();
            #endregion
        }
    }
}
