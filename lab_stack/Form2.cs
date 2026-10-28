using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Queue<string> q1 = new Queue<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            q1.Clear();

            int count = int.Parse(textBox1.Text);
            int lim1 = int.Parse(textBox2.Text);
            int lim2 = int.Parse(textBox3.Text);

            char[] symbols = new char[36];

            for (int i = 0; i < 10; i++)
            {
                symbols[i] = '_';
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

                q1.Enqueue(str_random);
            }

            foreach (string str in q1)
            {
                textBox4.Text += str;
                textBox4.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";

            Queue<string> q2 = new Queue<string>();
            Queue<string> q3 = new Queue<string>();

            foreach (string str in q1)
            {
                if (str[0] == '_')
                    q2.Enqueue(str);
                else
                    q3.Enqueue(str);
            }

            textBox5.Text += "stack2:";
            textBox5.Text += Environment.NewLine;

            foreach (string str in q2)
            {
                textBox5.Text += str;
                textBox5.Text += Environment.NewLine;
            }

            textBox5.Text += Environment.NewLine + "stack3:" + Environment.NewLine;

            foreach (string str in q3)
            {
                textBox5.Text += str;
                textBox5.Text += Environment.NewLine;
            }
        }
    }
}