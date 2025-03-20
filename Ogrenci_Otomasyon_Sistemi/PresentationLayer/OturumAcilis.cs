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
using Ogrenci_Otomasyon_Sistemi.BusinessLogicLayer;
using Ogrenci_Otomasyon_Sistemi.PocosLayer;

namespace Ogrenci_Otomasyon_Sistemi
{
    public partial class Form1 : Form
    {
        TblKullanicilarBLL _tblKullanicilarBLL;
        public Form1()
        {
            InitializeComponent();

            _tblKullanicilarBLL = new TblKullanicilarBLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TblKullanicilarPoco _tblKullanicilarPoco = new TblKullanicilarPoco();

            _tblKullanicilarPoco = _tblKullanicilarBLL.getSorgu(txtKullaniciAdi.Text, txtSifre.Text);

            if ((_tblKullanicilarPoco.kullaniciAdi == null) || (_tblKullanicilarPoco.sifre == null))
            {
                MessageBox.Show("Kullanici Adi veya Şifre Hatalı", "Hata Mesajı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            else
            {
                this.Hide();

                MessageBox.Show("Sisteme Giriş Başarılı", "Mesaj", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                AnaMenu girisEkrani = new AnaMenu();
                girisEkrani.Show();
                
            }

            
        }
    }
}
