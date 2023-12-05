using Microsoft.AspNetCore.Mvc;
using TranQuocTrung.Models;
using TranQuocTrung.Service;

namespace TranQuocTrung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucService _danhMucService;

        public DanhMucController(IDanhMucService danhMucService)
        {
            _danhMucService = danhMucService ?? throw new ArgumentNullException(nameof(danhMucService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDanhMuc(TDanhMucSPModel danhMuc)
        {
            try
            {
                await _danhMucService.Add(danhMuc);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in CreateDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDanhMucSPModel>>> GetAllDanhMuc()
        {
            try
            {
                var danhMucs = await _danhMucService.GetAll();
                return Ok(danhMucs);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAllDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDanhMucSPModel>> GetDanhMucById(string id)
        {
            try
            {
                var danhMuc = await _danhMucService.GetById(id);
                if (danhMuc == null)
                {
                    return NotFound();
                }
                return Ok(danhMuc);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetDanhMucById: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDanhMuc(string id, TDanhMucSPModel danhMuc)
        {
            try
            {
                await _danhMucService.Update(id, danhMuc);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMuc(string id)
        {
            try
            {
                await _danhMucService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TDanhMucSPModel>>> SearchDanhMuc([FromQuery] string keyword)
        {
            try
            {
                var danhMucs = await _danhMucService.Search(keyword);
                return Ok(danhMucs);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<TDanhMucSPModel>>> GetPagedDanhMuc([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var danhMucs = await _danhMucService.GetPaged(page, pageSize);
                return Ok(danhMucs);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetPagedDanhMuc: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
