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
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=library_system; Integrated Security=true");

        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.VarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Student_Number", SqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.VarChar).Value = textBox6.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Details Added");
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
