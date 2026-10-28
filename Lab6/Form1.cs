using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int[,] matrix = new int[5, 5];
        private Random r = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = r.Next(-100, 101);
                }
            }

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns.Add($"column{i}", i.ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int[,] diagonals = new int[5,2];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        diagonals[i, 0] = matrix[i, j];
                    }
                    if (i + j == 4)
                    {
                        diagonals[i, 1] = matrix[i, j];
                    }
                }
            }

            textBox1.Text += "Элементы главной диагонали:" + Environment.NewLine;

            for (int i = 0; i < 5; i++)
            {
                textBox1.Text += diagonals[i, 0].ToString() + Environment.NewLine;
            }

            textBox1.Text += "Элементы побочной диагонали:" + Environment.NewLine;

            for (int i = 0; i < 5; i++)
            {
                textBox1.Text += diagonals[i, 1].ToString() + Environment.NewLine;
            }

            int j_min = 0;
            int min = diagonals[0, 0];
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (diagonals[i, j] < min)
                    {
                        min = diagonals[i, j];
                        j_min = j;
                    }
                }
            }
            int[] lim_colomns = new int[5];
            if (j_min == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    int min_colomn = matrix[0, j];
                    for (int i = 1; i < 5; i++)
                    {
                        if (matrix[i, j] < min_colomn)
                        {
                            min_colomn = matrix[i, j];
                        }
                    }
                    lim_colomns[j] = min_colomn;
                }

                textBox1.Text += "Минимальные элементы столбцов:" + Environment.NewLine;

                for (int i = 0; i < 5; i++)
                {
                    textBox1.Text += lim_colomns[i].ToString() + Environment.NewLine;
                }
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    int max_colomn = matrix[0, j];
                    for (int i = 1; i < 5; i++)
                    {
                        if (matrix[i, j] > max_colomn)
                        {
                            max_colomn = matrix[i, j];
                        }
                    }
                    lim_colomns[j] = max_colomn;
                }


                textBox1.Text += "Максимальные элементы столбцов:" + Environment.NewLine;

                for (int i = 0; i < 5; i++)
                {
                    textBox1.Text += lim_colomns[i].ToString() + Environment.NewLine;
                }
            }
        }
    }
}
     

