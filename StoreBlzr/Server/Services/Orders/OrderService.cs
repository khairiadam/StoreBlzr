using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Services;
using StoreBlzr.Server.Data;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Orders
{
    public class OrderService : IOrderService
    {

        private readonly StoreDbContext _db;
        public OrderService(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(string id)
        {
            var supOrder = await _db.Orders.FindAsync(id);
            if (supOrder is null) return false;
            _db.Orders.Remove(supOrder);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Get(string id)
        {
            var find = await _db.Orders.FindAsync(id);
            return find;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders.ToListAsync();

        }

        public async Task<bool> Post(Order order)
        {
            if (order == null) return false;
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            if (result < 0) return false;
            return true;
        }
    }
}