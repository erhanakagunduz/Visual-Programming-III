using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Veri tabanı işlemleri için kütüphaneler
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

// Veri tabanı bağlantısını içeren namespace
namespace Ogrenci_Otomasyon_Sistemi.dbConn
{
    // Veri tabanı bağlantısını ve sorgu işlemlerini yönettiğimiz sınıf
    internal class VeriTabaniBaglantisi
    {
        // SQL veri adaptörü
        public SqlDataAdapter dataAdapter;

        // SQL bağlantı nesnesi
        public SqlConnection baglanti;

        // Kurucu Metot (Constructor), bağlantıyı ve adaptörü başlatır
        public VeriTabaniBaglantisi()
        {
            //SQL Data Adapter nesnesini oluşturduk
            dataAdapter = new SqlDataAdapter();

            // SQL bağlantı dizesi, veri tabanına bağlanmak için gerekli bilgileri buraya yazalım
            //VT adı, kullanıcı adı, şifre gibi bilgileri kendi bilgisayarındaki
            //SSMS daki bilgilerden almalısınız
            baglanti = new SqlConnection(@"Server=FURKAN\SQLEXPRESS;Database=OgrenciOtomasyonu;User ID=sa;Password=1;TrustServerCertificate=True;");

        }

        // Veri tabanı bağlantısını açtığımız metodumuz
        private SqlConnection openConnection()
        {
            // VT bağlantımızın kapalı veya kopmuş olması ihtimaline karşın yapılacak işlem
            if (baglanti.State == ConnectionState.Closed || baglanti.State == ConnectionState.Broken)
            {
                baglanti.Open(); //VT bağlantımızı açıyoruz
            }
            // Açılan bağlantıyı talep edilen yere döndürüyoruz
            return baglanti;
        }

        // SELECT sorgusunu çalıştırmak ve sonuçları bir DataTable olarak döndürmek için
        public DataTable executeSelectQuery(string _query, SqlParameter[] sqlParameter)
        {
            // SQL komut nesnesi oluşturduk
            SqlCommand myCommand = new SqlCommand();

            // SQL sorgusundan dönen verileri geçici olarak saklamak için DataTable oluşturduk
            DataTable dataTable = new DataTable();
            
            // Birden fazla tablo içerebilecek bir veri kümesi (DataSet) oluşturduk
            DataSet ds = new DataSet();

            try
            {
                // SQL komutunun hangi veritabanı bağlantısını kullanacağını belirtiyoruz
                myCommand.Connection = openConnection();

                // SQL komutunun içeriğini belirtiyoruz (hangi sorgunun çalıştırılacağını yazıyoruz)
                myCommand.CommandText = _query;

                // SQL sorgusunda kullanılan parametreleri ekliyoruz (güvenliği de artırır)
                myCommand.Parameters.AddRange(sqlParameter);

                // SQL komutunu çalıştırıyoruz (veri ekleme, güncelleme veya silme işlemleri için)
                myCommand.ExecuteNonQuery();


                // SQL komutunu veri adaptörüne atar, çalıştırılacak sorguyu belirler
                dataAdapter.SelectCommand = myCommand;

                // Veri adaptörü, SQL sorgusunu çalıştırır ve dönen verileri DataSet'e ekler
                dataAdapter.Fill(ds);

                // DataSet içindeki ilk tabloyu (0. index) alarak DataTable nesnesine atadık
                dataTable = ds.Tables[0];

            }
            catch (SqlException e)
            {
                // Hata durumunda mesaj kutusunda hata gösterilir
                MessageBox.Show("Hata: " + e);
            }
            // DataTable'ı döndür
            return dataTable;
        }

        // INSERT (Veri ekleme) sorgusunu çalıştırır
        public bool executeInsertQuery(string _query, SqlParameter[] sqlParameter)
        {
            // SQL komut nesnesi oluşturulur
            SqlCommand myCommand = new SqlCommand();
            try
            {
                // Bağlantıyı aç ve sorguyu ata
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Hata mesajını gösterir
                MessageBox.Show("Hata: " + e);
                return false;
            }
            // İşlem başarılıysa true döndür
            return true;
        }

        // UPDATE (Veri güncelleme) sorgusunu çalıştırır
        public bool executeUpdateQuery(string _query, SqlParameter[] sqlParameter)
        {
            // SQL komut nesnesi oluşturulur
            SqlCommand myCommand = new SqlCommand();
            try
            {
                // Bağlantıyı aç ve sorguyu ata
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Hata mesajını gösterir
                MessageBox.Show("Hata: " + e);
                return false;
            }
            // İşlem başarılıysa true döndür
            return true;
        }

        // DELETE (Veri silme) sorgusunu çalıştırır
        public bool executeDeleteQuery(string _query, SqlParameter[] sqlParameter)
        {
            // SQL komut nesnesi oluşturulur
            SqlCommand myCommand = new SqlCommand();
            try
            {
                // Bağlantıyı aç ve sorguyu ata
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Hata mesajını gösterir
                MessageBox.Show("Hata: " + e);
                return false;
            }
            // İşlem başarılıysa true döndür
            return true;
        }
    }
}
