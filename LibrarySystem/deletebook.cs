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
    public partial class deletebook : UserControl
    {

        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public deletebook()
        {
            InitializeComponent();
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txt_bookId.Text.Trim() == "" && txt_bookname.Text.Trim() == "")
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
                else if (txt_bookId.Text.Trim() == "")
                {
                    query = "SELECT * FROM `bookrecord` WHERE `Book Name` LIKE '" + txt_bookname.Text + "%';";
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
                }
                else
                {
                    MessageBox.Show("Book Id And Book Name Not Exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            reader.Close();
            
        }

        private void guna2DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_bookId.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_bookname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_bookauthor.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_bookpublication.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_bookedition.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_bookId.Text == string.Empty)
                return;
            con.OpenConection();
            String query = "DELETE FROM `bookrecord` WHERE `bookrecord`.`Book Id` LIKE '%"+txt_bookId.Text.Trim()+"%'";
           MySqlDataReader reader = con.DataReader(query);

            MessageBox.Show("Book Id " + txt_bookId.Text + " was Successfully deleted.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            query = "SELECT * FROM `bookrecord;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);        
        }

        private void deletebook_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            String query = "SELECT * FROM `bookrecord;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);
        }

        private void txt_bookId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button2.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_bookname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_bookauthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_bookpublication_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_bookedition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar,txt_bookedition,4);
        }
    }
}
