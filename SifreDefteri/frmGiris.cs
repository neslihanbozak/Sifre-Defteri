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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SifreDBContext db = new SifreDBContext();
            Kullanici kullanici = db.Database.SqlQuery<Kullanici>
                ("exec spKullaniciGiris @eposta,@sifre",
                new SqlParameter("@eposta", txtEposta.Text),
                new SqlParameter("@sifre", txtSifre.Text)
                ).SingleOrDefault();
            if (kullanici == null)
            {
                MessageBox.Show("Eposta veya Şifre hatalı");
            }
            else
            {
                Program.kullanici = kullanici;
                this.Hide();
                //frmAnasayfa frmAnasayfa = new frmAnasayfa();
                //frmAnasayfa.Show();
                new frmAnasayfa().Show();
            }
        }
    }
}
