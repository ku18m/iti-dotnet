namespace Examination_System
{
    public class FinalExam : Exam
    {
        public FinalExam(string examName, int time, int numberOfQuestions) : base(examName, time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            this.StartExam();
            foreach (Question question in Questions)
            {
                Console.WriteLine(question);
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
            }
            Console.WriteLine("====================================");
            EndExam();
        }
    }
}
