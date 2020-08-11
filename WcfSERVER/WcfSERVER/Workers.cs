using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{
    [DataContract]
    public class Worker
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string FIO;
        [DataMember]
        public string gender;
        [DataMember]
        public string dateBirth;
        [DataMember]
        public string dateRegistration;
        [DataMember]
        public string direction;
        [DataMember]
        public string mail;
        [DataMember]
        public string password;
        public Worker()
        {

        }
        public Worker(int ID, string FIO, string gender, string dateBirth, string
            dateRegistration, string direction, string mail, string password)
        {
            this.ID = ID;
            this.FIO = FIO;
            this.gender = gender;
            this.dateBirth = dateBirth;
            this.dateRegistration = dateRegistration;
            this.direction = direction;
            this.mail = mail;
            this.password = password;
        }
    }

    public class Workers
    {
        static public void Add(Worker emp)
        {
            string[] fio = emp.FIO.Split(' ');
            string sql = System.String.Format("INSERT INTO Workers SET FIRST_NAME='{0}' ,MID_NAME='{1}',LAST_NAME='{2}',GENDER='{3}',DATEBIRTH='{4}',DATEREG = '{5}',DIRECTION='{6}'," +
                "MAIL='{5}',PASSWORRD = '{6}'", fio[1], fio[2], fio[0], emp.gender, emp.dateBirth, emp.dateRegistration,emp.direction,emp.mail,emp.password); // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
        }
        public static void Update(Worker emp)
        {
            string[] fio = emp.FIO.Split(' ');
            string sql = "";
            if (emp.dateRegistration == null || emp.dateRegistration == "")
                sql = System.String.Format("UPDATE  Workers SET FIRST_NAME='{0}' ,MID_NAME='{1}',LAST_NAME='{2}',GENDER='{3}',DATEBIRTH='{4}',DATEREG = '{5}',DIRECTION='{6}'," +
                "MAIL='{5}',PASSWORRD = '{6}'", fio[1], fio[2], fio[0], emp.gender, emp.dateBirth, emp.dateRegistration, emp.direction, emp.mail, emp.password, emp.ID); // Строка запроса
            else
                sql = System.String.Format("UPDATE Workers SET FIRST_NAME='{0}' ,MID_NAME='{1}',LAST_NAME='{2}',GENDER='{3}',DATEBIRTH='{4}',DATEREG = '{5}',DIRECTION='{6}'," +
                "MAIL='{5}',PASSWORRD = '{6}'", fio[1], fio[2], fio[0], emp.gender, emp.dateBirth, emp.dateRegistration, emp.direction, emp.mail, emp.password, emp.ID); // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
        }

      
        public static void Delete(int ID)
        {

            string sql = System.String.Format("UPDATE Workers SET DATEREG='{0}' WHERE ID={1}", DateTime.Today.ToString("yyyy-MM-dd"), ID); // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
        }
        public static List<Worker> GetWorkers(int page, int count)
        {
            List<Worker> list = new List<Worker>();

            int startID = count * (page - 1);

            string sql = "SELECT * FROM Workers where ISNULL(DATEREG)LIMIT " + startID.ToString() + "," + count.ToString(); ; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                Worker emp = new Worker(Convert.ToInt32(myData[i].ItemArray[0]), myData[i].ItemArray[1].ToString(), myData[i].ItemArray[2].ToString(), myData[i].ItemArray[3].ToString(), myData[i].ItemArray[4].ToString(), myData[i].ItemArray[5].ToString(), myData[i].ItemArray[6].ToString(), myData[i].ItemArray[7].ToString());
                list.Add(emp);
            }
            return list;
        }
        public static List<Worker> GetWorkersByFIO(string FIO)
        {
            List<Worker> list = new List<Worker>();
            string sql = "SELECT * FROM Workers"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);

            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                FIO = FIO.ToLower().Trim();
                string clFIO = myData[i].ItemArray[3].ToString() + " " + myData[i].ItemArray[1].ToString() + " " + myData[i].ItemArray[2].ToString();
                clFIO = clFIO.ToLower().Trim();
                if (clFIO.Contains(FIO))
                {
                    Worker emp = new Worker(Convert.ToInt32(myData[i].ItemArray[0]), myData[i].ItemArray[1].ToString(), myData[i].ItemArray[2].ToString(), myData[i].ItemArray[3].ToString(), myData[i].ItemArray[4].ToString(), myData[i].ItemArray[5].ToString(), myData[i].ItemArray[6].ToString(), myData[i].ItemArray[7].ToString());
                    list.Add(emp);
                }
            }
            return list;
        }
        public static Worker GetWorkerByID(int ID)
        {

            string sql = "SELECT * FROM Workers where ID=" + ID.ToString(); // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            Worker emp = new Worker(Convert.ToInt32(myData[0].ItemArray[0]), myData[0].ItemArray[1].ToString(), myData[0].ItemArray[2].ToString(), myData[0].ItemArray[3].ToString(), myData[0].ItemArray[4].ToString(), myData[0].ItemArray[5].ToString(), myData[0].ItemArray[6].ToString(), myData[0].ItemArray[7].ToString());
            return emp;
        }
        public static int Count()
        {
            string sql = "SELECT * FROM Workers"; // Строка запроса
            DataTable dt = baseDB.SendRequest(sql);
            var myData = dt.Select();
            return myData.Count();
        }

      
    }
}