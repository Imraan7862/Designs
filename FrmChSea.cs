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
    public partial class FrmChSea : Form
    {
        public FrmChSea()
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

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblCharter WHERE route = '" + textBox2.Text + "';", connection);
                command.ExecuteNonQuery();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView1.DataSource = bs;
                sda.Update(dbdataset);
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

        private void FrmChSea_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try {
                string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
                MySqlConnection connection = new MySqlConnection(con);


                try
                {
                    int count = 0;
                    connection.Open();
                    MySqlCommand command2 = new MySqlCommand("SELECT Count(route) from tblcharter", connection);

                    MySqlDataReader reader = command2.ExecuteReader();
                    reader.Read();

                    count = Convert.ToInt32(reader["count(route)"]);
                    connection.Close();
                    reader.Close();
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM tblcharter;", connection);
                    MySqlDataReader reader2 = command.ExecuteReader();
                    string pass;


                    // Create the list to use as the custom source. 
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(new string[count]);
                    int i = 0;
                    while (reader2.Read())
                    {
                        pass = reader2["route"].ToString();

                        source[i] = pass;
                        i++;
                    }


                    textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                    textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox2.AutoCompleteCustomSource = source;
                    connection.Close();

                }
                catch (Exception)
                {
                    //
                }

            }
            catch (Exception)
                {
                    //
                }

            }

    }
}
