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
    public partial class user_detail : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");
        public user_detail()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from login where roll_no='" + textBox3.Text + "' or password='" + textBox2.Text + "'", con);
            // SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read())
            {
                MessageBox.Show("user already exist");
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into login values('" + textBox1.Text + "','" + textBox2.Text + "' ," + textBox3.Text + ",0)", con);
                // SqlCommand cmd2 = new SqlCommand("insert into login values('hamza','123',5,0)", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("user successfully added");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            admin ad = new admin();
            ad.Show();
        }

        private void user_detail_Load(object sender, EventArgs e)
        {

        }
    }
}
