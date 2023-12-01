using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Services;

namespace TranQuocTrung_62132908._62.CNTT_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IEnumerable<TUser>> GetAllUsers()
        {
            return await _accountService.GetAllUsers();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<TUser>> GetUserByUsername(string username)
        {
            var user = await _accountService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("role/{role}")]
        public async Task<IEnumerable<TUser>> GetUsersByRole(string role)
        {
            return await _accountService.GetUsersByRole(role);
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IEnumerable<TUser>> SearchUsers(string searchTerm)
        {
            return await _accountService.SearchUsers(searchTerm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(TUser user)
        {
            try
            {
                await _accountService.CreateUser(user);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser(string username, TUser user)
        {
            await _accountService.UpdateUser(username, user);
            return Ok();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            await _accountService.DeleteUser(username);
            return Ok();
        }

        [HttpGet("exists/{username}")]
        public async Task<bool> UserExists(string username)
        {
            return await _accountService.UserExists(username);
        }
    }
}
