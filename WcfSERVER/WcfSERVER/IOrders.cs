using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfSERVER;

namespace WcfSERVER
{
    [ServiceContract]
    public interface IOrders
    {
        [OperationContract]
        void AddOrder(Order order);
        [OperationContract]
        void UpdateOrder(Order order);
        [OperationContract]
        void DeleteOrder(int id);
        
        /* [OperationContract]
         Order CreateOrder(int id, Client cl, Employee emp,List<Service> services, string comment, string Date,double cost, bool del);*/
        [OperationContract]
        int CountOrders();
        
    }
}
