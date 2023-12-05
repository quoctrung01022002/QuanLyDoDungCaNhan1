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
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        [HttpPost]
        public async Task<IActionResult> AddKhachHang([FromBody] TKhachHangModel khachHang)
        {
            try
            {
                await _khachHangService.Add(khachHang);
                return Ok("KhachHang added successfully");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in AddKhachHang: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding KhachHang");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKhachHangs()
        {
            try
            {
                var khachHangs = await _khachHangService.GetAll();
                return Ok(khachHangs);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAllKhachHangs: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting KhachHangs");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            try
            {
                var khachHang = await _khachHangService.GetById(id);
                if (khachHang != null)
                {
                    return Ok(khachHang);
                }
                return NotFound($"KhachHang with ID {id} not found");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetKhachHangById: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting KhachHang");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhachHang(string id, [FromBody] TKhachHangModel khachHang)
        {
            try
            {
                await _khachHangService.Update(id, khachHang);
                return Ok($"KhachHang with ID {id} updated successfully");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateKhachHang: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating KhachHang");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(string id)
        {
            try
            {
                await _khachHangService.Delete(id);
                return Ok($"KhachHang with ID {id} deleted successfully");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteKhachHang: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting KhachHang");
            }
        }
    }
}
