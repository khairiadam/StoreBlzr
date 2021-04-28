using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(string categoryId);
        Task<Category> Post(Category category, List<IFormFile> image);
        Task Put(Category category, List<IFormFile> image);
        Task Delete(string id);
    }
}