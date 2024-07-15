using Day_1.models;

namespace Day_1
{
    internal class StudentsList
    {
        List<Student> students = new List<Student>() {
            new Student(){ ID=1, FirstName="Ali", LastName="Mohammed", subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){ Code=33,Name="UML"}}},
            new Student(){ ID=2, FirstName="Mona", LastName="Gala", subjects=new Subject []{ new Subject(){ Code=22,Name="EF"}, new Subject (){ Code=34,Name="XML"},new Subject (){ Code=25, Name="JS"}}},
            new Student(){ ID=3, FirstName="Yara", LastName="Yousf", subjects=new Subject[]{ new Subject (){ Code=22,Name="EF"}, new Subject (){ Code=25,Name="JS"}}},
            new Student(){ ID=1, FirstName="Ali", LastName="Ali", subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},
        };


        public void Run()
        {
            // Query 1 Result
            var queryOneResult = students.Select(student => new
            {
                FullName = $"{student.FirstName} {student.LastName}",
                NoOfSubjects = student.subjects.Length
            });

            // Show the result of query one.
            Console.WriteLine("Query One Result:");
            foreach (var item in queryOneResult)
            {
                Console.WriteLine(item);
            }

            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Query 2 Result
            var queryTwoResult = students.OrderByDescending(student => student.FirstName)
                                .ThenBy(student => student.LastName)
                                .Select(student => $"{student.FirstName} {student.LastName}");

            // Show the result of query two.
            Console.WriteLine("Query Two Result:");
            foreach (var fullName in queryTwoResult)
            {
                Console.WriteLine(fullName);
            }
            
            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Query 3 Result
            var queryThreeResult = students
                                   .SelectMany(student => student.subjects, (student, subject) => new
                                   {
                                       StudentName = $"{student.FirstName} {student.LastName}",
                                       SubjectName = subject.Name
                                   });
            

            // Show the result of query three.
            Console.WriteLine("Query Three Result:");
            foreach (var item in queryThreeResult)
            {
                Console.WriteLine(item);
            }

            //SEPARATOR
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

            // Bonus Query.
            var bonusResult = students
                              .SelectMany(student => student.subjects, (student, subject) => new
                              {
                                  StudentName = $"{student.FirstName} {student.LastName}",
                                  SubjectName = subject.Name
                              })
                              .GroupBy(item => item.StudentName);

            // Show the result of bonus.
            Console.WriteLine("Bonus Result:");
            foreach (var group in bonusResult)
            {
                Console.WriteLine(group.Key);
                foreach (var row in group)
                {
                    Console.WriteLine($"\t{row.SubjectName}");
                }
            }
        }
    }
}
