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
    public partial class frmBkup : Form
    {
        public frmBkup()
        {
            InitializeComponent();
        }

        private void btnbkSubUp_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE tblbookings SET client = '" + textBox1.Text + "', helicopter = '" + comboBox2.Text + "' ,hours = '" + numericUpDown1.Text + "',learner ='" + checkBox1.Checked + "',pilot ='" + comboBox2.Text + "',purpose ='"+ textBox9.Text+"',routes='"+comboBox4.Text +"',times ='"+dateTimePicker1.Value +"'WHERE reference_number ='" + comboBox3.Text + "';", connection);
                command.ExecuteNonQuery();
               
                frmSpreadsheet fss = new frmSpreadsheet();
                fss.Show();
                Hide();
            }
            catch (Exception er)
            {
               // MessageBox.Show(er.ToString());
            }
        }

        private void btnbkBack_Click(object sender, EventArgs e)
        {

            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            try
            {
                connection.Open();
                textBox1.ReadOnly = false;
                
                //checkBox1.ReadOnly = false;
                textBox9.ReadOnly = false;
                
               // textBox6.ReadOnly = false;
                numericUpDown1.ReadOnly = false;
                //dateTimePicker1.ReadOnly = false;
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM tblbookings WHERE reference_number = '" + comboBox3.Text + "';", connection);
                MySqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["client"].ToString();
                comboBox1.Text = reader["helicopter"].ToString();
                numericUpDown1.Text = reader["hours"].ToString();
                checkBox1.Text = reader["learner"].ToString();
                comboBox2.Text = reader["pilot"].ToString();
                textBox9.Text = reader["purpose"].ToString(); 
                comboBox4.Text = reader["routes"].ToString();
                dateTimePicker1.Text = reader["times"].ToString();

            }
            catch (Exception)
            {
                //
            }
        }

        private void frmBkup_Load_1(object sender, EventArgs e)
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
                    comboBox4.Items.Add(pass3);
                }


            }
            catch (Exception)
            {
                //
            }
            string con4 = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection4 = new MySqlConnection(con4);
            string pass4 = "";

            try
            {
                connection4.Open();
                MySqlCommand command4 = new MySqlCommand("SELECT * FROM tblbookings;", connection4);
                MySqlDataReader reader = command4.ExecuteReader();

                while (reader.Read())
                {
                    pass4 = reader["reference_number"].ToString();
                    comboBox3.Items.Add(pass4);
                }
                
            }
            catch (Exception)
            {
                //MessageBox.Show(""+er);
            }

            string con5= "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection5 = new MySqlConnection(con5);
            string pass5 = "";

            try
            {
                connection5.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblmaintenance;", connection5);
                MySqlDataReader reader5 = command.ExecuteReader();

                while (reader5.Read())
                {
                    pass5 = reader5["helicopter"].ToString();
                    comboBox1.Items.Add(pass5);
                }
                reader5.Close();

            }
            catch (Exception)
            {
              //  MessageBox.Show("" + er);
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
                //MessageBox.Show("" + er);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

