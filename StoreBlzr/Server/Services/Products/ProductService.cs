using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Server.Services;
using Shared;
using StoreBlzr.Server.Data;
using StoreBlzr.Shared;


namespace StoreBlzr.Server.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;

        public ProductService(StoreDbContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Product>> GetAll()
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
           


            var DeleteProduct = await _context.Products.FindAsync(Id);

            _context.Products.Remove(DeleteProduct);
            await _context.SaveChangesAsync(); 
        }

       

        public async Task Update(Product product)
        {

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}