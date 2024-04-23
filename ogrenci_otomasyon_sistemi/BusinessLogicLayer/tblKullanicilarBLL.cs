using System;
using System.Data;
using ogrenci_otomasyon_sistemi.DataAccessObjectLayer;
using ogrenci_otomasyon_sistemi.PocosLayer;

namespace ogrenci_otomasyon_sistemi.BusinessLogicLayer
{
    public class tblKullanicilarBLL
    {
        //Poco Layer ım hazır, DAO kısmımda hazır.VT bağlantı kısmımda hazır. 
        //Artık sorgularımızı gönderebileceğimiz ve parametrelerimi ayaklandırabileceğimiz katmanımızı kodlayabiliriz. Yani Mantıksal İş Katmanını yazacağız
        //Burada aldığımız bilgileri göndereceğimiz yada gönderdiği bilgileri alacağım Poco katmanını eklememiz gerekiyor

        private tblKullanicilarDAO _tblKullanicilarDAO;
        
        public tblKullanicilarBLL() //constructor method
        {
            _tblKullanicilarDAO = new tblKullanicilarDAO();
        }
        public tblKullanicilarPoco getSorgu(string kullaniciAdi, string sifre)  
            //Kullanici giris ekrani icin tasarlanmis bir metoddur. VT gidip girdiğimiz kullanıcı adı ve sifremizi VT da sorguluyor
        {
            tblKullanicilarPoco kullaniciGirisi = new tblKullanicilarPoco();
           
            DataTable dataTable = new DataTable();

            dataTable = _tblKullanicilarDAO.searchKullaniciAdiveSifre(kullaniciAdi, sifre); 

            foreach (DataRow dr in dataTable.Rows)
            {
                kullaniciGirisi.kullaniciAdi = dr["kullaniciadi"].ToString();
                kullaniciGirisi.sifre = dr["sifre"].ToString();
            }

            return kullaniciGirisi;
        }
    }
}