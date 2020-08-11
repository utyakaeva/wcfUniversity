using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using WcfSERVER;

namespace WcfSERVER
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class main : IClients, IServices, IWorkers, IOrders
    {
       

        //КЛИЕНТЫ
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void UpdateClient(Client client)
        {
            Clients.Update(client);
        }

        public void DeleteClient(int id)
        {
            Clients.Delete(id);
        }

        

       

        
        /*public Client CreateClient(int ID, string FIO, string phone, bool del)
        {
            return new Client(ID, FIO, phone, del);
        }*/
        public int CountClients()
        {
            return Clients.Count();
        }



        //УСЛУГИ
        public void AddService(Service service)
        {
            Services.Add(service);
        }

        public void UpdateService(Service service)
        {
            Services.Update(service);
        }

        public void DeleteService(int id)
        {
            Services.Delete(id);
        }


        public List<Service> GetServices()
        {
            return Services.GetServices();
        }

        public Service GetServiceByID(int id)
        {
            return Services.GetServiceByID(id);
        }
        public int CountServices()
        {
            return Services.Count();
        }

        //СОТРУДНИКИ
        public void AddWorker(Worker Worker)
        {
            Workers.Add(Worker);
        }

        public void UpdateWorker(Worker Worker)
        {
            Workers.Update(Worker);
        }

        public void DeleteWorker(int id)
        {
            Workers.Delete(id);
        }

        public List<Worker> GetWorkers(int page, int count)
        {
            return Workers.GetWorkers(page, count);
        }

        public List<Worker> GetWorkersByFIO(string FIO)
        {
            return Workers.GetWorkersByFIO(FIO);
        }
        
        public Worker GetWorkerByID(int ID)
        {
            return Workers.GetWorkerByID(ID);
        }
        public int CountWorkers()
        {
            return Workers.Count();
        }


        //ЗАКАЗЫ
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            Orders.Update(order);
        }

        public void DeleteOrder(int id)
        {
            Orders.Delete(id);
        }

       
        public int CountOrders()
        {
            return Orders.Count();
        }
        /* public Order CreateOrder(int id, Client cl, Employee emp, List<Service> services, string comment, string Date, double cost, bool del)
         {
             return new Order(id, cl, emp,services, comment,Date, cost,del);
         }*/
        public double CalcOrderCost(Order order)
        {
            double cost = 0;
            foreach (Service S in order.services)
            {
             //   cost = cost + S.cost;
            }
            return cost;
        }


     

        

      

      

        
    }
}
