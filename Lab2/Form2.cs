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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            if (x <= 0)
            {
                textBox2.Text = "X должен быть больше 0";
                textBox2.Text += Environment.NewLine;
            }
            else
            {
                textBox2.Text += "X = " + x.ToString();
                double a = 5 * Math.Log(Math.Pow(x, 3));
                double b = 7.2 * Math.Log(Math.Abs(x), 2);
                double f = a + b / 3;
                textBox2.Text += Environment.NewLine + "Результат f = " + f.ToString();

                double c = 5 * Math.Exp(9 * x + 5);
                double d = Math.Abs(Math.Pow(Math.Log10(Math.Pow(x, 3)),7));
                double g = Math.Pow(c + d, 1d / 3);
                textBox2.Text += Environment.NewLine + "Результат g = " + g.ToString();
            }
        }
    }
}