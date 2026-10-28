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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            char[] a = new char [n];
            string eng = "abcdefghijklmnoprstuvwxyz";
            string dp_range = "defghijklmnop";
            Random r = new Random();
            int count = 0;
            textBox2.Text = "";
            for (int i = 0; i < n; i++)
            {
                int index = r.Next(eng.Length);
                a[i] = eng[index];
                if (!dp_range.Contains(a[i]))
                {
                    count++;
                }
            }
            char[] b = new char [count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (!dp_range.Contains(a[i]))
                {
                    b[k] = a[i];
                    k++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                textBox2.Text += $" {a[i]}";
            }
            textBox2.Text += Environment.NewLine;

            for (int i = 0; i < count; i++)
            {
                textBox2.Text += $" {b[i]}";
            }
            textBox2.Text += Environment.NewLine;

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add($"column{i}", $"{i}");
            }

            dataGridView1.Rows.Add();

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = a[i];
            }

            dataGridView1.Rows.Add();

            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[1].Cells[i].Value = b[i];
            }
        }
    }
}
