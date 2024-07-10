using System;
using System.ComponentModel.DataAnnotations;
using Day1_plus;
namespace Day1
{
    class Program
    {
        static void Main()
        {
            #region variable declaration
            char character = 'A';
            short shortVar = 1;
            ushort ushortVar = 1;
            int intVar = 1;
            uint uintVar = 1;
            long longVar = 1;
            ulong ulongVar = 1;
            float floatVar = 1.1f;
            double doubleVar = 1.1d;
            decimal decimalVar = 1.1m;
            #endregion
            #region references declaration
            List<object> varslist = new List<object>{
                character,
                shortVar,
                ushortVar,
                intVar,
                uintVar,
                longVar,
                ulongVar,
                floatVar,
                doubleVar,
                decimalVar
            };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            #endregion
            #region loop
            foreach (var item in varslist)
            {
                int dataSize = Data.getVarSize(item);
                string dataType = item.GetType().Name;
                dictionary[dataType] = dataSize;
            }
            #endregion
            #region output
            foreach (var item in dictionary)
            {
                Console.WriteLine($"The {item.Key} size is {item.Value} bytes");
            }
            Console.ReadKey();
            #endregion
        }
    }
}
