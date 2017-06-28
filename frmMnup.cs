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
    public partial class frmMnup : Form
    {
        public frmMnup()
        {
            InitializeComponent();
        }

        private void btnMnUpSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE tblmaintenance SET former_issues='" + textBox1.Text + "',helicopter_make='" + textBox3.Text + "',last_service='" + dateTimePicker1.Value + "',next_service='" + dateTimePicker2.Value + "',service_by='" + textBox4.Text + "' WHERE helicopter='" + comboBox6.Text + "';", connection);
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

        private void btnMnUpBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            try
            {
                connection.Open();
                textBox1.ReadOnly = false;
                //dateTimePicker1.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                //dateTimePicker2.ReadOnly = false;
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblmaintenance WHERE helicopter = '" + comboBox6.Text + "';", connection);
                MySqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["former_issues"].ToString();
                dateTimePicker1.Text = reader["last_service"].ToString();
                textBox3.Text = reader["helicopter_make"].ToString();
                textBox4.Text = reader["service_by"].ToString();
                dateTimePicker2.Text = reader["next_service"].ToString();

            }
            catch (Exception)
            {
                //
            }
        }

        private void frmMnup_Load_1(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            string pass = "";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblmaintenance;", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader["helicopter"].ToString();
                    comboBox6.Items.Add(pass);
                }
                textBox1.ReadOnly = true;
                //dateTimePicker1.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                //dateTimePicker2.ReadOnly = true;

            }
            catch (Exception)
            {
                //
            }

        }
    }
}
