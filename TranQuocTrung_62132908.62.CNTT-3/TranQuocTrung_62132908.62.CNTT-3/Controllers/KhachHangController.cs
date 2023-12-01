using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepository _khachHangService;

        public KhachHangController(IKhachHangRepository khachHangService)
        {
            _khachHangService = khachHangService;
        }

        // Lấy danh sách tất cả khách hàng
        [HttpGet("khach-hangs")]
        public async Task<IActionResult> GetAllKhachHangs()
        {
            IEnumerable<TKhachHang> khachHangs = await _khachHangService.GetAllKhachHangs();
            return Ok(khachHangs);
        }

        // Lấy thông tin khách hàng theo ID
        [HttpGet("khach-hang/{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            var khachHang = await _khachHangService.GetKhachHangById(id);

            if (khachHang == null)
            {
                // Trả về NotFound nếu không tìm thấy khách hàng
                return NotFound("Không tìm thấy khách hàng.");
            }

            return Ok(khachHang);
        }

        // Tạo mới một khách hàng
        [HttpPost("khach-hang")]
        public async Task<IActionResult> CreateKhachHang([FromBody] TKhachHang khachHang)
        {
            if (khachHang == null)
            {
                // Trả về BadRequest nếu dữ liệu khách hàng không hợp lệ
                return BadRequest("Dữ liệu khách hàng không hợp lệ.");
            }

            await _khachHangService.CreateKhachHang(khachHang);
            return CreatedAtAction(nameof(GetKhachHangById), new { id = khachHang.MaKhanhHang }, khachHang);
        }

        // Cập nhật thông tin khách hàng theo ID
        [HttpPut("khach-hang/{id}")]
        public async Task<IActionResult> UpdateKhachHang(string id, [FromBody] TKhachHang khachHang)
        {
            if (khachHang == null || id != khachHang.MaKhanhHang)
            {
                // Trả về BadRequest nếu dữ liệu khách hàng không hợp lệ
                return BadRequest("Dữ liệu khách hàng không hợp lệ.");
            }

            try
            {
                await _khachHangService.UpdateKhachHang(id, khachHang);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                // Trả về NotFound nếu không tìm thấy khách hàng để cập nhật
                return NotFound(ex.Message);
            }
        }

        // Xóa khách hàng theo ID
        [HttpDelete("khach-hang/{id}")]
        public async Task<IActionResult> DeleteKhachHang(string id)
        {
            try
            {
                await _khachHangService.DeleteKhachHang(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                // Trả về NotFound nếu không tìm thấy khách hàng để xóa
                return NotFound(ex.Message);
            }
        }

        // Lấy danh sách khách hàng phân trang
        [HttpGet("khach-hangs/paged")]
        public async Task<IActionResult> GetPagedKhachHangs(int page = 1, int pageSize = 10)
        {
            var khachHangs = await _khachHangService.GetPagedKhachHangs(page, pageSize);
            return Ok(khachHangs);
        }

        // Tìm kiếm khách hàng theo từ khóa
        [HttpGet("khach-hangs/search")]
        public async Task<IActionResult> SearchKhachHangs(string keyword)
        {
            var khachHangs = await _khachHangService.SearchKhachHangs(keyword);
            return Ok(khachHangs);
        }

        // Lấy danh sách khách hàng được sắp xếp
        [HttpGet("khach-hangs/sorted")]
        public async Task<IActionResult> GetSortedKhachHangs(string sortBy = "TenKhachHang", bool ascending = true)
        {
            var khachHangs = await _khachHangService.GetSortedKhachHangs(sortBy, ascending);
            return Ok(khachHangs);
        }
    }
}
