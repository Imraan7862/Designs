using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ServiceModel;
using System.Xml.Serialization;
using System.IO;

using System.Web.UI;
using System.Xml;
using System.Runtime.InteropServices;

namespace Jetstream
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }
        public string ac = "";
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit or no?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void btnSpreadsheet_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Spreadsheets";
        }

        private void btnSpreadsheet_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void lstWeather_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "BackUp";
        }

        private void lstWeather_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "";
        }



        private void button2_MouseHover(object sender, EventArgs e)
        {
            label3.Text = "Import";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void btnSpreadsheet_Click(object sender, EventArgs e)
        {
            frmSpreadsheet fss = new frmSpreadsheet();
            fss.Show();
            Hide();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);
            MySqlConnection connection1 = new MySqlConnection(con);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblbookings;", connection);
                MySqlDataReader reader = command.ExecuteReader();
                DateTime d;
                DateTime n = DateTime.Now;
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    int refe = Convert.ToInt32(reader["reference_number"]);
                    d = Convert.ToDateTime(reader["times"]);
            
                    if (d.Date < n.Date)
                    {
                        
                        connection1.Open();
                        MySqlCommand command1 = new MySqlCommand("DELETE FROM tblbookings WHERE reference_number = '" + refe + "';", connection1);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                
            }
            Form1 f1 = new Form1();
            ac = f1.returnAdmin();
            //MessageBox.Show(ac.ToString());
            if (ac.Equals("False"))
            {
                btnSpreadsheet.Visible = false;
                btnImport.Visible = false;
            }
            else if (ac.Equals("True"))
            {
                btnSpreadsheet.Visible = true;
                btnImport.Visible = true;
            }



            //string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection2 = new MySqlConnection(con);

            try
            {
                connection2.Open();

                MySqlCommand com = new MySqlCommand("SELECT * FROM tblBookings ORDER BY Times LIMIT 3;", connection2);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    lstNoticeBoard.Items.Add("Client " + reader["Client"].ToString());
                    lstNoticeBoard.Items.Add("Pilot " + reader["Pilot"].ToString());
                    lstNoticeBoard.Items.Add("Times " + reader["Times"].ToString());
                }
                reader.Close();
            }
            catch (Exception)
            {
                
            }
            try
            {
                string query = string.Format("http://api.openweathermap.org/data/2.5/forecast/city?id=1007311&APPID=f60634f3e5a30f812677c0b4b1235968&mode=xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(query);

                XmlNode channel = doc.SelectSingleNode("weatherdata").SelectSingleNode("forecast").SelectSingleNode("time");
                string tempmax = channel.SelectSingleNode("temperature").Attributes["max"].Value;
                string tempmin = channel.SelectSingleNode("temperature").Attributes["min"].Value;
                string wdir = channel.SelectSingleNode("windDirection").Attributes["name"].Value;
                string wdirde = channel.SelectSingleNode("windDirection").Attributes["deg"].Value;
                string wspeed = channel.SelectSingleNode("windSpeed").Attributes["name"].Value;
                string wspeedmps = channel.SelectSingleNode("windSpeed").Attributes["mps"].Value;
                string pressure = channel.SelectSingleNode("pressure").Attributes["value"].Value;
                string humidity = channel.SelectSingleNode("humidity").Attributes["value"].Value;
                string clouds = channel.SelectSingleNode("clouds").Attributes["value"].Value;



                lstWeath.Items.Add("Temperature: Max : " + tempmax + "C || Min : " + tempmin + "C");
                lstWeath.Items.Add("Wind Direction : " + wdir);
                lstWeath.Items.Add("Wind Angle : " + wdirde);
                lstWeath.Items.Add("Wind Speed : " + wspeed + " : " + wspeedmps + " mps");
                lstWeath.Items.Add("Pressure : " + pressure + " kPa");
                lstWeath.Items.Add("Humidity : " + humidity + " %");
                lstWeath.Items.Add("Overall : " + clouds.ToUpper());


            }
            catch (Exception)
            {
                lstWeath.Items.Add("Connection Failure");
            }

        }



        private void lstNoticeBoard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            string filer = "";
            if (op.ShowDialog() == DialogResult.OK)
            {
               filer = op.SelectedPath;
            }
            string datea = DateTime.Now.ToString();
            MessageBox.Show(datea);
            datea = datea.Replace("/","-");
            string name = "\\JETSTREAM_BACKUP_" + datea + ".sql";
            name = name.Replace(":", "!");
            string file = @filer + name;
            

            file = file.Replace(@"\", "\\");
            //MessageBox.Show(file);
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {

                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                            MessageBox.Show("BackUp Done");
                        }

                        catch (Exception)
                        {
                            
                        }

                    }
                }
            }

        }

    


        private void lstWeath_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            string file = op.FileName;
           // MessageBox.Show(file);
            file = file.Replace(@"\","\\");
            //MessageBox.Show(file);
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {

                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                            MessageBox.Show("Import Done");
                        }

                        catch (Exception)
                        {

                        }

                    }
                }
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            Hide();
        }
    }
}
