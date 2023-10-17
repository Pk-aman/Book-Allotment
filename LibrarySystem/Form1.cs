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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showBack()
        {
            btn_back.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            homecontrol homecontrol1 = new homecontrol(this);
            switchcontrol.showControl(homecontrol1, Content);
            btn_back.Visible = false;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(0, 0);
            
        }

        /*public void showContrl(Control Ucontrol)
        {
            Content.Controls.Clear();

            Ucontrol.Dock = DockStyle.Fill;
            Ucontrol.BringToFront();
            Ucontrol.Focus();

            Content.Controls.Add(Ucontrol);
        }*/

        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_back.PerformClick();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            homecontrol homecontrol1 = new homecontrol(this);
            switchcontrol.showControl(homecontrol1, Content);
            btn_back.Visible = false;
        }
    }
}
