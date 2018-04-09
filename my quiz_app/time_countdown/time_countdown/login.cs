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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");


        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // labl1:
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from login where name='" + nam.Text + "' and password='" + pswd.Text + "'", con);
            // SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            SqlDataReader dt = cmd.ExecuteReader();

            if (dt.Read())
            {

                int user_id = dt.GetInt32(0);
                string name = dt.GetString(1);

              //  Test_Instruction ti = new Test_Instruction( name);

                if (dt.GetString(1) == nam.Text && dt.GetString(2) == pswd.Text )
                {
                    

                    if (dt.GetInt32(3) == 1)
                    {
                        this.Hide();
                        admin ad = new admin();
                        ad.Show();
                       // we r = new we();
                        
                       // r.Show();
                        
                    }

                    else {

                        this.Hide();

                        Test_Instruction ts = new Test_Instruction();
                       
                        Form1 fl = new Form1(user_id, name);
                        ts.Show();


                    }
                }
                
                con.Close();
            }
            else
            {
                MessageBox.Show("Name or password is not correct");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signu su = new signu();
            su.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pswd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
