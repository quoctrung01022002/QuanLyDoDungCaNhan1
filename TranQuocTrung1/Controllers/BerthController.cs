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
    public class BerthController : ControllerBase
    {
        private readonly IBerthService _berthService;

        public BerthController(IBerthService berthService)
        {
            _berthService = berthService;
        }

        // GET: api/Berth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BerthModel>>> GetBerths()
        {
            try
            {
                var berths = await _berthService.GetAll();
                return Ok(berths);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Berth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BerthModel>> GetBerth(int id)
        {
            try
            {
                var berth = await _berthService.GetById(id);
                if (berth == null)
                {
                    return NotFound();
                }

                return Ok(berth);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // POST: api/Berth
        [HttpPost]
        public async Task<ActionResult> PostBerth(BerthModel berth)
        {
            try
            {
                await _berthService.Add(berth);
                return CreatedAtAction(nameof(GetBerth), new { id = berth.Id }, berth);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/Berth/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBerth(int id, BerthModel berth)
        {
            try
            {
                await _berthService.Update(id, berth);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/Berth/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBerth(int id)
        {
            try
            {
                await _berthService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<BerthModel>>> SearchBerths([FromQuery] string keyword)
        {
            try
            {
                var berths = await _berthService.SearchBerths(keyword);
                return Ok(berths);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
