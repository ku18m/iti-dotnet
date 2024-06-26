namespace Examination_System
{
    public class ChooseAll: Question, ICloneable
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
                if (value < 1 || value > 15)
                {
                    throw new ArgumentOutOfRangeException("Correct answer must be between 1 and 15 as choose all");
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
                if (value < 1 || value > 15)
                {
                    throw new ArgumentOutOfRangeException("Answer must be between 1 and 15 as choose all");
                }
                answer = value;
            }
        }

        public ChooseAll(string header, string body, int marks, Dictionary<byte, string> questionChoices, byte correctAnswer): base(header, body, marks, questionChoices)
        {
            CorrectAnswer = correctAnswer;
        }

        public object Clone()
        {
            ChooseAll question = new(Header, Body, Marks, QuestionChoices, CorrectAnswer);
            return question;
        }
    }
}
