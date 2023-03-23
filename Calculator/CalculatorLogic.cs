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
        public double result;
        public double currentNumber;
        public char currentOperation;

        public CalculatorLogic()
        {
            result = 0;
            currentNumber = 0;
            currentOperation = ' ';
        }

        public void Calculate()
        {
            Console.WriteLine("revious result: " + result.ToString());
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
                    result /= currentNumber;
                    break;
            }
            currentNumber = 0;
            Console.WriteLine("current result: " + result.ToString());
        }

    }
}