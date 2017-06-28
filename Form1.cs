using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_cost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        


        private void button1_Click_1(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown1.Value);
            double num4 = Convert.ToDouble(numericUpDown2.Value);
            double num5 = 350;
            double ans1;

            ans1 = num3 * num4 * 350;
            ans1 = ans1 / 1000000;
            
            textBox2.Text = ans1.ToString("N2");
            string s = ans1.ToString("N2");

            if (ans1 < 1)
            {
                double a = 1;
                textBox2.Text = a.ToString();
                string st = a.ToString("N2");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double num1 = 1300;
            double ans;
            double num2 = Convert.ToDouble(numericUpDown4.Value) + 4;

            ans = num1 / num2;
            textBox1.Text = ans.ToString();
        }

        private void btnCutout_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown5.Value);
            double num4 = Convert.ToDouble(numericUpDown3.Value);
            double num5 = 350;
            double ans2;

            ans2 = num3 * num4 * 350;
            ans2 = ans2 / 1000000;

            textBox3.Text = ans2.ToString("N2");
            string s = ans2.ToString("N2");

            if (ans2 < 1)
            {
                double b = 1;
                textBox3.Text = b.ToString();
                string st = b.ToString("N2");
            }
        }

        private void btnBanner_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown7.Value);
            double num4 = Convert.ToDouble(numericUpDown6.Value);
            double num5 = 550;
            double ans3;

            ans3 = num3 * num4 * 550;
            ans3 = ans3 / 1000000;

            textBox4.Text = ans3.ToString("N2");
            string s = ans3.ToString("N2");

            if (ans3 < 1)
            {
                double a = 1;
                textBox4.Text = a.ToString();
                string st = a.ToString("N2");
            }
        }

        private void btnCorrex_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown9.Value);
            double num4 = Convert.ToDouble(numericUpDown8.Value);
            double num5 = 400;
            double ans4;

            ans4 = num3 * num4 * 400;
            ans4 = ans4 / 1000000;

            textBox5.Text = ans4.ToString("N2");
            string s = ans4.ToString("N2");

            if (ans4 < 1)
            {
                double a = 1;
                textBox5.Text = a.ToString();
                string st = a.ToString("N2");
            }
        }

        private void btnContra_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown11.Value);
            double num4 = Convert.ToDouble(numericUpDown10.Value);
            double num5 = 450;
            double ans5;

            ans5 = num3 * num4 * 450;
            ans5 = ans5 / 1000000;

            textBox6.Text = ans5.ToString("N2");
            string s = ans5.ToString("N2");

            if (ans5 < 1)
            {
                double a = 1;
                textBox6.Text = a.ToString();
                string st = a.ToString("N2");
            }
        }

        private void btnABS_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown13.Value);
            double num4 = Convert.ToDouble(numericUpDown12.Value);
            double num5 = 400;
            double ans6;

            ans6 = num3 * num4 * 400;
            ans6 = ans6 / 1000000;

            textBox7.Text = ans6.ToString("N2");
            string s = ans6.ToString("N2");

            if (ans6 < 1)
            {
                double a = 1;
                textBox7.Text = a.ToString();
                string st = a.ToString("N2");
            }
        }

        private void btnChroma_Click(object sender, EventArgs e)
        {
            double num3 = Convert.ToDouble(numericUpDown15.Value);
            double num4 = Convert.ToDouble(numericUpDown14.Value);
            double num5 = 500;
            double ans7;

            ans7 = num3 * num4 * 500;
            ans7 = ans7 / 1000000;

            textBox8.Text = ans7.ToString("N2");
            string s = ans7.ToString("N2");

            if (ans7 < 1)
            {
                double a = 1;
                textBox8.Text = a.ToString();
                string st = a.ToString("N2");
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }
    }
}
