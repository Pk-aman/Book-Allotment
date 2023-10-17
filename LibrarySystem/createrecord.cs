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
   
    public partial class createrecord : UserControl
    {

        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public createrecord()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_stdname.Text = "";
            txt_fathername.Text = "";
            txt_address.Text = "";
            txt_mobileno.Text = "";
            txt_phoneno.Text = "";

        }

        private void createrecord_Load(object sender, EventArgs e)
        {
            con.OpenConection();

            String query = "SELECT * FROM `studentrecord`;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);

            query = "SELECT COUNT(`Student Id`) FROM `studentrecord`;";
            MySqlDataReader reader = con.DataReader(query);
            reader.Read();

            int id = Int32.Parse(reader.GetString(0));
            txt_stdid.Text = "S00" +(id + 1).ToString();

            reader.Close();
            txt_stdname.Focus();
        }
        private bool AllFieldFill()
        {
            if (txt_stdname.Text == string.Empty)
                return false;
            else if (txt_fathername.Text == string.Empty)
                return false;
            else if (txt_address.Text == string.Empty)
                return false;
            else if (txt_mobileno.Text == string.Empty)
                return false;
            else if (txt_phoneno.Text == string.Empty)
                return false;
            else
                return true;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!AllFieldFill())
                return;
            String query = "INSERT INTO `studentrecord` (`Student Id`, `Student Name`, `Father Name`, `Address`, `Mobile Number`, `Phone Number`) VALUES ('"+txt_stdid.Text+"', '"+txt_stdname.Text+"', '"+txt_fathername.Text+"', '"+txt_address.Text+"', '"+txt_mobileno.Text+"', '"+txt_phoneno.Text+"');";
            
            con.ExecuteQueries(query);
            createrecord_Load(this, null);
            MessageBox.Show("Record are successfully created.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        private void txt_stdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly(e.KeyChar);
        }

        private void txt_stdname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_fathername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void txt_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar,txt_mobileno,10);
        }

        private void txt_phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar, txt_phoneno, 10);
        }
    }
}
