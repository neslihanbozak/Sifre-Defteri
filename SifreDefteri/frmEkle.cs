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
    public partial class frmEkle : Form
    {
        public frmEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SifreDBContext db = new SifreDBContext();
            decimal veriID= db.Database.SqlQuery<decimal>
                ("exec spVeriEkle @kullaniciID,@eposta,@sifre,@aciklama",
                new SqlParameter("@eposta",txtEposta.Text),
                new SqlParameter("@sifre", txtSifre.Text),
                new SqlParameter("@kullaniciID", Program.kullanici.kullaniciID),
                new SqlParameter("@aciklama", txtAciklama.Text)
                ).SingleOrDefault();
            MessageBox.Show(veriID.ToString());
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
