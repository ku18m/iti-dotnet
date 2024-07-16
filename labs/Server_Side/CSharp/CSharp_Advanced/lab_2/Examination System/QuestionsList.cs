namespace Examination_System
{
    public class QuestionsList: List<Question>
    {
        string fileName;
        new public void Add(Question question)
        {
            base.Add(question);

            string path = Path.Combine(@"D:\ITI\Repos\iti-dotnet\labs\C#\C# Advanced\lab_2\Exams", $"{fileName}.txt");
            using StreamWriter sw = File.AppendText(path);
                sw.WriteLine($"{question}\nCorrect Answer: {(Choices)question.CorrectAnswer}");
        }

        new public void Remove(Question question)
        {
            base.Remove(question);
        }

        public QuestionsList(int numberOfQuestions, string? examName = null) : base(numberOfQuestions)
        {
            fileName = examName ?? $"Exam-{DateTime.Now:yyyyMMdd_HHmmss}";
        }
    }
}
