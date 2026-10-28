using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int counter2 = 0;
        private int counter3 = 0;
        private Queue<string> window1 = new Queue<string>();
        private Queue<string> window2 = new Queue<string>();
        private Queue<string> window3 = new Queue<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            int counter = window1.Count;
            counter += 1;
            if (counter < 10) 
            {
                window1.Enqueue($"S0{counter}");
            }
            else
            {
                window1.Enqueue($"S{counter}");
            }

            textBox1.Text = "";

            foreach (string i in window1)
            {
                textBox1.Text += i + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter2 += 1;

            if (counter2 < 10)
            {
                if(window2.Count == window3.Count)
                    window2.Enqueue($"K0{counter2}");
                else
                    window3.Enqueue($"K0{counter2}");
            }
            else
            {
                if (window2.Count == window3.Count)
                    window2.Enqueue($"K{counter2}");
                else
                    window3.Enqueue($"K{counter2}");
            }

            if (window2.Count > window3.Count)
            {
                textBox2.Text = "";
                foreach (string i in window2)
                {
                    textBox2.Text += i + Environment.NewLine;
                }
            }
            else
            {
                textBox3.Text = "";
                foreach (string i in window3)
                {
                    textBox3.Text += i + Environment.NewLine;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            counter3 += 1;

            if (counter3 < 10)
            {
                if (window2.Count == window3.Count)
                    window2.Enqueue($"B0{counter3}");
                else
                    window3.Enqueue($"B0{counter3}");
            }
            else
            {
                if (window2.Count == window3.Count)
                    window2.Enqueue($"B{counter3}");
                else
                    window3.Enqueue($"B{counter3}");
            }

            if (window2.Count > window3.Count)
            {
                textBox2.Text = "";
                foreach (string i in window2)
                {
                    textBox2.Text += i + Environment.NewLine;
                }
            }
            else
            {
                textBox3.Text = "";
                foreach (string i in window3)
                {
                    textBox3.Text += i + Environment.NewLine;
                }
            }
        }
    }
}