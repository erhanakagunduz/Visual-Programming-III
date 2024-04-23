using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ogrenci_otomasyon_sistemi.dbConn;

namespace ogrenci_otomasyon_sistemi.DataAccessObjectLayer
{
    public class tblKullanicilarDAO
    {
        private VeriTabaniBaglantisi baglanti;

        public tblKullanicilarDAO() //constructor method
        {
            baglanti = new VeriTabaniBaglantisi();
        }


        //bu method BLL katmanındaki DataTable veri gönderip ve ordan veri alıyor
        public DataTable searchKullaniciAdiveSifre(string kullaniciAdi, string sifre)
        {
            string sorgu = string.Format("Select * From tbl_kullanicilar Where KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre");
            //Kullanıcıdan gelen "kullaniciAdi" değeri sorgu daki @KullaniciAdi ile eşlemelidir
            //Kullanıcıdan gelen "sifre" değeri sorgu daki @Sifre ile eşlemelidir

            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@KullaniciAdi", SqlDbType.NChar);
            sqlParameters[0].Value = Convert.ToString(kullaniciAdi);

            sqlParameters[1] = new SqlParameter("@Sifre", SqlDbType.NChar);
            sqlParameters[1].Value = Convert.ToString(sifre);

            return baglanti.execute_select_query(sorgu, sqlParameters);
        }
    }
}
