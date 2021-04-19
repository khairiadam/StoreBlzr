using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Services;
using StoreBlzr.Server.Data;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Orders
{
    public class OrderService : ITypeCrud<Order>
    {

        public Task<List<Type>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Post(Order Order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Put(Order Order)
        {
            throw new System.NotImplementedException();
        }
    }
}