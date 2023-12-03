using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;

namespace TranQuocTrung_62132908._62.CNTT_3.Repository
{
    public interface IKhachHangRepository : BaseRepository<TKhachHang>
    {
        // Lấy danh sách tất cả khách hàng
        Task<IEnumerable<TKhachHang>> GetAllKhachHangs();

        // Tạo mới một khách hàng
        Task CreateKhachHang(TKhachHang khachHang);

        // Lấy thông tin khách hàng theo ID
        Task<TKhachHang> GetKhachHangById(string id);

        // Cập nhật thông tin khách hàng theo ID
        Task UpdateKhachHang(string id, TKhachHang khachHang);

        // Xóa khách hàng theo ID
        Task DeleteKhachHang(string id);

        // Lấy danh sách khách hàng phân trang
        Task<IEnumerable<TKhachHang>> GetPagedKhachHangs(int page, int pageSize);

        // Tìm kiếm khách hàng theo từ khóa
        Task<IEnumerable<TKhachHang>> SearchKhachHangs(string keyword);

        // Lấy danh sách khách hàng được sắp xếp
        Task<IEnumerable<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending);

        // Kiểm tra sự tồn tại của khách hàng theo ID
        Task<bool> KhachHangExists(string id);

        // Lưu thay đổi vào cơ sở dữ liệu
        Task Save();
    }
}
