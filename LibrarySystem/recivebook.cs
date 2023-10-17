using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllValidation;
using MySql.Data.MySqlClient;

namespace LibrarySystem
{
    public partial class recivebook : UserControl
    {
        private ConnectWithDB con = new ConnectWithDB();
        validation validate = new validation();
        public recivebook()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_bookid.Text = "";
            txt_bookname.Text = "";
            txt_stdid.Text = "";
            txt_stdname.Text = "";

        }

        private void recivebook_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            String query = "SELECT p.`Book Id` , b.`Book Name` , p.`Student Id`, s.`Student Name`, p.`Date To`, p.`Date From` From `providebook` As p, `bookrecord` As b, `studentrecord` As s WHERE p.`Book Id` = b.`Book Id` And p.`Student Id` = s.`Student Id` And b.`Availability` = false;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (txt_bookid.Text == "")
            {
                return;
            }
            con.OpenConection();
            String query = "UPDATE `bookrecord` SET `Availability` = true WHERE `bookrecord`.`Book Id` = '" + txt_bookid.Text + "';";
            con.ExecuteQueries(query);

            MessageBox.Show("Book is Successfully recived.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            recivebook_Load(this, null);
        }

        private void txt_bookid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button2.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
            
        }

        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txt_bookid.Text);
            con.OpenConection();
            String query = "SELECT p.`Book Id` , b.`Book Name` , p.`Student Id`, s.`Student Name`, p.`Date To`, p.`Date From`, b.`Availability` From `providebook` As p, `bookrecord` As b, `studentrecord` As s WHERE p.`Book Id` = b.`Book Id` And p.`Student Id` = s.`Student Id` And b.`Availability` = false And p.`Book Id`= '" + txt_bookid.Text + "';";

            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                DataTable dtable = new DataTable();
                dtable.Load(reader);
                guna2DataGridView1.DataSource = dtable;
            }
            else
            {
                MessageBox.Show("This book is not provide any ony.","Not Providea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            reader.Close();
            query = "SELECT p.`Book Id` , b.`Book Name` , p.`Student Id`, s.`Student Name`, p.`Date To`, p.`Date From`, b.`Availability` From `providebook` As p, `bookrecord` As b, `studentrecord` As s WHERE p.`Book Id` = b.`Book Id` And p.`Student Id` = s.`Student Id` And b.`Availability` = false And p.`Book Id`= '" + txt_bookid.Text + "';";

            reader = con.DataReader(query);
            reader.Read();

            txt_bookname.Text = reader.GetString(1);
            txt_stdid.Text = reader.GetString(2);
            txt_stdname.Text = reader.GetString(3);

            reader.Close();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
             con.OpenConection();
             String query = "SELECT p.`Book Id` , b.`Book Name` , p.`Student Id`, s.`Student Name`, p.`Date To`, p.`Date From`, b.`Availability` From `providebook` As p, `bookrecord` As b, `studentrecord` As s WHERE p.`Book Id` = b.`Book Id` And p.`Student Id` = s.`Student Id` And b.`Availability` = false And s.`Student Id` = '" + txt_stdid.Text +"';";
             guna2DataGridView1.DataSource = con.ShowDataInGridView(query);

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            recivebook_Load(this, null);
        }

        private void guna2DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_bookid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_bookname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_stdid.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_stdname.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();        
        }

        private void txt_stdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button3.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_bookid_Leave(object sender, EventArgs e)
        {

        }
    }
}
