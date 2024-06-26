namespace Examination_System
{
    public abstract class Question : IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public abstract byte CorrectAnswer { get; set; }
        public abstract byte Answer { get; set; }
        public Dictionary<byte, string> QuestionChoices { get; set; }

        protected Question(string header, string body, int marks, Dictionary<byte, string>? choices)
        {
            Header = header;
            Body = body;
            Marks = marks;
            QuestionChoices = choices?? [];
        }

        public override string ToString()
        {
            string txt = Header + "\n" + Body + "\n";
            foreach (KeyValuePair<byte, string> answer in QuestionChoices)
            {
                txt += $"\t{(Choices)answer.Key}) {answer.Value}.\n";
            }
            txt += "Marks: " + Marks.ToString();
            return txt;
        }

        public int CompareTo(Question? other)
        {
            return Marks.CompareTo(other?.Marks);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            Question q = (Question)obj;
            return Header == q.Header && Body == q.Body && Marks == q.Marks && QuestionChoices == q.QuestionChoices;
        }
    }
}
