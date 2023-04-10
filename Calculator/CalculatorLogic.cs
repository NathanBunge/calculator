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
        public double num;
        public double current;
        public char currentOperation;

        public CalculatorLogic()
        {
            num = 0;
            current = 0;
            currentOperation = ' ';
        }

        public void Logic()
        {
            Console.WriteLine("revious result: " + num.ToString());
            switch (currentOperation)
            {
                case '+':
                    num += current;
                    break;
                case '-':
                    num -= current;
                    break;
                case '*':
                    num *= current;
                    break;
                case '/':
                    num /= current;
                    break;
            }
            current = 0;
            Console.WriteLine("current result: " + num.ToString());
        }

    }
}