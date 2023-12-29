using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung1.Models;
using TranQuocTrung1.Services;

namespace TranQuocTrung1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipService _shipService;

        public ShipController(IShipService shipService)
        {
            _shipService = shipService;
        }

        [HttpPost]
        public async Task<IActionResult> AddShip([FromBody] ShipModel ship)
        {
            try
            {
                await _shipService.Add(ship);
                return Ok(new { Message = "Ship added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error adding ship: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShip(int id)
        {
            try
            {
                await _shipService.Delete(id);
                return Ok(new { Message = "Ship deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error deleting ship: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShips()
        {
            try
            {
                var ships = await _shipService.GetAll();
                return Ok(ships);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error retrieving ships: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipById(int id)
        {
            try
            {
                var ship = await _shipService.GetById(id);
                if (ship == null)
                {
                    return NotFound(new { ErrorMessage = "Ship not found." });
                }
                return Ok(ship);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error retrieving ship: {ex.Message}" });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchShips([FromQuery] string keyword)
        {
            try
            {
                var ships = await _shipService.SearchShips(keyword);
                return Ok(ships);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error searching ships: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShip(int id, [FromBody] ShipModel ship)
        {
            try
            {
                await _shipService.Update(id, ship);
                return Ok(new { Message = "Ship updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = $"Error updating ship: {ex.Message}" });
            }
        }
    }
}
