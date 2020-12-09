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

namespace S2_ZS
{
    public partial class Form1 : Form
    {
        string connectionstring = @"Data Source=PK306-9\MSSQLSERVER1;Initial Catalog=drivers;Integrated Security=True";
        string connectionstring1 = @"Data Source=PK306-9\MSSQLSERVER1;Initial Catalog=za_s2;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            string query = "update Drivers1 set ";
            if(textBox1.Text != "")
            {
                query += "name = '"+textBox1.Text+"',";
            }

            if (textBox2.Text != "")
            {
                query += "middlename = '" + textBox2.Text + "',";
            }

            if (textBox4.Text != "")
            {
                query += "[passport serial] = '" + textBox4.Text + "',";
            }

            if (textBox3.Text != "")
            {
                query += "[passport number] = '" + textBox3.Text + "',";
            }

            if (textBox8.Text != "")
            {
                query += "postcode = '" + textBox8.Text + "',";
            }

            if (textBox7.Text != "")
            {
                query += "address = '" + textBox7.Text + "',";
            }

            if (textBox6.Text != "")
            {
                query += "[address life] = '" + textBox6.Text + "',";
            }

            if (textBox5.Text != "")
            {
                query += "company = '" + textBox5.Text + "',";
            }

            if (textBox9.Text != "")
            {
                query += "jobname = '" + textBox9.Text + "',";
            }

            if (textBox13.Text != "")
            {
                query += "phone = '" + textBox13.Text + "',";
            }

            if (textBox12.Text != "")
            {
                query += "email = '" + textBox12.Text + "',";
            }

            if (textBox11.Text != "")
            {
                query += "photo = '" + textBox11.Text + "',";
            }

            if (textBox10.Text != "")
            {
                query += "description = '" + textBox10.Text + "',";
            }

            string query1 = "";
            for(int i=0; i<query.Length-1;i++)
            {
                query1 += query[i];
            }

            query1 += " where id ='"+textBox14.Text+"'";
            
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query1, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Ok!");
            }

            string sql = "Select * from Drivers1";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            // Создаем объект Dataset
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
            // Отображаем данные
            dataGridView1.DataSource = ds.Tables[0];
        }

        class Data
        {
            public string Id { get; set; }
            public string Car_num { get; set; }
            public string Region { get; set; }
            public string Licence_num { get; set; }
            public string Create_date { get; set; }
            public string Photo { get; set; }
        }

        public string getFines(DateTime date)
        {
            SqlConnection connection = new SqlConnection(connectionstring1);
            connection.Open();
            string output="";
            string query1 = "Select count(*) from data where create_date >'" + date + "'";
            SqlCommand command1 = new SqlCommand(query1, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            List<string[]> data1 = new List<string[]>();
            reader1.Read();
            int count = Convert.ToInt32(reader1[0]);
            reader1.Close();
            if (count<=5)
            {
                string query2 = "Select * from data where create_date >'" + date + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query2, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                string query2 = "Select TOP(5) * from data where create_date >'" + date + "' order by create_date";
                SqlDataAdapter adapter = new SqlDataAdapter(query2, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            return output;
        }

        public string postFine()
        {
            string output = "";
            
            return output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string sql = "Select * from Drivers1";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            // Создаем объект Dataset
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
            // Отображаем данные
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            getFines(dateTime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
