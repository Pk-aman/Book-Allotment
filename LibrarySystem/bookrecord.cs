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
using AllValidation;

namespace LibrarySystem
{
    public partial class bookrecord : UserControl
    {

        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public bookrecord()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_bookId.Text = "";
            txt_bookname.Text = "";
        }
        private void setStatusbar(string bookname)
        {
            con.OpenConection();
            string sql = "SELECT COUNT(`Book Name`) AS `Number of Book` FROM `bookrecord` WHERE `Book Name` = '" + bookname + "' And `Availability` = true GROUP By `Book Name`, `Book Author`, `Book Publication` ORDER BY `Book Id` ASC";
            MySqlDataReader reader = con.DataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                lbl_number.Text = reader.GetString(0);
                con.CloseConnection();
            }
            else
            {
                lbl_number.Text = "0";
                con.CloseConnection();
            }



            con.OpenConection();
             sql = "SELECT COUNT(`Book Name`) AS `Number of Book` FROM `bookrecord` WHERE `Book Name` = '" + bookname + "' GROUP By `Book Name`, `Book Author`, `Book Publication` ORDER BY `Book Id` ASC";
            reader = con.DataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                lbl_nobook.Text = reader.GetString(0);
                con.CloseConnection();
            }
            else
            {
                lbl_nobook.Text = "0";
                con.CloseConnection();
            }

        }
        private void bookrecord_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            DataTable dtable = new DataTable();
            String viewquary = "SELECT * FROM `bookrecord`";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(viewquary);

            txt_bookId.Focus();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txt_bookId.Text.Trim() == "" && txt_bookname.Text.Trim()=="")
            {
                return;
            }

            String query = "";
            con.OpenConection();
            DataTable dtable = new DataTable();

            if (txt_bookname.Text.Trim() == "")
            {
                query = "SELECT * FROM `bookrecord` WHERE `Book Id` LIKE '%" + txt_bookId.Text + "%';";
            }
            else if(txt_bookId.Text.Trim() == "")
            {
                query = "SELECT * FROM `bookrecord` WHERE `Book Name` LIKE '%" + txt_bookname.Text + "%';";
            }
            else
            {
                query = "SELECT * FROM `bookrecord` WHERE `Book Id` LIKE '%" + txt_bookId.Text + "%' OR `Book Name` LIKE '%" + txt_bookname.Text + "%';";
            }

            MySqlDataReader reader = con.DataReader(query);

            if (reader.HasRows)
            {
                
                dtable.Load(reader);
                guna2DataGridView1.DataSource = dtable;
                setStatusbar(txt_bookname.Text);
                reset();
            }
            else
            {
                MessageBox.Show("Book Id And Book Name Not Exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            bookrecord_Load(this, null);
            reset();
        }

        private void txt_bookId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button1.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_bookname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button1.PerformClick();
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setStatusbar(guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString());
        }
    }
    
}
