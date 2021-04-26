using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Orders
{
    public interface IOrderService
    {
         Task<List<Order>> GetAll();
         Task<Order> Get(string id);
         Task<bool> Post(Order Order);
         Task<bool> Put(Order Order);
         Task<bool> Delete(string id);

    }
}