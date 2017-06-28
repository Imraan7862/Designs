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
    public partial class FrmAcnew : Form
    {
        public FrmAcnew()
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
                int boom = Convert.ToInt32(numericUpDown1.Value) - Convert.ToInt32(numericUpDown2.Value);
                MySqlCommand command = new MySqlCommand("INSERT INTO tblaccounts(reference_number,client_id,date,name,cell,total,paid,due) VALUES('" + textBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value+ "','" + textBox4.Text + "','" + textBox2.Text + "','" + numericUpDown1.Text+ "','" + numericUpDown2.Text + "','" + boom + "');", connection);
                command.ExecuteNonQuery();
                //MessageBox.Show("Update Successfull");
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox1.Text, out num))
            {
                label8.Text = "Cannot contain letters";
                textBox1.Text = "";
            }
            else
            {
                label8.Text = "";
            }
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
        public static int ask;
        private void FrmAcnew_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            textBox3.Visible = true;
            frmBknew b = new frmBknew();
            int ask = b.returnit();

            if (ask != 0)
            {
                textBox1.Text = ask.ToString();
                textBox1.ReadOnly = true;
                comboBox2.Visible = true;
                textBox3.Visible = false;
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
                    numericUpDown1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    numericUpDown2.ReadOnly = false;
                }
                catch (Exception)
                {
                    //
                }
            }
            else
            {
                textBox1.ReadOnly = false;
            }

            b.fixit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
                MySqlConnection connection = new MySqlConnection(con);
                string pass = "";
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader["client_id"].ToString();
                    comboBox2.Items.Add(pass);
                }
                numericUpDown1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                numericUpDown2.ReadOnly = false;
                reader.Close();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblaccounts WHERE client_id = '"+comboBox2.Text+"';", connection);
                MySqlDataReader reader1 = command.ExecuteReader();
                reader1.Read();
                numericUpDown1.Value = Convert.ToInt32(reader1["total"].ToString());
                textBox2.Text = reader1["cell"].ToString();
                textBox4.Text = reader1["name"].ToString();
                numericUpDown2.Value = Convert.ToInt32(reader1["paid"].ToString());
                dateTimePicker1.Text = reader1["date"].ToString();
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
