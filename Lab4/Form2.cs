using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startNum = 4;
            int limitNum = 30;

            bool flag1 = true;
            bool flag2 = true;

            int count = 0;

            textBox1.Text = "";

            for (int currNum = startNum; currNum <= limitNum; currNum += 2)
            {
                for (int part1 = 2; part1 + part1 <= currNum; part1++)
                {
                    int part2 = currNum - part1;
                    for (int div = 2; div * div <= part1; div++)
                    {
                        if (part1 % div == 0)
                        {
                            flag1 = false;
                            break;
                        }
                    }
                    for (int div = 2; div * div <= part2; div++)
                    {
                        if (part2 % div == 0)
                        {
                            flag2 = false;
                            break;
                        }
                    }
                    if (flag1 && flag2 == true)
                    {
                        textBox1.Text += $"{currNum} = {part1} + {part2}" + Environment.NewLine;
                        count += 1;
                        break;
                    }
                    else
                    {
                        flag1 = true;
                        flag2 = true;
                    }
                }
            }
            if (count == (limitNum - startNum) / 2 + 1)
            {
                textBox1.Text += "Гипотеза верна!";
                textBox1.Text += Environment.NewLine;
            }
            else
            {
                textBox1.Text += "Гипотеза не верна!";
                textBox1.Text += Environment.NewLine;
            }
        }
    }
}