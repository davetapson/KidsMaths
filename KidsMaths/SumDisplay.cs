namespace KidsMaths
{
    public class SumDisplay
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Answer { get; set; }
        public string Operator { get; set; }
        Operator Oper { get; set; }

        public SumDisplay(int firstNumber, int lastNumber, int answer, Operator oper)
        {
            FirstNumber = firstNumber;
            SecondNumber = lastNumber;
            Answer = answer;
            Oper = oper;
            switch (oper)
            {
                case KidsMaths.Operator.Addition:
                    Operator = "+";
                    break;
                case KidsMaths.Operator.Subtraction:
                    Operator = "-";
                    break;
                case KidsMaths.Operator.Multiplication:
                    Operator = "x";
                    break;
                case KidsMaths.Operator.Division:
                    Operator = "/";
                    break;
                default:
                    break;
            }
        }
    }
}
