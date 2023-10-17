using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;
using Microsoft.SqlServer.Server;
using AllValidation;

namespace LibrarySystem
{
    public partial class providebook : UserControl
    {
        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public providebook()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_bookid.Text = "";
            txt_bookname.Text = "";
            txt_stdid.Text = "";
            txt_stdname.Text = "";
            dt_todate.Value = DateTime.Today;
            dt_fromdate.Value = DateTime.Today;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if(txt_bookid.Text == "")
            {
                return;
            }
            con.OpenConection();

            String query = "SELECT `Availability` From `bookrecord` WHERE `Book Id` = '" + txt_bookid.Text + "';";
            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetString("Availability") == "True")
                {
                    reader.Close();

                    query = "INSERT INTO `providebook` (`Book Id`, `Student Id`, `Date To`, `Date From`) VALUES ('" + txt_bookid.Text + "', '" + txt_stdid.Text + "', '" + dt_todate.Text + "', '" + dt_fromdate.Text + "');";
                    con.ExecuteQueries(query);

                    MessageBox.Show("Record was successfully saved.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    query = "UPDATE `bookrecord` SET `Availability` = false WHERE `bookrecord`.`Book Id` = '" + txt_bookid.Text + "';";
                    con.ExecuteQueries(query);

                    reset();
                    providebook_Load(this, null);
                    
                }
                else
                {
                    MessageBox.Show("Sorry Book is not Available now!.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Sorry Book Id is not exist in book list.", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void providebook_Load(object sender, EventArgs e)
        {
            dt_todate.CustomFormat = "yyyy-MM-dd";
            dt_fromdate.CustomFormat = "yyyy-MM-dd";

            con.OpenConection();
            String query = "SELECT p.`Book Id`, b.`Book Name`, p.`Student Id`, s.`Student Name`, p.`Date To`, p.`Date From` FROM `providebook` as p, `bookrecord` As b, `studentrecord` As s WHERE p.`Book Id` = b.`Book Id` AND p.`Student Id` = s.`Student Id`;";
            
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);

            txt_bookid.Focus();

            dt_todate.Text = DateTime.Today.ToString();
            dt_fromdate.Text = DateTime.Today.ToString();
        }

       

        private void txt_bookid_Leave(object sender, EventArgs e)
        {
            if(txt_bookid.Text == "")
            {
                return;
            }
            con.OpenConection();
            String query = "SELECT `Book Name` FROM `bookrecord` WHERE `Book Id`  = '" + txt_bookid.Text + "';";
            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                reader.Read();
                txt_bookname.Text = reader.GetString(0);
            }
            else
            {
                MessageBox.Show("Book Id is not found in Book list.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_bookid.Focus();
                txt_bookname.Text = "";
            }
            reader.Close();
        }

        private void txt_stdid_Leave(object sender, EventArgs e)
        {
            if(txt_stdid.Text == "")
            {
                return;
            }
            con.OpenConection();
            String query = "SELECT `Student Name` FROM `studentrecord` WHERE `Student Id` = '" + txt_stdid.Text + "'";
            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                reader.Read();
                txt_stdname.Text = reader.GetString(0);
            }
            else
            {
                MessageBox.Show("Student Id is not found in Student list.\n Please Add Student first.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_stdid.Focus();
                txt_stdname.Text = string.Empty;
            }
            reader.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txt_bookid_Leave(this, null);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txt_stdid_Leave(this, null);
        }

        

        private void txt_bookid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button2.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_stdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button3.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_bookname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_stdname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        
    }
}
