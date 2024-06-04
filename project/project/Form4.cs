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
using System.Xml;

namespace project
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataReader myreader;
        SqlConnectionStringBuilder s = new SqlConnectionStringBuilder("Data Source=DESKTOP-QB3AVP3;Initial Catalog=SCHOOL;Integrated Security=True;Pooling=False");
        public Form4()
        {
            InitializeComponent();
            con.ConnectionString = s.ConnectionString;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.ConnectionString = s.ConnectionString;
            if (con.State == ConnectionState.Closed)
                con.Open();
            string insert = "insert into teacher values (" +
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
                string strsql = "update teacher set fname= '" + textBox2.Text + "', lname= '" + textBox3.Text + "',gender = '" + textBox4.Text + "', email= '" + textBox5.Text + "', salary= '" + textBox6.Text + "' where id= " + textBox1.Text;
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
                string strsql = "delete from teacher where id= " + textBox1.Text;
                SqlCommand cmd = new SqlCommand(strsql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string strsql = "select * from teacher where id=" + textBox1.Text;

            SqlCommand cmd = new SqlCommand(strsql, con);

            object res = cmd.ExecuteScalar();

            if (res == null)
                MessageBox.Show("teacher  not found", "Wrong ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                myreader = cmd.ExecuteReader();
                myreader.Read();
                textBox2.Text = myreader["fname"].ToString();
                textBox3.Text = myreader["lname"].ToString();
                textBox4.Text = myreader["gender"].ToString();
                textBox5.Text = myreader["email"].ToString();
                textBox6.Text = myreader["salary"].ToString();
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
