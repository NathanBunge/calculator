using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public class CalculatorLogic
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

        public double Result
        {
            get { return result; }
            set { result = value; }
        }

        public double CurrentNumber
        {
            get { return currentNumber; }
            set { currentNumber = value; }
        }

        public char CurrentOperation
        {
            get { return currentOperation; }
            set { currentOperation = value; }
        }

        public void Calculate()
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
            currentNumber = 0;
        }

        public void Clear()
        {
            result = 0;
            currentNumber = 0;
            currentOperation = ' ';
        }
    }
}