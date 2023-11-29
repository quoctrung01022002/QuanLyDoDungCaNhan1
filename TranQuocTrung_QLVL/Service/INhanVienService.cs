using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Service
{
    public interface INhanVienService
    {
        Task<List<TNhanVien>> GetAllNhanViens();
        Task<TNhanVien> GetNhanVienById(string id);
        Task CreateNhanVien(TNhanVien nhanVien);
        Task UpdateNhanVien(string id, TNhanVien nhanVien);
        Task DeleteNhanVien(string id);
        Task<List<TNhanVien>> GetPagedNhanViens(int page, int pageSize);
        Task<List<TNhanVien>> SearchNhanViens(string keyword);
        Task<List<TNhanVien>> GetSortedNhanViens(string sortBy, bool ascending);
        Task<bool> NhanVienExists(string id);
    }
}