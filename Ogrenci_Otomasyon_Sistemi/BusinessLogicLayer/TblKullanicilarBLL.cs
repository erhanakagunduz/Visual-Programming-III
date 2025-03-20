using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Ogrenci_Otomasyon_Sistemi.DataAccessObjects;
using Ogrenci_Otomasyon_Sistemi.PocosLayer;




namespace Ogrenci_Otomasyon_Sistemi.BusinessLogicLayer
{
    internal class TblKullanicilarBLL
    {
        private TblKullanicilarDAO _tblKullanicilarDAO;

        //Kurucu Metot
        public TblKullanicilarBLL() 
        {
            _tblKullanicilarDAO = new TblKullanicilarDAO();
        }


        public TblKullanicilarPoco getSorgu(string kullaniciAdi, string sifre)
        {
            TblKullanicilarPoco kullaniciGirisi = new TblKullanicilarPoco();
            
            DataTable dataTable = new DataTable();

            dataTable = _tblKullanicilarDAO.SearchKullaniciAdiveSifre(kullaniciAdi, sifre);

            foreach (DataRow dr in dataTable.Rows)
            {
                kullaniciGirisi.kullaniciAdi = dr["kullaniciAdi"].ToString();
                kullaniciGirisi.sifre = dr["sifre"].ToString() ;
            }

            return kullaniciGirisi;

        }

    }
}
