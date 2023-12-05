using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Models;
using TranQuocTrung.Service;

namespace TranQuocTrung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonBanController : ControllerBase
    {
        private readonly IHoaDonBanService _hoaDonBanService;

        public HoaDonBanController(IHoaDonBanService hoaDonBanService)
        {
            _hoaDonBanService = hoaDonBanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<THoaDonBanModel>>> GetAll()
        {
            try
            {
                var hoaDonBans = await _hoaDonBanService.GetAll();
                return Ok(hoaDonBans);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<THoaDonBanModel>> GetById(string id)
        {
            try
            {
                var hoaDonBan = await _hoaDonBanService.GetById(id);

                if (hoaDonBan == null)
                    return NotFound();

                return Ok(hoaDonBan);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetById: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] THoaDonBanModel hoaDonBan)
        {
            try
            {
                await _hoaDonBanService.Add(hoaDonBan);
                return CreatedAtAction(nameof(GetById), new { id = hoaDonBan.MaHoaDon }, hoaDonBan);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Add: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] THoaDonBanModel hoaDonBan)
        {
            try
            {
                await _hoaDonBanService.Update(id, hoaDonBan);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Update: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _hoaDonBanService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
