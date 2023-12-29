using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;

namespace TranQuocTrung1.Services
{
    public interface IBerthService
    {
        Task Add(BerthModel berth);
        Task<IEnumerable<BerthModel>> GetAll();
        Task<BerthModel> GetById(int id);
        Task Update(int id, BerthModel berth);
        Task Delete(int id);
        Task<IEnumerable<BerthModel>> SearchBerths(string keyword);
    }
}
