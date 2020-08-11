using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfSERVER
{
    [ServiceContract]
    public interface IWorkers
    {
        [OperationContract]
        void AddWorker(Worker worker);
        [OperationContract]
        void UpdateWorker(Worker worker);
        [OperationContract]
        void DeleteWorker(int id);
        [OperationContract]
        List<Worker> GetWorkers(int page, int count);
        [OperationContract]
        List<Worker> GetWorkersByFIO(string FIO);
        [OperationContract]
        Worker GetWorkerByID(int ID);
        [OperationContract]
        int CountWorkers();
      

    }
}
