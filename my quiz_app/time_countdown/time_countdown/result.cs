﻿using System;
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
    public partial class result : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");
        DataTable d = new DataTable();
        public result()
        {
            InitializeComponent();
        }



        private void result_Load(object sender, EventArgs e)
        {

            //for (int i = 0; i < 4; i++)
            //{

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT marks.marks,login.name,login.roll_no from marks inner join login on marks.std_id=login.id ", con);
            // SqlCommand cmd = new SqlCommand("select * from quiz_pro where id=" + idd + "", con);
            // cmd.CommandType = CommandType.Text;


            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            dt.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            d.Clear();
            // DataTable d = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT marks.marks,login.name,login.roll_no from marks inner join login on marks.std_id=login.id  where login.name='" + textBox1.Text + "'", con);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);

            //if (dt.Equals(""))
            //{
            //    MessageBox.Show("no record found");

            //}
            //else
            //{
            dt.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin ad = new admin();
            ad.Show();
        }
    }
}
