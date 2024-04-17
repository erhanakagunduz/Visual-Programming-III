using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ogrenci_otomasyon_sistemi.PresentationLayer.Kullanicilar;

namespace ogrenci_otomasyon_sistemi.PresentationLayer
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void yeniKullanıcıKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYeniKayit yeni_kayit = new KullaniciYeniKayit();
            yeni_kayit.Show();
            this.Close();
        }
    }
}
