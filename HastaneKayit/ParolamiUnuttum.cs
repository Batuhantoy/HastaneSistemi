using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net;

namespace HastaneKayit
{
    public partial class ParolamiUnuttum : Form
    {               

        public ParolamiUnuttum()
        {
            InitializeComponent();
        }


        Form1 frm1 = new Form1();

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                frm1.uyelerBaglantisi.Open();
                OleDbCommand cmd = new OleDbCommand("Select * From Uyeler where TC='"+maskedtxtTC.Text+"'", frm1.uyelerBaglantisi);
                OleDbDataReader dr = cmd.ExecuteReader();
                bool parola_Verildimi = false;
                while (dr.Read())
                {
                    try
                    {
                        SmtpClient smtpserver = new SmtpClient();
                        MailMessage mail = new MailMessage();

                        String mailadresin = ("gurhospital@hotmail.com"); // msn
                        String mailsifren = ("ismailGUR123"); // sifre
                        String smptsrvr = "smtp.live.com"; // dokunma
                        String kime = (dr["Eposta"].ToString());
                        String konu = ("Parola Hatırlatma"); //konu
                        String yazi = ("Sayın "+dr["Adı"].ToString()+" "+dr["Soyadı"].ToString()+"\nParolanız = " + dr["Parola"].ToString());  // metin

                        smtpserver.Credentials = new NetworkCredential(mailadresin, mailsifren);
                        smtpserver.Port = 587;
                        smtpserver.Host = smptsrvr;
                        smtpserver.EnableSsl = true;
                        mail.From = new MailAddress(mailadresin);
                        mail.To.Add(kime);
                        mail.Subject = konu;
                        mail.Body = yazi;
                        smtpserver.Send(mail);
                        MessageBox.Show("Mailinize gelen Şifreyle Hesabınıza giriş yapınız.\nGüvenliğiniz İçin Ardından Lütfen şifrenizi değiştiriniz.");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                    }
                    parola_Verildimi = true;

                    if (parola_Verildimi)
                    {
                        this.Close();
                    }
                }
                if (parola_Verildimi==false)
                {
                    MessageBox.Show("Hatalı Bilgiler");
                }
                frm1.uyelerBaglantisi.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                this.Close();
            }
        }

        private void maskedtxtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnGonder_Click(sender, e);
            }
        }

        private void ParolamiUnuttum_Load(object sender, EventArgs e)
        {
            maskedtxtTC.Text = "1";
            maskedtxtTC.Text = "";
            maskedtxtTC.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        private void ParolamiUnuttum_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm1.uyelerBaglantisi.Close();
        }

    }
}
