using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;

namespace Server.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> Product(string Id);
        Task<Product> CreateProduct(Product model);
        Task<string> DeleteProduct(string Id);
        Task<string> UpdateProduct(string Id, Product model);
    }
}