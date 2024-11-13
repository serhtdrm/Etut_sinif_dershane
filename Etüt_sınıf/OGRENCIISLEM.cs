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

namespace Etüt_sınıf
{
    public partial class OGRENCIISLEM : Form
    {
        public OGRENCIISLEM()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbEtut;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLOGRENCI (AD,SOYAD,FOTOGRAF,SINIF,TELEFON,MAIL) Values(@P1,@P2,@P3,@P4,@P5,@P6)",baglanti);
            komut.Parameters.AddWithValue("@P1", txogrenciAd.Text);
            komut.Parameters.AddWithValue("@P2", txtogrenciSoyad.Text);
            komut.Parameters.AddWithValue("@P3", pictureBox2.ImageLocation);
            komut.Parameters.AddWithValue("@P4", txtSınıf.Text);
            komut.Parameters.AddWithValue("@P5", msktelefon.Text);
            komut.Parameters.AddWithValue("@P6", txtMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ÖĞRENCİ KAYDINIZ YAPILDI","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txogrenciAd.Text = "";
            txtogrenciSoyad.Text = "";
            pictureBox2.ImageLocation = "";
            txtSınıf.Text = "";
            msktelefon.Text = "";
            txtMail.Text = "";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
