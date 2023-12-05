using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface IHoaDonBanService
    {
        Task Add(THoaDonBanModel hoaDonBan);
        Task<IEnumerable<THoaDonBanModel>> GetAll();
        Task<THoaDonBanModel> GetById(string id);
        Task Update(string id, THoaDonBanModel nhanVien);
        Task Delete(string id);
    }
}
