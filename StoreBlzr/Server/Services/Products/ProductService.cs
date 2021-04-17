using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Shared;
using StoreBlzr.Server.Data;

namespace Server.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;

        public ProductService(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();


        }




        public async Task<Product> Product(string Id)
        {
            var getProduct = await _context.Products.FindAsync(Id);


            return getProduct;


        }

        public async Task<Product> CreateProduct(Product model)
        {
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;


        }

        public async Task<string> DeleteProduct(string Id)
        {
            var DeleteProdcut = await _context.Products.FindAsync(Id);

            _context.Products.Remove(DeleteProdcut);
            await _context.SaveChangesAsync();

            return ("Product has been Deleted");
        }

        public async Task<string> UpdateProduct(string Id, Product model)
        {
            var GetProduct = await _context.Products.FindAsync(Id);

            _context.Products.Update(GetProduct);
           await _context.SaveChangesAsync();

            return ("Product has been updated");

        }

    }
}