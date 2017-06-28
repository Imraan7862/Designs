using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;

namespace Jetstream
{
    public partial class FrmChNew : Form
    {
        public FrmChNew()
        {
            InitializeComponent();
        }

      

        private void btnUpSub_Click_1(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO tblCharter(route, pillot, information_on_route) VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "');", connection);
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

        private void btnChback_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void FrmChNew_Load(object sender, EventArgs e)
        {

        }
    }
}
