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
using System.IO;

namespace Etüt_sınıf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbEtut;Integrated Security=True;");
      void derslistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLDERSLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.ValueMember = "DERSID";
            cmbders.DisplayMember = "DERSAD";
            cmbders.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            derslistesi();
            
        }
      void ogrttablo()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLOGRENCI",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLOGRETMEN WHERE BRANSID =" + cmbders.SelectedValue, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Ogretmen", typeof(string), "AD +' '+ SOYAD");
            cmbogretmen.DisplayMember = "OGRETMEN";
            cmbogretmen.ValueMember = "OGRTID";
            cmbogretmen.DataSource = dt;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      /*  void etütlistesi()
        {
            
        }*/
        private void btnetütolustur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLETUT (DERSID,OGRETMENID,TARIH,SAAT) values(@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", cmbders.SelectedValue);
            komut.Parameters.AddWithValue("@P2", cmbogretmen.SelectedValue);
            komut.Parameters.AddWithValue("@P3", msktarih.Text);
            komut.Parameters.AddWithValue("@P4", msksaat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ETÜT OLUŞTURULDU!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtetütid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnetütver_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLETUT SET OGRENCIID=@P1,DURUM=@P2 WHERE ID=@P3",baglanti);
            komut.Parameters.AddWithValue("@P1", txogrenciid.Text);
            komut.Parameters.AddWithValue("@P2", "true");
            komut.Parameters.AddWithValue("@P3", txtetütid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ETÜT VERİLDİ ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OGRENCIISLEM fr = new OGRENCIISLEM();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DERSISLEMLERI FR = new DERSISLEMLERI();
            FR.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OGRETMENISLEMLER FR = new OGRETMENISLEMLER();
            FR.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ogrttablo();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da3 = new SqlDataAdapter("execute Etütt ", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                bool durum = Convert.ToBoolean(dt3.Rows[i]["DURUM"]);
                if (durum == true)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void cmbogretmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
