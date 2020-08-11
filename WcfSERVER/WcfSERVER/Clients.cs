using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace WcfSERVER
{
    public class Clients
    {
        static public void Add(Client client)
        {
        
            string sqlExpression = @"INSERT INTO Client (FIO, Mail,dateRegistration,Addr,Pass, FlagDelete)" + "VALUES (@fio, @mail,@dateReg,@addr,@pass, @del)";

            SqlCommand commm = baseDB.PrepareRequest(sqlExpression);
            commm.Parameters.AddWithValue("@fio", client.FIO);
            commm.Parameters.AddWithValue("@mail", client.mail);
            commm.Parameters.AddWithValue("@del", client.Deleted);
            commm.Parameters.AddWithValue("@dataReg", client.dateRegistration);
            commm.Parameters.AddWithValue("@addr", client.address);
            commm.Parameters.AddWithValue("@pass", client.password);
            DataTable dt = baseDB.ExecutePrepared();
           
        }
       
                              

        public static void Update(Client client)
        {
            
            string sqlExpression = @"INSERT INTO Clients (FIO, Mail,dateRegistration,Addr,Pass, FlagDelete,ID)" + "VALUES (@fio, @mail,@dateReg,@addr,@pass, @del,@ID)";

            SqlCommand commm = baseDB.PrepareRequest(sqlExpression);
            commm.Parameters.AddWithValue("@fio", client.FIO);
            commm.Parameters.AddWithValue("@mail", client.mail);
            commm.Parameters.AddWithValue("@del", client.Deleted);
            commm.Parameters.AddWithValue("@dataReg", client.dateRegistration);
            commm.Parameters.AddWithValue("@addr", client.address);
            commm.Parameters.AddWithValue("@pass", client.password);
            DataTable dt = baseDB.ExecutePrepared();

        }
        public static void Delete(int ID)
        {
            string sqlExpression = @"DELETE FROM Clients WHERE (ID)" + "VALUES(@ID)"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sqlExpression);
        }
       
        
       
        
      
        public static int Count()
        {
            string sql = "SELECT * FROM Clients"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            return myData.Count();

        }

    }
}