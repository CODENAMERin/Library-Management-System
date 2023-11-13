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

namespace Library_Management_System
{
    public partial class IssueBook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=library_system; Integrated Security=true");

        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getbooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentNO", SqlDbType.VarChar).Value = textBox6.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addissuebook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.VarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Student_no", SqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = comboBox1.Text;
            cmd.Parameters.Add("@Issue_Date", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToShortDateString();
            cmd.Parameters.Add("@Return_Date", SqlDbType.VarChar).Value = "";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issued Book Added");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
