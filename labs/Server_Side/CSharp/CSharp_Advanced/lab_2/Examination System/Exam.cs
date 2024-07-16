using System.Reflection;

namespace Examination_System
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public string ExamName { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionsList Questions { get; set; }
        public Dictionary<Question, byte> Corrections { get; set; }

        public Exam(string examName, int time, int numberOfQuestions)
        {
            ExamName = examName;
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new QuestionsList(numberOfQuestions, examName);
            Corrections = new Dictionary<Question, byte>(numberOfQuestions);
        }

        abstract public void ShowExam();

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            Questions.Remove(question);
        }

        public void StartExam()
        {
            Console.WriteLine($"Starting {ExamName} exam");
            Console.WriteLine($"Time: {Time} minutes");
            Console.WriteLine($"Number of questions: {NumberOfQuestions}");
            Console.WriteLine("Good luck!");
        }

        public abstract void TakeExam();

        public void AnswerQuestion(Question question, byte answer)
        {
            Corrections[question] = answer;
        }

        public void EndExam()
        {
            Console.WriteLine($"Ending {ExamName} exam");
            Console.WriteLine($"Correcting {NumberOfQuestions} questions");
            Console.WriteLine($"Your grade is: {CorrectExam()}");
        }

        public int CorrectExam()
        {
            int grade = 0;
            foreach (KeyValuePair<Question, byte> questionAnswer in Corrections)
            {
                if (questionAnswer.Key.CorrectAnswer == questionAnswer.Value)
                {
                    grade += questionAnswer.Key.Marks;
                }
            }
            return grade;
        }
    }
}
