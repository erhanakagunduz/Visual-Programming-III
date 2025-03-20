using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Ogrenci_Otomasyon_Sistemi.PresentationLayer.Kullanici;

namespace Ogrenci_Otomasyon_Sistemi.PresentationLayer
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYeniKayit yeniKayit = new KullaniciYeniKayit();
            yeniKayit.Show();
            this.Close();
        }
    }
}
