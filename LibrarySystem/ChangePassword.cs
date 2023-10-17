using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class ChangePassword : Form
    {

        ConnectWithDB con = new ConnectWithDB();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private bool matchPassword(String s1, string s2)
        {
            if (string.Equals(s1, s2))
                return true;
            else
            {
                MessageBox.Show("Confirm Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (matchPassword(txt_password.Text, txt_conPassword.Text))
            {
                try
                {
                    con.OpenConection();
                    string sql = "UPDATE `logintable` SET `user_password` = '"+txt_password.Text+"' WHERE `logintable`.`user_id` = '"+txt_userid.Text+"'";
                    con.ExecuteQueries(sql);
                    MessageBox.Show("Password Successfully changed.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Password does not change.\n" + ex.Message, "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.CloseConnection();
                }
            }
        }
    }
}
