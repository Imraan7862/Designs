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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string admini = "";
        public string returnAdmin()
        {
            return admini;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tblLogin WHERE username = '" + txtUser.Text + "';", connection);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string pass = reader["Password"].ToString();
                admini = reader["Admin_rights"].ToString();
                
                if (txtPassword.Text.Equals(pass))
                {


                    frmMainMenu fmm = new frmMainMenu();
                    
                    fmm.Show();
                    Hide();

                }
                connection.Close();
            }
            catch (Exception)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit or no?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(dr== DialogResult.Yes)
            {
                this.Close(); 
            }


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var hb = new HatchBrush(HatchStyle.Percent90, this.TransparencyKey);
            e.Graphics.FillRectangle(hb, this.DisplayRectangle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblRights.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Login To Jetstream Database Manager";
            btnLogin.BackColor = Color.Black;
            btnLogin.ForeColor = Color.Red;

        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
            btnLogin.BackColor = Color.Black;
            btnLogin.ForeColor = Color.White;
        }

        private void txtUser_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Enter Username";
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            label3.Text = "Enter Password";
        }

        private void txtUser_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                label4.Text = "Field required";
            }
            else
            {
                label4.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                label5.Text = "Field required";
            }
            else
            {
                label5.Text = "";
            }
        }
    }
}
