using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime;

namespace S2_ZS
{
    public partial class Form3 : Form
    {
        Timer timer1 = new Timer();
        public int i = 0;
        public Form3()
        {
            InitializeComponent();
        }
 
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == textBox2.Text && textBox1.Text == "inspector")
            {
                MessageBox.Show("Вы вошли как inspector");
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                i++;
                MessageBox.Show("Введен неверный пароль");
                if(3<=i)
                {
                    MessageBox.Show("Блокировка на 1 минуту");
                    timer1.Interval = 60000;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    button1.Enabled = false;
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Start();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            i = 0;
            timer1.Stop();
        }
    }
}
