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
    public partial class update_user : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");
        int id;
        public update_user()
        {
            InitializeComponent();
        }

        private void update_user_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT name from login", con);
            // SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            SqlDataReader dt = cmd.ExecuteReader();
            while (dt.Read())
            {
                string n = dt.GetString(0);
                comboBox111.Items.Add(n);
            }

            con.Close();
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * from login where name='"+comboBox1.Text+"'", con);
            //// SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            //SqlDataReader dt = cmd.ExecuteReader();
            //while (dt.Read())
            //{
            //    id = dt.GetInt32(0);
            //    textBox1.Text = dt.GetString(1);
            //    textBox2.Text = dt.GetString(2);
            //    textBox3.Text = dt.GetInt32(3).ToString();
            //}
            //con.Close();
        }

        private void comboBox111_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from login where name='" + comboBox111.Text + "'", con);
            // SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            SqlDataReader dt = cmd.ExecuteReader();
            while (dt.Read())
            {
                id = dt.GetInt32(0);
                textBox1.Text = dt.GetString(1);
                textBox2.Text = dt.GetString(2);
                textBox3.Text = dt.GetInt32(3).ToString();
            }
            con.Close();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmdd = new SqlCommand("UPDATE login SET name='" + textBox1.Text + "',password='" + textBox2.Text + "',roll_no=" + textBox3.Text + " where id=" + id + "", con);
            cmdd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            con.Close();
            MessageBox.Show("Successfuly Updated!", "Message", MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure you want to Delete!", "Message", MessageBoxButtons.YesNoCancel);

            con.Open();

            SqlCommand cmd = new SqlCommand("delete  from login where id=" + id + "", con);
            cmd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            con.Close();
            MessageBox.Show("Successfuly Deleted!", "Message", MessageBoxButtons.OK);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void update_user_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin ad = new admin();
            ad.Show();
        }
    }
}
