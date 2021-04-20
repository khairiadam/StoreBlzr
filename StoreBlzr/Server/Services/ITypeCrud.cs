using StoreBlzr.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ITypeCrud<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Post(T type);
        Task Put(T type);
        Task Delete(string id);
    }
}