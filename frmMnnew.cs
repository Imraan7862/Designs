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
    public partial class frmMnnew : Form
    {
        public frmMnnew()
        {
            InitializeComponent();
        }

        private void btnMnNewSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO tblmaintenance(former_issues,helicopter,helicopter_make,last_service,next_service,service_by) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','"+textBox4.Text +"');", connection);
                command.ExecuteNonQuery();
                
                frmSpreadsheet fss = new frmSpreadsheet();
                fss.Show();
                Hide();
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.ToString());
            }
        }

        private void btnMnNewBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void frmMnnew_Load(object sender, EventArgs e)
        {

        }
    }
}
