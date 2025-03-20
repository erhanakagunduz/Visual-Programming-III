using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ogrenci_Otomasyon_Sistemi.PresentationLayer;

namespace Ogrenci_Otomasyon_Sistemi.PresentationLayer.Kullanici
{
    public partial class KullaniciYeniKayit : Form
    {
        public KullaniciYeniKayit()
        {
            InitializeComponent();
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            AnaMenu girisEkrani = new AnaMenu();
            girisEkrani.Show();
            this.Close();
        }
    }
}
