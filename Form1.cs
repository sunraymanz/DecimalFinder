using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecimalFinder
{
    public partial class Form1 : Form
    {
        long x, y;
        int position = 1;
        int decimalNum;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(textBox1.Text, out x)) label4.Text = "Input x = " + x;
            else
            {
                x = 0;
                label4.Text = "Invalid Input x";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(textBox2.Text, out y)) label4.Text = "Input y = " + y;
            else
            {
                y = 0; 
                label4.Text = "Invalid Input y";
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out position))
            {
                if (position < 1)
                {
                    position = 1;
                    textBox3.Text = "1";
                    label4.Text = "Position must be Positive";
                }
                else label4.Text = "Find decimal at " + position;
            }
            else
            {
                position = 0;
                label4.Text = "Invalid Input Position";
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {             
            decimalNum = ValueAtPosition(x,y, position) ;
            if (decimalNum == -1)
            {
                label4.Text = "Invalid Input";
            }
            else label4.Text = "Answer is : " + decimalNum;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "1";
            label4.Text = "";
            x = 0;
            y = 0;
            position = 1;
        }

        public int ValueAtPosition(long x, long y, int position)
        {
            if (y == 0)
                return -1;
            x = Math.Abs(x);
            y = Math.Abs(y);
            long quotient = x / y;
            long remainder = x % y;
            for (int i = 1; i <= position; i++)
            {
                remainder *= 10;
                quotient = remainder / y;
                remainder %= y;

                if (i == position)
                    return (int)quotient;

                if (remainder == 0)
                    break;
            }
            return -1; 
        }

    }
}
