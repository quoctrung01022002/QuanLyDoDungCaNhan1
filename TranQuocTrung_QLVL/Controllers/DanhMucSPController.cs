// DanhMucSPController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;
using TranQuocTrung_QLVL.Service;

namespace TranQuocTrung123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSPController : ControllerBase
    {
        private readonly IDanhMucService _danhMucService;

        public DanhMucSPController(IDanhMucService danhMucService)
        {
            _danhMucService = danhMucService;
        }

        // GET: api/danh-muc-sps
        [HttpGet("danh-muc-sps")]
        public async Task<IActionResult> GetAllDanhMucSPs()
        {
            var danhMucSPs = await _danhMucService.GetAllDanhMucSPs();
            return Ok(danhMucSPs);
        }

        // GET: api/danh-muc-sp/{id}
        [HttpGet("danh-muc-sp/{id}")]
        public async Task<IActionResult> GetDanhMucSPById(string id)
        {
            var danhMucSP = await _danhMucService.GetDanhMucSPById(id);

            if (danhMucSP == null)
            {
                return NotFound("Không tìm thấy danh mục sản phẩm.");
            }

            return Ok(danhMucSP);
        }

        // POST: api/danh-muc-sp
        [HttpPost("danh-muc-sp")]
        public async Task<IActionResult> CreateDanhMucSP([FromBody] TDanhMucSp danhMucSP)
        {
            if (danhMucSP == null)
            {
                return BadRequest("Dữ liệu danh mục sản phẩm không hợp lệ.");
            }

            await _danhMucService.CreateDanhMucSP(danhMucSP);

            return CreatedAtAction(nameof(GetDanhMucSPById), new { id = danhMucSP.MaSp }, danhMucSP);
        }

        // PUT: api/danh-muc-sp/{id}
        [HttpPut("danh-muc-sp/{id}")]
        public async Task<IActionResult> UpdateDanhMucSP(string id, [FromBody] TDanhMucSp danhMucSP)
        {
            if (danhMucSP == null || id != danhMucSP.MaSp)
            {
                return BadRequest("Dữ liệu danh mục sản phẩm không hợp lệ.");
            }

            await _danhMucService.UpdateDanhMucSP(id, danhMucSP);

            return NoContent();
        }

        // DELETE: api/danh-muc-sp/{id}
        [HttpDelete("danh-muc-sp/{id}")]
        public async Task<IActionResult> DeleteDanhMucSP(string id)
        {
            await _danhMucService.DeleteDanhMucSP(id);

            return NoContent();
        }

        // GET: api/danh-muc-sps/paged
        [HttpGet("danh-muc-sps/paged")]
        public async Task<IActionResult> GetPagedDanhMucSPs(int page = 1, int pageSize = 10)
        {
            var danhMucSPs = await _danhMucService.GetPagedDanhMucSPs(page, pageSize);
            return Ok(danhMucSPs);
        }

        // GET: api/danh-muc-sps/search
        [HttpGet("danh-muc-sps/search")]
        public async Task<IActionResult> SearchDanhMucSPs(string keyword)
        {
            var danhMucSPs = await _danhMucService.SearchDanhMucSPs(keyword);
            return Ok(danhMucSPs);
        }

        // GET: api/danh-muc-sps/sorted
        [HttpGet("danh-muc-sps/sorted")]
        public async Task<IActionResult> GetSortedDanhMucSPs(string sortBy = "TenSp", bool ascending = true)
        {
            var danhMucSPs = await _danhMucService.GetSortedDanhMucSPs(sortBy, ascending);
            return Ok(danhMucSPs);
        }

        // New functions
        [HttpGet("danh-muc-sps/category/{categoryId}")]
        public async Task<IActionResult> GetDanhMucSPsByCategory(string categoryId)
        {
            var danhMucSPs = await _danhMucService.GetDanhMucSPsByCategory(categoryId);
            return Ok(danhMucSPs);
        }

        [HttpGet("danh-muc-sps/brand/{brandId}")]
        public async Task<IActionResult> GetDanhMucSPsByBrand(string brandId)
        {
            var danhMucSPs = await _danhMucService.GetDanhMucSPsByBrand(brandId);
            return Ok(danhMucSPs);
        }

        [HttpGet("danh-muc-sps/brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _danhMucService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("danh-muc-sps/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _danhMucService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("danh-muc-sps/price-range")]
        public async Task<IActionResult> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var danhMucSPs = await _danhMucService.GetProductsByPriceRange(minPrice, maxPrice);
            return Ok(danhMucSPs);
        }

        [HttpGet("danh-muc-sps/country/{countryId}")]
        public async Task<IActionResult> GetDanhMucSPsByCountry(string countryId)
        {
            var danhMucSPs = await _danhMucService.GetDanhMucSPsByCountry(countryId);
            return Ok(danhMucSPs);
        }

        [HttpGet("danh-muc-sps/materials")]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _danhMucService.GetAllMaterials();
            return Ok(materials);
        }
    }
}
