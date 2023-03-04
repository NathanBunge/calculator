using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalculatorLogic
    {
        private double result;
        private double currentNumber;
        private char currentOperation;

        public CalculatorLogic()
        {
            result = 0;
            currentNumber = 0;
            currentOperation = ' ';
        }

        public char CurrentOperation
        {
            get { return currentOperation; }
        }

        public void SetCurrentNumber(double number)
        {
            currentNumber = number;
        }

        public void SetCurrentOperation(char operation)
        {
            currentOperation = operation;
        }

        public double Calculate()
        {
            switch (currentOperation)
            {
                case '+':
                    result += currentNumber;
                    break;
                case '-':
                    result -= currentNumber;
                    break;
                case '*':
                    result *= currentNumber;
                    break;
                case '/':
                    if (currentNumber != 0)
                    {
                        result /= currentNumber;
                    }
                    else
                    {
                        throw new DivideByZeroException("Cannot divide by zero");
                    }
                    break;
            }
            return result;
        }

        public void Clear()
        {
            result = 0;
            currentNumber = 0;
            currentOperation = ' ';
        }
    }
}

