using System;
using System.Data;
using System.Data.SqlClient;

namespace WcfSERVER
{
    public static class baseDB
    {
       
       public static string connStr = @"Data Source=DESKTOP-5HTO901\SQL_UTYA;
                            Initial Catalog=DATEBASEWCF;
                            Integrated Security=True";
       public static SqlConnection connection = new SqlConnection(connStr);
        
        static SqlCommand sqlCom;


        public static void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public static void CloseConnection()
        {
            connection.Close();
        }
        static public SqlCommand PrepareRequest(string sql)
        {
            sqlCom = new SqlCommand(sql, connection);
            return sqlCom;
        }
        static public DataTable SendRequest(string sql)
        {
            try
            {
                OpenConnection();
                sqlCom = new SqlCommand(sql, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCom);
                dataAdapter.Fill(dt);
                return dt;
            }
            catch
            {
                CloseConnection(); OpenConnection();
                string sqlD = "SELECT * FROM Services";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlD, connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }

        }
         static public int LastInsertedID()
           {
            return Convert.ToInt32(sqlCom.ExecuteScalar());
          }
        static public DataTable ExecutePrepared()
        {
            try
            {
                OpenConnection();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCom);
                dataAdapter.Fill(dt);
                return dt;
            }
            catch
            {
                CloseConnection(); OpenConnection();
                string sql = "SELECT * FROM Services";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            }
        }

       
    }
