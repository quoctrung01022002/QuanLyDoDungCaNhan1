using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface IDanhMucService
    {
        // Thêm danh mục sản phẩm
        Task Add(TDanhMucSPModel danhMucSP);

        // Lấy tất cả danh mục sản phẩm
        Task<IEnumerable<TDanhMucSPModel>> GetAll();

        // Lấy danh mục sản phẩm theo ID
        Task<TDanhMucSPModel> GetById(string id);

        // Cập nhật thông tin danh mục sản phẩm
        Task Update(string id, TDanhMucSPModel danhMucSP);

        // Xóa danh mục sản phẩm
        Task Delete(string id);

        // Tìm kiếm danh mục sản phẩm theo từ khóa
        Task<IEnumerable<TDanhMucSPModel>> Search(string keyword);

        // Lấy danh sách danh mục sản phẩm theo trang và số lượng trang
        Task<IEnumerable<TDanhMucSPModel>> GetPaged(int page, int pageSize);
    }
}
