// Gerekli kütüphaneleri içe aktarır
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

// Öğrenci Otomasyon Sistemi bileşenlerinden bize lazım olanları içe aktarıyoruz
using Ogrenci_Otomasyon_Sistemi.DataAccessObjects; // DataAccessObjects katmanını içeri aktarır
using Ogrenci_Otomasyon_Sistemi.PocosLayer; // POCO (Plain Old CLR Object) katmanını içeri aktarır

// İş mantığı katmanını tanımlar
namespace Ogrenci_Otomasyon_Sistemi.BusinessLogicLayer
{
    // Kullanıcılar için iş mantığı sınıfı
    internal class TblKullanicilarBLL
    {
        // Veritabanı ile iletişim kuracak olan DAO sınıfının örneği oluşturulacak değişken
        private TblKullanicilarDAO _tblKullanicilarDAO;

        // Kurucu metot(constructor), sınıfın bir nesnesi oluşturulduğunda çalışır
        public TblKullanicilarBLL()
        {
            // DAO nesnesi oluşturduk
            _tblKullanicilarDAO = new TblKullanicilarDAO();
        }

        //Kullanıcıdan alınan Kullanıcı adı ve şifreye göre sorgu yap
        public TblKullanicilarPoco getSorgu(string kullaniciAdi, string sifre)
        {
            // Kullanıcı giriş bilgilerini saklamak için bir POCO nesnesi oluşturuyoruz
            TblKullanicilarPoco kullaniciGirisi = new TblKullanicilarPoco();

            // Veritabanından gelen verileri saklayacak bir DataTable nesnesi oluşturuyoruz
            DataTable dataTable = new DataTable();

            // DAO sınıfını kullanarak veritabanında sorgu yapalım
            //SearchKullaniciAdiveSifre metodunun DATAACCESSOBJECTS (DAO) olduğunu unutmayın
            dataTable = _tblKullanicilarDAO.SearchKullaniciAdiveSifre(kullaniciAdi, sifre);

            // DataTable içindeki satırlarda gezelim ve kullanıcı bilgilerini alalım
            foreach (DataRow dr in dataTable.Rows)
            {
                // Kullanıcı adı ve şifre bilgileri POCO nesnesine atanır
                kullaniciGirisi.kullaniciAdi = dr["kullaniciAdi"].ToString();
                kullaniciGirisi.sifre = dr["sifre"].ToString();
            }

            // POCO nesnesi geri döndürülür
            return kullaniciGirisi;
        }
    }
}
