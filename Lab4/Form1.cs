using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n_static = Convert.ToInt32(textBox1.Text);
            int n = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            if (b >= 0 && b <= 9)
            {
                bool flag = false;
                while (n != 0)
                {
                    if (n % 10 == b)
                    {
                        textBox3.Text = $"Цифра {b} есть в числе {n_static}";
                        flag = true;
                        break;
                    }
                    n /= 10;
                }
                if (flag == false)
                    textBox3.Text = $"Цифры {b} нет в числе {n_static}";
            }
            else
                textBox3.Text = "Ошибка";
        }
    }
}
