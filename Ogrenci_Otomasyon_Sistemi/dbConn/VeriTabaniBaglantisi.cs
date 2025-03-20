using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Ogrenci_Otomasyon_Sistemi.dbConn
{
    internal class VeriTabaniBaglantisi
    {

        private SqlDataAdapter dataAdapter;

        private SqlConnection baglanti;

        //Kurucu Metot
        public VeriTabaniBaglantisi()
        {
            dataAdapter = new SqlDataAdapter();

            baglanti = new SqlConnection(@"Data Source=FURKAN\SQLEXPRESS;Initial Catalog=OgrenciOtomasyonu;Persist Security Info=True;User ID=sa;Password=***********;Encrypt=False;Trust Server Certificate=True");
        }

        private SqlConnection openConnection()
        {

            if (baglanti.State == ConnectionState.Closed || baglanti.State == ConnectionState.Broken)
            {
                baglanti.Open();
            }


            return baglanti;
        }


        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
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

                dataAdapter.SelectCommand = myCommand;
                dataAdapter.Fill(ds);
                dataTable = ds.Tables[0];

            }
            catch (SqlException e)
            {
                MessageBox.Show("Hata: " + e); 
            }

            return dataTable;
        }

        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                MessageBox.Show("Hata: " + e);

                return false;
            }

            return true;
        }

        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Hata: " + e);

                return false;
            }

            return true;

        }

        public bool executeDeleteQury(String _query, SqlParameter[] sqlParameter)
        { 
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Hata: " + e);

                return false;
            }

            return true;
        }
    }
}
