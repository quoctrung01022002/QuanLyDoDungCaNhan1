using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Add this for Entity Framework Core
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly QLBanVaLiContext _dbContext;

        public AccountRepository(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TUser>> GetAllUsers()
        {
            return await _dbContext.TUsers.ToListAsync();
        }

        public async Task<TUser> GetUserByUsername(string username)
        {
            return await _dbContext.TUsers.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<TUser>> GetUsersByRole(string role)
        {
            return await _dbContext.TUsers.Where(u => u.Role == role).ToListAsync();
        }

        public async Task<IEnumerable<TUser>> SearchUsers(string searchTerm)
        {
            return await _dbContext.TUsers
                .Where(u => u.Username.Contains(searchTerm) || u.Role.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task CreateUser(TUser user)
        {
            _dbContext.TUsers.Add(user);
            await Save();
        }

        public async Task UpdateUser(string username, TUser user)
        {
            var existingUser = await _dbContext.TUsers.FirstOrDefaultAsync(u => u.Username == username);

            if (existingUser != null)
            {
                existingUser.Password = user.Password;
                existingUser.LoaiUser = user.LoaiUser;
                existingUser.Role = user.Role;

                await Save();
            }
        }

        public async Task DeleteUser(string username)
        {
            var userToDelete = await _dbContext.TUsers.FirstOrDefaultAsync(u => u.Username == username);

            if (userToDelete != null)
            {
                _dbContext.TUsers.Remove(userToDelete);
                await Save();
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return await _dbContext.TUsers.AnyAsync(u => u.Username == username);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
