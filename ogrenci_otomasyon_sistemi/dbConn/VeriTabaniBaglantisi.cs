using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ogrenci_otomasyon_sistemi.dbConn
{
    public class VeriTabaniBaglantisi
    {
        string baglanti_yolu = "Data Source = DESKTOP-5PGN9UA\\SQLEXPRESS; Initial Catalog = OgrenciOtomasyonu; Integrated Security = True;";

        privete SqlDataAdapter dataAdapter;

        private SqlConnection baglanti;

        public void sqlbaglan()
        {
            baglanti = new SqlConnection(baglanti_yolu);
        }

        //constructor (yapici) olusturalim
        public VeriTabaniBaglantisi()
        {
            dataAdapter = new SqlDataAdapter();
        }


        public SqlConnection openConnection()
        {
            //DB baglantisini acalim
            sqlbaglan();

            if (baglanti.State == ConnectionState.Closed || baglanti.State == ConnectionState.Broken )
            {
                baglanti.Open();
            }

            return baglanti;
        }

        public DataTable execute_select_query(string _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;

            DataSet ds = new DataSet();

            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();

                //Tablo islemleri
                dataAdapter.SelectCommand = myCommand;

                dataAdapter.Fill(ds);

                dataTable = ds.Tables[0];

            }
            catch (SqlException e)
            {
                Console.WriteLine("Hata : Connection.ExecuteSelectQuery - Query : " + _query + "\n Exception : " + e.StackTrace.ToString());
                return null; // cikis
            }

            return dataTable;

        }

        public bool execute_insert_query(string _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                dataAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Hata : Connection.ExecuteInsertQuery - Query : " + _query + "\n Exception : " + e.StackTrace.ToString());
                return false;
            }

            return true;

        }

        public bool execute_update_query(string _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();

            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                dataAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Hata : Connection.ExecuteUpdateQuery - Query : " + _query + "\n Exception : " + e.StackTrace.ToString());
                return false; 
            }

            return true;

        }


        public bool execute_delete_query(string _query)
        {
            SqlCommand myCommand = new SqlCommand();

            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                dataAdapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Hata : Connection.ExecuteDeleteQuery - Query : " + _query + "\n Exception : " + e.StackTrace.ToString());
                return false;
            }

            return true;

        }
    }
}
