using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_countdown
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login LO = new login();
            LO.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            result r = new result();
            r.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            update_user up = new update_user();
            up.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            user_detail us = new user_detail();
            us.Show();
            this.Hide();
        }
    }
}
