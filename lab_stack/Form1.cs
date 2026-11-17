using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab_stack
{
    public partial class Form1 : Form
    {
        private Stack<string> stack1 = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private static char[] CreateCharMas()
        {
            char[] symbols = new char[36];

            for (int i = 0; i < 10; i++)
                symbols[i] = (char)('\u0030' + i);

            for (int i = 10; i < 36; i++)
                symbols[i] = (char)('\u0061' + i - 10);

            return symbols;
        }

        private static void FillStack(Stack<string> stack,char[] symbols,
            int count, int lim1, int lim2)
        {
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                string strRandom = "";
                int strLength = r.Next(lim1, lim2 + 1);

                for (int j = 0; j < strLength; j++)
                {
                    int index = r.Next(36);
                    strRandom += symbols[index];
                }

                stack.Push(strRandom);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            stack1.Clear();

            int count = int.Parse(textBox1.Text);
            int lim1 = int.Parse(textBox2.Text);
            int lim2 = int.Parse(textBox3.Text);
            char[] symbols = CreateCharMas();

            FillStack(stack1, symbols, count, lim1, lim2);

            foreach(string str in stack1)
                textBox4.Text += str + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";

            Stack<string> stack2 = new Stack<string>();
            Stack<string> stack3 = new Stack<string>();

            foreach (string str in stack1)
            {
                if ("0123456789".Contains(str[0]))
                    stack3.Push(str);
                else
                    stack2.Push(str);
            }

            textBox5.Text += "stack2:" + Environment.NewLine;

            foreach (string str in stack2)
                textBox5.Text += str + Environment.NewLine;

            textBox5.Text += Environment.NewLine + "stack3:" + Environment.NewLine;

            foreach (string str in stack3)
                textBox5.Text += str + Environment.NewLine;
        }
    }
}
