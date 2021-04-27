using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(string Id);
        Task<Product> Post(Product model);
        Task Delete(string Id);
        Task Update(Product model);
    }
}