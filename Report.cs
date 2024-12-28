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

namespace EmployeeDataStore
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Employee", con);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            da.Fill(table);
            dataGridView1.DataSource = table;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con =  new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn =  new SqlCommand("select * from Employee where employeeid=@employeeid", con);
            cnn.Parameters.AddWithValue("@EmployeeID", int.Parse(textBox1.Text));
            SqlDataAdapter da =  new SqlDataAdapter(cnn);
            DataTable table =  new DataTable();
            da.Fill(table);
            con.Close();
            dataGridView1.DataSource = table;
        }
    }
}
