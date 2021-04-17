using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(string categoryId);
        Task<Category> Post(Category category);
        Task Put(Category category);
        Task Delete(string id);

    }
}