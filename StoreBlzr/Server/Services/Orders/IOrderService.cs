using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Orders
{
    public interface IOrderService
    {
         Task<List<Order>> GetAll();
         Task<Order> Get(string id);
         Task<Order> Post(Order Order);
         Task<Order> Put(Order Order);
         Task<Order> Delete(string id);

    }
}