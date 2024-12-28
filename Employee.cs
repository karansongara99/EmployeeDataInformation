using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDataStore
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");  
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Employee values(@employeeid,@employeename,@emailid,@address,@position,@salary,@phoneno)",con);
            cnn.Parameters.AddWithValue("@EmployeeID",int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@EmployeeName", textBox2.Text);
            cnn.Parameters.AddWithValue("@EmailID", textBox3.Text);
            cnn.Parameters.AddWithValue("@Address", textBox4.Text);
            cnn.Parameters.AddWithValue("@Position", textBox5.Text);
            cnn.Parameters.AddWithValue("@Salary", int.Parse(textBox6.Text));
            cnn.Parameters.AddWithValue("@PhoneNo", int.Parse(textBox7.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Are Saved Data Successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Employee", con);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update Employee set employeename-@employeename,emailid=@emailid,address=@address,position=@position,salary=@salary,phoneno=@phoneno where employeeid=@employeeid", con);
            cnn.Parameters.AddWithValue("@EmployeeID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@EmployeeName", textBox2.Text);
            cnn.Parameters.AddWithValue("@EmailID", textBox3.Text);
            cnn.Parameters.AddWithValue("@Address", textBox4.Text);
            cnn.Parameters.AddWithValue("@Position", textBox5.Text);
            cnn.Parameters.AddWithValue("@Salary", int.Parse(textBox6.Text));
            cnn.Parameters.AddWithValue("@PhoneNo", int.Parse(textBox7.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Are Updated Data Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from Employee where employeeid=@employeeid", con);
            cnn.Parameters.AddWithValue("@EmployeeID", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Data Successfully");
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=EmployeeDb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Employee", con);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            da.Fill(table);
            dataGridView1.DataSource = table;
            count1.Text = table.Rows.Count.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
