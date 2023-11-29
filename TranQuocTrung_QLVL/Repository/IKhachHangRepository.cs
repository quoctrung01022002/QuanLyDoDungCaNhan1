// IKhachHangRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Repository
{
    public interface IKhachHangRepository
    {
        Task<List<TKhachHang>> GetAllKhachHangs();
        Task CreateKhachHang(TKhachHang khachHang);
        Task<TKhachHang> GetKhachHangById(string id);
        Task UpdateKhachHang(string id, TKhachHang khachHang);
        Task DeleteKhachHang(string id);
        Task<List<TKhachHang>> GetPagedKhachHangs(int page, int pageSize);
        Task<List<TKhachHang>> SearchKhachHangs(string keyword);
        Task<List<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending);
        Task<bool> KhachHangExists(string id);
        Task Save();
    }
}
