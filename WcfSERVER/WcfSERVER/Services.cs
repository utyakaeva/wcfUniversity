
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{
    [DataContract]
    public class Service
    {

        [DataMember]
        public int ID;
        [DataMember]
        public string name;
        [DataMember]
        public double cost;
        [DataMember]
        public string del;

        


       public Service(int id, string name, double cost, string del)
       {
           this.ID = id;
           this.name = name;
           this.cost = cost;
           this.del = del;
       }
    }
  
   
    public class Services 
    {
        static public void Add(Service service)
        {
           
            string sqlExpression =@"INSERT INTO Services (Imya, Cost, FlagDelete)" + "VALUES (@name, @cost, @del)";
          
              SqlCommand commm = baseDB.PrepareRequest(sqlExpression);
              commm.Parameters.AddWithValue("@cost", service.cost);
              commm.Parameters.AddWithValue("@name", service.name);
              commm.Parameters.AddWithValue("@del", service.del);
              DataTable dt = baseDB.ExecutePrepared();
        }
        public static void Update(Service service)
        {
            
            string sqlExpression = @"UPDATE INTO Services (Imya, Cost, FlagDelete)" + "VALUES (@name, @cost, @del)";

           
              SqlCommand comm = baseDB.PrepareRequest(sqlExpression);
              comm.Parameters.AddWithValue("@cost", service.cost);
              comm.Parameters.AddWithValue("@name", service.name);
              DataTable dt = baseDB.ExecutePrepared();
        }
        public static void Delete(int ID)
        {
          
            string sqlExpression = @"DELETE FROM Services WHERE (ID)"+"VALUES(@ID)";

           
            DataTable dt = baseDB.SendRequest(sqlExpression);
        }
        

        public static List<Service> GetServices()
        {

            List<Service> list = new List<Service>();
            string sql = "SELECT * from Services"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                Service serv = new Service(Convert.ToInt32(myData[i].ItemArray[0]), myData[i].ItemArray[1].ToString(), Convert.ToDouble(myData[i].ItemArray[2]), myData[i].ItemArray[3].ToString());
              list.Add(serv);
            }
            return list;
        }
        public static List<Service> GetServicesForOrder(int ID)
        {
            List<Service> list = new List<Service>();
            string sql = "Select * from Services_in_Orders where  ORDER_ID=" + ID; ; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                Service serv = Services.GetServiceByID(Convert.ToInt32(myData[i].ItemArray[2]));
                list.Add(serv);
            }
            return list;
        }
        public static Service GetServiceByID(int ID)
        {
            string sql = "SELECT * FROM Services where ID=" + ID.ToString(); // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            Service serv = new Service(Convert.ToInt32(myData[0].ItemArray[0]), myData[0].ItemArray[1].ToString(), Convert.ToDouble(myData[0].ItemArray[2]), myData[0].ItemArray[3].ToString());
            return serv;
        }
        public static int Count()
        {
            string sql = "SELECT * FROM Services"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            return myData.Count();
        }
    }

}
