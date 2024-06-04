using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataReader myreader;
        SqlConnectionStringBuilder s = new SqlConnectionStringBuilder("Data Source=DESKTOP-QB3AVP3;Initial Catalog=SCHOOL;Integrated Security=True;Pooling=False");
        public Form6()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("Fname", "FIRST NAME");
            dataGridView1.Columns.Add("Lname", "LAST NAME");
            dataGridView1.Columns.Add("gender", "GENDER");
            dataGridView1.Columns.Add("bdate", "Birth date");
            dataGridView1.Columns.Add("gpa", "GPA");


        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            con.ConnectionString = s.ConnectionString;
            con.Open();
            string select = "select * from students";
            SqlCommand command = new SqlCommand(select, con);
            myreader = command.ExecuteReader();
            while (myreader.Read())
            {
                dataGridView1.Rows.Add(myreader["id"].ToString(),
                    myreader["Fname"].ToString(),
                    myreader["Lname"].ToString(),
                    myreader["gender"].ToString(),
                    myreader["bdate"].ToString(),
                    myreader["gpa"].ToString()
                    );
            }
        }
    }
}
