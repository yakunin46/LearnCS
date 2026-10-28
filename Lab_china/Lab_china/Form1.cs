using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_china
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int curr_year = Convert.ToInt32(textBox1.Text);
            curr_year = (curr_year - 4) % 60;
            int a1 = curr_year / 12;
            int a2 = curr_year % 12;
            string color_year = "Зеленый";
            string animal_year = "Крыса";
            textBox2.Text = "";
            switch (a1)
            {
                case 0:
                    color_year = "Зеленый";
                    break;
                case 1:
                    color_year = "Красный";
                    break;
                case 2:
                    color_year = "Желтый";
                    break;
                case 3:
                    color_year = "Белый";
                    break;
                case 4:
                    color_year = "Черный";
                    break;
            }
            switch (a2)
            {
                case 0:
                    animal_year = "Крыса";
                    break;
                case 1:
                    animal_year = "Корова";
                    break;
                case 2:
                    animal_year = "Тигр";
                    break;
                case 3:
                    animal_year = "Заяц";
                    break;
                case 4:
                    animal_year = "Дракон";
                    break;
                case 5:
                    animal_year = "Змея";
                    break;
                case 6:
                    animal_year = "Лошадь";
                    break;
                case 7:
                    animal_year = "Овца";
                    break;
                case 8:
                    animal_year = "Обезьяна";
                    break;
                case 9:
                    animal_year = "Курица";
                    break;
                case 10:
                    animal_year = "Собака";
                    break;
                case 11:
                    animal_year = "Свинья";
                    break;
            }
            textBox2.Text += color_year;
            textBox2.Text += animal_year;
        }
    }
}
