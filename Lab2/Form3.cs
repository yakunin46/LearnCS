using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox4.Text = "Решение:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double z = Convert.ToDouble(textBox3.Text);
            textBox4.Text += Environment.NewLine + "X = " + x.ToString();
            textBox4.Text += Environment.NewLine + "Y = " + y.ToString();
            textBox4.Text += Environment.NewLine + "Z = " + z.ToString();

            double a1 = 3 + Math.Exp(y - 1);
            double a2 = 1 + x * Math.Abs(y - Math.Tan(z));
            double a = a1 / a2;

            double b1 = 1 + Math.Abs(y - x) + Math.Pow(y - x, 2) / 2;
            double b2 = Math.Pow(Math.Abs(y - x), 3) / 3;
            double b = b1 + b2;

            textBox4.Text += Environment.NewLine + "a = " + a.ToString();
            textBox4.Text += Environment.NewLine + "b = " + b.ToString();
        }
    }
}
