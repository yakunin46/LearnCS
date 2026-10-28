using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text ="";
            Random r = new Random();
            int three_sum;
            int min_sum = 3001;
            int[] mas = new int[15];
            int i_min = 0;
            for (int i = 0; i < 15; i++)
            {
                mas[i] = r.Next(1,1001);
                textBox1.Text += $"{mas[i]} ";
            }
            for (int i = 0; i < 13; i++)
            {
                three_sum = mas[i] + mas[i + 1] + mas[i + 2];
                textBox1.Text += Environment.NewLine;
                textBox1.Text += $"Сумма {i+1} тройки: {three_sum}";
                if (three_sum < min_sum)
                {
                    min_sum = three_sum;
                    i_min = i;
                }
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Columns.Add($"column{i}", $"{i}");
            }

            dataGridView1.Rows.Add();

            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = mas[i];
            }
            textBox1.Text += Environment.NewLine;
            textBox1.Text += $"Минимальная сумма тройки: {min_sum}";
            textBox1.Text += Environment.NewLine;
            textBox1.Text += $"Индекс первого элемента этой тройки: {i_min}";
        }
    }
}