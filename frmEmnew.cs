using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jetstream
{
    public partial class frmEmnew : Form
    {
        public frmEmnew()
        {
            InitializeComponent();
        }

        private void btnEmNewSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO tblemployee(address,contact,hourly_rate,hours_worked,ID,job_description,name,net_wage,pilot) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "');", connection);
                command.ExecuteNonQuery();
                
                frmSpreadsheet fss = new frmSpreadsheet();
                fss.Show();
                Hide();
            }
            catch (Exception)
            {
                //
            }
        }

        private void btnEmNewBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox2.Text, out num))
            {
                label10.Text = "Cannot contain letters";
                textBox2.Text = "";
            }
            else
            {
                label10.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox5.Text, out num))
            {
                label11.Text = "Cannot contain letters";
                textBox5.Text = "";
            }
            else
            {
                label11.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox3.Text, out num))
            {
                label12.Text = "Cannot contain letters";
                textBox3.Text = "";
            }
            else
            {
                label12.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox4.Text, out num))
            {
                label13.Text = "Cannot contain letters";
                textBox4.Text = "";
            }
            else
            {
                label13.Text = "";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox8.Text, out num))
            {
                label14.Text = "Cannot contain letters";
                textBox8.Text = "";
            }
            else
            {
                label14.Text = "";
            }
        }

        private void frmEmnew_Load(object sender, EventArgs e)
        {

        }
    }
}
