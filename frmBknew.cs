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
    public partial class frmBknew : Form
    {
        public frmBknew()
        {
            InitializeComponent();
        }
        public static int refi;
        public int returnit()
        {
            return refi;
        }
        public void fixit()
            {
            refi = 0;
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnbkSub_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                bool learn = false;
                if (checkBox1.Checked)
                {
                    learn = true;
                }
                connection.Open();
                refi = Convert.ToInt32(textBox8.Text);
                MySqlCommand command = new MySqlCommand("INSERT INTO tblbookings(client,helicopter,hours,learner,pilot,purpose,reference_number,routes,times) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + learn + "','" + comboBox2.Text + "','"+textBox9.Text+"','"+textBox8.Text+"','"+comboBox3.Text+"','"+dateTimePicker1.Value+"');", connection);
                command.ExecuteNonQuery();
                
                FrmAcnew fss = new FrmAcnew();
                fss.Show();
                Hide();
            }
            catch (Exception)
            {
                //
            }
        }

        private void btnbkBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox3.Text, out num))
            {
                label10.Text = "Cannot contain letters";
                textBox3.Text = "";
                label10.Text = "";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(textBox8.Text, out num))
            {
                label11.Text = "Cannot contain letters";
                textBox8.Text = "";
            }
            else
            {
                label11.Text = "";
            }
        }

        private void frmBknew_Load(object sender, EventArgs e)
        {
            string con3 = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection3 = new MySqlConnection(con3);
            string pass3 = "";

            try
            {
                connection3.Open();
                MySqlCommand command3 = new MySqlCommand("SELECT * FROM tblcharter;", connection3);
                MySqlDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                {
                    pass3 = reader3["route"].ToString();
                    comboBox3.Items.Add(pass3);
                }


            }
            catch (Exception)
            {
                //
            }
            //===============
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
                    comboBox1.Items.Add(pass);
                }
                reader.Close();
             
            }
            catch (Exception)
            {
                //
            }

            string con1 = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection1 = new MySqlConnection(con1);
            string pass1 = "";

            try
            {
                connection1.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblemployee;", connection1);
                MySqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    pass1 = reader1["id"].ToString();
                    comboBox2.Items.Add(pass1);
                }

            }
            catch (Exception)
            {
                //
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

