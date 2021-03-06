using System.Collections.Generic;
using System.Threading.Tasks;

using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Products
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