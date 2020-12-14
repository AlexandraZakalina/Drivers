using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2_ZS
{
    public partial class Form2 : Form
    {
        string connectionstring = @"Data Source=DESKTOP-HHT7APO;Integrated Security=SSPI;Initial Catalog=data";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string sql = "Select * from Data";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            // Создаем объект Dataset
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
            // Отображаем данные
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT photo FROM Data WHERE id="+textBox1.Text, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string photo = reader[0].ToString();
            reader.Close();
            conn.Close();
            Process.Start(Application.StartupPath + @"\pic\"+photo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Data set ";
            if (textBox3.Text != "")
            {
                query += "num_car = '" + textBox3.Text + "',";
            }

            if (textBox4.Text != "")
            {
                query += "region = " + Convert.ToInt32(textBox4.Text) + ",";
            }

            string query1 = "";
            for (int i = 0; i < query.Length - 1; i++)
            {
                query1 += query[i];
            }
            query1 += " where id =" + Convert.ToInt32(textBox2.Text) + "";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand command = new SqlCommand(query1, conn);
            command.ExecuteNonQuery();
            MessageBox.Show("Запись отредактирована");

            string sql = "Select * from Data";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            // Создаем объект Dataset
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
            // Отображаем данные
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
