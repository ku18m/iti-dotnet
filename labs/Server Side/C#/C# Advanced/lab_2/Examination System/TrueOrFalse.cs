namespace Examination_System
{
    public class TrueOrFalse : Question, ICloneable
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
                if (value < 1 || value > 2)
                {
                    throw new ArgumentOutOfRangeException("Correct answer must be 1 or 2");
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
                if (value < 1 || value > 2)
                {
                    throw new ArgumentOutOfRangeException("Answer must be 1 or 2");
                }
                answer = value;
            }
        }

        public TrueOrFalse(string header, string body, int marks, byte correctAnswer) : base(header, body, marks, new Dictionary<byte, string>(1))
        {
            CorrectAnswer = correctAnswer;
            QuestionChoices[1] = "True";
            QuestionChoices[2] = "False";
        }

        public object Clone()
        {
            TrueOrFalse question = new(Header, Body, Marks, CorrectAnswer);
            return question;
        }
    }
}
