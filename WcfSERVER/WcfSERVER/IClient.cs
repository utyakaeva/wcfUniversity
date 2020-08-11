using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{
    [ServiceContract]
    public interface IClients
    {
        [OperationContract]
        void AddClient(Client client);
        [OperationContract]
        void UpdateClient(Client client);
        [OperationContract]
        void DeleteClient(int id);
        [OperationContract]
       
        
        /*[OperationContract]
        Client CreateClient(int ID, string FIO, string phone, bool del);*/
        
        int CountClients();
    }
}

