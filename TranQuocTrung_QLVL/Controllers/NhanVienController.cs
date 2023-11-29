using Microsoft.AspNetCore.Mvc;
using TranQuocTrung_QLVL.Models;
using TranQuocTrung_QLVL.Service;

[Route("api/[controller]")]
[ApiController]
public class NhanVienController : ControllerBase
{
    private readonly INhanVienService _nhanVienService;

    public NhanVienController(INhanVienService nhanVienService)
    {
        _nhanVienService = nhanVienService;
    }

    [HttpGet("nhan-viens")]
    public async Task<IActionResult> GetAllNhanViens()
    {
        var nhanViens = await _nhanVienService.GetAllNhanViens();
        return Ok(nhanViens);
    }

    [HttpGet("nhan-vien/{id}")]
    public async Task<IActionResult> GetNhanVienById(string id)
    {
        var nhanVien = await _nhanVienService.GetNhanVienById(id);

        if (nhanVien == null)
        {
            return NotFound("Không tìm thấy nhân viên.");
        }

        return Ok(nhanVien);
    }

    [HttpPost("nhan-vien")]
    public async Task<IActionResult> CreateNhanVien([FromBody] TNhanVien nhanVien)
    {
        if (nhanVien == null)
        {
            return BadRequest("Dữ liệu nhân viên không hợp lệ.");
        }

        await _nhanVienService.CreateNhanVien(nhanVien);

        return CreatedAtAction(nameof(GetNhanVienById), new { id = nhanVien.MaNhanVien }, nhanVien);
    }

    [HttpPut("nhan-vien/{id}")]
    public async Task<IActionResult> UpdateNhanVien(string id, [FromBody] TNhanVien nhanVien)
    {
        if (nhanVien == null || id != nhanVien.MaNhanVien)
        {
            return BadRequest("Dữ liệu nhân viên không hợp lệ.");
        }

        await _nhanVienService.UpdateNhanVien(id, nhanVien);

        return NoContent();
    }

    [HttpDelete("nhan-vien/{id}")]
    public async Task<IActionResult> DeleteNhanVien(string id)
    {
        var nhanVien = await _nhanVienService.GetNhanVienById(id);

        if (nhanVien == null)
        {
            return NotFound("Không tìm thấy nhân viên.");
        }

        await _nhanVienService.DeleteNhanVien(id);

        return NoContent();
    }

    [HttpGet("nhan-viens/paged")]
    public async Task<IActionResult> GetPagedNhanViens(int page = 1, int pageSize = 10)
    {
        var nhanViens = await _nhanVienService.GetPagedNhanViens(page, pageSize);
        return Ok(nhanViens);
    }

    [HttpGet("nhan-viens/search")]
    public async Task<IActionResult> SearchNhanViens(string keyword)
    {
        var nhanViens = await _nhanVienService.SearchNhanViens(keyword);
        return Ok(nhanViens);
    }

    [HttpGet("nhan-viens/sorted")]
    public async Task<IActionResult> GetSortedNhanViens(string sortBy = "TenNhanVien", bool ascending = true)
    {
        var nhanViens = await _nhanVienService.GetSortedNhanViens(sortBy, ascending);
        return Ok(nhanViens);
    }
}
