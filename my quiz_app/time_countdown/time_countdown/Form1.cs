using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_countdown
{

   

    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G1N3VRK;initial catalog=quiz;integrated security=true");
        StreamWriter f;
        StreamReader fr;
        string reading;
        //int ac = 1;
        int fc = 0;
        int pqc=0;
        int qc = 0;
        int cnt = 0;
       // Form1 fn=new Form1();
        
       
       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["time_countdown.Properties.Settings.quizConnectionString"].ConnectionString);
        int[] a = new int [70];

       

        int row_count=0;
        //id for fetchng result
       // int idd = 1;
        int qid;
        int uid;
        //right ans var
        string right_ans;
        string right_ans2;
        //total num of result
        int point = 0;

        //var for hours,min,sec
        int h, m, s;
        string name;
        
        public Form1(int iddd,string aa)
        {
            uid = iddd;
            name = aa;
            InitializeComponent();
        }
       
        // timer countdown
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            s = s - 1;
            if (s==-1)
            {
                m = m - 1;
                s = 59;
            }
            if (m==-1)
            {
                h = h - 1;
                m = 59;
            }


            if (h==0 && m==0 && s==0)
            {
                timer1.Stop();
                if (File.Exists("quiz.txt"))
                {
                    File.Delete("quiz.txt");
                }
                MessageBox.Show("time up & your Result is=" + point + "");
                
                //will close form
                this.Close();
              
            }
            label1.Text = Convert.ToString(h);
            label3.Text = Convert.ToString(m);
            label5.Text = Convert.ToString(s);
        }

        //stop timer
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            label7.Text = name;
        }

        private void ques_id_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = name;
        }

        //form/page load function,timer satrt with sart of program
        private void Form1_Load(object sender, EventArgs e)
        {
           // var aa = new >();

            if (File.Exists("quiz.txt"))
            {
                fr = new StreamReader("quiz.txt");
                if (reading == null)
                {
                    reading = fr.ReadLine();
                    if (reading == uid.ToString())
                    {
                        a[cnt] = Convert.ToInt32(reading);
                        cnt++;

                        //    //cnt = 0;
                        while ((reading = fr.ReadLine()) != null)
                        {

                            a[cnt] = Convert.ToInt32(reading);

                            cnt++;
                        }


                        //if ar_ch=6
                        int indx = 0;
                        indx = cnt - 1; //6-1=5
                        row_count = a[indx];

                        indx = indx - 1;//5-1=4
                        s = a[indx];
                        indx = indx - 1;//4-1=3
                        m = a[indx];
                        indx = indx - 1;//3-1=2
                        h = a[indx];
                        indx = indx - 1;//2-1=1
                        point = a[indx];
                    }
                    else
                    {
                        h = 0;
                        m = 2;
                        s = 3;

                    }
                }
                fr.Close();
            }
            else
            {
                h = 0;
                m = 2;
                s = 3;

            }
            label2:
             con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 10 PERCENT * FROM quiz_pro ORDER BY NEWID()", con);  // for random questions 

            // SqlCommand cmd1 = new SqlCommand("insert into marks values ("+point+")", con);
            SqlDataReader dt = cmd.ExecuteReader();

           
                //for (int j = 1; j <= 10; i++)
                //{

            if (dt.Read())
            {
                qid = dt.GetInt32(dt.GetOrdinal("id"));
                //will check ques is repeating or not 
		pqc=1;
                for (int c = 1; c < 10; c++)
                {
                    // qc++;   
                    if (a[pqc] == qid)
                    {
                     //  pqc += 6;
                        //it is closed b/c after this label 1 opens new connection which give new question via exec query again
                        //if its not closed ,then last fetched data remain in dt and may cause problem if con is not open in label
                        con.Close();
                        goto label2;
                    }
 			pqc += 7;
                }


                //it will count total rows/question fetched yet from database
                row_count++;

                ques_id.Text = row_count.ToString();
                ques.Text = dt.GetString(1);


                right_ans = dt.GetString(5);
                right_ans2 = dt.GetString(7);

                //decide on the base of question that is this single or multi ans que
                if (right_ans != "" && right_ans2 !="")
                {
                    // checkBox1.Show();
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();

                    checkBox1.Show();
                    checkBox2.Show();
                    checkBox3.Show();

                    checkBox1.Text = dt.GetString(2);
                    checkBox2.Text = dt.GetString(3);
                    checkBox3.Text = dt.GetString(4);
                }
                else
                {
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();

                    radioButton1.Show();
                    radioButton2.Show();
                    radioButton3.Show();

                    radioButton1.Text = dt.GetString(2);
                    radioButton2.Text = dt.GetString(3);
                    radioButton3.Text = dt.GetString(4);
                    //fil.Write();
                }
                con.Close();
            }




            label6.Text = DateTime.Now.ToString();
            //will give value for hour,min,sec
            
            timer1.Start();

        }

        //next button for fethng next question
        private void button3_Click(object sender, EventArgs e)
        {
            //my_quiz ob = new my_quiz();
            //ob.qmethod();
            if (radioButton1.Checked || radioButton2.Checked|| radioButton3.Checked)
            { 
            // start_quiz();
            //if questions completed it will terminate program
            //if (row_count >= 10)
            //{
            //    //this.Close();
            //    // int uid = fn.user_id;
            //    // f.Close();
            //    // File.Delete(f);
            //    con.Open();
            //    SqlCommand cmd1 = new SqlCommand("insert into marks(marks,std_id) values (" + point + "," + uid + ")", con);
            //    cmd1.ExecuteReader();
            //    con.Close();
            //    if (File.Exists("quiz.txt"))
            //    {
            //        File.Delete("quiz.txt");
            //    }
            //    MessageBox.Show("your Result is=" + marks.Text + "");
            //    this.Close();
            //    Application.Exit();

            //}


                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                {

                    //for (int j = 1; j <= 10; i++)
                    //{
                    //will count total marks of result
                    if (radioButton1.Checked)
                    {
                        if (radioButton1.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }

                    }

                    if (radioButton2.Checked)
                    {
                        if (radioButton2.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }
                    }


                    if (radioButton3.Checked)
                    {
                        if (radioButton3.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }
                    }

                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;

                    // ac++;
                    //will store id of questions coming from database
                    for (int i = row_count; i <= row_count; i++)
                    {
                        a[cnt] = uid;
                        a[cnt + 1] = qid;
                        a[cnt + 2] = point;
                        a[cnt + 3] = h;
                        a[cnt + 4] = m;
                        a[cnt + 5] = s;
                        a[cnt + 6] = row_count;


                    }
                    cnt += 7;
                    //filing, isert quest ids,marks and count down time in file
                    //if program termnate b/c of any problem then we will fetch all data from file and strt from last position 
                    f = new StreamWriter("quiz.txt");
                    //fc=1 b/c it will write data into file from index 1 when new loop strt below
                    fc = 0;
                    for (int i = 1; i <= row_count; i++)
                    {
                        //using fc instead of i b/c fc inc to +5 after fst iteration ,while i will become 2 on 2nd iteration
                        //on 2nd iteration we need to jump on 6th index of array and fc will do it,i bring us to 2nd index again and overrite it

                        //uid id
                        f.WriteLine(a[fc]);
                        //ques id
                        f.WriteLine(a[fc + 1]);
                        //point
                        f.WriteLine(a[fc + 2]);
                        //hour
                        f.WriteLine(a[fc + 3]);
                        //min
                        f.WriteLine(a[fc + 4]);
                        //sec
                        f.WriteLine(a[fc + 5]);
                        //row count
                        f.WriteLine(a[fc + 6]);
                        fc += 7;
                    }
                    f.Close();
                    if (row_count >= 10)
                    {
                        //this.Close();
                        // int uid = fn.user_id;
                        // f.Close();
                        // File.Delete(f);
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("insert into marks(marks,std_id) values (" + point + "," + uid + ")", con);
                        cmd1.ExecuteReader();
                        con.Close();
                        if (File.Exists("quiz.txt"))
                        {
                            File.Delete("quiz.txt");
                        }
                        MessageBox.Show("your Result is=" + marks.Text + "");
                        this.Close();
                        Application.Exit();

                    }
                }
                else
                {
                    MessageBox.Show("Please select option !!!");
                }
            // label6.Text= idd.ToString();

            // }
            labl1:
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 10 PERCENT * FROM quiz_pro ORDER BY NEWID()", con);

                // SqlCommand cmd1 = new SqlCommand("insert into marks values ("+point+")", con);
                SqlDataReader dt = cmd.ExecuteReader();
                if (dt.Read())
                {
                    qid = dt.GetInt32(dt.GetOrdinal("id"));
                    //will check ques is repeating or not 
                    qc = 1;
                    for (int c = 1; c <= 10; c++)
                    {
                        // qc++;   
                        if (a[qc] == qid)
                        {
                            // qc += 6;
                            //it is closed b/c after this label 1 opens new connection which give new question via exec query again
                            //if its not closed ,then last fetched data remain in dt and may cause problem if con is not open in label
                            con.Close();
                            goto labl1;
                        }
                        qc += 7;
                    }


                    //it will count total rows/question fetched yet from database
                    row_count++;

                    ques_id.Text = row_count.ToString();
                    ques.Text = dt.GetString(1);


                    right_ans = dt.GetString(5);
                    right_ans2 = dt.GetString(7);


                    //decide on the base of question that is this single or multi ans que
                    if (right_ans != "" && right_ans2 != "")
                    {
                        // checkBox1.Show();
                        radioButton1.Hide();
                        radioButton2.Hide();
                        radioButton3.Hide();

                        checkBox1.Show();
                        checkBox2.Show();
                        checkBox3.Show();

                        checkBox1.Text = dt.GetString(2);
                        checkBox2.Text = dt.GetString(3);
                        checkBox3.Text = dt.GetString(4);
                    }
                    else
                    {
                        checkBox1.Hide();
                        checkBox2.Hide();
                        checkBox3.Hide();

                        radioButton1.Show();
                        radioButton2.Show();
                        radioButton3.Show();

                        radioButton1.Text = dt.GetString(2);
                        radioButton2.Text = dt.GetString(3);
                        radioButton3.Text = dt.GetString(4);
                        //fil.Write();
                    }

                }
                con.Close();

            }
            else if (checkBox1.Checked && checkBox2.Checked || checkBox1.Checked && checkBox3.Checked || checkBox2.Checked && checkBox3.Checked)
                {

                    //for (int j = 1; j <= 10; i++)
                    //{
                    //will count total marks of result
                    if (checkBox1.Checked && checkBox2.Checked)
                    {
                        if (checkBox1.Text == right_ans && checkBox2.Text == right_ans2)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }
                        else if (checkBox1.Text == right_ans2 && checkBox2.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }

                    }

                    if (checkBox2.Checked && checkBox3.Checked)
                    {
                        if (checkBox2.Text == right_ans && checkBox3.Text == right_ans2)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }
                        else if (checkBox2.Text == right_ans2 && checkBox3.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }

                    }


                    if (checkBox1.Checked && checkBox3.Checked)
                    {
                        if (checkBox1.Text == right_ans && checkBox3.Text == right_ans2)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }
                        else if (checkBox1.Text == right_ans2 && checkBox3.Text == right_ans)
                        {
                            point++;
                            marks.Text = point.ToString();
                        }

                    }

                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    // ac++;
                    //will store id of questions coming from database
                    for (int i = row_count; i <= row_count; i++)
                    {

                        a[cnt] = uid;
                        a[cnt + 1] = qid;
                        a[cnt + 2] = point;
                        a[cnt + 3] = h;
                        a[cnt + 4] = m;
                        a[cnt + 5] = s;
                        a[cnt + 6] = row_count;


                    }
                    cnt += 7;
                    //filing, isert quest ids,marks and count down time in file
                    //if program termnate b/c of any problem then we will fetch all data from file and strt from last position 
                    f = new StreamWriter("quiz.txt");
                    //fc=1 b/c it will write data into file from index 1 when new loop strt below
                    fc = 0;
                    for (int i = 1; i <= row_count; i++)
                    {
                        //using fc instead of i b/c fc inc to +5 after fst iteration ,while i will become 2 on 2nd iteration
                        //on 2nd iteration we need to jump on 6th index of array and fc will do it,i bring us to 2nd index again and overrite it

                        //uid id
                        f.WriteLine(a[fc]);
                        //ques id
                        f.WriteLine(a[fc + 1]);
                        //point
                        f.WriteLine(a[fc + 2]);
                        //hour
                        f.WriteLine(a[fc + 3]);
                        //min
                        f.WriteLine(a[fc + 4]);
                        //sec
                        f.WriteLine(a[fc + 5]);
                        //row count
                        f.WriteLine(a[fc + 6]);
                        fc += 7;
                    }
                    f.Close();
                    if (row_count >= 10)
                    {
                        //this.Close();
                        // int uid = fn.user_id;
                        // f.Close();
                        // File.Delete(f);

                        if (File.Exists("quiz.txt"))
                        {
                            File.Delete("quiz.txt");
                        }

                        Application.Exit();

                    }

                // label6.Text= idd.ToString();

                // }
                labl1:
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 10 PERCENT * FROM quiz_pro ORDER BY NEWID()", con);

                    // SqlCommand cmd1 = new SqlCommand("insert into marks values ("+point+")", con);
                    SqlDataReader dt = cmd.ExecuteReader();
                    if (dt.Read())
                    {
                        qid = dt.GetInt32(dt.GetOrdinal("id"));
                        //will check ques is repeating or not 
                        qc = 1;
                        for (int c = 1; c <= 10; c++)
                        {
                            // qc++;   
                            if (a[qc] == qid)
                            {
                                // qc += 6;
                                //it is closed b/c after this label 1 opens new connection which give new question via exec query again
                                //if its not closed ,then last fetched data remain in dt and may cause problem if con is not open in label
                                con.Close();
                                goto labl1;
                            }
                            qc += 7;
                        }


                        //it will count total rows/question fetched yet from database
                        row_count++;

                        ques_id.Text = row_count.ToString();
                        ques.Text = dt.GetString(1);


                        right_ans = dt.GetString(5);
                        //will not take null values getvalue method,so should not be null in sql
                        right_ans2 = dt.GetString(7);

                        //will cause problem if check like thi " " below
                        //decide on the base of question that is this single or multi ans que
                        if (right_ans != "" && right_ans2 != "")
                        {
                            // checkBox1.Show();
                            radioButton1.Hide();
                            radioButton2.Hide();
                            radioButton3.Hide();

                            checkBox1.Show();
                            checkBox2.Show();
                            checkBox3.Show();

                            checkBox1.Text = dt.GetString(2);
                            checkBox2.Text = dt.GetString(3);
                            checkBox3.Text = dt.GetString(4);
                        }
                        else
                        {
                            checkBox1.Hide();
                            checkBox2.Hide();
                            checkBox3.Hide();

                            radioButton1.Show();
                            radioButton2.Show();
                            radioButton3.Show();

                            radioButton1.Text = dt.GetString(2);
                            radioButton2.Text = dt.GetString(3);
                            radioButton3.Text = dt.GetString(4);
                            //fil.Write();
                        }

                    }
                    con.Close();

                }
            else
            {
                MessageBox.Show("select option please.....");
            }
            }

        }
       
        }

       
       
    




    