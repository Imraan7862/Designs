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
    public partial class frmSpreadsheet : Form
    {
        public frmSpreadsheet()
        {
            InitializeComponent();
        }
        private void btnChBack_Click(object sender, EventArgs e)
        {
            frmMainMenu mm = new frmMainMenu();
            mm.Show();
            Hide();
        }

        

        private void btnChDispl_Click(object sender, EventArgs e)
        
            {
            
        }

        

       
        private void btnchNew_Click(object sender, EventArgs e)
        {
            FrmChNew fcn = new FrmChNew();
            fcn.Show();
            this.Hide();
           
        }

        private void btnchUpdate_Click(object sender, EventArgs e)
        {
            FrmChUp mm = new FrmChUp();
            mm.Show();
            this.Hide();
        }

        private void btnchDelete_Click(object sender, EventArgs e)
        {
            FrmChDel mm = new FrmChDel();
            mm.Show();
            this.Hide();

        }

        private void btnchSea_Click(object sender, EventArgs e)
        {
            FrmChSea mm = new FrmChSea();
            mm.Show();
            this.Hide();

        }

        private void btnAccDispl_Click(object sender, EventArgs e)
        { 
        }

        private void btnAccNew_Click(object sender, EventArgs e)
        {
            FrmAcnew mm = new FrmAcnew();
            mm.Show();
            this.Hide();
        }

        private void btnAccUp_Click(object sender, EventArgs e)
        {
            FrmAcUp mm = new FrmAcUp();
            mm.Show();
            this.Hide();
        }

        private void btnAccDel_Click(object sender, EventArgs e)
        {
            FrmAcDel fad = new FrmAcDel();
            fad.Show();
            this.Hide();
        }

        private void btnBkDispl_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCliDispl_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEmpDispl_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMainDispl_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBkNew_Click(object sender, EventArgs e)
        {
            frmBknew bkn = new frmBknew();
            bkn.Show();
            this.Hide();
        }

        private void btnBkUp_Click(object sender, EventArgs e)
        {
            frmBkup bku = new frmBkup();
            bku.Show();
            this.Hide();
        }

        private void btnBkDel_Click(object sender, EventArgs e)
        {
            frmBkdel bkd = new frmBkdel();
            bkd.Show();
            this.Hide();
        }

        private void btnBkSea_Click(object sender, EventArgs e)
        {
            frmBksea bks = new frmBksea();
            bks.Show();
            this.Hide();
        }

        private void btnCliNew_Click(object sender, EventArgs e)
        {
            }

        private void btnCliUp_Click(object sender, EventArgs e)
        {
            }

        private void btnCliDel_Click(object sender, EventArgs e)
        {
                    }

        private void btnCliSea_Click(object sender, EventArgs e)
        {
            }

        private void btnEmpNew_Click(object sender, EventArgs e)
        {
            frmEmnew emn = new frmEmnew();
            emn.Show();
            this.Hide();
        }

        private void btnEmpUp_Click(object sender, EventArgs e)
        {
            frmEmup emu = new frmEmup();
            emu.Show();
            this.Hide();

        }

        private void btnEmpDel_Click(object sender, EventArgs e)
        {
            frmEmdel emd = new frmEmdel();
            emd.Show();
            this.Hide();
        }

        private void btnEmpSea_Click(object sender, EventArgs e)
        {
            frmEmsea ems = new frmEmsea();
            ems.Show();
            this.Hide();
        }

        private void btnMainNew_Click(object sender, EventArgs e)
        {
            frmMnnew mnn = new frmMnnew();
            mnn.Show();
            this.Hide();
        }

        private void btnMainUp_Click(object sender, EventArgs e)
        {
            frmMnup mnu = new frmMnup();
            mnu.Show();
            this.Hide();
        }

        private void btnMainDel_Click(object sender, EventArgs e)
        {
            frmMndel mnd = new frmMndel();
            mnd.Show();
            this.Hide();
        }

        private void btnMainSea_Click(object sender, EventArgs e)
        {
            frmMnsea mns = new frmMnsea();
            mns.Show();
            this.Hide();
        }

        private void frmSpreadsheet_Load(object sender, EventArgs e)
        {

            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblCharter;", connection);
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

            
            MySqlConnection connection1 = new MySqlConnection(con);

            try
            {
                connection1.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection1);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView2.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }

            
            MySqlConnection connection2 = new MySqlConnection(con);

            try
            {
                connection2.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblbookings;", connection2);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView3.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
            
            
            MySqlConnection connection4 = new MySqlConnection(con);

            try
            {
                connection4.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblemployee;", connection4);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView5.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }

            
            MySqlConnection connection5 = new MySqlConnection(con);

            try
            {
                connection5.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblmaintenance;", connection5);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView7.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblCharter;", connection);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView2.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);


            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblbookings;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView3.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblemployee;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView5.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblmaintenance;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView7.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void btnchBack_Click_1(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnAccBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnBkBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnCliBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnEmpBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnMainBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            Hide();
        }

        private void btnAccSea_Click(object sender, EventArgs e)
        {
            FrmAcSea fas = new FrmAcSea();
            fas.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblCharter;", connection);
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

        private void tabPage2_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblaccounts;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView2.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblbookings;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView3.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblemployee;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView5.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
            string con = "server=127.0.0.1;uid=root;" + "pwd=;database=dbjetstream;";
            MySqlConnection connection = new MySqlConnection(con);

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tblmaintenance;", connection);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();

                bs.DataSource = dbdataset;
                dataGridView7.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception)
            {
                //
            }
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
    

