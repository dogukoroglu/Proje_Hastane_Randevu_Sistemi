using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.TCNumara = mskdTc.Text;
                frs.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Hatalı Kullanıcı TC Numarası ya da  Şifre Girdiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bgl.baglanti().Close();
        }
    }
}
