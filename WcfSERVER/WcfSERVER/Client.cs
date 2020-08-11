using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{

    [DataContract]
    public class Client
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string FIO;
        [DataMember]
        public string mail;
        [DataMember]
        public string dateRegistration;
        [DataMember]
        public string address;
        [DataMember]
        public string password;
        [DataMember]
        public string Deleted;

        public Client(int ID, string FIO, string mail, string dateRegistration, string address, string password, string del)
        {
            this.ID = ID;
            this.FIO = FIO;
            this.mail = mail;
            this.dateRegistration = dateRegistration;
            this.address = address;
            this.password = password;
            this.Deleted = del;
        }
    }
}
