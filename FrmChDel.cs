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
    public partial class FrmChDel : Form
    {
        public FrmChDel()
        {
            InitializeComponent();
        }

        private void btnSubm_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM tblcharter WHERE route = '" + comboBox7.Text + "';", connection);
                command.ExecuteNonQuery();
                MySqlCommand command1 = new MySqlCommand("UPDATE tblbookings SET route = '', WHERE route = '" + comboBox7.Text + "';", connection);
                command1.ExecuteNonQuery();
                
                frmSpreadsheet fss = new frmSpreadsheet();
                fss.Show();
                Hide();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmChDel_Load(object sender, EventArgs e)
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
                    comboBox7.Items.Add(pass);
                }


            }
            catch (Exception)
            {
                //
            }
        }
    }
}
