using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_countdown
{
    public partial class Test_Instruction : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");

       public string name;
        public int user_id;
        private object label3;

        public Test_Instruction()
        {
            InitializeComponent();
        }
        public Test_Instruction(int ab ,string aa)
        {
            user_id = ab;
            name = aa;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        
          //  label3.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fl = new Form1(user_id, name);

            fl.Show();
        }

        private void Test_Instruction_Load(object sender, EventArgs e)
        {

        }
    }
}
