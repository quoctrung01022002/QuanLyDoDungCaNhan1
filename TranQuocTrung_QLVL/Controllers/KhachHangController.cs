// KhachHangController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;
using TranQuocTrung_QLVL.Service;

namespace TranQuocTrung123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        [HttpGet("khach-hangs")]
        public async Task<IActionResult> GetAllKhachHangs()
        {
            List<TKhachHang> khachHangs = await _khachHangService.GetAllKhachHangs();
            return Ok(khachHangs);
        }

        [HttpGet("khach-hang/{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            var khachHang = await _khachHangService.GetKhachHangById(id);

            if (khachHang == null)
            {
                return NotFound("Không tìm thấy khách hàng.");
            }

            return Ok(khachHang);
        }

        [HttpPost("khach-hang")]
        public async Task<IActionResult> CreateKhachHang([FromBody] TKhachHang khachHang)
        {
            if (khachHang == null)
            {
                return BadRequest("Dữ liệu khách hàng không hợp lệ.");
            }

            await _khachHangService.CreateKhachHang(khachHang);
            return CreatedAtAction(nameof(GetKhachHangById), new { id = khachHang.MaKhanhHang }, khachHang);
        }

        [HttpPut("khach-hang/{id}")]
        public async Task<IActionResult> UpdateKhachHang(string id, [FromBody] TKhachHang khachHang)
        {
            if (khachHang == null || id != khachHang.MaKhanhHang)
            {
                return BadRequest("Dữ liệu khách hàng không hợp lệ.");
            }

            await _khachHangService.UpdateKhachHang(id, khachHang);
            return NoContent();
        }

        [HttpDelete("khach-hang/{id}")]
        public async Task<IActionResult> DeleteKhachHang(string id)
        {
            await _khachHangService.DeleteKhachHang(id);
            return NoContent();
        }

        [HttpGet("khach-hangs/paged")]
        public async Task<IActionResult> GetPagedKhachHangs(int page = 1, int pageSize = 10)
        {
            var khachHangs = await _khachHangService.GetPagedKhachHangs(page, pageSize);
            return Ok(khachHangs);
        }

        [HttpGet("khach-hangs/search")]
        public async Task<IActionResult> SearchKhachHangs(string keyword)
        {
            var khachHangs = await _khachHangService.SearchKhachHangs(keyword);
            return Ok(khachHangs);
        }

        [HttpGet("khach-hangs/sorted")]
        public async Task<IActionResult> GetSortedKhachHangs(string sortBy = "TenKhachHang", bool ascending = true)
        {
            var khachHangs = await _khachHangService.GetSortedKhachHangs(sortBy, ascending);
            return Ok(khachHangs);
        }
    }
}
