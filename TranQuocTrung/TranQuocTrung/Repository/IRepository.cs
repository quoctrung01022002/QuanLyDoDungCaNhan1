using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranQuocTrung.Repository
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Update(string id, T entity);
        Task Delete(string id);
        Task<IEnumerable<T>> Search(string keyword);
        Task<IEnumerable<T>> GetPaged(int page, int pageSize);
    }
}
