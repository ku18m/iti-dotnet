using System.Transactions;

namespace Examination_System
{
    internal class Program
    {
        private static int GetExamType()
        {
            Console.WriteLine("Enter the exam type by 1 for Practice, 2 for Final");
            Console.WriteLine("1) Practice");
            Console.WriteLine("2) Final");
            string examType = Console.ReadLine();
            switch (examType)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                default:
                    Console.WriteLine("Invalid exam type");
                    return GetExamType();
            }
        }
        private static Exam createExam()
        {
            Exam exam = null;
            try
            {
                int examType = GetExamType();
                Console.WriteLine("Enter the exam name");
                string examName = Console.ReadLine();
                Console.WriteLine("Enter the exam time");
                int time = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of questions");
                int numberOfQuestions = int.Parse(Console.ReadLine());
                if (examType == 1)
                {
                    exam = new PracticeExam(examName, time, numberOfQuestions);
                }
                else
                {
                    exam = new FinalExam(examName, time, numberOfQuestions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                createExam();
            }
            return exam;
        }

        private static int GetQuestionType()
        {
            Console.WriteLine("Enter the question type by 1 for True or False, 2 for Choose, 3 for Multiple Choice");
            Console.WriteLine("1) True or False");
            Console.WriteLine("2) Choose");
            Console.WriteLine("3) Multiple Choice");
            string questionType = Console.ReadLine();
            switch (questionType)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    Console.WriteLine("Invalid question type");
                    return GetQuestionType();
            }
        }

        private static Question? CreateQuestion()
        {
            Question question = null;
            try
            {
                int questionType = GetQuestionType();
                Console.WriteLine("Enter the question header");
                string header = Console.ReadLine();
                Console.WriteLine("Enter the question body");
                string body = Console.ReadLine();
                Console.WriteLine("Enter the question marks");
                int marks = int.Parse(Console.ReadLine());
                byte correctAnswer;
                switch (questionType)
                {
                    case 1:
                        Console.WriteLine("Enter the correct answer by 1 for True, 2 for False");
                        correctAnswer = byte.Parse(Console.ReadLine());
                        question = new TrueOrFalse(header, body, marks, correctAnswer);
                        break;
                    case 2:
                        Dictionary<byte, string> choices = new Dictionary<byte, string>();
                        for (byte i = 1; i <= 8; i*=2)
                        {
                            Console.WriteLine("Enter choice " + (Choices)i);
                            choices[i] = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the correct answer");
                        correctAnswer = (byte)Enum.Parse(typeof(Choices), Console.ReadLine());
                        question = new Choose(header, body, marks, choices, correctAnswer);
                        break;
                    case 3:
                        Dictionary<byte, string> mulchoices = new Dictionary<byte, string>();
                        for (byte i = 1; i <= 8; i*=2)
                        {
                            Console.WriteLine("Enter choice " + (Choices)i);
                            mulchoices[i] = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the correct answer");
                        correctAnswer = (byte)Enum.Parse(typeof(Choices), Console.ReadLine());
                        question = new ChooseAll(header, body, marks, mulchoices, correctAnswer);
                        break;
                    default:
                        Console.WriteLine("Invalid question type");
                        return CreateQuestion();
                }
                return question;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return CreateQuestion();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Exam exam = createExam();
                for (int i = 1; i <= exam.NumberOfQuestions; i++)
                {
                    Console.WriteLine($"Question {i}:");
                    exam.AddQuestion(CreateQuestion());
                }
                exam.TakeExam();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main(args);
            }
        }
    }
}
