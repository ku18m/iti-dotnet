namespace Examination_System
{
    public class PracticeExam : Exam
    {
        public PracticeExam(string examName, int time, int numberOfQuestions) : base(examName, time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            this.StartExam();
            foreach (Question question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine($"Correct Answer: {(Choices)question.CorrectAnswer}");
            }
            this.EndExam();
        }

        public override void TakeExam()
        {
            StartExam();
            Console.WriteLine("====================================");
            foreach (Question question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine("Enter your answer");
                byte answer = (byte)Enum.Parse(typeof(Choices), Console.ReadLine());
                AnswerQuestion(question, answer);
                Console.WriteLine("====================================");
                Console.WriteLine($"The correct Answer is: {(Choices)question.CorrectAnswer}");
            }
            Console.WriteLine("====================================");
            EndExam();
        }
    }
}
