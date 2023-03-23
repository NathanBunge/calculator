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
            if (calculator.Result == 0 || calculator.CurrentOperation != ' ')
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
                calculator.CurrentNumber = number;
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            calculator.CurrentOperation = button.Text[0];
            if (calculator.CurrentOperation != ' ')
            {
                try
                {
                    calculator.Calculate();
                    resultLabel.Text = calculator.Result.ToString();
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    calculator.Clear();
                    resultLabel.Text = "0";
                    return;
                }
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            try
            {
                calculator.Calculate();
                resultLabel.Text = calculator.Result.ToString();
                calculator.CurrentOperation = ' ';
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                calculator.Clear();
                resultLabel.Text = "0";
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            resultLabel.Text = "0";
        }

        private void resultLabel_Click(object sender, EventArgs e)
        {
        }
    }
}