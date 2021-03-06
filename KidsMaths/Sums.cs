﻿using System;
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

        public SumDisplay GetAdditionAndSubtraction()
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
            int answer = rand.Next(RangeLow/2, RangeHigh/2 + 1);
            int half = answer * 2;

            return new SumDisplay(half, half, answer, Operator.Addition);
        }

        internal SumDisplay GetTimesTables(int timesTablesValue)
        {
            _operator = Operator.Multiplication;
            int firstNumber = rand.Next(1, 13);
                       
            int answer = firstNumber * timesTablesValue;

            return new SumDisplay(firstNumber, timesTablesValue, answer, _operator);
        }

        internal SumDisplay GetTens(int tensValue)
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int answer = 0;

            switch (_operator)
            {
                // 30 + 70 = 100 (30 + ? = 100)
                case Operator.Addition:
                    firstNumber = (rand.Next(0, (tensValue / 10) + 1)) * 10;
                    secondNumber = tensValue - firstNumber;
                    answer = tensValue;
                    break;
                case Operator.Subtraction:
                    // 100 - 70 = 30 (100 - 70 = ?)
                    firstNumber = tensValue;
                    secondNumber = (rand.Next(0, (tensValue / 10) + 1)) * 10;
                    answer = firstNumber - secondNumber;
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

        internal SumDisplay GetGroupings(int bondsValue)
        {
            // get random mix, weighted towards = 10
            int random = rand.Next(0, 10);
            if (random <= 6){
                return EqualsBondsValueSum(bondsValue);
            }
            else
            {
                return BondsValuePlusSum(bondsValue);
            }
        }

        private SumDisplay BondsValuePlusSum(int bondsValue)
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int answer = 0;            

            switch (_operator)
            {
                // 20 = 15 + 4
                case Operator.Addition:
                    answer = rand.Next(bondsValue, (bondsValue * 2) + 1);
                    firstNumber = 10; // rand.Next(0, bondsValue + 1);
                    secondNumber = answer - firstNumber;
                    break;
                case Operator.Subtraction:
                    // 5 = 20 - 15
                    //firstNumber = 10; // rand.Next(answer, bondsValue + 1);
                    answer = rand.Next(0, bondsValue);
                    secondNumber = 10; // firstNumber - answer;
                    firstNumber = answer + secondNumber;
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

        private SumDisplay EqualsBondsValueSum(int value)
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int answer = value;

            switch (_operator)
            {
                // 20 = 15 + 4
                case Operator.Addition:
                    firstNumber = rand.Next(0, answer + 1);
                    secondNumber = answer - firstNumber;
                    break;
                case Operator.Subtraction:
                    // 5 = 20 - 15
                    firstNumber = rand.Next(answer, value + 10 + 1);
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
    }
}
