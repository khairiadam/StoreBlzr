using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Services;
using StoreBlzr.Server.Data;
using StoreBlzr.Shared;


namespace StoreBlzr.Server.Services.Products
{
    public class ProductService : ITypeCrud<Product>
    {
        private readonly StoreDbContext _context;

        public ProductService(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task<Product> Get(string Id)
        {
            var getProduct = await _context.Products.FindAsync(Id);


            return getProduct;
        }

        public async Task<Product> Post(Product model)
        {
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(string Id)
        {
            var DeleteProdcut = await _context.Products.FindAsync(Id);

            _context.Products.Remove(DeleteProdcut);
            await _context.SaveChangesAsync();

          
        }

        public async Task Put(Product model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            
        }

        
    }
}