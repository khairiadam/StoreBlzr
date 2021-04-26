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

        public async Task Delete(string id)
        {
            var supOrder = await _db.Orders.FindAsync(id);
             _db.Orders.Remove(supOrder);
            await _db.SaveChangesAsync();
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

        public async Task<Order> Post(Order type)
        {
            _db.Orders.Add(type);
            await _db.SaveChangesAsync();
            return type;

        }

        public async Task Put(Order type)
        {
            _db.Entry(type).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }

        Task<Order> IOrderService.Delete(string id)
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderService.Put(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}