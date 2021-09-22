using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Counter;

namespace Calculator__sharp_
{
    public partial class Form1 : Form
    {
        Counter.Counter count = new Counter.Counter();
        public string rec = "";
        public string op = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rec += "1";
            richTextBoxAnswer.Text = rec;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rec += "2";
            richTextBoxAnswer.Text = rec;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rec += "3";
            richTextBoxAnswer.Text = rec;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rec += "4";
            richTextBoxAnswer.Text = rec;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rec += "5";
            richTextBoxAnswer.Text = rec;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rec += "6";
            richTextBoxAnswer.Text = rec;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rec += "7";
            richTextBoxAnswer.Text = rec;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rec += "8";
            richTextBoxAnswer.Text = rec;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rec += "9";
            richTextBoxAnswer.Text = rec;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            rec += "0";
            richTextBoxAnswer.Text = rec;
        }

        private void button00_Click(object sender, EventArgs e)
        {
            rec += "00";
            richTextBoxAnswer.Text = rec;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e){}

        private void buttonDel_Click(object sender, EventArgs e)
        {
            Result check = new Result();
            rec = richTextBoxAnswer.Text;
            check = count.DeleteSymbol(ref rec);
            if (check == Result.VALUE_ERROR)
            {
                richTextBoxErrorsText.Text = "Wrong type of value. Try again";
                richTextBoxOperationSymbol.Text = "";
                richTextBoxAnswer.Text = "";
            }
            else
            {
                richTextBoxAnswer.Text = rec;
                rec = "";
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            count.ClearValue(ref rec);
            richTextBoxAnswer.Text = "0";
            richTextBoxOperationSymbol.Text = "";
            richTextBoxErrorsText.Text = "";
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            richTextBoxOperationSymbol.Text = "=";
            Result error = new Result();
            rec = richTextBoxAnswer.Text;
            error = count.Calculate(ref rec, op);
            richTextBoxAnswer.Text = count.res.ToString();
            switch (error)
            {
                case Result.NO_ERROR:
                    break;
                case Result.DIVISION_ERROR:
                    richTextBoxErrorsText.Text = "Division by 0 is unpossible. Try again";
                    richTextBoxOperationSymbol.Text = "";
                    richTextBoxAnswer.Text = "";
                    break;
                case Result.GETTING_SQUARE_ERROR:
                    richTextBoxErrorsText.Text = "Extraciting the square from negative" +
                        " numbers is unpossible. Try again";
                    richTextBoxOperationSymbol.Text = "";
                    richTextBoxAnswer.Text = "";
                    break;
                case Result.VALUE_ERROR:
                    richTextBoxErrorsText.Text = "Wrong type of value. Try again";
                    richTextBoxOperationSymbol.Text = "";
                    richTextBoxAnswer.Text = "";
                    break;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            op = "+";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e){}

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            op = "-";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            op = "*";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
            richTextBoxAnswer.Text = count.res.ToString();
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            op = ":";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
        }

        private void buttonProc_Click(object sender, EventArgs e)
        {
            op = "%";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            op = "sq";
            richTextBoxOperationSymbol.Text = op;
            rec = richTextBoxAnswer.Text;
            count.Calculate(ref rec, op);
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            richTextBoxOperationSymbol.Text = "MC";
            count.ClearMemory();
            richTextBoxAnswer.Text = "0";
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            richTextBoxOperationSymbol.Text = "MR";
            richTextBoxAnswer.Text = count.memoryValue.ToString();
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            Result check = new Result();
            richTextBoxOperationSymbol.Text = "M+";
            check = count.MemoryPlus(richTextBoxAnswer.Text);
            if (check == Result.VALUE_ERROR)
            {
                richTextBoxErrorsText.Text = "Wrong type of value. Try again";
                richTextBoxOperationSymbol.Text = "";
                richTextBoxAnswer.Text = "";
            }
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            Result check = new Result();
            richTextBoxOperationSymbol.Text = "M-";
            check = count.MemoryMinus(richTextBoxAnswer.Text);
            if (check == Result.VALUE_ERROR)
            {
                richTextBoxErrorsText.Text = "Wrong type of value. Try again";
                richTextBoxOperationSymbol.Text = "";
                richTextBoxAnswer.Text = "";
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            rec += ",";
            richTextBoxAnswer.Text = rec;
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e){}

        private void Form1_Load(object sender, EventArgs e){}

        private void richTextBoxErrors_TextChanged(object sender, EventArgs e){}

        private void button10_Click(object sender, EventArgs e)
        {
            rec = "-" + rec;
            richTextBoxAnswer.Text = rec;
        }
    }
}
