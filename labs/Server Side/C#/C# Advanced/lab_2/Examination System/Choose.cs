namespace Examination_System
{
    public class Choose : Question, ICloneable
    {
        byte correct;
        byte answer;

        public override byte CorrectAnswer
        {
            get
            {
                return correct;
            }
            set
            {
                if (value < 1 || value > 8 || (value & (value - 1)) != 0)
                {
                    Console.WriteLine($"Value before exception {value}");
                    throw new ArgumentOutOfRangeException("Correct answer must be between a and d");
                }
                correct = value;
            }
        }

        public override byte Answer
        {
            get
            {
                return answer;
            }
            set
            {
                if (value < 1 || value > 8 || (value & (value - 1)) != 0)
                {
                    throw new ArgumentOutOfRangeException("Answer must be between 1 and 8");
                }
                answer = value;
            }
        }

        public Choose(string header, string body, int marks, Dictionary<byte, string> choices, byte correctAnswer): base(header, body, marks, choices)
        {
            CorrectAnswer = correctAnswer;
        }

        public object Clone()
        {
            Choose question = new(Header, Body, Marks, QuestionChoices, CorrectAnswer);
            return question;
        }
    }
}
