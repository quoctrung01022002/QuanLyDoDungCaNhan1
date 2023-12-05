using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface INhanVienService
    {
        Task Add(TNhanVienModel nhanVien);
        Task<IEnumerable<TNhanVienModel>> GetAll();
        Task<TNhanVienModel> GetById(string id);
        Task Update(string id, TNhanVienModel nhanVien);
        Task Delete(string id);
    }
}
