using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketerApi.Services
{
    public interface IGenericDataService<T> : IDataService
        where T : class
    {
        Task<T> AddAsync(T item);

        Task DeleteAsync(T item);

        Task EditAsync(T item);

        Task<List<T>> GetAsync();

        Task<T> GetAsync(int id);
    }
}
