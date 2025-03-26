// Gerekli kütüphaneleri içe aktarır
using System;
using System.Windows.Forms;

// Öğrenci Otomasyon Sistemi bileşenlerinden bize lazım olanları içe aktarıyoruz
using Ogrenci_Otomasyon_Sistemi.PresentationLayer;
using Ogrenci_Otomasyon_Sistemi.BusinessLogicLayer;
using Ogrenci_Otomasyon_Sistemi.PocosLayer;

// Ana namespace tanımlanır
namespace Ogrenci_Otomasyon_Sistemi
{
    // Form1 sınıfı, Windows Forms'un Form sınıfından türetilmektedir
    public partial class Form1 : Form
    {
        // Kullanıcı işlemleri için iş mantığı sınıfının örneği oluşturulacak değişken
        TblKullanicilarBLL _tblKullanicilarBLL;

        // Form1 yapıcı (constructor) metodu
        public Form1()
        {
            // Form bileşenlerini başlatır
            //Form üzerindeki buton, textbox vb. bileşenleri yükler.
            InitializeComponent();

            //Kullanıcı yönetimi için İş mantığı sınıfından nesne oluşturduk
            _tblKullanicilarBLL = new TblKullanicilarBLL();
        }

        // Giriş butonuna tıklandığında çalışacak metodumuz
        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcı bilgilerini saklayacak bir nesne oluşturduk
            TblKullanicilarPoco _tblKullanicilarPoco = new TblKullanicilarPoco();

            // Kullanıcı adı ve şifre ile veritabanı sorgusu yapılır
            _tblKullanicilarPoco = _tblKullanicilarBLL.getSorgu(txtKullaniciAdi.Text, txtSifre.Text);

            // Eğer kullanıcı adı veya şifre boşsa
            if ((_tblKullanicilarPoco.kullaniciAdi == null) || (_tblKullanicilarPoco.sifre == null))
            {
                // Kullanıcıya hata mesajı gösterilir
                MessageBox.Show("Kullanici Adi veya Şifre Hatalı", "Hata Mesajı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            // Eğer giriş başarılıysa
            else
            {
                // Kullanıcıya başarılı giriş yaptığını mesajı ile göster
                MessageBox.Show("Sisteme Giriş Başarılı", "Mesaj", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                // Mevcut formu gizle
                this.Hide();
                // Ana menü formunu oluştur
                AnaMenu girisEkrani = new AnaMenu();

                // Ana menü formunu aç
                girisEkrani.Show();
            }
        }
    }
}
