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
    public partial class FrmAcDel : Form
    {
        public FrmAcDel()
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

                MySqlCommand command = new MySqlCommand("DELETE FROM tblaccounts WHERE reference_number = '" + comboBox2.Text + "';", connection);
                MySqlCommand command1 = new MySqlCommand("DELETE FROM tblbookings WHERE reference_number = '" + comboBox2.Text + "';", connection);
                command.ExecuteNonQuery();
                command1.ExecuteNonQuery();
                

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmAcDel_Load(object sender, EventArgs e)
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
                    pass = reader["client_id"].ToString();
                    comboBox2.Items.Add(pass);
                }


            }
            catch (Exception)
            {
                //
            }
        }
    }
}
