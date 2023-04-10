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
    public partial class Form1 : Form
    {
        private CalculatorLogic calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new CalculatorLogic();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            if (calculator.num == 0 || calculator.currentOperation != ' ')
            {
                resultLabel.Text = "";
            }
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!resultLabel.Text.Contains("."))
                {
                    resultLabel.Text += ".";
                }
            }
            else
            {
                resultLabel.Text += button.Text;
            }
            double number;
            if (Double.TryParse(resultLabel.Text, out number))
            {
                calculator.current = number;
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            calculator.currentOperation = button.Text[0];
            if (calculator.currentOperation != ' ')
            {
                calculator.Logic();
                resultLabel.Text = calculator.num.ToString();
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            calculator.Logic();
            resultLabel.Text = calculator.num.ToString();
            calculator.currentOperation = ' ';
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {

            calculator.num = 0;
            calculator.current = 0;
            calculator.currentOperation = ' ';
            
            resultLabel.Text = "0";
        }

        private void resultLabel_Click(object sender, EventArgs e)
        {
        }
    }
}