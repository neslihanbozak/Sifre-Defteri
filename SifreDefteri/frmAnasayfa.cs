using SifreDefteri.Model;
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

namespace SifreDefteri
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            lblKullanici.Text = "Hoşgeldin " + Program.kullanici.ad + " " + Program.kullanici.soyad;
            //Tüm verielri getir

            Doldur();
        }

        private void Doldur()
        {
            SifreDBContext db = new SifreDBContext();
            List<Veri> veriler = db.Database.SqlQuery<Veri>
                ("exec spVerileriGetir @kullaniciID",
                new SqlParameter("@kullaniciID", Program.kullanici.kullaniciID)
                ).ToList();
            dataSifreler.DataSource = veriler.Select(x => new
            {
                x.veriID,
                x.KullaniciID,
                x.eposta,
                x.aciklama
            });
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmEkle frmEkle = new frmEkle();
            DialogResult sonuc = frmEkle.ShowDialog();
            if (sonuc != DialogResult.OK)
            {
                MessageBox.Show("İptal Edildi");
            }
            else
            {
                //MessageBox.Show("Eklendi");
                //Listeyi yenile
                Doldur();
            }
        }
    }
}
