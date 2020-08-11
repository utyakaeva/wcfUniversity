using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Data.SqlClient;

namespace WcfSERVER
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int ID;
        [DataMember]
        public Client client;
        [DataMember]
        public Worker worker;
        [DataMember]
        public List<Service> services;
        [DataMember]
        public string Comment;
        [DataMember]
        public string StartDate;
        [DataMember]
        public string DateLastUpdate;
        [DataMember]
        public string EndDate;
        [DataMember]
        public double Cost;
        [DataMember]
        public string Status;
        [DataMember]
        public bool Deleted;

        public Order()
        {
        }

        public Order(int id, Client cl, Worker emp, List<Service> services, string comment, string StartDate, string DateLastUpdate, string enddate, double cost,string status, bool del)
        {
            this.ID = id;
            this.services = services;
            this.client = cl;
            this.worker = emp;
            this.Comment = comment;
            this.StartDate = StartDate;
            this.DateLastUpdate = DateLastUpdate;
            this.EndDate = enddate;
            this.Status = status;
            this.Cost = cost;
            this.Deleted = del;
        }
    }
    class Orders
    {
        static public void Add(Order order)
        {
            string sql = System.String.Format("INSERT INTO Orders SET CLIENT_ID={0},WORKER_ID={1}, COMMENT=@comment,COST=@cost,DATE='{2}',DATELASTUP = '{3}',END_DATE='{4}',STATUS = '{5}'", order.client.ID, order.worker.ID, order.StartDate, order.DateLastUpdate, order.EndDate,order.Cost,order.Status); // Строка запроса
            SqlCommand comm = baseDB.PrepareRequest(sql);
            comm.Parameters.AddWithValue("@cost", order.Cost);
            comm.Parameters.AddWithValue("@comment", order.Comment);
            System.Data.DataTable dt = baseDB.ExecutePrepared();
           int orderID = baseDB.LastInsertedID();
            foreach (Service serv in order.services)
            {
                sql = System.String.Format("INSERT INTO Services_in_Orders SET ORDER_ID={0} ,SERVICE_ID={1}", orderID, serv.ID); // Строка запроса
                dt = baseDB.SendRequest(sql);
            }
        }
        public static void Update(Order order)
        {


            string sql = System.String.Format("UPDATE  Orders SET CLIENT_ID={0},WORKER_ID={1}, COMMENT=@comment,COST=@cost,DATE='{2}',DATELASTUP = '{3}',END_DATE='{4}',STATUS = '{5}'", order.client.ID, order.worker.ID, order.StartDate, order.DateLastUpdate, order.EndDate, order.Cost, order.Status); // Строка запроса
            SqlCommand comm = baseDB.PrepareRequest(sql);
            comm.Parameters.AddWithValue("@cost", order.Cost);
            comm.Parameters.AddWithValue("@comment", order.Comment);
            System.Data.DataTable dt = baseDB.ExecutePrepared();
            sql = System.String.Format("DELETE FROM Services_in_Orders WHERE ORDER_ID={0}", order.ID); // Строка запроса
            dt = baseDB.SendRequest(sql);
            foreach (Service serv in order.services)
            {
                sql = System.String.Format("INSERT INTO Services_in_Orders SET ORDER_ID={0} ,SERVICE_ID={1}", order.ID, serv.ID); // Строка запроса
                dt = baseDB.SendRequest(sql);
            }
        }
        public static void Delete(int ID)
        {

            string sql = System.String.Format("UPDATE Orders SET DEL='true' WHERE ID={0}", ID); // Строка запроса
            System.Data.DataTable dt = baseDB.SendRequest(sql);
        }
       
       
        public static int Count()
        {
            string sql = "SELECT * FROM Orders"; // Строка запроса
            System.Data.DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            return myData.Count();
        }
        
        }
    }

