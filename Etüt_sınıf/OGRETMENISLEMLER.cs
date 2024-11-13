using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etüt_sınıf
{
    public partial class OGRETMENISLEMLER : Form
    {
        public OGRETMENISLEMLER()
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
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLOGRETMEN(AD,SOYAD,BRANSID) values(@P1,@P2,@P3)", baglanti);
            cmd.Parameters.AddWithValue("@P1", txtOgretmenAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtOgretmensoyad.Text);
            cmd.Parameters.AddWithValue("@P3", cmbBrans.SelectedValue);
            baglanti.Close();
           
        }
      
            
        
        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLDERSLER  ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbBrans.DisplayMember = "DERSAD";
            cmbBrans.ValueMember = "DERSID";

        }

        private void OGRETMENISLEMLER_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbEtutDataSet1.TBLDERSLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLDERSLERTableAdapter.Fill(this.dbEtutDataSet1.TBLDERSLER);

        }
    }
}
