using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Kullanıcı arayüzü katmanı (Presentation Layer) içindeki formları kullanmak için gereklidir
using Ogrenci_Otomasyon_Sistemi.PresentationLayer;

// Kullanıcı ile ilgili formların bulunduğu namespace
namespace Ogrenci_Otomasyon_Sistemi.PresentationLayer.Kullanici
{
    // Kullanıcı yeni kayıt ekranını temsil eden form sınıfı
    public partial class KullaniciYeniKayit : Form
    {
        // Kurucu metot (Constructor) - Form oluşturulduğunda çağrılır
        public KullaniciYeniKayit()
        {
            // Form bileşenlerini başlatır
            //Form elemanlarını başlatan metottur. (Örn: Buton, TextBox vb.)
            InitializeComponent(); 
        }

        // Ana Menü butonuna tıklandığında çalışan olay metodu
        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            // Ana Menü formunu oluşturur
            AnaMenu girisEkrani = new AnaMenu();

            // Ana Menü formunu açar
            girisEkrani.Show();

            // Mevcut formu kapatır
            this.Close();
        }
    }
}
