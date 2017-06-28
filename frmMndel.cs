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
    public partial class frmMndel : Form
    {
        public frmMndel()
        {
            InitializeComponent();
        }

        private void btnMnDelSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM tblmaintenance WHERE helicopter = '" + comboBox2.Text + "';", connection);
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

        private void btnMnDelBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void frmMndel_Load(object sender, EventArgs e)
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
