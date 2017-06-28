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
    public partial class frmEmup : Form
    {
        public frmEmup()
        {
            InitializeComponent();
        }

        private void btnEmUpSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE tblemployee SET address='" + textBox1.Text + "',contact='" + textBox2.Text + "',hourly_rate='" + textBox3.Text + "',hours_worked='" + textBox4.Text + "',job_description='" + textBox6.Text + "',name='" + textBox7.Text + "',net_wage='" + textBox8.Text + "',pilot='" + textBox9.Text + "' WHERE ID = '"+comboBox5.Text+"';", connection);
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

        private void btnEmUpBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            try
            {
                connection.Open();
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblemployee WHERE id = '" + comboBox5.Text + "';", connection);
                MySqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["address"].ToString();
                textBox2.Text = reader["contact"].ToString();
                textBox3.Text = reader["hourly_rate"].ToString();
                textBox4.Text = reader["hours_worked"].ToString();
                textBox6.Text = reader["job_description"].ToString();
                textBox7.Text = reader["name"].ToString();
                textBox8.Text = reader["net_wage"].ToString();
                textBox9.Text = reader["pilot"].ToString();

            }
            catch (Exception)
            {
                //
            }
        }

        private void frmEmup_Load_1(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            string pass = "";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblemployee;", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader["id"].ToString();
                    comboBox5.Items.Add(pass);
                }
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;

            }
            catch (Exception)
            {
                //
            }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox3.Text, out num))
            {
                label11.Text = "Cannot contain letters";
                textBox3.Text = "";
            }
            else
            {
                label11.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox4.Text, out num))
            {
                label12.Text = "Cannot contain letters";
                textBox4.Text = "";
            }
            else
            {
                label12.Text = "";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox8.Text, out num))
            {
                label13.Text = "Cannot contain letters";
                textBox8.Text = "";
            }
            else
            {
                label13.Text = "";
            }
        }
    }
}
