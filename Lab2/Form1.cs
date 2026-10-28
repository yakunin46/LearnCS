using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Вывод строки в многострочный редактор
            textBox4.Text = "Решение:";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Считывание значения x
            double x = double.Parse(textBox1.Text);
            // Вывод значения x в окно
            textBox4.Text += Environment.NewLine + "X = " + x.ToString();
            // Считывание значения y
            double y = double.Parse(textBox2.Text);
            // Вывод значения y в окно
            textBox4.Text += Environment.NewLine + "Y = " + y.ToString();
            // Считывание значения Z
            double z = double.Parse(textBox3.Text);
            // Вывод значения Z в окно
            textBox4.Text += Environment.NewLine + "Z = " + z.ToString();
            // Вычисляем арифметическое выражение
            double a = Math.Tan(x + y) * Math.Tan(x + y);
            double b = Math.Exp(y - z);
            double c = Math.Sqrt(Math.Cos(x * x) + Math.Sin(z * z));
            double u = a - b * c;
            // Выводим результат в окно
            textBox4.Text += Environment.NewLine + "Результат U = " + u.ToString();
        }
    }
}
