using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsMaths
{
    public enum Operator { Addition, Subtraction, Multiplication, Division }
    
    public class Sums
    {
        Random rand = new Random();

        public Operator _operator;

        public int RangeLow { get; set; }
        public int RangeHigh { get; set; }
        
        public Sums(int rangeLow, int rangeHigh, Operator oper)
        {
            RangeLow = rangeLow;
            RangeHigh = rangeHigh;
            _operator = oper;
        }

        public Sums()
        {
        }

        public SumDisplay Get()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int answer;

            answer = rand.Next(RangeLow, RangeHigh + 1);            

            switch (_operator)
            {
                // 20 = 15 + 4
                case Operator.Addition:
                    firstNumber = rand.Next(0, answer + 1);
                    secondNumber = answer - firstNumber;
                    break;
                case Operator.Subtraction:
                    // 5 = 20 - 15
                    firstNumber = rand.Next(answer, RangeHigh + 1);
                    secondNumber = firstNumber - answer;
                    break;
                case Operator.Multiplication:
                    break;
                case Operator.Division:
                    break;
                default:
                    break;
            }

            return new SumDisplay(firstNumber, secondNumber, answer, _operator);
        }

        internal SumDisplay GetDouble()
        {
            int answer = rand.Next(RangeLow, RangeHigh + 1);
            answer = answer / 2 * 2;
            int half = answer / 2;

            return new SumDisplay(half, half, answer, Operator.Addition);
        }

        internal SumDisplay GetHalf()
        {
            int answer = rand.Next(RangeLow, RangeHigh/2 + 1);
            int half = answer * 2;

            return new SumDisplay(half, half, answer, Operator.Addition);
        }
    }
}
