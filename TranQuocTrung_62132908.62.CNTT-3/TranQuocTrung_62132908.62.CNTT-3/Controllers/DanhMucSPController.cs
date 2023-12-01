using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Services;

namespace TranQuocTrung_62132908._62.CNTT_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly DanhMucService _danhMucService;

        public DanhMucController(DanhMucService danhMucService)
        {
            _danhMucService = danhMucService;
        }

        // Lấy danh sách tất cả danh mục sản phẩm
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var danhMucList = await _danhMucService.GetAllAsync();
            return Ok(danhMucList);
        }

        // Lấy thông tin danh mục sản phẩm theo mã sản phẩm
        [HttpGet("{maSp}")]
        public async Task<IActionResult> GetByIdAsync(string maSp)
        {
            var danhMuc = await _danhMucService.GetByIdAsync(maSp);

            if (danhMuc == null)
            {
                // Trả về NotFound nếu không tìm thấy danh mục sản phẩm
                return NotFound();
            }

            return Ok(danhMuc);
        }

        // Thêm mới một danh mục sản phẩm
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TDanhMucSp danhMucSp)
        {
            await _danhMucService.AddAsync(danhMucSp);
            return Ok();
        }

        // Cập nhật thông tin danh mục sản phẩm theo mã sản phẩm
        [HttpPut("{maSp}")]
        public async Task<IActionResult> UpdateAsync(string maSp, [FromBody] TDanhMucSp danhMucSp)
        {
            var existingDanhMuc = await _danhMucService.GetByIdAsync(maSp);

            if (existingDanhMuc == null)
            {
                // Trả về NotFound nếu không tìm thấy danh mục sản phẩm để cập nhật
                return NotFound();
            }

            danhMucSp.MaSp = maSp;
            await _danhMucService.UpdateAsync(danhMucSp);

            return Ok();
        }

        // Xóa danh mục sản phẩm theo mã sản phẩm
        [HttpDelete("{maSp}")]
        public async Task<IActionResult> DeleteAsync(string maSp)
        {
            var existingDanhMuc = await _danhMucService.GetByIdAsync(maSp);

            if (existingDanhMuc == null)
            {
                // Trả về NotFound nếu không tìm thấy danh mục sản phẩm để xóa
                return NotFound();
            }

            await _danhMucService.DeleteAsync(maSp);
            return Ok();
        }

        // Tìm kiếm danh mục sản phẩm theo từ khóa
        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string keyword)
        {
            var danhMucList = await _danhMucService.SearchAsync(keyword);
            return Ok(danhMucList);
        }

        // Lấy danh sách danh mục sản phẩm phân trang
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page, [FromQuery] int pageSize)
        {
            var danhMucList = await _danhMucService.GetPagedAsync(page, pageSize);
            return Ok(danhMucList);
        }

        // Lấy danh sách danh mục sản phẩm theo mã nhà sản xuất
        [HttpGet("manufacturer/{manufacturerCode}")]
        public async Task<IActionResult> GetByManufacturerAsync(string manufacturerCode)
        {
            var danhMucList = await _danhMucService.GetByManufacturerAsync(manufacturerCode);
            return Ok(danhMucList);
        }

        // Lấy danh sách danh mục sản phẩm theo mã loại sản phẩm
        [HttpGet("category/{categoryCode}")]
        public async Task<IActionResult> GetByCategoryAsync(string categoryCode)
        {
            var danhMucList = await _danhMucService.GetByCategoryAsync(categoryCode);
            return Ok(danhMucList);
        }

        // Lấy danh sách danh mục sản phẩm bán chạy nhất theo số lượng
        [HttpGet("topselling/{count}")]
        public async Task<IActionResult> GetTopSellingAsync(int count)
        {
            var danhMucList = await _danhMucService.GetTopSellingAsync(count);
            return Ok(danhMucList);
        }
    }
}
