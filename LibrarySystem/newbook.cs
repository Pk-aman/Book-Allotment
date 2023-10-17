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
    public partial class newbook : UserControl
    {

        private ConnectWithDB con = new ConnectWithDB();
        validation validate = new validation();
        public newbook()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_bookname.Text = "";
            txt_authorname.Text = "";
            txt_publication.Text = "";
            txt_edition.Text = "";
            txt_numberofbook.Text = "1";

        }

        private bool AllFieldFilled()
        {
            if (txt_authorname.Text == string.Empty)
                return false;
            else if (txt_bookname.Text == string.Empty)
                return false;
            else if (txt_edition.Text == string.Empty)
                return false;
            else if (txt_numberofbook.Text == "0")
            {
                MessageBox.Show("Number of Book can't be 0 (Zero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txt_publication.Text == string.Empty)
                return false;
            return true;
        }
        
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            if (!AllFieldFilled())
                return;
            con.OpenConection();
                do
                {
                    String query = "INSERT INTO bookrecord (`Book Id`, `Book Name`, `Book Author`, `Book Publication`, `Book Edition`) VALUES ('" + txt_bookid.Text + "', '" + txt_bookname.Text + "', '" + txt_authorname.Text + "', '" + txt_publication.Text + "', '" + txt_edition.Text + "');";
                    con.ExecuteQueries(query);
                    newbook_Load(this, null);
                    i++;
                } while (i < Int32.Parse(txt_numberofbook.Text));
                MessageBox.Show(txt_numberofbook.Text+" Book are successfully add.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            
        }
        private string getNewBookId()
        {
            con.OpenConection();
            String quary = "SELECT `Book Id` FROM `bookrecord` ORDER by `Book Id` DESC LIMIT 1";
            MySqlDataReader reader = con.DataReader(quary);
            if (reader.HasRows)
            {
                reader.Read();
                string id = reader.GetString(0);
                reader.Close();
                id = id.Substring(3);
                return id;
            }
            reader.Close();
            return "0";
            
        }
        private void newbook_Load(object sender, EventArgs e)
        {
            con.OpenConection();

            String viewquary = "SELECT `Book Id`, `Book Name`, `Book Author`, `Book Publication`, `Book Edition`, COUNT(`Book Name`) AS `Number of Book` FROM `bookrecord` GROUP By `Book Name`, `Book Author`, `Book Publication` ORDER BY `Book Id` ASC;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(viewquary);

            String id = getNewBookId();
            txt_bookid.Text = "B00"+(Convert.ToInt32(id) + 1).ToString();

            txt_bookname.Focus();
        }

        private void txt_bookname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_authorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_publication_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_edition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar,txt_edition,4);
        }

        private void txt_numberofbook_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly(e.KeyChar);
        }

        private void txt_numberofbook_Enter(object sender, EventArgs e)
        {
            txt_numberofbook.SelectAll();
        }

        
    }
}
