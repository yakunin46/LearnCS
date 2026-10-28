using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int digit1 = Convert.ToInt32(textBox1.Text);
            int digit2 = Convert.ToInt32(textBox2.Text);
            int sum = digit1 + digit2;
           

            textBox3.Text = "Цифра1: " + digit1.ToString();
            textBox3.Text += Environment.NewLine + "Цифра2: " + digit2.ToString();
            textBox3.Text += Environment.NewLine + "Результат: ";

            switch (sum)
            {
                case 0:
                    textBox3.Text += "Ноль";
                    break;
                case 1:
                    textBox3.Text += "Один";
                    break;
                case 2:
                    textBox3.Text += "Два";
                    break;
                case 3:
                    textBox3.Text += "Три";
                    break;
                case 4:
                    textBox3.Text += "Четыре";
                    break;
                case 5:
                    textBox3.Text += "Пять";
                    break;
                case 6:
                    textBox3.Text += "Шесть";
                    break;
                default: textBox3.Text += "Ошибка"; break;

            }
        }
    }
}
