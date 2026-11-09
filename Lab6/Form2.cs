using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static int[,] matrix;

        private static int n, m;

        private static void GenerateMatrix()
        {
            matrix = new int[n, m];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = r.Next(-10, 10);
        }
        private static void ShowMatrix(DataGridView dataGridView, int[,] matrix)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            int rowsCount = matrix.GetLength(0);
            int columnsCount = matrix.GetLength(1);

            for (int j = 0; j < columnsCount; j++)
                dataGridView.Columns.Add($"column{j}", j.ToString());

            dataGridView.RowCount = rowsCount;

            for (int i = 0; i < rowsCount; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = i.ToString();
                for (int j = 0; j < columnsCount; j++)
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
            }
        }

        private static int FindString(TextBox tb)
        {
            int count = 0;
            int countOfUniq = 0;
            int[] uniq = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < m; k++)
                        if (matrix[i, j] == matrix[i, k])
                            count++;

                    if (count == 1)
                        countOfUniq++;

                    count = 0;
                }
                uniq[i] = countOfUniq;
                countOfUniq = 0;
            }

            for (int i = 0; i < n; i++)
                tb.Text += $"{uniq[i].ToString()} ";

            int maxCountOfUniq = uniq[0];
            int numOfString = 0;

            for (int i = 1; i < n; i++)
                if (uniq[i] > maxCountOfUniq)
                {
                    maxCountOfUniq = uniq[i];
                    numOfString = i;
                }
            return numOfString;
        }

        private static void SortString(int numOfString)
        {
            int[] elementsOfString = new int[m];
            for (int j = 0; j < m; j++)
                elementsOfString[j] = matrix[numOfString, j];
            for (int i = 0; i < elementsOfString.Length - 1; i++)
            {
                for (int j = 0; j < elementsOfString.Length - 1 - i; j++)
                {
                    if (elementsOfString[j] > elementsOfString[j + 1])
                    {
                        int temp = elementsOfString[j];
                        elementsOfString[j] = elementsOfString[j + 1];
                        elementsOfString[j + 1] = temp;
                    }
                }
            }
            for (int j = 0; j < m; j++)
                matrix[numOfString, j] = elementsOfString[j];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            GenerateMatrix();
            ShowMatrix(dataGridView1, matrix);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            SortString(FindString(textBox3));
            ShowMatrix(dataGridView2, matrix);
        }
    }
}