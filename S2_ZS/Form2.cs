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
        string connectionstring = @"Data Source=PK306-9\MSSQLSERVER1;Initial Catalog=za_s2;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string sql = "Select * from data";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            // Создаем объект Dataset
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
            // Отображаем данные
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Process.Start(@"Z:\ИС-17 Закалина Катаева\Сессии\S2_ZS\packages\Newtonsoft.Json.12.0.3\packageIcon.png");
        }
    }
}
