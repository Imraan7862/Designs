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
    public partial class FrmAcUp : Form
    {
        public FrmAcUp()
        {
            InitializeComponent();
        }

        private void btnAcsub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("UPDATE tblaccounts SET client_id = '" + textBox3.Text + "', date = '" + dateTimePicker1.Value + "' ,name = '" + textBox4.Text + "',cell ='"+textBox2.Text +"',total ="+numericUpDown1.Value+ ",paid ="+numericUpDown2.Value+ ",due = '"+(numericUpDown1.Value - numericUpDown2.Value)+"'WHERE reference_number ='"+Convert.ToInt32(comboBox2.Text)+"';", connection);
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

        private void btnAcback_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void FrmAcUp_Load(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            string pass = "";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader["reference_number"].ToString();
                    comboBox2.Items.Add(pass);
                }
                
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                numericUpDown1.ReadOnly = true;
                numericUpDown2.ReadOnly = true;

            }
            catch (Exception)
            {
                //
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            try
            {
                connection.Open();
                numericUpDown1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                numericUpDown2.ReadOnly = false;
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblaccounts WHERE reference_number = '" + comboBox2.Text + "';", connection);
                MySqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                numericUpDown1.Value = Convert.ToInt32(reader["paid"].ToString());
                textBox2.Text = reader["cell"].ToString();
                textBox3.Text = reader["client_id"].ToString();
                textBox4.Text = reader["name"].ToString();
                numericUpDown2.Value = Convert.ToInt32(reader["total"].ToString());
                dateTimePicker1.Text = reader["date"].ToString();
            }
            catch (Exception)
            {
                //
            }
        }

        private void FrmAcUp_Load_1(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            string pass = "";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader["reference_number"].ToString();
                    comboBox2.Items.Add(pass);
                }
                numericUpDown1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                numericUpDown2.ReadOnly = true;

            }
            catch (Exception)
            {
                //
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox3.Text, out num))
            {
                label9.Text = "Cannot contain letters";
                textBox3.Text = "";
            }
            else
            {
                label9.Text = "";
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
    }
    }

