using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface IChiTietHoaDonBanService
    {
        Task Add(TChiTietHdbModel chiTietHdb);
        Task<IEnumerable<TChiTietHdbModel>> GetAll();
        Task<TChiTietHdbModel> GetById(string id);
        Task Update(string id, TChiTietHdbModel chiTietHdb);
        Task Delete(string id);
    }
}
