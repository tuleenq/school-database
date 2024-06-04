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

namespace project
{
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataReader myreader;
        SqlConnectionStringBuilder s = new SqlConnectionStringBuilder("Data Source=DESKTOP-QB3AVP3;Initial Catalog=SCHOOL;Integrated Security=True;Pooling=False");
        public Form7()
        {
            InitializeComponent();
            con.ConnectionString = s.ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.ConnectionString = s.ConnectionString;
            if (con.State == ConnectionState.Closed)
                con.Open();
            string insert = "insert into students values (" +
            Int32.Parse(textBox1.Text) + ","
            + "'" + textBox2.Text + " '" + "," + "'" + textBox3.Text + "'" + "," + "'" + textBox4.Text + "'" + "," + "'" + textBox5.Text + "'" + "," + float.Parse(textBox6.Text) + ")";

            SqlCommand cmd = new SqlCommand(insert, con);
            int c = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                con.Open();
                string strsql = "update students set fname= '" + textBox2.Text + "', lname= '" + textBox3.Text + "',gender = '" + textBox4.Text + "', bdate= '" + textBox5.Text + "', gpa= '" + textBox6.Text + "' where id= " + textBox1.Text;
                SqlCommand cmd = new SqlCommand(strsql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                con.Open();
                string strsql = "delete from students where id= " + textBox1.Text;
                SqlCommand cmd = new SqlCommand(strsql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string strsql = "select * from students where id=" + textBox1.Text;

            SqlCommand cmd = new SqlCommand(strsql, con);

            object res = cmd.ExecuteScalar();

            if (res == null)
                MessageBox.Show("student  not found", "Wrong ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                myreader = cmd.ExecuteReader();
                myreader.Read();
                textBox2.Text = myreader["fname"].ToString();
                textBox3.Text = myreader["lname"].ToString();
                textBox4.Text = myreader["gender"].ToString();
                textBox5.Text = myreader["bdate"].ToString();
                textBox6.Text = myreader["gpa"].ToString();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }
    }
}
