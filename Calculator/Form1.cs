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
        private double result;
        private double currentNumber;
        private char currentOperation;

        public Form1()
        {
            InitializeComponent();
            result = 0;
            currentNumber = 0;
            currentOperation = ' ';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            if (resultLabel.Text == "0" || currentOperation != ' ')
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
                currentNumber = number;
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            currentOperation = button.Text[0];
            if (currentOperation != ' ')
            {
                try
                {
                    Calculate();
                    resultLabel.Text = result.ToString();
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                    resultLabel.Text = "0";
                    return;
                }
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
                resultLabel.Text = result.ToString();
                currentOperation = ' ';
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Clear();
                resultLabel.Text = "0";
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            resultLabel.Text = "0";
        }

        private void Calculate()
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

        private void resultLabel_Click(object sender, EventArgs e)
        {
        }
    }
}

