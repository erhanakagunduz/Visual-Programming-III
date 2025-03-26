// Gerekli kütüphaneleri içe aktarır
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// POCO (Plain Old CLR Object) sınıflarının bulunduğu namespace
namespace Ogrenci_Otomasyon_Sistemi.PocosLayer
{
    // Kullanıcı bilgilerini temsil eden POCO sınıfı
    internal class TblKullanicilarPoco
    {
        // Kullanıcı bilgilerini saklayan özel değişkenler (Encapsulation - Kapsülleme uygulayalım)
        private string _kullaniciID { get; set; }
        private string _tcKimlik { get; set; }
        private string _kullaniciAdi { get; set; }
        private string _sifre { get; set; }
        private string _ad { get; set; }
        private string _soyad { get; set; }
        private string _birimID { get; set; }

        // Varsayılan kurucu metot (constructor)
        public TblKullanicilarPoco()
        {
            //lazım olursa burayı doldururuz
        }

        // Kullanıcı ID özelliği
        // get: Değeri okumaya yarar
        // set: Değeri değiştirmeye yarar
        public string kullaniciID
        {
            get
            {
                return _kullaniciID; // Değeri döndürür
            }
            set
            {
                _kullaniciID = value; // Yeni değer atar
            }
        }

        // TC Kimlik Numarası özelliği
        public string tcKimlik
        {
            get
            {
                return _tcKimlik;
            }
            set
            {
                _tcKimlik = value;
            }
        }

        // Kullanıcı Adı özelliği
        public string kullaniciAdi
        {
            get
            {
                return _kullaniciAdi;
            }
            set
            {
                _kullaniciAdi = value;
            }
        }

        // Şifre özelliği
        public string sifre
        {
            get
            {
                return _sifre;
            }
            set
            {
                _sifre = value;
            }
        }

        // Ad (isim) özelliği
        public string ad
        {
            get
            {
                return _ad;
            }
            set
            {
                _ad = value;
            }
        }

        // Soyad özelliği
        public string soyad
        {
            get
            {
                return _soyad;
            }
            set
            {
                _soyad = value;
            }
        }

        // Birim ID özelliği
        public string birimId
        {
            get
            {
                return _birimID;
            }
            set
            {
                _birimID = value;
            }
        }
    }
}
