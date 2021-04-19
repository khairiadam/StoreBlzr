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

        private readonly StoreDbContext _db;
        public OrderService(StoreDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            var supOrder = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(supOrder);
            await _db.SaveChangesAsync();
        }
    }
}