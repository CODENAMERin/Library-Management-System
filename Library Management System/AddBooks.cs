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
    public partial class AddBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=library_system; Integrated Security=true");

        public AddBooks()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_add_books", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName",SqlDbType.VarChar).Value= textBox1.Text;
            cmd.Parameters.Add("@AuthorName", SqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@publication", SqlDbType.VarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@purchaseDate", SqlDbType.VarChar).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@BookPrice", SqlDbType.VarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = textBox6.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Added");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
