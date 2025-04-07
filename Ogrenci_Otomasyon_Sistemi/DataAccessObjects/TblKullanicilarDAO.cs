// Gerekli kütüphaneleri içe aktarır
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Veri tabanı işlemleri için kütüphaneler
using System.Data;
using System.Data.SqlClient;

// Öğrenci Otomasyon Sistemi bileşenlerinden bize lazım olanları içe aktarıyoruz
using Ogrenci_Otomasyon_Sistemi.dbConn; // Veritabanı bağlantı sınıfını içe aktarır

// Veri erişim katmanını tanımlar
namespace Ogrenci_Otomasyon_Sistemi.DataAccessObjects
{
    // Kullanıcılarla ilgili veritabanı işlemlerini gerçekleştiren sınıf
    internal class TblKullanicilarDAO
    {
        // Veritabanı bağlantısını yönetecek nesneyi sınıfının örneği oluşturulacak değişken
        private VeriTabaniBaglantisi baglanti;

        // Kurucu metot (Constructor), sınıf çağrıldığında otomatik çalışır
        public TblKullanicilarDAO()
        {
            // Veritabanı bağlantısı için nesnemizi oluşturup - başlattık
            baglanti = new VeriTabaniBaglantisi();
        }

        // Kullanıcı adı ve şifreye göre veritabanında arama yaptığımız metot
        public DataTable SearchKullaniciAdiveSifre(string kullaniciAdi, string sifre)
        {
            // SQL sorgusunu oluşturur (Kullanıcı adı ve şifreye göre filtreleme işlemi yapar)
            string sorgu = string.Format("SELECT * FROM tbl_Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre");

            // Parametre dizisi oluşturalım (SQL Injection saldırılarını önlemek için)
            SqlParameter[] sqlParameters = new SqlParameter[2];

            // Kullanıcı adı parametresi tanımladık ve değerini atadık
            sqlParameters[0] = new SqlParameter("@KullaniciAdi", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(kullaniciAdi);

            // Şifre parametresi tanımladık ve değerini atadık
            sqlParameters[1] = new SqlParameter("@Sifre", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(sifre);

            // Veritabanı bağlantı sınıfını kullanarak sorguyu çalıştıralım ve sonucu çağrılan yere döndürelim
            return baglanti.executeSelectQuery(sorgu, sqlParameters);
        }

        public bool insertKullanicilar(string kullaniciid, string tckimlik, string kullaniciadi, string sifre, string ad, string soyad, string birimId)
        {
            string sorgu = string.Format("INSERT INTO tbl_kullanicilar(KullaniciId, TcKimlik, KullaniciAdi, Sifre, Ad, Soyad, BirimID) VALUES(@kullaniciid,@tckimlik,@kullaniciadi,@sifre,@ad, @soyad, @birimId)");

            SqlParameter[] sqlParameters = new SqlParameter[7];

            sqlParameters[0] = new SqlParameter("@kullaniciid", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(kullaniciid);

            sqlParameters[1] = new SqlParameter("@tckimlik", SqlDbType.NVarChar);
            sqlParameters[1].Value= Convert.ToString(tckimlik);

            sqlParameters[2] = new SqlParameter("@kullaniciadi", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(kullaniciadi);

            sqlParameters[3] = new SqlParameter("@sifre", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(sifre);

            sqlParameters[4] = new SqlParameter("@ad", SqlDbType.NVarChar);
            sqlParameters[4].Value = Convert.ToString(ad);

            sqlParameters[5] = new SqlParameter("@soyad", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(soyad);

            sqlParameters[6] = new SqlParameter("@birimId", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(birimId);

            return baglanti.executeInsertQuery(sorgu, sqlParameters);


        }
    }
}
