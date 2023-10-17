using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public class switchcontrol : Form1
    {
        public static void showControl(Control Ucontrol,Control content)
        {
            content.Controls.Clear();

            Ucontrol.Dock = DockStyle.Fill;
            Ucontrol.BringToFront();
            content.BringToFront();
            Ucontrol.Focus();

            content.Controls.Add(Ucontrol);
        }
    }
}
