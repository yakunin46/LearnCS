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

        private static int[,] matrix = new int[5, 5];

        private static void GenerateMatrix()
        {
            Random r = new Random();
            for (int i = 0; i< 5; i++)
                for (int j = 0; j< 5; j++)
                    matrix[i, j] = r.Next(-100, 101);
        }
        private static void ShowMatrix(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            for (int i = 0; i < 5; i++)
            {
                dataGridView.Columns.Add($"column{i}", i.ToString());
                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = i.ToString();
            }

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
        }

        private static void ShowMinOfColumns(TextBox tb)
        {
            int[] minOfColumns = new int[5];
            for (int j = 0; j < 5; j++)
            {
                int minOfColumn = matrix[0, j];
                for (int i = 1; i < 5; i++)
                    if (matrix[i, j] < minOfColumn)
                        minOfColumn = matrix[i, j];
                minOfColumns[j] = minOfColumn;
            }

            tb.Text += "Минимальные элементы столбцов:" + Environment.NewLine;

            for (int i = 0; i < 5; i++)
                tb.Text += $"{minOfColumns[i]} ";
        }

        private static void ShowMaxOfColumns(TextBox tb)
        {
            int[] maxOfColumns = new int[5];
            for (int j = 0; j < 5; j++)
            {
                int maxOfColumn = matrix[0, j];
                for (int i = 1; i < 5; i++)
                    if (matrix[i, j] > maxOfColumn)
                        maxOfColumn = matrix[i, j];
                maxOfColumns[j] = maxOfColumn;
            }

            tb.Text += "Максимальные элементы столбцов:" + Environment.NewLine;

            for (int i = 0; i < 5; i++)
                tb.Text += $"{maxOfColumns[i]} ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateMatrix();
            ShowMatrix(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int minOfMain = matrix[0, 0];
            int minOfSecond = matrix[0, 4];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, i] < minOfMain)
                        minOfMain = matrix[i, i];

                    if (matrix[i, 4 - i] < minOfSecond)
                        minOfSecond = matrix[i, 4 - i];
                }

            if (minOfMain < minOfSecond)
                ShowMinOfColumns(textBox1);
            else
                ShowMaxOfColumns(textBox1);
        }
    }
}