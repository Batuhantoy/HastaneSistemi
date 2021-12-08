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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbCommand komut;
        OleDbConnection yol;
        OleDbDataReader okuyucu;

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitgetir();
            tasarim();
        }
        private void kayitgetir()
        {
            yol = new OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            yol.Open();
            komut =new OleDbCommand ("select * from hastalar",yol);
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                listBox1.Items.Add(" " + okuyucu["hastano"].ToString());
            }
            yol.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hastaekle he = new hastaekle();
            he.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            yazdır();
        }
        private void yazdır()
        {
            int sira = Convert.ToInt16(listBox1.SelectedItem);
            yol = new OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            yol.Open();
            komut = new OleDbCommand("select * from hastalar", yol);
            okuyucu = komut.ExecuteReader();

            
                for (int i = 1; i <= sira; i++)
                {
                    okuyucu.Read();
                }
            
            textBox1.Text = okuyucu["ad"].ToString();
            textBox2.Text = okuyucu["soyad"].ToString();
            textBox3.Text = okuyucu["doktorad"].ToString();
            textBox4.Text = okuyucu["doktorsira"].ToString();
            textBox5.Text = sira.ToString();
            yol.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yol = new OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            yol.Open();
            
            komut = new OleDbCommand("update hastalar set ad='" + textBox1.Text + "' where hastano=" + textBox5.Text, yol);
            komut = new OleDbCommand("update hastalar set soyad='" + textBox2.Text + "' where hastano=" + textBox5.Text, yol);
            komut = new OleDbCommand("update hastalar set doktorsira=" + textBox4.Text + " where hastano=" + textBox5.Text, yol);
            komut = new OleDbCommand("update hastalar set doktorad='" + textBox3.Text + "' where hastano=" + textBox5.Text, yol);
            
            komut.ExecuteNonQuery();
            MessageBox.Show("DÜzenleme İşlemi Başarılı");
            yol.Close();
        }

        private void tasarim()
        {
            this.BackColor = Color.AntiqueWhite;
            listBox1.BackColor = Color.Turquoise;
            button3.BackColor = Color.BlueViolet;
            button2.BackColor = Color.IndianRed;
            button1.BackColor = Color.ForestGreen;
            textBox1.BackColor = Color.Turquoise;
            textBox2.BackColor = Color.Turquoise;
            textBox3.BackColor = Color.Turquoise;
            textBox4.BackColor = Color.Turquoise;
            textBox5.BackColor = Color.Turquoise;
        }

    }
}
