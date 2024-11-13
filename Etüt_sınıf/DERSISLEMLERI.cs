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
using System.Runtime.ConstrainedExecution;

namespace Etüt_sınıf
{
    public partial class DERSISLEMLERI : Form
    {
        public DERSISLEMLERI()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbEtut;Integrated Security=True;");
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makerrer();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLDERSLER (DERSAD) values(@P1)", baglanti);
                komut.Parameters.AddWithValue("@P1", txtderssad.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("DERS KAYDINIZ YAPILMIŞTIR!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtderssad.Text = "";
            }
            else
            {
                MessageBox.Show("BU DERS KAYDI DAHA ÖNCE YAPILMIŞ!EKLEME GERÇEKLEŞTİRİLEMEDİ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }
        bool durum;

        void makerrer()
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("select *from TBLDERSLER where DERSAD=@P1", baglanti);
            cmd.Parameters.AddWithValue("@P1", txtderssad.Text);

            SqlDataReader dr =cmd.ExecuteReader();

            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            baglanti.Close();
        }


    }
}
