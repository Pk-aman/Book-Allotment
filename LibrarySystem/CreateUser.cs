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
    public partial class CreateUser : Form
    {

        ConnectWithDB con = new ConnectWithDB();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool matchPassword(String s1, string s2)
        {
            if(string.Equals(s1,s2))
                return true;
            else
            {
                MessageBox.Show("Confirm Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (matchPassword(txt_password.Text, txt_conPassword.Text))
            {
                try
                {
                    con.OpenConection();
                    string sql = "INSERT INTO `logintable` (`user_id`, `user_password`) VALUES ('" + txt_userid.Text + "','" + txt_password.Text + "')";
                    con.ExecuteQueries(sql);
                    MessageBox.Show("New user successfully created.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.CloseConnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("New user not created.\n"+ ex.Message, "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.CloseConnection();
                }
            }
        }
    }
}
