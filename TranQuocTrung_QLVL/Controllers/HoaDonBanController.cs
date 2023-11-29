using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonBanController : ControllerBase
    {
        private readonly QLBanVaLiContext _dbContext;

        public HoaDonBanController(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/hoa-don-bans
        [HttpGet("hoa-don-bans")]
        public IActionResult GetAllHoaDonBans()
        {
            List<THoaDonBan> hoaDonBans = _dbContext.THoaDonBans.ToList();
            return Ok(hoaDonBans);
        }

        // GET: api/hoa-don-ban/{id}
        [HttpGet("hoa-don-ban/{id}")]
        public IActionResult GetHoaDonBanById(string id)
        {
            THoaDonBan hoaDonBan = _dbContext.THoaDonBans.Find(id);

            if (hoaDonBan == null)
            {
                return NotFound("Không tìm thấy hóa đơn bán.");
            }

            return Ok(hoaDonBan);
        }

        // POST: api/hoa-don-ban
        [HttpPost("hoa-don-ban")]
        public IActionResult CreateHoaDonBan([FromBody] THoaDonBan hoaDonBan)
        {
            if (hoaDonBan == null)
            {
                return BadRequest("Dữ liệu hóa đơn bán không hợp lệ.");
            }

            _dbContext.THoaDonBans.Add(hoaDonBan);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetHoaDonBanById), new { id = hoaDonBan.MaHoaDon }, hoaDonBan);
        }

        // PUT: api/hoa-don-ban/{id}
        [HttpPut("hoa-don-ban/{id}")]
        public IActionResult UpdateHoaDonBan(string id, [FromBody] THoaDonBan hoaDonBan)
        {
            if (hoaDonBan == null || id != hoaDonBan.MaHoaDon)
            {
                return BadRequest("Dữ liệu hóa đơn bán không hợp lệ.");
            }

            _dbContext.Entry(hoaDonBan).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonBanExists(id))
                {
                    return NotFound("Không tìm thấy hóa đơn bán.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/hoa-don-ban/{id}
        [HttpDelete("hoa-don-ban/{id}")]
        public IActionResult DeleteHoaDonBan(string id)
        {
            THoaDonBan hoaDonBan = _dbContext.THoaDonBans.Find(id);

            if (hoaDonBan == null)
            {
                return NotFound("Không tìm thấy hóa đơn bán.");
            }

            _dbContext.THoaDonBans.Remove(hoaDonBan);
            _dbContext.SaveChanges();

            return NoContent();
        }

        private bool HoaDonBanExists(string id)
        {
            return _dbContext.THoaDonBans.Any(e => e.MaHoaDon == id);
        }
    }
}
