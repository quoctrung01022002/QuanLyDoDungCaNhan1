using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranQuocTrung.Models;
using TranQuocTrung.Service;

namespace TranQuocTrung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNhanVien([FromBody] TNhanVienModel nhanVien)
        {
            try
            {
                await _nhanVienService.Add(nhanVien);
                return Ok("NhanVien added successfully.");
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhanVien()
        {
            try
            {
                var nhanViens = await _nhanVienService.GetAll();
                return Ok(nhanViens);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanVienById(string id)
        {
            try
            {
                var nhanVien = await _nhanVienService.GetById(id);
                if (nhanVien == null)
                {
                    return NotFound("NhanVien not found.");
                }

                return Ok(nhanVien);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhanVien(string id, [FromBody] TNhanVienModel nhanVien)
        {
            try
            {
                await _nhanVienService.Update(id, nhanVien);
                return Ok("NhanVien updated successfully.");
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            try
            {
                await _nhanVienService.Delete(id);
                return Ok("NhanVien deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
