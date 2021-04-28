using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StoreBlzr.Shared.Services.Category
{
    interface ICategoryDataService
    {
        Task<List<Shared.Category>> GetAll();
        Task<Shared.Category> Get(string categoryId);
        Task<Shared.Category> Post(Shared.Category category, IFormFile image);
        Task Put(Shared.Category category);
        Task Delete(string id);
    }
}
