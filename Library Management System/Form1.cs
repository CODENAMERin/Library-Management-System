﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=library_system; Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = textBox2.Text;
            SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
            {
                //MessageBox.Show("Login Success");
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
                else
            {
                MessageBox.Show("Login Failed");
            }
                con.Close();
        }
    }
}
