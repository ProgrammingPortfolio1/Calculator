using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double tot = 0.0;

        //if 0 is pressed
        private void button10_Click(object sender, EventArgs e)
        {
            displayNums("0");
        }

        //if 1 is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            displayNums("1");
        }

        //if 2 is pressed
        private void button2_Click(object sender, EventArgs e)
        {
            displayNums("2");
        }

        //if 3 is pressed
        private void button3_Click(object sender, EventArgs e)
        {
            displayNums("3");
        }

        //if 4 is pressed
        private void button4_Click(object sender, EventArgs e)
        {
            displayNums("4");
        }

        //if 5 is pressed
        private void button5_Click(object sender, EventArgs e)
        {
            displayNums("5");
        }

        //if 6 is pressed
        private void button6_Click(object sender, EventArgs e)
        {
            displayNums("6");
        }

        //if 7 is pressed
        private void button7_Click(object sender, EventArgs e)
        {
            displayNums("7");
        }

        //if 8 is pressed
        private void button8_Click(object sender, EventArgs e)
        {
            displayNums("8");
        }

        //if 9 is pressed
        private void button9_Click(object sender, EventArgs e)
        {
            displayNums("9");
        }

        //if , is pressed
        private void button20_Click(object sender, EventArgs e)
        {
            displayOperands(",");
        }

        //if ÷ is pressed
        private void button11_Click(object sender, EventArgs e)
        {
            displayOperands("÷");
        }

        //if - is pressed
        private void button13_Click(object sender, EventArgs e)
        {
            displayOperands("-");
        }

        //if × is pressed
        private void button12_Click(object sender, EventArgs e)
        {
            displayOperands("×");
        }

        //if + is pressed
        private void button14_Click(object sender, EventArgs e)
        {
            displayOperands("+");
        }

        //if ( is pressed
        private void button15_Click(object sender, EventArgs e)
        {
            displayOperands("(");
        }

        //if ) is pressed
        private void button16_Click(object sender, EventArgs e)
        {
            displayOperands(")");
        }

        //displays the numbers
        private void displayNums(string s)
        {
            textBox1.SelectedText = s;
            textBox1.Focus();
        }

        //displays the operands
        private void displayOperands(string s2)
        {
            textBox1.SelectedText = s2;
            textBox1.Focus();
        }

        //if = is pressed
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                tot = Evaluate(textBox1.Text);
                textBox2.Text = Math.Round(tot, 3).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("The arithmetic expression contains errors", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Focus();
            }
        }

        //if Clear is pressed
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            tot = 0.0;
            textBox1.Focus();
        }

        //if Backspace is pressed
        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionStart != 0)
            {
                int index = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart - 1, 1);
                textBox1.Select(index - 1, 0);
                textBox1.Focus();
            }
        }

        //makes the calculations
        private static double Evaluate(string expression)
        {
            expression = expression.Replace("×", "*");
            expression = expression.Replace("÷", "/");
            expression = expression.Replace(",", ".");

            DataTable evDataTable = new DataTable();
            DataColumn evDataColumn = new DataColumn("Eval", typeof(double), expression);
            evDataTable.Columns.Add(evDataColumn);
            evDataTable.Rows.Add(0);
            return (double)(evDataTable.Rows[0]["Eval"]);
        }

        //checking for forbidden characters
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^0-9^+^\-^/^*^(^)^.^÷^×^,]");

            MatchCollection matches = regex.Matches(textBox1.Text);
            if (matches.Count > 0)
            {
                int index = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart - 1, 1);
                textBox1.Select(index - 1, 0);
                textBox1.Focus();
            }
        }
    }
}
