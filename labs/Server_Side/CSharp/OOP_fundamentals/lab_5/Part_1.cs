namespace part_1
{
    abstract class Question
    {
        public string Body { get; set; }
        public int Marks { get; set; }
        public string Header { get; set; }
        public short Answer { get; set; }
        public Question(string body, int marks, string header)
        {
            Body = body;
            Marks = marks;
            Header = header;
            Answer = -1;
        }

        abstract public void Display();
    }

    class TrueFalseQuestion : Question
    {

        public TrueFalseQuestion(string body, int marks, bool answer) : base(body, marks, "True/False")
        {
            this.Answer = (short)(answer ? 1 : 0);
        }

        public override void Display()
        {
            System.Console.WriteLine($"Marks: {this.Marks}\n" + $"Question Type: {this.Header} \n" + $"{this.Body} \t (       )");
        }
    }

    class ChooseOneQuestion : Question
    {
        public string[] Options { get; set; }

        public ChooseOneQuestion(string body, string[] options, int marks, short answer) : base(body, marks, "Choose One")
        {
            this.Options = options;
            this.Answer = answer;
        }

        public override void Display()
        {
            Console.WriteLine($"Marks: {this.Marks}\n" + $"Question Type: {this.Header} \n" + $"{this.Body}");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.Write($"{i + 1}. {Options[i]}\t");
            }
            Console.WriteLine();
        }
    }

    class ChooseAll: ChooseOneQuestion
    {
        public ChooseAll(string body, string[] options, int marks, short answer) : base(body, options, marks, answer)
        {
            this.Header = "Choose All";
            string[] optionsWithChooseAll = [.. options, "Choose All"];
            this.Options = optionsWithChooseAll;
        }
    }

    class Part1
    {
        public static void Run()
        {
            Question[] questions =
            [
                new TrueFalseQuestion("Is the earth round?", 1, true),
                new ChooseOneQuestion("What is the capital of Pakistan?", new string[] { "Karachi", "Islamabad", "Lahore", "Quetta" }, 2, 2),
                new ChooseAll("Which of the following are cities of Pakistan?", new string[] { "Karachi", "Islamabad", "Lahore", "Quetta" }, 4, 5),
            ];
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine();
                questions[i].Display();
            }
        }
    }
}
