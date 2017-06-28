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
    public partial class FrmChUp : Form
    {
        public FrmChUp()
        {
            InitializeComponent();
        }
        private void btnSub_Click_1(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE tblCharter SET Pillot = '" + textBox1.Text + "', information_on_route = '" + textBox3.Text + "' WHERE route = '" + comboBox1.Text + "';", connection);
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

        private void button1_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void FrmChUp_Load(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            string pass = "";
            
                try
                {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblcharter;", connection);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    pass = reader["route"].ToString();
                    comboBox1.Items.Add(pass);
                }
                textBox1.ReadOnly = true;
                textBox3.ReadOnly = true;

            }
            catch (Exception)
            {
                //
            }
            }
        private void comboBox1_TextUpdate(Object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            try
            {
                connection.Open();
                // Add the text box to the form.
               
                textBox1.ReadOnly = false;
                textBox3.ReadOnly = false;

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblcharter WHERE route = '" + comboBox1.Text + "';", connection);
                MySqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["pillot"].ToString();
                textBox3.Text = reader["Information_On_Route"].ToString();

            }
            catch (Exception)
            {
                //MessageBox.Show(er+"");
            }
        }
    }
}
