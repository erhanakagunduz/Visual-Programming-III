using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Otomasyon_Sistemi.dbConn;

namespace Ogrenci_Otomasyon_Sistemi.DataAccessObjects
{
    internal class TblKullanicilarDAO
    {
        private VeriTabaniBaglantisi baglanti;

        //Yapıcı Methot
        public TblKullanicilarDAO() 
        { 
            baglanti = new VeriTabaniBaglantisi();
        }

        public DataTable SearchKullaniciAdiveSifre(string kullaniciAdi, string sifre)
        {
            string sorgu = string.Format("Select * From tbl_Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre");

            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@KullaniciAdi",SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(kullaniciAdi);

            sqlParameters[1] = new SqlParameter("@Sifre", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(sifre);

            return baglanti.executeSelectQuery(sorgu, sqlParameters);
        }
    }
}
