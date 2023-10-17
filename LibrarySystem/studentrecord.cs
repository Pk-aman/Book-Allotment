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
    public partial class studentrecord : UserControl
    {
        private ConnectWithDB con = new ConnectWithDB();
        private validation validate = new validation();
        public studentrecord()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txt_stdid.Text = "";
            txt_stdname.Text = "";
        }

        private void setStatusbar(string stdid)
        {
            con.OpenConection();
            string sql = "SELECT Count(`Student Id`) FROM `providebook` WHERE `Student Id` = '"+stdid+"' GROUP BY `Student Id";
            MySqlDataReader reader = con.DataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                lbl_noallot.Text = reader.GetString(0);
                con.CloseConnection();
            }
            else
            {
                lbl_noallot.Text = "0";
                con.CloseConnection();
            }
        }

            private void studentrecord_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            DataTable dtable = new DataTable();
            String viewquary = "SELECT * FROM `studentrecord`;";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(viewquary);
        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_stdid.Text.Trim() == "" && txt_stdname.Text.Trim() == "")
            {
                return;
            }

            String query = "";
            con.OpenConection();
            
                DataTable dtable = new DataTable();
                if (txt_stdname.Text.Trim() == "")
                {
                    query = "SELECT * FROM `studentrecord` WHERE `Student Id` LIKE '%" + txt_stdid.Text + "%' ;";
                }
                else if (txt_stdid.Text.Trim() == "")
                {
                    query = "SELECT * FROM `studentrecord` WHERE `Student Name` LIKE '%" + txt_stdname.Text + "%';";
                }
                else
                {
                    query = "SELECT * FROM `studentrecord` WHERE `Student Id` LIKE '%" + txt_stdid.Text + "%' OR `Student Name` LIKE '%" + txt_stdname.Text + "%';";
                }

                MySqlDataReader reader = con.DataReader(query);

                if (reader.HasRows)
                {
                    dtable.Load(reader);
                    guna2DataGridView1.DataSource = dtable;
                setStatusbar(txt_stdid.Text);
                    reset();
                }
                else
                {
                    MessageBox.Show("Student Id And Student Name Not Exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            reader.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            studentrecord_Load(this, null);
            reset();

        }

        private void txt_stdid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button1.PerformClick();
            e.KeyChar = validate.getnumberandletters(e.KeyChar);
        }

        private void txt_stdname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guna2Button1.PerformClick();
            e.KeyChar = validate.getAlphabetOnly(e.KeyChar);
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setStatusbar(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
