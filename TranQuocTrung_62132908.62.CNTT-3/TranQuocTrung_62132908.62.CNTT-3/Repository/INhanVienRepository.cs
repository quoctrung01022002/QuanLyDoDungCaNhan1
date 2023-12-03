using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;

namespace TranQuocTrung_62132908._62.CNTT_3.Repository
{
    public interface INhanVienRepository : BaseRepository<TKhachHang>
    {
        Task<IEnumerable<TNhanVien>> GetAllNhanViens();
        Task<TNhanVien> GetNhanVienById(string id);
        Task CreateNhanVien(TNhanVien nhanVien);
        Task UpdateNhanVien(string id, TNhanVien nhanVien);
        Task DeleteNhanVien(string id);
        Task<IEnumerable<TNhanVien>> GetPagedNhanViens(int page, int pageSize);
        Task<IEnumerable<TNhanVien>> SearchNhanViens(string keyword);
        Task<IEnumerable<TNhanVien>> GetSortedNhanViens(string sortBy, bool ascending);
        Task<bool> NhanVienExists(string id);
        Task Save();
    }
}
