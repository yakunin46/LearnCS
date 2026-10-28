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

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int digit = Convert.ToInt32(textBox1.Text);
            int number = Convert.ToInt32(textBox2.Text);
            int a1, a2, a3;
            a3 = number % 10;
            a2 = (number - a3) / 10 % 10;
            a1 = number / 100;

            textBox3.Text = "Цифра: " + digit.ToString();
            textBox3.Text += Environment.NewLine + "Старшая цифра: " + a1.ToString();
            textBox3.Text += Environment.NewLine + "Средняя цифра: " + a2.ToString();
            textBox3.Text += Environment.NewLine + "Младшая цифра: " + a3.ToString();

            if (digit == a1) textBox3.Text += Environment.NewLine +
                    "Результат: " + ((a1 + a2 + a3) / 3d).ToString();
         
            else if (digit == a2) textBox3.Text += Environment.NewLine +
                    "Результат: " + Math.Pow(a1 * a2 * a3, 1d/3).ToString();

            else if (digit == a3) textBox3.Text += Environment.NewLine +
                    "Результат: " + (a1 + a2 + a3).ToString();

            else textBox3.Text += Environment.NewLine +
                    "Результат: " + (a1 * a2 * a3).ToString();
        }
    }
}
