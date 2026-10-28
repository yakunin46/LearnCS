using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_stack
{
    public partial class Form1 : Form
    {
        private Stack<string> stack1 = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            stack1.Clear();

            int count = int.Parse(textBox1.Text);
            int lim1 = int.Parse(textBox2.Text);
            int lim2 = int.Parse(textBox3.Text);

            char[] symbols = new char[36];

            for (int i = 0; i < 10; i++)
            {
                symbols[i] = (char)('\u0030' + i);
            }
            for (int i = 10; i < 36; i++)
            {
                symbols[i] = (char)('\u0061' + i - 10);
            }

            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                string str_random = "";
                int str_length = r.Next(lim1, lim2 + 1);

                for (int j = 0; j < str_length; j++)
                {
                    int index = r.Next(36);
                    str_random += symbols[index];
                }

                stack1.Push(str_random);
            }

            foreach(string str in stack1)
            {
                textBox4.Text += str;
                textBox4.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";

            Stack<string> stack2 = new Stack<string>();
            Stack<string> stack3 = new Stack<string>();

            string str_digits = "0123456789";

            foreach (string str in stack1)
            {
                if (str_digits.Contains(str[0]))
                    stack3.Push(str);
                else
                    stack2.Push(str);
            }

            textBox5.Text += "stack2:";
            textBox5.Text += Environment.NewLine;

            foreach (string str in stack2)
            {
                textBox5.Text += str;
                textBox5.Text += Environment.NewLine;
            }

            textBox5.Text += Environment.NewLine + "stack3:" + Environment.NewLine;

            foreach (string str in stack3)
            {
                textBox5.Text += str;
                textBox5.Text += Environment.NewLine;
            }
        }
    }
}
