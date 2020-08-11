using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{
    [ServiceContract]
    public interface IServices
    {
        [OperationContract] 
        void AddService(Service service);
        [OperationContract]
        void UpdateService(Service service);
        [OperationContract]
        void DeleteService(int id);
       
        [OperationContract]
        List<Service> GetServices();
        [OperationContract]
        Service GetServiceByID(int id);
        [OperationContract]
        int CountServices();
    }
}

