﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        string sign;
        double num1;
        double num2;
        bool startNewNumber = true;
        bool gcd = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button_num_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;
            if (startNewNumber || textBox1.Text.Equals("0"))
            {
                textBox1.Text = "";
                
            }
            textBox1.Text += pressedButton.Text;
            startNewNumber = false;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(textBox1.Text);
            label1.Text = String.Empty;
            switch(sign)
            {
                case "+":
                    textBox1.Text = Convert.ToString(num1 + num2);
                    break;
                case "-":
                    textBox1.Text = Convert.ToString(num1 - num2);
                    break;
                case "*":
                    textBox1.Text = Convert.ToString(num1 * num2);
                    break;
                case "/":
                    if(num2 == 0)
                    {
                        textBox1.Text = "Cannot be divided by 0";
                    }
                    else
                    {
                        textBox1.Text = Convert.ToString(num1 / num2);
                    }
                    break;
            }
            startNewNumber=true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Operation("+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            Operation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Operation("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Operation("/");
        }
        private void Operation(string sign)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            label1.Text = textBox1.Text;
            label1.Text += sign;
            this.sign = sign;
            startNewNumber = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void buttonNWW_Click(object sender, EventArgs e)
        {
            string[] nums = textBox1.Text.Split(',');
            if (nums.Length == 2)
            {
                label1.Text = textBox1.Text + " NWW";
                int[] numbers = Array.ConvertAll<string, int>(textBox1.Text.Split(','), int.Parse);
                textBox1.Text = calculate_NWW(numbers[0], numbers[1]).ToString();
            }
            else
            {
                MessageBox.Show("Podaj dwie liczby oddzielone przecinkiem za pomoca klawiatury np. 8,12 i nacisnij NWW");
            }
        }

        private void buttonNWD_Click(object sender, EventArgs e)
        {
            string[] nums = textBox1.Text.Split(',');
            if (nums.Length == 2)
            {
                label1.Text = textBox1.Text + " NWD";
                int[] numbers = Array.ConvertAll<string, int>(textBox1.Text.Split(','), int.Parse);
                textBox1.Text = calculate_NWD(numbers[0], numbers[1]).ToString();
            }
            else
            {
                MessageBox.Show("Podaj dwie liczby oddzielone przecinkiem za pomoca klawiatury np. 8,12 i nacisnij NWD");
            }
        }

        private int calculate_NWD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }
        private int calculate_NWW(int num1, int num2)
        {
            return (num1 / calculate_NWD(num1, num2)) * num2;
        }

    }
}
