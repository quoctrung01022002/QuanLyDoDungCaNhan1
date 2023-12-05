using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface IUserService
    {
        Task Add(TUserModel user);
        Task<IEnumerable<TUserModel>> GetAll();
        Task<TUserModel> GetById(string id);
        Task Update(string id, TUserModel user);
        Task Delete(string id);
    }
}
