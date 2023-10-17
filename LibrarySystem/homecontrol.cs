using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace LibrarySystem
{
    public partial class homecontrol : UserControl
    {
        private ConnectWithDB con = new ConnectWithDB();
        private Form1 f1;
        public static bool loged = false;
        public static bool isAdmin = false;
        public homecontrol(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
        }

        private void setAllDropButton()
        {
            studentdrop.Height = 40;
            bookdrop.Height = 40;
            viewdrop.Height = 40;
            inventrydrop.Height = 40;

            settingdrop.Visible = false;
            notificationslide.Visible = false;

        }

        private void InitializeNotificationTable()
        {
            con.OpenConection();

            String query = "SELECT p.`Book Id`, b.`Book Name`, p.`Student Id`, p.`Date From` FROM `providebook` as p, `bookrecord` As b WHERE p.`Book Id` = b.`Book Id` And `Date From` = '"+DateTime.Today.ToString("yyyy-MM-dd")+"'";
            guna2DataGridView1.DataSource = con.ShowDataInGridView(query);
        }
        private void InitializeNotification()
        {
            con.OpenConection();

            String query = "SELECT COUNT(`Date From`) FROM `providebook` WHERE `Date From` = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            MySqlDataReader reader = con.DataReader(query);
            if (reader.HasRows)
            {
                reader.Read();
                lbl_notification.Text = reader.GetString(0);

                lbl_numberofrecivedbook.Text = "Today " + reader.GetString(0) + " will be recives.";
            }
            else
            {
                lbl_notification.Text = "0";
            }
            reader.Close();
        }
        private void drop(Guna2Panel dropmenu)
        {
            if (dropmenu.Height == 122)
            {
                dropmenu.Height = 40;
            }
            else
            {
                dropmenu.Height = 122;
            }
        }
        public void EnableControl()
        {
            MessageBox.Show("You Are Successfully Login","Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
            inventrydrop.Enabled = true;
            viewdrop.Enabled = true;
            bookdrop.Enabled = true;
            studentdrop.Enabled = true;

            btn_about.Enabled = true;
            btn_notification.Enabled = true;
            btn_setting.Enabled = true;

            if (isAdmin)
                btn_createuser.Enabled = true;
            else
                btn_createuser.Enabled = false;

            InitializeNotification();
            btn_login.Visible = false;

            //loged = true;
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            drop(bookdrop);
        }

        private void guna2TileButton5_Click(object sender, EventArgs e)
        {
            loginForm logform = new loginForm(this);
            logform.ShowDialog();
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            drop(studentdrop);
        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {
            drop(viewdrop);
        }

        private void guna2TileButton13_Click(object sender, EventArgs e)
        {
            drop(inventrydrop);
        }

        private void homecontrol_Load(object sender, EventArgs e)
        {
            setAllDropButton();
            
            if (loged)
            {
                inventrydrop.Enabled = true;
                viewdrop.Enabled = true;
                studentdrop.Enabled = true;
                bookdrop.Enabled = true;

                btn_about.Enabled = true;
                btn_notification.Enabled = true;
                btn_setting.Enabled = true;

                if (isAdmin)
                    btn_createuser.Enabled = true;
                else
                    btn_createuser.Enabled = false;

                btn_login.Visible = false;

                InitializeNotification();
            }

        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            newbook newbook1 = new newbook();
            switchcontrol.showControl(newbook1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {
            deletebook deletebook1 = new deletebook();
            switchcontrol.showControl(deletebook1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            createrecord createrecord1 = new createrecord();
            switchcontrol.showControl(createrecord1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            updaterecord deleterecord = new updaterecord();
            switchcontrol.showControl(deleterecord, homepanel);
            f1.showBack();
        }

        private void guna2TileButton9_Click(object sender, EventArgs e)
        {
            studentrecord studentrecord1 = new studentrecord();
            switchcontrol.showControl(studentrecord1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            bookrecord bookrecord1 = new bookrecord();
            switchcontrol.showControl(bookrecord1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton12_Click(object sender, EventArgs e)
        {
            providebook providebook1 = new providebook();
            switchcontrol.showControl(providebook1, homepanel);
            f1.showBack();
        }

        private void guna2TileButton11_Click(object sender, EventArgs e)
        {
            recivebook recivebook1 = new recivebook();
            switchcontrol.showControl(recivebook1, homepanel);
            f1.showBack();

        }


        private void homeimg_Click(object sender, EventArgs e)
        {
            setAllDropButton();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            notificationslide.Visible = false;

            if (settingdrop.Visible == false)
            {
                settingdrop.Visible = true;
            }
            else
            {
                settingdrop.Visible = false;
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            settingdrop.Visible = false;
            if (notificationslide.Visible == false)
            {
                notificationslide.Visible = true;
                InitializeNotificationTable();
            }
            else
            {
                notificationslide.Visible = false;
            }
            
        }

        public void DiseableControl()
        {
            MessageBox.Show("You Are Successfully log out", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            inventrydrop.Enabled = false;
            viewdrop.Enabled = false;
            bookdrop.Enabled = false;
            studentdrop.Enabled = false;

            btn_about.Enabled = false;
            btn_notification.Enabled = false;
            btn_setting.Enabled = false;

            //InitializeNotification();
            lbl_notification.Text = "0";

            settingdrop.Visible = false;

            btn_login.Visible = true;

            isAdmin = false;
            loged = false;
        }
        private void guna2TileButton15_Click(object sender, EventArgs e)
        {
            DiseableControl();
            setAllDropButton();
        }

        private void guna2TileButton14_Click(object sender, EventArgs e)
        {
            settingdrop.Visible = false;
            CreateUser user = new CreateUser();
            user.ShowDialog();
            
        }

        private void guna2TileButton5_Click_1(object sender, EventArgs e)
        {
            settingdrop.Visible = false;
            ChangePassword ch = new ChangePassword();
            ch.ShowDialog();
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.ShowDialog();

        }
    }
}
  