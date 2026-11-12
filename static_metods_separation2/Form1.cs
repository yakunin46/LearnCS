using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace StaticMethodsSeparation2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private static int[] ParseLimsOfCoeffs(TextBox tb1, TextBox tb2)
        {
            int[] limsOfCoeffs = new int[2];
            limsOfCoeffs[0] = int.Parse(tb1.Text);
            limsOfCoeffs[1] = int.Parse(tb2.Text) + 1;
            return limsOfCoeffs;
        }
        private static void FillRandomCoeffs(int[] limsOfCoeffs,
            TextBox tb1, TextBox tb2, TextBox tb3)
        {
            int limOfCoeffs1 = limsOfCoeffs[0];
            int limOfСoeffs2 = limsOfCoeffs[1];
            Random r = new Random();
            tb1.Text = r.Next(limOfCoeffs1, limOfСoeffs2).ToString();
            tb2.Text = r.Next(limOfCoeffs1, limOfСoeffs2).ToString();
            tb3.Text = r.Next(limOfCoeffs1, limOfСoeffs2).ToString();
            //tb4.Text = r.Next(limOfCoeffs1, limOfСoeffs2).ToString();
        }
        private static double[] ParseCoeffs(TextBox tb1, TextBox tb2, TextBox tb3)
        {
            double[] coeffs = new double[3];
            coeffs[0] = double.Parse(tb1.Text);
            coeffs[1] = double.Parse(tb2.Text);
            coeffs[2] = double.Parse(tb3.Text);
            //coeffs[3] = int.Parse(tb4.Text);
            return coeffs;
        }
        private static void ShowCoeffs(double[] coeffs, TextBox tb)
        {
            tb.Text = "";

            double a = coeffs[0];
            double b = coeffs[1];
            double c = coeffs[2];
            //int d = coeffs[3];

            tb.Text += $"A = {a}\t B = {b}\t C = {c}";
            tb.Text += Environment.NewLine + Environment.NewLine;
        }
        private static void ShowEquation(double[] coeffs, TextBox tb)
        {
            double a = coeffs[0];
            double b = coeffs[1];
            double c = coeffs[2];
            //int d = coeffs[3];

            tb.Text = "";

            if (a != 0)
            {
                tb.Text += $"{a}x\u00B2";
            }

            if (a != 0 & b > 0)
            {
                tb.Text += $" + {b}x";
            }
            else 
                if (b != 0)
                    tb.Text += $" {b}x";

            if ((a != 0 | b != 0) & c > 0)
            {
                tb.Text += $" + {c}";
            }
            else
                if (c != 0)
                    tb.Text += $" {c}";

            //if ((a != 0 | b != 0 | c != 0) & d > 0)
            //{
            //    tb.Text += $" + {d}";
            //}
            //else
            //    if (d != 0)
            //        tb.Text += $" {d}";
        }
        private static double CalculateY(double x, double[] coeffs)
        {
            double a = coeffs[0];
            double b = coeffs[1];
            double c = coeffs[2];
            //int d = coeffs[3];

            double y = a * Math.Pow(x, 2) + b * x + c;
            return y;
        }
        private static double[,] FindXY(double[] coeffs, int xLim1, int xLim2, double step)
        {
            double a = coeffs[0];
            double b = coeffs[1];
            double c = coeffs[2];
            //int d = coeffs[3];

            int length = (int)((xLim2 - xLim1) / step + 1);
            double[,] masXY = new double[length, 2];
            for (double x = xLim1; x <= xLim2; x += step)
            {
                double y = CalculateY(x, coeffs);
                int i = (int) ((x - xLim1) / step);
                masXY[i, 0] = x;
                masXY[i, 1] = y;
            }

            return masXY;
        }
        private static void ShowXY(double[,] masXY, TextBox tb)
        {
            int length = masXY.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                tb.Text += $"x = {masXY[i, 0]:F1}\t y = {masXY[i, 1]:F3}";
                tb.Text += Environment.NewLine;
            }
        }
        private  static double[,] FindChangeSign(double[,] masXY, int length)
        {
            double[,] changeSign = new double[5, 2];
            int count = 0;
            int countZero = 0;
            for (int i = 1; i < length - 1; i++)
            {
                int index = i - 1 - countZero;
                if (masXY[index, 1] * masXY[i, 1] < 0)
                {
                    changeSign[count, 0] = masXY[index, 0];
                    changeSign[count, 1] = masXY[index, 1];
                    changeSign[count + 1, 0] = masXY[i, 0];
                    changeSign[count + 1, 1] = masXY[i, 1];
                    count += 2; countZero = 0;
                }
                if (masXY[i, 1] >= -0.001 && masXY[i, 1] <= 0.001)
                {
                    if (masXY[index, 1] * masXY[i + 1, 1] > 0)
                    {
                        changeSign[count, 0] = masXY[index, 0];
                        changeSign[count, 1] = masXY[index, 1];
                        changeSign[count + 1, 0] = masXY[i + 1, 0];
                        changeSign[count + 1, 1] = masXY[i + 1, 1];
                        count += 2; countZero = 0;
                    }
                    countZero++;
                }
            }

            changeSign[4, 0] = count;

            return changeSign;
        }
        private static void ShowChangeSign(double[,] changeSign, TextBox tb)
        {
            double length = changeSign[4, 0];

            for (int i = 0; i < length; i += 2)
            {
                tb.Text += "Смена знаков:" + Environment.NewLine;
                tb.Text += $"x = {changeSign[i, 0]:F1}\t y = {changeSign[i, 1]:F3}";
                tb.Text += Environment.NewLine;
                tb.Text += $"x = {changeSign[i + 1, 0]:F1}\t y = {changeSign[i + 1, 1]:F3}";
                tb.Text += Environment.NewLine;
            }
        }
        private static double CalculateYLimit(int[] limsOfCoeffs, int xLim1, int xLim2)
        {
            int limOfCoeffs1 = limsOfCoeffs[0];
            int limOfCoeffs2 = limsOfCoeffs[1];

            double maxCoeff = Math.Max(Math.Abs(limOfCoeffs1), Math.Abs(limOfCoeffs2));
            double maxX = Math.Max(Math.Abs(xLim1), Math.Abs(xLim2));
            double yLimit = maxCoeff * Math.Pow(maxX, 3) + maxCoeff * Math.Pow(maxX, 2) +
                maxCoeff * maxX + maxCoeff;

            return yLimit;
        }
        private static double[] Method1 (double[,] changeSign, double[] coeffs,
            double smallStep, double yLimit)
        {
            double count = changeSign[4, 0];
            double[] roots = new double[3];
            int countRoots = 0;

            for (int i = 0; i < count; i += 2)
            {
                double botLim = changeSign[i, 0];
                double topLim = changeSign[i + 1, 0];
                double xExemplary = botLim;
                double yLimitCurr = yLimit;
                for (double x = botLim; x <= topLim; x += smallStep)
                {
                    double y = Math.Abs(CalculateY(x, coeffs));
                    if (y < yLimitCurr)
                    {
                        xExemplary = x;
                        yLimitCurr = y;
                    }
                }
                roots[i / 2] = xExemplary;
                countRoots++;
            }
            roots[2] = countRoots;
            return roots;
        }
        private static double[] Method2 (double[,] changeSign, double[] coeffs, double accuracy)
        {
            double count = changeSign[4, 0];
            double[] roots = new double[3];
            int countRoots = 0;

            for (int i = 0; i < count; i += 2)
            {
                double botLim = changeSign[i, 0];
                double topLim = changeSign[i + 1, 0];
                double xExemplary = botLim;
                while (topLim - botLim >= accuracy)
                {
                    xExemplary = (botLim + topLim) / 2;
                    double yBot = CalculateY(botLim, coeffs);
                    double yTop = CalculateY(topLim, coeffs);
                    double yCurr = CalculateY(xExemplary, coeffs);
                    if (yCurr == 0)
                    {
                        roots[i] = xExemplary;
                        countRoots++;
                    }
                    if (yCurr * yBot < 0)
                        topLim = xExemplary;
                    else
                        if (yCurr * yTop < 0)
                            botLim = xExemplary;
                }
            }
            roots[2] = countRoots;
            return roots;
        }
        private static void ShowExemplaryXY(double[] coeffs, double[] roots, TextBox tb)
        {
            tb.Text = "";
            double countOfRoots = roots[2];

            for(int i = 0; i < countOfRoots; i++) {
                    tb.Text += $"{roots[i]:F9}" + Environment.NewLine;
                    double yExemplary = CalculateY(roots[i], coeffs);
                    tb.Text += $"{yExemplary:F9}" + Environment.NewLine;
            }
        }
        private static void ProcessCompare(double[] coeffs, double[] roots,
            RadioButton rb1, RadioButton rb2, RadioButton rb3, RadioButton rb4, TextBox tb)
        {
            double x1 = roots[0];
            double x2 = roots[1];
            double countOfRoots = roots[2];

            if (countOfRoots == 0)
            {
                if (rb1.Checked || rb3.Checked) 
                    if (CalculateY(0, coeffs) > 0)
                        tb.Text += $"x \u2208 (-\u267E ; +\u267E)";
                    else
                        tb.Text += $"x \u2208 \u2205";

                if (rb2.Checked || rb4.Checked)
                    if (CalculateY(0, coeffs) < 0)
                        tb.Text += $"x \u2208 (-\u267E ; +\u267E)";
                    else
                        tb.Text += $"x \u2208 \u2205";
            }

            if (countOfRoots == 1)
            {
                if (rb1.Checked)
                    if (CalculateY(0, coeffs) >= 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}) \u222A ({x1:F3}; +\u267E)";
                    else
                        tb.Text += $"x \u2208 \u2205";

                if (rb2.Checked)
                    if (CalculateY(0, coeffs) <= 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}) \u222A ({x1:F3}; +\u267E)";
                    else
                        tb.Text += $"x \u2208 \u2205";

                if (rb3.Checked)
                    if (CalculateY(0, coeffs) >= 0)
                        tb.Text += $"x \u2208 (-\u267E ; +\u267E)";
                    else
                        tb.Text += $"x \u2208 {{ {x1:F3} }}";

                if (rb4.Checked)
                    if (CalculateY(0, coeffs) <= 0)
                        tb.Text += $"x \u2208 (-\u267E ; +\u267E)";
                    else
                        tb.Text += $"x \u2208 {{ {x1:F3} }}";
            }

            if (countOfRoots == 2)
            {
                if (rb1.Checked)
                {
                    if (CalculateY((x1 + x2) / 2, coeffs) > 0)
                        tb.Text += $"x \u2208 ({x1:F3} ; {x2:F3})";

                    if (CalculateY((x1 + x2) / 2, coeffs) < 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}) \u222A ({x2:F3}, +\u267E)";
                }

                if (rb2.Checked)
                {
                    if (CalculateY((x1 + x2) / 2, coeffs) < 0)
                        tb.Text += $"x \u2208 ({x1:F3} ; {x2:F3})";

                    if (CalculateY((x1 + x2) / 2, coeffs) > 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}) \u222A ({x2:F3}, +\u267E)";
                }

                if (rb3.Checked)
                {
                    if (CalculateY((x1 + x2) / 2, coeffs) > 0)
                        tb.Text += $"x \u2208 [{x1:F3} ; {x2:F3}]";

                    if (CalculateY((x1 + x2) / 2, coeffs) < 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}] \u222A [{x2:F3}, +\u267E)";
                }

                if (rb4.Checked)
                {
                    if (CalculateY((x1 + x2) / 2, coeffs) < 0)
                        tb.Text += $"x \u2208 [{x1:F3} ; {x2:F3}]";

                    if (CalculateY((x1 + x2) / 2, coeffs) > 0)
                        tb.Text += $"x \u2208 (-\u267E ; {x1:F3}] \u222A [{x2:F3}, +\u267E)";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] limsOfCoeffs = ParseLimsOfCoeffs(textBox14, textBox15);

            FillRandomCoeffs(limsOfCoeffs, textBox1, textBox2, textBox3);

            double[] coeffs = ParseCoeffs(textBox1, textBox2, textBox3);

            ShowEquation(coeffs, textBox5);
        }
        private void button2_Click(object sender, EventArgs e)
        {

            double[] coeffs = ParseCoeffs(textBox1, textBox2, textBox3);

            ShowEquation(coeffs, textBox5);

            ShowCoeffs(coeffs, textBox9);

            int xLim1 = int.Parse(textBox6.Text);
            int xLim2 = int.Parse(textBox7.Text);
            double step = double.Parse(textBox8.Text);
            int length = (int)((xLim2 - xLim1) / step) + 1;

            double[,] masXY = FindXY(coeffs, xLim1, xLim2, step);

            ShowXY(masXY, textBox9);

            double[,] changeSign = FindChangeSign(masXY, length);

            ShowChangeSign(changeSign, textBox9);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int[] limsOfCoeffs = ParseLimsOfCoeffs(textBox14, textBox15);
            double[] coeffs = ParseCoeffs(textBox1, textBox2, textBox3);

            int xLim1 = int.Parse(textBox6.Text);
            int xLim2 = int.Parse(textBox7.Text);
            double step = double.Parse(textBox8.Text);
            int length = (int)((xLim2 - xLim1) / step) + 1;

            double smallStep = double.Parse(textBox12.Text);

            double[,] masXY = FindXY(coeffs, xLim1, xLim2, step);
            double[,] changeSign = FindChangeSign(masXY, length);
            double yLimit = CalculateYLimit(limsOfCoeffs, xLim1, xLim2);

            double[] roots = Method1(changeSign, coeffs, smallStep, yLimit);

            ShowExemplaryXY(coeffs, roots, textBox10);

            ProcessCompare(coeffs, roots, radioButton1, radioButton2,
                radioButton3, radioButton4, textBox9);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            double[] coeffs = ParseCoeffs(textBox1, textBox2, textBox3);

            int start = int.Parse(textBox6.Text);
            int end = int.Parse(textBox7.Text);
            int step = int.Parse(textBox8.Text);
            int length = (end - start) / step + 1;

            double accuracy = double.Parse(textBox13.Text);

            double[,] masXY = FindXY(coeffs, start, end, step);
            double[,] changeSign = FindChangeSign(masXY, length);

            double[] roots = Method2(changeSign, coeffs, accuracy);

            ShowExemplaryXY(coeffs, roots, textBox11);
        }
    }
}