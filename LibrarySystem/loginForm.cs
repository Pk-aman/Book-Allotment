using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AllValidation;

namespace LibrarySystem
{
    public partial class loginForm : Form
    {
        ConnectWithDB con = new ConnectWithDB();

        homecontrol homecontrol1;
        public loginForm(homecontrol hm)
        {
            InitializeComponent();
            homecontrol1 = hm;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            String query = "SELECT * FROM logintable WHERE user_id = '" + txt_userid.Text + "'";
            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                reader.Read();
                if (check(reader.GetString(0), reader.GetString(1)))
                {
                    if (txt_userid.Text == "S001")
                        homecontrol.isAdmin = true;
                    homecontrol.loged = true;
                    homecontrol1.EnableControl();
                    Close();

                }
                else
                {
                    //linkforgerpass.Visible = true;
                }
            }
            else
            {
                txt_userid.BorderColor = Color.Red;
                MessageBox.Show("User Id is wornd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();

        }

        private bool check(String dbid, String dbpassword)
        {
            if (dbid.Equals(txt_userid.Text))
            {

                txt_userid.BorderColor = Color.White;
                if (txt_password.Text.Equals(dbpassword))
                {
                    txt_password.BorderColor = Color.White;
                    return true;
                }
                else
                {
                    txt_password.BorderColor = Color.Red;
                    MessageBox.Show("Password is wornd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                txt_userid.BorderColor = Color.Red;
                MessageBox.Show("User Id is wornd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
