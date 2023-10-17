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
    public partial class updaterecord : UserControl
    {

        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public updaterecord()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_address.Text = "";
            txt_fathername.Text = "";
            txt_mobileno.Text = "";
            txt_phoneno.Text = "";
            txt_stdid.Text = "";
            txt_stdname.Text = "";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_stdid.Text == string.Empty)
                return;
            con.OpenConection();

                String query = "UPDATE `studentrecord` SET `Student Name` = '"+txt_stdname.Text+"', `Father Name` = '"+txt_fathername.Text+"', `Address` = '"+txt_address.Text+"', `Mobile Number` = '"+txt_mobileno.Text+"', `Phone Number` = '"+txt_phoneno.Text+"' WHERE `studentrecord`.`Student Id` = '"+txt_stdid.Text+"'";
                con.ExecuteQueries(query);
                MessageBox.Show("Successfully Update the detais of Student Id = " + txt_stdid.Text + "", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();

                query = "SELECT * FROM `studentrecord`";
                guna2DataGridView1.DataSource = con.ShowDataInGridView(query);
            
        }

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(txt_stdid.Text.Trim() == "")
            {
                return;
            }
            con.OpenConection();
            
                DataTable dtable = new DataTable();

                String query = "SELECT * FROM `studentrecord` WHERE `Student Id` LIKE '" + txt_stdid.Text + "';";

                MySqlDataReader reader = con.DataReader(query);

                if (reader.HasRows)
                {
                    dtable.Load(reader);
                    guna2DataGridView1.DataSource = dtable;
                }
                else
                {
                    MessageBox.Show("Student Id And Student Name Not Exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            reader.Close();
        }



        private void guna2DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_stdid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_stdname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_fathername.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_address.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_mobileno.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt_phoneno.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void updaterecord_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            String query = "SELECT * FROM `studentrecord`;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);
        }

        private void txt_stdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button2.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
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
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar, txt_mobileno, 10);
        }

        private void txt_phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = validate.getNumberOnly_Ndigit(e.KeyChar, txt_phoneno, 10);
        }

      
    }
}
