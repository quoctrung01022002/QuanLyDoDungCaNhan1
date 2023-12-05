using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranQuocTrung.Models;
using TranQuocTrung.Service;

namespace TranQuocTrung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonBanController : ControllerBase
    {
        private readonly IChiTietHoaDonBanService _chiTietHoaDonBanService;

        public ChiTietHoaDonBanController(IChiTietHoaDonBanService chiTietHoaDonBanService)
        {
            _chiTietHoaDonBanService = chiTietHoaDonBanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TChiTietHdbModel>>> GetAll()
        {
            try
            {
                var chiTietHoaDonBanList = await _chiTietHoaDonBanService.GetAll();
                return Ok(chiTietHoaDonBanList);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TChiTietHdbModel>> GetById(string id)
        {
            try
            {
                var chiTietHoaDonBan = await _chiTietHoaDonBanService.GetById(id);
                if (chiTietHoaDonBan == null)
                {
                    return NotFound();
                }
                return Ok(chiTietHoaDonBan);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TChiTietHdbModel chiTietHoaDonBan)
        {
            try
            {
                await _chiTietHoaDonBanService.Add(chiTietHoaDonBan);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Add: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] TChiTietHdbModel chiTietHoaDonBan)
        {
            try
            {
                await _chiTietHoaDonBanService.Update(id, chiTietHoaDonBan);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Update: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _chiTietHoaDonBanService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
