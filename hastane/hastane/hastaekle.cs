using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace hastane
{
    public partial class hastaekle : Form
    {
        OleDbCommand komut;
        OleDbConnection yol;
        OleDbDataReader okuyucu;
        public hastaekle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "")
            {
                yol = new OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
                yol.Open();
                komut = new OleDbCommand("insert into hastalar(ad,soyad,doktorsira,doktorad) values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox4.Text + ",'" + textBox3.Text + "')", yol);
                komut.ExecuteNonQuery();
                yol.Close();
            }
            else
                MessageBox.Show("Bir alanı boş bıraktınız");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Green;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.Yellow;
        }

        private void hastaekle_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.NavajoWhite;
            textBox1.BackColor = Color.Turquoise;
            textBox2.BackColor = Color.Turquoise;
            textBox3.BackColor = Color.Turquoise;
            textBox4.BackColor = Color.Turquoise;
        }
    }
}
