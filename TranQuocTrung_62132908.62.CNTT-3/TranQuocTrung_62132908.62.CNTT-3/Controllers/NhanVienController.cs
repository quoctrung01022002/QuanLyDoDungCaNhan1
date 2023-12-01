using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _nhanVienService;

        public NhanVienController(INhanVienRepository nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        // Lấy danh sách tất cả nhân viên
        [HttpGet("nhan-viens")]
        public async Task<IActionResult> GetAllNhanViens()
        {
            var nhanViens = await _nhanVienService.GetAllNhanViens();
            return Ok(nhanViens);
        }

        // Lấy thông tin nhân viên theo ID
        [HttpGet("nhan-vien/{id}")]
        public async Task<IActionResult> GetNhanVienById(string id)
        {
            var nhanVien = await _nhanVienService.GetNhanVienById(id);

            if (nhanVien == null)
            {
                // Trả về NotFound nếu không tìm thấy nhân viên
                return NotFound("Không tìm thấy nhân viên.");
            }

            return Ok(nhanVien);
        }

        // Tạo mới một nhân viên
        [HttpPost("nhan-vien")]
        public async Task<IActionResult> CreateNhanVien([FromBody] TNhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                // Trả về BadRequest nếu dữ liệu nhân viên không hợp lệ
                return BadRequest("Dữ liệu nhân viên không hợp lệ.");
            }

            await _nhanVienService.CreateNhanVien(nhanVien);

            return CreatedAtAction(nameof(GetNhanVienById), new { id = nhanVien.MaNhanVien }, nhanVien);
        }

        // Cập nhật thông tin nhân viên theo ID
        [HttpPut("nhan-vien/{id}")]
        public async Task<IActionResult> UpdateNhanVien(string id, [FromBody] TNhanVien nhanVien)
        {
            if (nhanVien == null || id != nhanVien.MaNhanVien)
            {
                // Trả về BadRequest nếu dữ liệu nhân viên không hợp lệ
                return BadRequest("Dữ liệu nhân viên không hợp lệ.");
            }

            await _nhanVienService.UpdateNhanVien(id, nhanVien);

            return NoContent();
        }

        // Xóa nhân viên theo ID
        [HttpDelete("nhan-vien/{id}")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            var nhanVien = await _nhanVienService.GetNhanVienById(id);

            if (nhanVien == null)
            {
                // Trả về NotFound nếu không tìm thấy nhân viên để xóa
                return NotFound("Không tìm thấy nhân viên.");
            }

            await _nhanVienService.DeleteNhanVien(id);

            return NoContent();
        }

        // Lấy danh sách nhân viên phân trang
        [HttpGet("nhan-viens/paged")]
        public async Task<IActionResult> GetPagedNhanViens(int page = 1, int pageSize = 10)
        {
            var nhanViens = await _nhanVienService.GetPagedNhanViens(page, pageSize);
            return Ok(nhanViens);
        }

        // Tìm kiếm nhân viên theo từ khóa
        [HttpGet("nhan-viens/search")]
        public async Task<IActionResult> SearchNhanViens(string keyword)
        {
            var nhanViens = await _nhanVienService.SearchNhanViens(keyword);
            return Ok(nhanViens);
        }

        // Lấy danh sách nhân viên được sắp xếp
        [HttpGet("nhan-viens/sorted")]
        public async Task<IActionResult> GetSortedNhanViens(string sortBy = "TenNhanVien", bool ascending = true)
        {
            var nhanViens = await _nhanVienService.GetSortedNhanViens(sortBy, ascending);
            return Ok(nhanViens);
        }
    }
}
