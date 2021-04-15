using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;

namespace Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        //TODO Each one of the group should implement one Methode
        public Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> Get(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> Post(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Put(string categoryId, Category category)
        {
            throw new System.NotImplementedException();
        }

    }
}