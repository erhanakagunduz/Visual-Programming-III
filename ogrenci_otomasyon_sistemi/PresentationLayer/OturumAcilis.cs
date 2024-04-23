using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ogrenci_otomasyon_sistemi.PresentationLayer;
using ogrenci_otomasyon_sistemi.BusinessLogicLayer;
using ogrenci_otomasyon_sistemi.PocosLayer;

namespace ogrenci_otomasyon_sistemi
{
    public partial class OturumAcilis : Form
    {
        //iş katmanını çalışmamız lazım
        tblKullanicilarBLL _tblKullanicilarBLL;
        public OturumAcilis()  //constructor method
        {
            InitializeComponent();
            _tblKullanicilarBLL = new tblKullanicilarBLL(); //başlangıçta otomatik çalışsın
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Poco lar ile çalışacağız. bu sebeple poco dan yeni nesne türetiyoruz
            tblKullanicilarPoco _tblKullanicilarPoco = new tblKullanicilarPoco();

            //poco ya ne göndereceğim peki iş katmanındaki getSorgu yu göndereceğim.

            _tblKullanicilarPoco = _tblKullanicilarBLL.getSorgu(textBox1.Text, textBox2.Text);

            if ((_tblKullanicilarPoco.kullaniciAdi == null) || (_tblKullanicilarPoco.sifre == null))
                MessageBox.Show("Hatali Giris Yaptiniz...");
                MessageBox.Show("Hatali Giris Yaptiniz", "Hata Mesajı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
            {
                this.Hide();
                MessageBox.Show("Hoş Geldiniz : " + _tblKullanicilarPoco.kullaniciAdi, "Kullanıcı Giriş Mesajı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                AnaMenu girisEkrani = new AnaMenu();
                girisEkrani.Show();
            }
        }
    }
}
