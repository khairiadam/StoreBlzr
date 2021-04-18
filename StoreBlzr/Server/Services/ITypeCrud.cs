using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ITypeCrud<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(string categoryId);
        Task<T> Post(T category);
        Task Put(T category);
        Task Delete(string id);

    }
}